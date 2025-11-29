import { Link as RouterLink } from "react-router-dom";
import styles from "./Text.module.css";

export const LinkTextItem = ({ text, to }) => {
  return (
    <RouterLink className={styles.link} to={to}>
      {text}
    </RouterLink>
  );
};



