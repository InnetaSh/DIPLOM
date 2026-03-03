import React from "react";
import styles from "./AdminMenu.module.css";
import {Text} from "../../components/UI/Text/Text.jsx";
import {ImageSvg} from "../../components/UI/Image/ImageSvg.jsx"

export const AdminMenuItem = ({ label,iconName, active, onClick }) =>{
  return (
    <button
      type="button"
      onClick={onClick}
      className={`${styles.menuItem} ${active ? styles.menuItemActive : ""}`}
    >
      <ImageSvg src={iconName} sizeX={30} sizeY="27"/>
      <Text text ={label} type = "m_500_s_24"/>
    </button>
  );
}
