import styles from "./History_card.module.css";
import { Text } from "../UI/Text/Text.jsx";

import { useNavigate } from "react-router-dom";

export const History_card = ({ imgSrc, title, tripId }) => {
  const navigate = useNavigate();



  return (
    <div
      className={styles.hotelCard}
    
      role="button"
      tabIndex={0}
    >
      <img src={imgSrc} alt={title} />
      <div className={styles.text}>
        <p>{title}</p> 
      </div>
    </div>
  );
};
