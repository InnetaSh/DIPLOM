import { useContext } from "react";
import { useTranslation } from "react-i18next";
import { ThemeContext } from "../../contexts/ThemeContext";
import { Text } from "../UI/Text/Text.jsx";
import { Image } from "../UI/Image/Image.jsx";

import { IconSvg } from "../UI/Image/IconSvg.jsx";
import styles from "./MainPage_bg.module.css";




export const MainPageBg = ({
  imageSrc,
  className,
}) => {
  const { t } = useTranslation();
  
    const { darkMode } = useContext(ThemeContext);
const keySrc = darkMode
    ? "/img/main_page/key_dark.svg"
    : "/img/main_page/key_light.svg";

  return (
    <div className={`${styles.main_page_bg}`}>
      <div className={`${styles.main_page_bg_container}`}>
        
          <div className={`${styles.card__imageWrapper_left_top} ${styles.card__imageWrapper}`}>
            <Image src={keySrc} alt="key"  />
          </div>
            <div className={`${styles.card__imageWrapper_left_bottom} ${styles.card__imageWrapper}`}>
            <Image src={keySrc} alt="key"  />
          </div>
          <div className={`${styles.card__imageWrapper_right_top} ${styles.card__imageWrapper}`}>
            <Image src={keySrc} alt="key"  />
          </div>
            <div className={`${styles.card__imageWrapper_right_bottom} ${styles.card__imageWrapper}`}>
            <Image src={keySrc} alt="key"  />
          </div>
            {/* <div className={`${styles.card__curveWrapper}`}>
            <Image src="/img/main_page/curve.svg" alt="key"  />
             <Image src="/img/main_page/curve.svg" alt="key"  />
          </div> */}
      </div>
    </div>
  );
};
