import React from "react";
import { HotelCard } from "./HotelCard";
import styles from "./HotelCardList.module.css";

export const HotelCardList = ({
  hotels = [],
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
          image={hotel.rentObj?.images?.length > 0 ? hotel.rentObj.images[0] : 'default-image.jpg'}
          city={hotel.city}
          country={hotel.country}
          distance={hotel.distance}
          rating={hotel.rating}
          reviews={hotel.reviews}
          price={hotel.totalPrice}
          badges={hotel.badges || []}
          onClick={() => onCardClick && onCardClick(hotel.id)}
          onCheckAvailability={() =>
            onCheckAvailability && onCheckAvailability(hotel.id)
          }
        />
      ))}
    </div>
  );
};

