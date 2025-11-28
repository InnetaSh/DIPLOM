import "../../../styles/globals.css";

export const IconButton = ({ icon, onClick, size = 32, disabled }) => {
  return (
    <button
      className="btn btn-icon"
      style={{ width: size, height: size }}
      onClick={onClick}
      disabled={disabled}
    >
      {icon}
    </button>
  );
};
