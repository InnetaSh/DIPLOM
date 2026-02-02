import React from "react";
import { useTranslation } from "react-i18next";

import { Logo_Oselya_128 } from "../Logo/Logo_Oselya_128.jsx";
import { Text } from "../UI/Text/Text.jsx"
import { ActionButton__Primary } from "../UI/Button/ActionButton_Primary.jsx";
import { TwoColumnInfoSection_Card } from "./TwoColumnInfoSection_Card.jsx"

import styles from './Info_components.module.css';

export const TwoColumnInfoSection = () => {
  const { t } = useTranslation();

  return (
    <div className={styles.infoSection}>
      <svg
        className={styles.infoSection__svg}
        viewBox="0 0 1920 687"
        preserveAspectRatio="xMidYMid meet"
      >
        <path
          d="M0 146.127C0 138.096 4.67434 130.9 12.0782 127.79C70.0433 103.439 318.355 0 353.727 0C393.818 0 633.818 122.106 707.455 132.88C775.386 142.819 1749.93 134.42 1900.52 133.059C1911.64 132.958 1920 141.95 1920 153.07V667C1920 678.046 1911.05 687 1900 687H20C8.95434 687 0 678.046 0 667V146.127Z"
          fill="#EDE5D1"
        />
        <g transform="translate(154 97)">
          <foreignObject width="420" height="175">
            <div xmlns="http://www.w3.org/1999/xhtml" className={styles.infoSection__logo_wrapper}>
              <Logo_Oselya_128 />
            </div>
          </foreignObject>
        </g>
      </svg>
      <div className={styles.infoSection__content}>
        <div className={styles.infoSection__title}>
          <Text text={t("infoSection.title")} type="m_700_s_40" />
        </div>
        <div className={styles.infoSection__columns}>
          <div className={styles.infoSection__columns_container}>
            <div className={styles.infoSection__column}>
              <div className={styles.infoSection__grid}>
                <TwoColumnInfoSection_Card text={t("infoSection.left_column.icon")} className={styles.infoSection_card__container_left} />
                <Text text={t("infoSection.left_column.text")} type="m_400_s_20" />
              </div>
              <div className={styles.infoSection__btn}>
                <ActionButton__Primary text={t("infoSection.left_column.btn")} className="btn-br-r-10 btn-w-full btn-h-full " />
              </div>
            </div>


            <div className={styles.infoSection__column}>
              <div className={styles.infoSection__grid}>
                <TwoColumnInfoSection_Card text={t("infoSection.right_column.icon")} className={styles.infoSection_card__container_right} />
                <Text text={t("infoSection.right_column.text")} type="m_400_s_20" />
              </div>
              <div className={styles.infoSection__btn}>
                <ActionButton__Primary text={t("infoSection.left_column.btn")} className="btn-br-r-10 btn-w-full btn-h-full " />
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};
