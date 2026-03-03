import React from "react";
import { useRef } from "react";
import { useContext } from "react";
import { useTranslation } from "react-i18next";
import { footerLinks } from '../../data/footerLinks.js';
import { ThemeContext } from "../../contexts/ThemeContext";
import { IconButtonArrow } from '../UI/Button/IconButton_arrow.jsx';
import { Logo_Oselya_128 } from "../Logo/Logo_Oselya_128.jsx";
import { Link } from "../UI/Text/Link.jsx"
import { Text } from "../UI/Text/Text.jsx"
import { ActionButton__Primary } from "../UI/Button/ActionButton_Primary.jsx";
import { MoreOffersSection_card } from "./MoreOffersSection_card.jsx"

import styles from './Info_components.module.css';



export const MoreOffersSection = () => {
  const { t } = useTranslation();
  const trackRef = useRef(null);
  const { darkMode } = useContext(ThemeContext);

  const CARD_WIDTH = 370;
  const GAP = 78;
  const SLIDE_WIDTH = CARD_WIDTH * 2 + GAP; // 818

  const classNameArrowLeft = darkMode
    ? "btn_arrow_left_dark"
    : "btn_arrow_left_light";

  const classNameArrowRight = darkMode
    ? "btn_arrow_right_dark"
    : "btn_arrow_right_light";

  const scrollLeft = () => {
    trackRef.current?.scrollBy({ left: -SLIDE_WIDTH, behavior: "smooth" });
  };

  const scrollRight = () => {
    trackRef.current?.scrollBy({ left: SLIDE_WIDTH, behavior: "smooth" });
  };

  return (
    <div className={styles.moreOffersSection}>
      <div className={styles.btn_container}>
        <IconButtonArrow
          onClick={() => scrollLeft()}
          className={classNameArrowLeft}
        />
        <div className="flex-center btn-w-full p-20 mb-30">
          <Text text={t("moreOffersSection.title")} type="title" />
        </div>

        <IconButtonArrow
          onClick={() => scrollRight()}
          className={classNameArrowRight}
        />
      </div>
      <div className={styles.moreOffersSection_content}>
        {/* viewport */}
        <div className={styles.sliderViewport}>
          {/* track */}
          <div className={styles.sliderTrack} ref={trackRef}>
            {/* slide */}
            <div className={styles.moreOffersSection__grid}>
              <MoreOffersSection_card showText={false}
                className={styles.moreOffersSection_card__container_left}
              />
              <MoreOffersSection_card
                title={t("moreOffersSection.right_column.title")}
                text={t("moreOffersSection.right_column.text")}
              />
              <MoreOffersSection_card
                title={t("moreOffersSection.left_column.title")}
                text={t("moreOffersSection.left_column.text")}
              />
              <MoreOffersSection_card showText={false}
                className={styles.moreOffersSection_card__container_right}
              />
            </div>
          </div>
        </div>

      </div>
    </div>
  );
};
