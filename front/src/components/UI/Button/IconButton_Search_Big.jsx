import {IconSvg} from "../Image/IconSvg.jsx";
import "../../../styles/globals.css";

export const IconButton_Search_Big = ({
  icon_name,
  icon_src,
  size = 40,
  onClick,
  disabled,
  title = null,
}) => {
  return (
    <button
      className="btn btn_search flex-center btn-br-r-10  "
      onClick={onClick}
      disabled={disabled}
      title={title}
    >
      <IconSvg
        name={icon_name}
        src={icon_src}
        size={size}
        alt={title}
         className="icon-svg"
      />
    </button>
  );
};
