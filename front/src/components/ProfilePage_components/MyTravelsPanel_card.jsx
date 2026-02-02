import styles from "./MyTravelsPanel_card.module.css";
import { Text } from "../UI/Text/Text.jsx";

import { useNavigate } from "react-router-dom";

export const MyTravelsPanel_card = ({ imgSrc, title, tripId }) => {
  const navigate = useNavigate();

  const handleClick = () => {
    navigate(`/profile/trips/past/${tripId}`);
  };

  return (
    <div
      className={styles.hotelCard}
      onClick={handleClick}
      role="button"
      tabIndex={0}
    >
      <img src={imgSrc} alt={title} />
      <div className={styles.text}>
        <Text text={title} type="m_600_s_20" />
      </div>
    </div>
  );
};
