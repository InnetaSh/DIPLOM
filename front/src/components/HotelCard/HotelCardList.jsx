import React, { useEffect, useState, useRef } from "react";
import { HotelCard } from "./HotelCard";
import styles from "./HotelCardList.module.css";

export const HotelCardList = ({
  hotels = [],
  adults = "1",
  children="0",
  startDate = "2026-01-22",
  endDate = "2026-01-24",
  onCardClick,
  onCheckAvailability,
  myHistoryIdList,
  cardWidth = 424,
  gap = 20,
  openFilterMenu = false, 
  showHeart
}) => {
  const containerRef = useRef(null);
  const [columns, setColumns] = useState(1);

  const updateColumns = () => {
    if (!containerRef.current) return;

    const containerWidth = containerRef.current.offsetWidth;
    const cols = Math.floor((containerWidth + gap) / (cardWidth + gap));
    setColumns(Math.max(cols, 1));
  };

  useEffect(() => {
    updateColumns(); 

    window.addEventListener("resize", updateColumns);
    return () => window.removeEventListener("resize", updateColumns);
  }, [cardWidth, gap]);

useEffect(()=>{
  console.log({hotelList: hotels})
}, [hotels]);

  useEffect(() => {
    updateColumns();
  }, [openFilterMenu]);
console.log({ hotels });
  return (
    <div
      ref={containerRef}
      className={styles.hotelCardList}
      style={{
        display: "grid",
        gap: `${gap}px`,
        gridTemplateColumns: `repeat(${columns}, 1fr)`,
      }}
    >
      {hotels.map((hotel) => (
        <HotelCard
          key={hotel.id}
          id={hotel.id}
          title={hotel.title}
          image={hotel.rentObj?.[0]?.mainImageUrl || "-image.jpg"}
          city={hotel.rentObj[0].cityTitle}
          cityId={hotel.rentObj?.[0]?.cityId}
          country={hotel.country}
          distance={hotel.distanceToCenter}
          rating={
                      hotel.overallRating != null
                        ? hotel.overallRating.toFixed(2)
                        : "7.10"
                    }
          reviews={hotel.reviews}
          price={hotel.pricePerDay ?? hotel.totalPrice}
           adults ={adults}
              children={children}
          startDate={startDate}
          endDate={endDate}
          myHistoryIdList={myHistoryIdList}
          showHeart = {showHeart}
          onClick={() => {
            console.log ({id: hotel.id})
          }}
        />
      ))}
    </div>
  );
};
