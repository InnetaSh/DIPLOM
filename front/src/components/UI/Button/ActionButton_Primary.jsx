import {Text} from "../../UI/Text/Text";
import "../../../styles/globals.css";

export const ActionButton__Primary = ({ text,text_2="",type="m_600",type_2="",  className = "btn-w-573 btn-h-59", onClick, disabled }) => {
  return (
    <button 
     className={`btn btn-action ${className}`}
     onClick={onClick} disabled={disabled}>
      <Text text = {text } type={type}/>
        <Text text = {text_2 } type={type_2}/>
    </button>
  );
};
