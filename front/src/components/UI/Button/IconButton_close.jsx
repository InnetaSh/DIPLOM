import {ImageSvg} from "../Image/ImageSvg.jsx";
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
      <ImageSvg
        name={icon_name}
        src={icon_src}
        sizeX={size}
        sizeY={size}
        alt={title}
      />
    </button>
  );
};
