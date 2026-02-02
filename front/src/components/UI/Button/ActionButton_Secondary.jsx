
import { Text } from "../Text/Text.jsx";
import "../../../styles/globals.css";

export const ActionButton__Secondary = ({ text, width = 425, onClick, disabled }) => {
  return (
    <button 
    className="btn btn-action-secondary"
    style={{ width: `${width}px` }}
     onClick={onClick} disabled={disabled}>
      <Text text ={text} type ="m_500"/>
    </button>
  );
};
