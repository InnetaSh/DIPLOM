import React, { useState } from "react";
import { useTranslation } from "react-i18next";
import styles from "./SortMenu.module.css";
import { SortMenuItem } from "./SortMenuItem";

const optionsIds = [
  "recommended",
  "distance",
  "priceAsc",
  "priceDesc",
  "ratingAsc",
  "ratingDesc",
];

export const SortMenuModal = () => {
  const { t } = useTranslation("SortMenu"); 
  const [activeId, setActiveId] = useState(optionsIds[0]);

  return (
    <div className={styles.container}>
      <div className={styles.menuList}>
       {optionsIds.map((id, index) => (  
          <SortMenuItem
            key={id}
            label={t(id)}
            active={id === activeId}
            onClick={() => setActiveId(id)}
          />
        ))}
      </div>
    </div>
  );
};
