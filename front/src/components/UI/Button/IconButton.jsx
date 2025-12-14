import "../../../styles/globals.css";

export const IconButton = ({ icon, onClick, size = 32, disabled, title = null }) => {
  return (
    <button
      className="btn btn-icon"
      style={{ width: size, height: size }}
      onClick={onClick}
      disabled={disabled}
        title={title}
    >
      {icon}
    </button>
  );
};
