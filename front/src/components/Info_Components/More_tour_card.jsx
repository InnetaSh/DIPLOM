
import { useTranslation } from "react-i18next";
import { Text } from "../UI/Text/Text.jsx";
import { Image } from "../UI/Image/Image.jsx";

import { IconSvg } from "../UI/Image/IconSvg.jsx";
import styles from "./More_tour.module.css";




export const More_tour_card = ({
  imageSrc,
  textKey,
  className_Rotation,
  className_Container,
}) => {
  const { t } = useTranslation();

  return (
    <div className={`${styles.more_tour_card} ${className_Container ?? ""}`}>
      
      <div className={`${styles.more_tour_card_container} ${className_Rotation ?? ""}`}>
        
        <div className={`${styles.container_wrapper} `}>
          
          <div className={styles.card__imageWrapper}>
            <Image src={imageSrc} alt={t(textKey)} type="card" />
          </div>

          <div className={styles.card__textWrapper}>
            <IconSvg name="navigator" size="43" />
            <Text text={t(textKey)} type="m_600" />
            <IconSvg name="heart" size="24" />
          </div>

        </div>
      </div>
    </div>
  );
};
