
import { useState } from "react";
import { Text } from "../Text/Text.jsx";
import "../../../styles/globals.css";

export const StateButton__Filter = ({ text,icon, className = "btn-h-37 btn-br-r-20", onClick, disabled }) => {
  const [active, setActive] = useState(false);

  const handleClick = (e) => {
    setActive(prev => !prev); 
    onClick?.(e);             
  };

  return (
    <button
      className={`btn btn-state btn-state_filter  ${className} ${active ? "btn-state--active" : ""}`}
      onClick={handleClick}
      disabled={disabled}
    >
      <span>
        {icon}
        <Text text = {text } type="m_400"/>
      </span>
    </button>
  );
};
