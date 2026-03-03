import { forwardRef } from "react";
import { IconSvg } from "../UI/Image/IconSvg.jsx";
import styles from "./SearchBar.module.css";

export const DateInputWithIcon = forwardRef(
  (
    {
      value,
      icon_title = "calendar_small",
      icon_size = "18",
      onClick,
      placeholder,
      classTitle = "btn-h-35 btn-w-276",
      input_className = styles.input_date_title_txt
    },
    ref
  ) => {
    return (
      <button
        type="button"
        className={`${styles.input_wrapper} ${classTitle} btn-br-r-10 flex-left`}
        onClick={onClick}
        ref={ref}
      >
        <IconSvg name={icon_title} size={icon_size} />
        <span className={`${styles.input_date_title}  ${input_className} ${value ? "has-value" : ""}`}>
          {value || placeholder}
        </span>
      </button>
    );
  }
);

DateInputWithIcon.displayName = "DateInputWithIcon";
