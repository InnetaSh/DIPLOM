import React from "react";
import { useTranslation } from "react-i18next";
import { FilterCategory } from "./FilterCategory.jsx";
import { Text } from "../UI/Text/Text.jsx";

import styles from './FilterSidebar.module.css';

export const FilterSidebar = ({ filtersData, selectedFilters, onFilterChange }) => {
  const { t } = useTranslation();

  return (
    <div className={styles.filterSidebar}>
      <div className={`${styles.filterSidebar_title} flex-center`}>
        <Text text={t("filters.filterTitle")} type="m_700_s_32" />
      </div>
      <div className={`${styles.filterSidebar_line} flex-center`}>
        <div className={`${styles.line_wrapper} gap-12`}>
          <div className={`${styles.line} ${styles.left} `}>
            <div className={`${styles.circle_left} ${styles.circle}`}></div>
            <div className={`${styles.circle_right} ${styles.circle}`}></div>
          </div>

          {/* <div className={`${styles.line} ${styles.right}`}>
                            <div className={styles.circle}></div>
                        </div> */}
        </div>
      </div>

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
