import React from "react";
import { useContext } from "react";
import { ThemeContext } from "../../contexts/ThemeContext";
import { useTranslation } from "react-i18next";
import { ImageSvg } from "../../components/UI/Image/ImageSvg.jsx";
import styles from "./FilterOption.module.css";

import { StateButton__Filter } from "../UI/Button/StateButton_Filter.jsx";



export const FilterOption = ({ option, className, isSelected, onClick }) => {
  const { t } = useTranslation();
  const { darkMode } = useContext(ThemeContext);

  const themeFolder = darkMode
    ? "dark_tema"
    : "light_tema";


  const src = `img/icon_params/${themeFolder}/${option.iconName}.svg`;

  const hasIcon = Boolean(option.iconName);

  return (
    <label className={styles.filterOption}>
      <StateButton__Filter
        text={t(option.title)}
        {...(hasIcon && { iconSrc: src })}
        sizeX={25}
        sizeY={25}
        classNameIcon="icon_param_filter"
        className={className}
        onClick={onClick}
        active={isSelected}
      />
    </label>
  );

};

