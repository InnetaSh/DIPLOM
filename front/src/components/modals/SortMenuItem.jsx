import React from "react";
import styles from "./SortMenu.module.css";
import {Text} from "../../components/UI/Text/Text.jsx";

export const SortMenuItem = ({ label, active, onClick }) =>{
  return (
    <button
      type="button"
      onClick={onClick}
      className={`${styles.menuItem} ${active ? styles.menuItemActive : ""}`}
    >
      <Text text ={label} type = "m_500_s_24"/>
    </button>
  );
}
