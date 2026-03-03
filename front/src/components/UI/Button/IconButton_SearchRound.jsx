import {IconSvg} from "../Image/IconSvg.jsx";
import "../../../styles/globals.css";

export const IconButton_SearchRound = ({
  icon_name="search",
  icon_src,
  size = 25,
  onClick,
  classTitle ="btn-br-r-10 btn-h-35 btn-w-35",
  disabled,
  title = null,
}) => {
  return (
    <button
      className=  {`${classTitle} btn btn_search btn-br-r-50  flex-center`}
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
