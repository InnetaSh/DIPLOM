import React from "react";
import styles from "./FilterCategory.module.css";
import { FilterOption } from "./FilterOption";
import { Text } from "../UI/Text/Text.jsx";

export const FilterCategory = ({ category, selectedFilters, onFilterChange }) => {
  const selected = selectedFilters[category.title] || [];

  return (
    <div className="filter-category">
      <Text text={category.title} type="bolt" />
      <div className="filter-options">
        {category.items.map(item => (
          <FilterOption
            key={item.id}
            option={item}
            isSelected={selected.includes(item.title)}
            onClick={() => onFilterChange(category.title, item.title)}
          />
        ))}
      </div>
    </div>
  );
};