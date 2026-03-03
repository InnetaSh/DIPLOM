
import { useState } from "react";
import { Text } from "../Text/Text.jsx";
import { ImageSvg } from "../Image/ImageSvg.jsx";
import "../../../styles/globals.css";

export const StateButton__Filter = ({ text,iconName,iconSrc,sizeX, sizeY,active,classNameIcon, className = "btn-h-37 btn-br-r-20", onClick, disabled }) => {
  const [isActive, setIsActive] = useState(active);

  const handleClick = (e) => {
    setIsActive(prev => !prev); 
    onClick?.(e);             
  };

  return (
    <button
      className={`btn btn-state btn-state_filter  ${className} ${isActive ? "btn-state--active" : ""}`}
      onClick={handleClick}
      disabled={disabled}
    >
     
        {(iconName || iconSrc) &&(
        <ImageSvg name={iconName} src={iconSrc} sizeX={sizeX} sizeY={sizeY} className={classNameIcon}/>
        )}
        <Text text = {text } type="m_400"/>
   
    </button>
  );
};
