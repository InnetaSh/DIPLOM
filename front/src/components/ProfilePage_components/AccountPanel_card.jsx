import styles from "./AccountPanel_card.module.css";
import {Text} from "../UI/Text/Text.jsx";

export const AccountPanel_card = ({ title, imgSrc, onClick }) => {
  return (
    <button className={styles.hotelCard} onClick={onClick}>
      <img src={imgSrc} alt={title} />
      <Text text = {title} type ="m_600_s_20"/>
    </button>
  );
};
