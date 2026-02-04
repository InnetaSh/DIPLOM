
import {IconSvg} from "../UI/Image/ImageSvg.jsx";
import "../../../styles/globals.css";

export const BookingSuccess = () => {
  return (
    <div
      className="btn btn-icon btn-h-35 btn-w-35  flex-center"
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
    </div>
  );
};
