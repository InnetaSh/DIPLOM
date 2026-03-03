import React, { useState, useEffect, useRef } from "react";
import { useTranslation } from "react-i18next";
import {Text} from "../UI/Text/Text.jsx";
import styles from "./FilterCategory.module.css";

export const PriceProgressBar = ({ min, max, value, onChange }) => {
  const rangeRef = useRef(null);
  const [progressWidth, setProgressWidth] = useState(0);
  const { t } = useTranslation();

  useEffect(() => {
    const percent = ((value - min) / (max - min)) * 100;
    setProgressWidth(percent);
  }, [value, min, max]);

  return (
    <div className={styles.priceProgressBar}>
      <div className={styles.sliderWrapper}>
        <div
          className={styles.progressBar}
          style={{ width: `${progressWidth}%` }}
        />
        <input
          ref={rangeRef}
          type="range"
          min={min}
          max={max}
          value={value}
          onChange={onChange}
          className={styles.slider}
        />
      </div>

      <div className={styles.priceLabels}>
        <Text
          text={`${t("filters.price.from")} ${min} UAH`}
          type="m_400_s_14"
        />
        <Text
          text={`${t("filters.price.to")} ${value} UAH`}
          type="m_400_s_14"
        />
      </div>
    </div>
  );
};
