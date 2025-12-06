
import "../../../styles/globals.css";

export const PrimaryButton = ({ text, onClick, disabled }) => {
  return (
    <button className="btn btn-primary" onClick={onClick} disabled={disabled}>
      {text}
    </button>
  );
};
