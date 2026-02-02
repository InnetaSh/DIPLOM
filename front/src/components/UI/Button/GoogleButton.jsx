import "../../../styles/globals.css";
import {Text} from "../Text/Text";

export const GoogleButton = ({ text,   className = "btn-w-1165",onClick, disabled }) => {
  return (
    <button 
     className={`btn btn-google ${className}`}
     onClick={onClick} disabled={disabled}>
      <span>
        <Text text = {text } type="m_600"/>
      </span>
      
    </button>
  );
};
