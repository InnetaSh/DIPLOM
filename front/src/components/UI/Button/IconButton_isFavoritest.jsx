import { useState, useContext, useEffect } from "react";
import { ApiContext } from "../../../contexts/ApiContext.jsx";

import { ImageSvg } from "../Image/ImageSvg.jsx";

export const IconButton_isFavoritest = ({
  hotelId,
  className = "",
  icon_src,
  sizeX = 36,
  sizeY = 36,
  onClick,
  title = null,
  myHistoryIdList = [],
  initialActive = false,
}) => {
  const [isActive, setIsActive] = useState(initialActive);
  const [isHover, setIsHover] = useState(false);
  const [loading, setLoading] = useState(false);

  const { userApi } = useContext(ApiContext);


  useEffect(() => {
    if (myHistoryIdList?.includes(hotelId)) {
      setIsActive(true);
    } else {
      setIsActive(false);
    }
  }, [hotelId, myHistoryIdList]);

  const handleClick = async (e) => {
    e.preventDefault();
    e.stopPropagation();

    if (loading) return;

    const newState = !isActive;
    setIsActive(newState);
    setLoading(true);

    try {
      if (newState) {
        await userApi.setMyHistory(hotelId);
      } else {
        // если сняли — добавить метод userApi.removeFromHistory(hotelId)
        // await userApi.removeFromHistory(hotelId);
      }

      if (onClick) onClick(newState);
    } catch (err) {
      console.error("Ошибка при изменении избранного", err);
      setIsActive(!newState);
    } finally {
      setLoading(false);
    }
  };

  const icon_name = isActive || isHover ? "isFavoritest_active" : "isFavoritest";

  return (
    <button
      className={`btn btn_icon_isFavorite ${className} flex-center`}
      onClick={handleClick}
      title={title}
      onMouseEnter={() => setIsHover(true)}
      onMouseLeave={() => setIsHover(false)}
    >
      <ImageSvg
        name={icon_name}
        src={icon_src}
        sizeX={sizeX}
        sizeY={sizeY}
        alt={title}
      />
    </button>
  );
};
