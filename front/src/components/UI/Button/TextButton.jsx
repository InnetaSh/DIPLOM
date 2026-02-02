import "../../../styles/globals.css";
import {Text} from "../../UI/Text/Text";

export const TextButton = ({ text,   className = "btn-w-573",onClick, disabled }) => {
  return (
    <button 
     className={`btn btn-text ${className}`}
     onClick={onClick} disabled={disabled}>
      <Text text = {text } type="m_600"/>
    </button>
  );
};
