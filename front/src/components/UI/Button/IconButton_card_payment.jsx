import {ImageSvg} from "../Image/ImageSvg.jsx";
import "../../../styles/globals.css";

export const IconButton_card_payment = ({
  icon_name,
  icon_src,
  sizeX = 80,
  sizeY=29,
  onClick,
  disabled,
  title = null,
}) => {
  return (
    <button
      className="btn btn-icon btn-icon_card btn-h-100 btn-w-100  flex-center"
      onClick={onClick}
      disabled={disabled}
      title={title}
    >
      <ImageSvg
        name={icon_name}
        src={icon_src}
        sizeX={sizeX}
        sizeY={sizeY}
        alt={title}
      />
    </button>
  );
};
