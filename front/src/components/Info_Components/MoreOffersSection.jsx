import React from "react";
import { useRef } from "react";
import { useContext } from "react";
import { useTranslation } from "react-i18next";
import { useNavigate } from "react-router-dom";

import { ThemeContext } from "../../contexts/ThemeContext";
import { Logo_Oselya_128 } from "../Logo/Logo_Oselya_128.jsx";
import { Link } from "../UI/Text/Link.jsx"
import { Text } from "../UI/Text/Text.jsx"
import { MoreOffersSection_card } from "./MoreOffersSection_card.jsx"

import styles from './Info_components.module.css';



export const MoreOffersSection = () => {
  const { t } = useTranslation();
  const navigate = useNavigate();
  const trackRef = useRef(null);
  const { darkMode } = useContext(ThemeContext);

  const CARD_WIDTH = 370;
  const GAP = 78;
  const SLIDE_WIDTH = CARD_WIDTH * 2 + GAP; 


  return (
    <div className={styles.moreOffersSection}>
      <div className="flex-center btn-w-full p-20 mb-30">
        <Text text={t("moreOffersSection.title")} type="title" />
      </div>
      <div className={styles.moreOffersSection_content}>

        {/* slide */}
        <div className={styles.moreOffersSection__grid}>
          <div className={styles.moreOffersSection__row_top}>
            <MoreOffersSection_card showText={false}
              className={styles.moreOffersSection_card__container_left}
            />
            <MoreOffersSection_card
              title={t("moreOffersSection.right_column.title")}
              text={t("moreOffersSection.right_column.text")}
               
            />
          </div>
          <div className={styles.moreOffersSection__row_bottom}>
            <MoreOffersSection_card
              title={t("moreOffersSection.left_column.title")}
              text={t("moreOffersSection.left_column.text")}
               onClick={() => navigate("/attraction")}
            />
            <MoreOffersSection_card showText={false}
              className={styles.moreOffersSection_card__container_right}
            />
          </div>

        </div>

      </div>
    </div>
  );
};
