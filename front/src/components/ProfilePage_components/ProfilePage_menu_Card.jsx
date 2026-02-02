
import {Text} from "../UI/Text/Text.jsx";
import { useTranslation } from "react-i18next";
import styles from './Info_components.module.css';

export const TwoColumnInfoSection_Card = ({
 className, 
 text ="bunner.room" 
}) => {
     const { t } = useTranslation();
  return (
    <div className={`${styles.infoSection_card} flex-center`}>
            <div className={`${styles.infoSection_card__container} ${className}`}>
                <Text text={t(text)} type="cagliostro_400_s_40" />
            </div>
        </div>
  );
};


