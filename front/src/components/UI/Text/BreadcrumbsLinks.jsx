import { Link, useLocation } from "react-router-dom";
import { FiChevronRight } from "react-icons/fi";
import styles from "./Text.module.css";
import { useState } from "react";

export const Breadcrumbs = ({ 
   country="Украина",
  region="Львовская область",
  city={city} ,  // передаём state из Header
  hotelTitle,
  last_path="Результаты поиска"
}) => {

  
  const parts = [
    country && { label: country, to: `/country/${encodeURIComponent(country)}` },
    region && { label: region, to: `/region/${encodeURIComponent(region)}` },
    city && { label: city, to: `/city/${encodeURIComponent(city)}` },
    // district && { label: district, to: `/district/${encodeURIComponent(district)}` }
  ].filter(Boolean); 


  const items = [
    { label: "Главная", to: "/" },
    ...parts
  ];

  if (parts.length > 0) {
    items.push({ label: last_path, to: null });
  }


  return (
    <div className={styles.breadcrumbs}>
      {items.map((item, index) => (
        <div key={index} className={styles.item}>
          {item.to ? (
            <Link to={item.to} className={styles.breadcrumbs_link}>
              {item.label}
            </Link>
          ) : (
            <span className={styles.disabled}>{item.label}</span>
          )}

          {index < items.length - 1 && (
            // <FiChevronRight className={styles.icon} />
             <svg className={styles.icon} width="11" height="15">
            +    <use href="/img/sprite.svg#breadcrumbs_next_icon" />
            +  </svg>
          )}
        </div>
      ))}
    </div>
  );
};
