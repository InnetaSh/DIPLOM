
import { useLanguage } from "../../contexts/LanguageContext.jsx"; 
import { useTranslation } from "react-i18next";

import { Text } from "../../components/UI/Text/Text.jsx";

import styles from './Hotel_description.module.css';

// функция для автоматической замены одиночных переносов на двойные
function formatDescription(text) {
  if (!text) return "";
  return text
    .split("\n")             
    .map(line => line.trim()) 
    .join("\n\n");           
}

export const HotelDescription = ({  text }) => {
  const { language } = useLanguage(); 
  const { t } = useTranslation();

  const formattedText = formatDescription(text);

  return (
    <section className={styles.hotel_description}>
      <div className={styles.hotel_description__container}>
        <Text text={t("hotel_description.info_about_hotel")} type="m_600_s_32" />
          <div className={`${styles.hotel_description__container_description}`}>
           <p className="text_m_400_s_20">{formattedText}</p>
            </div>
      </div>
    </section>
  );
};
