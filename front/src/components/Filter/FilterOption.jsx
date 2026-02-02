import React from "react";
import { useTranslation } from "react-i18next";
import styles from "./FilterOption.module.css"; 

import {StateButton__Filter} from "../UI/Button/StateButton_Filter.jsx";

export const FilterOption = ({ option, isSelected, onClick }) => {
   const { t } = useTranslation();
  return (
    <label className={styles.filterOption}>
      <StateButton__Filter text={t(`${option.title}`)} onChange={onClick}/>
    </label>
  );
};
