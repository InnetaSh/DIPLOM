
import React, { useState} from "react";
import { useTranslation } from "react-i18next";
import { FilterCategory } from "./FilterCategory.jsx";
import { Text } from "../UI/Text/Text.jsx";
import { ActionButton__Primary } from "../UI/Button/ActionButton_Primary.jsx";

import styles from './FilterSidebar.module.css';

export const FilterSidebar = ({
  city,
  filtersData,
  setParamsString,
  params,
  setParams
}) => {
  const { t } = useTranslation();
  const [tempParams, setTempParams] = useState({ ...params });

  const handleFilterChange = (paramId, value, isToggle = true) => {
    setTempParams(prev => {
      const updated = { ...prev };

      if (isToggle) {
        if (paramId in updated) {
          delete updated[paramId];
        } else {
          updated[paramId] = value;
        }
      } else {
        updated[paramId] = value;
      }

      const paramsString = Object.entries(updated)
        .map(([key, val]) => `${key}:${val}`)
        .join(",");

      console.log("paramsString:", paramsString);

      setParamsString(paramsString);

      return updated;
    });
  };

  const handleApply = () => {
    setParams(tempParams);

    const paramsStr = Object.entries(tempParams)
      .map(([key, val]) => `${key}:${val}`)
      .join(",");
    setParamsString(paramsStr);

    console.log("Applied paramsString:", paramsStr);
  };

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
        </div>
      </div>

      {filtersData.map(category => (
       <FilterCategory
  key={category.id}
  city={city}
  category={category}
  selectedParams={tempParams}   
  onFilterChange={handleFilterChange}
/>

      ))}
      <div className="flex-center btn-w-full">
        <ActionButton__Primary
          className="btn-w-190 btn-h-44 btn-br-r-20 "
          text={t("filters.filterBtn")}
          type="m_700_s_20"
          onClick={handleApply}
        />
      </div>

    </div>
  );
};
