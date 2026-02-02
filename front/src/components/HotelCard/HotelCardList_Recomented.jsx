import React from "react";
import { useContext } from "react";
import { useTranslation } from "react-i18next";
import { ThemeContext } from "../../contexts/ThemeContext";

import { HotelCard_Recomented } from "./HotelCard_Recomented";
import { Text } from "../../components/UI/Text/Text.jsx";

import styles from "./HotelCardList_Recomented.module.css";


export const HotelCardList_Recomented = ({
  hotels = [],
  guests = "1",
  startDate = "2026-01-22",
  endDate = "2026-01-24",
  onCardClick,
  onCheckAvailability,
}) => {

  const { darkMode } = useContext(ThemeContext);
  const { t } = useTranslation();

  const imageSrc = darkMode
    ? "/img/main_page/hotel_recomented_dark.svg"
    : "/img/main_page/hotel_recomented_light.svg";

  return (
    <div className={styles.hotelCardList}>
       <div className="flex-center btn-w-full p-20 mb-30 ">
              <Text text={t("hotel-recomented.title")} type="title" />
            </div>
      <div className={styles.hotelCardList__container}>
        <div className={styles.hotelCardList__columns}>
          <div className={styles.hotelCardList__cardsColumn}>

            {hotels.slice(0, 4).map((hotel) => (
              <HotelCard_Recomented
                key={hotel.id}
                id={hotel.id}
                title={hotel.title}
                image={hotel.rentObj?.[0]?.mainImageUrl || '-image.jpg'}
                city={hotel.city}
                country={hotel.country}
                rating={hotel.rating}
                endDate={endDate}
                onClick={() => onCardClick && onCardClick(hotel.id)}
                onCheckAvailability={() =>
                  onCheckAvailability && onCheckAvailability(hotel.id)
                }
              />
            ))}
          </div>
          <div className={styles.hotelCardList__imgColumn}>
            <div className={styles.imageCard}>

              <img
                src={imageSrc}
                alt="Building"
                className={styles.image}
              />

              <div className={styles.badge}>
                <div className="flex-center-column  ">
                  <Text text="15 000+" type="m_500_s_36" />
                  <div className={styles.line}></div>
                  <Text text={t("hotel-recomented.badgeText")} type="m_500_s_24" />
                </div>

              </div>

            </div>


          </div>
        </div>
      </div>

    </div>
  );
};

