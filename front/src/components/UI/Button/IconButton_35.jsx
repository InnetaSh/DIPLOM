import {IconSvg} from "../Image/IconSvg.jsx";
import "../../../styles/globals.css";

export const IconButton__35 = ({
  icon_name,
  icon_src,
  size = 24,
  onClick,
  disabled,
  title = null,
}) => {
  return (
    <button
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
    </button>
  );
};
