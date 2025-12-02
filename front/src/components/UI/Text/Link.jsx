
import styles from "./Text.module.css";

export const Link = ({ text, to,type }) => {
   const className = {
    link: styles.link,
    grey_link: styles.grey_link,
   }
  return (
    <a className={className} href={to}>
      {text}
    </a>
  );
};



