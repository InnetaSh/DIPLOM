import "../../../styles/globals.css";

export const TextButton = ({ text, onClick, disabled }) => {
  return (
    <button className="btn btn-text" onClick={onClick} disabled={disabled}>
      {text}
    </button>
  );
};
