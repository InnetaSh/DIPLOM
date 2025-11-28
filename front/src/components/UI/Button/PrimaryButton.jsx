
import "../../../styles/globals.css";

export const PrimaryButton = ({ children, onClick, disabled }) => {
  return (
    <button className="btn btn-primary" onClick={onClick} disabled={disabled}>
      {children}
    </button>
  );
};
