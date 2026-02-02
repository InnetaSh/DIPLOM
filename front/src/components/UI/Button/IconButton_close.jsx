import {IconSvg} from "../Image/IconSvg.jsx";
import "../../../styles/globals.css";

export const IconButtonClose = ({
  icon_name = "close",
  className,
  icon_src,
  size = 30,
  onClick,
  disabled,
  title = null,
}) => {
  return (
    <button
      className={`btn btn_icon_close ${className}  flex-center`}
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
