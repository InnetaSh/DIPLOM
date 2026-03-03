
import { useContext } from "react";
import { useTranslation } from "react-i18next";
import { useRef } from 'react';
import { ThemeContext } from "../../contexts/ThemeContext";
import { IconButtonArrow } from '../UI/Button/IconButton_arrow.jsx';
import { HotelCard_Recomented } from "./HotelCard_Recomented";
import { Text } from "../../components/UI/Text/Text.jsx";

import styles from "./HotelCardList_Recomented.module.css";

const scrollAmount = 320;


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

  const classNameArrowLeft = darkMode
    ? "btn_arrow_left_dark"
    : "btn_arrow_left_light";

  const classNameArrowRight = darkMode
    ? "btn_arrow_right_dark"
    : "btn_arrow_right_light";

  const trackRef = useRef(null);
  const CARD_WIDTH = 370;
  const GAP = 30;
  const SLIDE_WIDTH = CARD_WIDTH * 2 + GAP;

  const scrollLeft = () => {
    trackRef.current?.scrollBy({
      left: -SLIDE_WIDTH,
      behavior: 'smooth',
    });
  };

  const scrollRight = () => {
    trackRef.current?.scrollBy({
      left: SLIDE_WIDTH,
      behavior: 'smooth',
    });
  };


  const imageSrc = darkMode
    ? "/img/main_page/hotel_recomented_dark.svg"
    : "/img/main_page/hotel_recomented_light.svg";

  return (
    <div className={styles.hotelCardList}>

      <div className={styles.btn_container}>
        <IconButtonArrow
          onClick={() => scrollLeft()}
          className={classNameArrowLeft}
        />
        <div className="flex-center btn-w-full  mb-30 ">
          <Text text={t("hotel-recomented.title")} type="title" />
        </div>
        <IconButtonArrow
          onClick={() => scrollRight()}
          className={classNameArrowRight}
        />
      </div>
      <div className={styles.hotelCardList__container}>
        <div className={styles.hotelCardList__columns}>

          <div className={styles.sliderViewport}>
            <div className={styles.sliderTrack} ref={trackRef}>
              <div
                className={
                  hotels.length < 3
                    ? styles.hotelCardList__cardsColumn
                    : styles.hotelCardList__cardGrid
                }
              >

                {hotels.slice(0, 4).map((hotel) => (
                  <HotelCard_Recomented
                    key={hotel.id}
                    id={hotel.id}
                    title={hotel.title}
                    image={hotel.rentObj?.[0]?.mainImageUrl || '-image.jpg'}
                    city={hotel.rentObj?.[0]?.cityTitle}
                    country={hotel.country}
                    rating={
                      hotel.overallRating != null
                        ? hotel.overallRating.toFixed(2)
                        : "7.10"
                    }
                    endDate={endDate}
                    onClick={() => onCardClick && onCardClick(hotel.id)}
                    onCheckAvailability={() =>
                      onCheckAvailability && onCheckAvailability(hotel.id)
                    }
                  />
                ))}


              </div>
            </div>
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

