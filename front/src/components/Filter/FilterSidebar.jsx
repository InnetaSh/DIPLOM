import React from "react";
import { FilterCategory } from "./FilterCategory.jsx";

export const FilterSidebar = ({ filtersData, selectedFilters, onFilterChange }) => {
  return (
    <div className="filter-sidebar">
      {filtersData.map(category => (
        <FilterCategory
          key={category.id}
          category={category}
          selectedFilters={selectedFilters}
          onFilterChange={onFilterChange}
        />
      ))}
    </div>
  );
};
