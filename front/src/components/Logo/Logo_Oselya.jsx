import { ImageSvg } from "../UI/Image/ImageSvg";

export const Logo_Oselya = ({
  sizeX = "187",
  sizeY = "85"
}) => {
  return (
    <div
      className={` header__logo_Oselya `}>
      <ImageSvg
        src="/img/icon_logo/logo_header.svg"
        sizeX={sizeX}
        sizeY={sizeY} />
    </div>
  );
};
