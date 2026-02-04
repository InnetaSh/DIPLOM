import React from "react";
import { Text } from "../../UI/Text/Text";
import "../../../styles/globals.css";

export const RadioButton = ({ text, active = false, onClick, disabled }) => {
  return (
    <button
     type="button" 
      className={`btn btn-radio gap-12`}
      onClick={onClick}
      disabled={disabled}
      title={text}
    >
     <div className={`circle_btn ${active ? "btn-radio--active" : ""}`} />
      <Text text={text} type="m_600_s_48"/>
    </button>
  );
};
