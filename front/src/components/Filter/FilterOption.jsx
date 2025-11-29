import React from "react";
import styles from "./FilterOption.module.css"; 

export const FilterOption = ({ option, isSelected, onClick }) => {
  return (
    <label className={styles.filterOption}>
      <span className={styles.optionText}>{option.title}</span>
      <input
        type="checkbox"
        checked={isSelected}
        onChange={onClick}
        className={styles.optionCheckbox}
      />
    </label>
  );
};
