
import "../../../styles/globals.css";

export const SecondaryButton = ({ children, onClick, disabled }) => {
  return (
    <button className="btn btn-secondary" onClick={onClick} disabled={disabled}>
      {children}
    </button>
  );
};
