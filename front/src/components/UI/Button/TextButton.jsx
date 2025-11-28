import "../../../styles/globals.css";

export const TextButton = ({ children, onClick, disabled }) => {
  return (
    <button className="btn btn-text" onClick={onClick} disabled={disabled}>
      {children}
    </button>
  );
};
