import React, { useState } from "react";
import { useTranslation } from "react-i18next";
import styles from "./SortMenu.module.css";
import { SortMenuItem } from "./SortMenuItem";


export const SortMenuModal = ({ onSortChange }) => {
  const { t } = useTranslation();

  const options = [
    { id: "recommended", label: t("SortMenu.recommended") },
    { id: "distance", label: t("SortMenu.distance") },
    { id: "priceAsc", label: t("SortMenu.priceAsc") },
    { id: "priceDesc", label: t("SortMenu.priceDesc") },
    { id: "ratingAsc", label: t("SortMenu.ratingAsc") },
    { id: "ratingDesc", label: t("SortMenu.ratingDesc") },
  ];

  const [activeId, setActiveId] = useState(options[0].id);

  return (
    <div className={styles.container}>
      <div className={styles.menuList}>
        {options.map((option) => (
          <SortMenuItem
            key={option.id}
            label={option.label}
            active={option.id === activeId}
            onClick={() => {
              setActiveId(option.id);
              onSortChange(option.id);
            }}
          />
        ))}
      </div>
    </div>
  );
};
