import React from "react";
import { useTranslation } from "react-i18next";
import { FilterOption } from "./FilterOption";
import { PriceProgressBar } from "./PriceProgressBar.jsx";
import { Text } from "../UI/Text/Text.jsx";

import styles from './FilterCategory.module.css';



export const FilterCategory = ({
  city,
  category,
  selectedParams,
  onFilterChange }) => {
  const { t } = useTranslation();

  const isDistanceCenter = category.id === 6;
  const isPrice = category.id === 2;
  const isLocation = category.id === 8;

  const [priceValue, setPriceValue] = React.useState(10000);

  const handlePriceChange = (e) => {
    const newValue = Number(e.target.value);
    const min = 1000;

    setPriceValue(newValue);

    const minItemId = category.items[0]?.id;
    const maxItemId = category.items[1]?.id;

    if (minItemId) {
      onFilterChange(minItemId, min, false);
    }

    if (maxItemId) {
      onFilterChange(maxItemId, newValue, false);
    }
  };

if (isLocation) return null;
  return (
    <div className={styles.filterSidebar__category}>
      <div className={`${styles.FilterCategory_title} flex-center`}>
        <Text
          text={
            isDistanceCenter
              ? `${city}: ${t(category.title)}`
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
              isSelected={!!selectedParams[item.id]}
              onClick={() => onFilterChange(item.id, true)}
            />
          ))
        )}
      </div>

    </div>
  );
};
