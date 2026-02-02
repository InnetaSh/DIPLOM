import React from "react";
import { useTranslation } from "react-i18next";
import { FilterOption } from "./FilterOption";
import {PriceProgressBar} from "./PriceProgressBar.jsx";
import { Text } from "../UI/Text/Text.jsx";

import styles from './FilterCategory.module.css';

export const FilterCategory = ({ category, selectedFilters, onFilterChange }) => {
  const selected = selectedFilters[category.title] || [];
  const { t } = useTranslation();

  const isDistanceCenter = category.id === "distance_center";
  const isPrice = category.id === "price";


   const [priceValue, setPriceValue] = React.useState(10000);

  const handlePriceChange = (e) => {
    const newValue = e.target.value;
    setPriceValue(newValue);
    onFilterChange(category.title, newValue);
  };


  return (
    <div className={styles.filterSidebar__category}>
     <div className={`${styles.FilterCategory_title} flex-center`}>
        <Text
          text={
            isDistanceCenter
              ? `${t("Львів")} ${t(category.title)}`
              : t(category.title)
          }
          type="m_700_s_20"
        />
      </div>
       <div className={styles.filterCategory__params}>
        {isPrice ? (
          <PriceProgressBar
            min={1000}
            max={20000}
            value={priceValue}
            onChange={handlePriceChange}
          />
        ) : (
          category.items.map(item => (
            <FilterOption
              key={item.id}
              option={item}
              isSelected={selected.includes(item.title)}
              onClick={() => onFilterChange(category.title, item.title)}
            />
          ))
        )}
      </div>
    </div>
  );
};
