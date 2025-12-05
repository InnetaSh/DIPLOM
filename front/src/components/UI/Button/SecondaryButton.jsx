
import { Text } from "../Text/Text.jsx";
import "../../../styles/globals.css";

export const SecondaryButton = ({ text, onClick, disabled }) => {
  return (
    <button className="btn btn-secondary" onClick={onClick} disabled={disabled}>
      <Text text ={text} type ="bold"/>
    </button>
  );
};
