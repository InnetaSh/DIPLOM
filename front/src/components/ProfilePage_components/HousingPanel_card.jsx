import styles from "./HousingPanel_card.module.css";
import { Text } from "../UI/Text/Text.jsx";

import { useNavigate } from "react-router-dom";

export const HousingPanel_card = ({
  id,
  imgSrc,
  title,
  tripId,
  setShowForm,
  setShowHostelList,
  setShowHostelId
}) => {
  const navigate = useNavigate();



  return (
    <div
      className={styles.hotelCard}
      onClick={() => {
        setShowForm(true)
        setShowHostelList(false)
        setShowHostelId(id)
      }}
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
