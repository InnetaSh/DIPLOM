import "../../../styles/globals.css";
import { Text } from "../Text/Text";
import { ImageSvg } from "../Image/ImageSvg.jsx";

export const GoogleButton = ({ text, className = "btn-w-1165", onClick, disabled }) => {
  return (
    <button
      className={`btn btn-google ${className}`}
      onClick={onClick} disabled={disabled}>
      <div className={`flex-left btn-w-full btn-google__container`}>
        <ImageSvg src="/img/card_google.svg" sizeX="69" sizeY="69" />
        <div >
          <Text text={text} type="m_600" />
        </div>
      </div>

    </button>
  );
};
