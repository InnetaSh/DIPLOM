

import { IconSvg } from "../Image/IconSvg.jsx";
import { Text } from "../Text/Text.jsx";
import "../../../styles/globals.css";

export const StateButton_Profile = ({
  text,
  icon_name,
  icon_src,
  size = 20,
  type="m_600",
  onClick,
  className = "",
  isActive = false,
  disabled
}) => {
  return (
    <button
      className={`btn btn-state btn-state_profile ${className} ${
        isActive ? "btn-state--active" : ""
      }`}
      onClick={onClick}
      disabled={disabled}
    >
      <IconSvg
        name={icon_name}
        src={icon_src}
        size={size}
        alt={text}
      />
      <Text text={text} type={type}/>
    </button>
  );
};

