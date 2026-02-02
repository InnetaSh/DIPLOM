import {IconSvg} from "../Image/IconSvg.jsx";
import "../../../styles/globals.css";

export const IconButtonArrow = ({
  icon_name,
  icon_src,
  className,
  size = 30,
  onClick,
  disabled,
  title = null,
}) => {
  return (
    <button
      className={`btn btn_arrow  flex-center ${className}`}
      onClick={onClick}
      disabled={disabled}
      title={title}
    >
      <IconSvg
        name={icon_name}
        src={icon_src}
        size={size}
        alt={title}
      />
    </button>
  );
};
