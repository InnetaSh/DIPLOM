import { Text } from "../Text/Text";
import "../../../styles/globals.css";

export const IconWithTextButton = ({
  icon,
  onClick,
  disabled,
  text,
  textType,
}) => {
  return (
    <button
      className="btn btn-icon-with-text"
      onClick={onClick}
      disabled={disabled}
    >
      <span className="btn-icon">
        {icon}
      </span>

      <Text text={text} type={textType} />
    </button>
  );
};
