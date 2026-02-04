
import { Text } from "../Text/Text.jsx";
import "../../../styles/globals.css";

export const ActionButton__Secondary = ({
   text, 
   width = 425,
    type ="m_500",
   className,
    onClick,
     disabled }) => {
  return (
    <button 
    className={`btn btn-action-secondary   ${className}`}
    style={{ width: `${width}px` }}
     onClick={onClick} disabled={disabled}>
      <Text text ={text} type ={type}/>
    </button>
  );
};
