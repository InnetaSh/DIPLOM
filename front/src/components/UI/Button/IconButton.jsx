import "../../../styles/globals.css";

export const IconButton = ({ icon, onClick, disabled, title = null }) => {
  return (
    <button
      className="btn btn-icon btn-icon__big"
      onClick={onClick}
      disabled={disabled}
        title={title}
    >
      {icon}
    </button>
  );
};
