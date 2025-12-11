import React from "react";
import { HotelCard } from "./HotelCard";
import styles from "./HotelCardList.module.css";

export const HotelCardList = ({
  hotels = [],
  guests,
  startDate,
  endDate,
  onCardClick,
  onCheckAvailability,
}) => {
  return (
    <div className={styles.hotelCardList}>
      {hotels.map((hotel) => (
        <HotelCard
          key={hotel.id}
          id={hotel.id}
          title={hotel.title}
          image={hotel.rentObj?.[0]?.mainImageUrl || '-image.jpg'}
          city={hotel.city}
          country={hotel.country}
          distance={hotel.distanceToCenter}
          rating={hotel.rating}
          reviews={hotel.reviews}
          price={hotel.totalPrice}
          guests={guests}
          startDate={startDate}
          endDate={endDate}
          onClick={() => onCardClick && onCardClick(hotel.id)}
          onCheckAvailability={() =>
            onCheckAvailability && onCheckAvailability(hotel.id)
          }
        />
      ))}
    </div>
  );
};

