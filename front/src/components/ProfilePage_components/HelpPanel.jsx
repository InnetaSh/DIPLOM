import { useTranslation } from "react-i18next";
import styles from './HelpPanel.module.css';

export const HelpPanel = () => {
  const { t } = useTranslation();

  const helpItems = [
    { id: 1, title: "Как забронировать жильё", description: "Пошаговое руководство по бронированию." },
    { id: 2, title: "Оплата и возвраты", description: "Информация о способах оплаты и возвратах." },
    { id: 3, title: "Связь с поддержкой", description: "Как связаться с нашей службой поддержки." },
  ];

  return (
    <div className={styles.helpPanel}>
      <div className={styles.helpPanel__container}>
        <div className={styles.container_btn}>
         
        </div>
        <div className={styles.container_card}>
          {helpItems.map(item => (
            <div key={item.id} className={styles.helpCard}>
              <div className={styles.helpCard_icon}>❓</div>
              <div className={styles.helpCard_content}>
                <h4 className={styles.helpCard_title}>{item.title}</h4>
                <p className={styles.helpCard_desc}>{item.description}</p>
              </div>
            </div>
          ))}
        </div>
      </div>
    </div>
  );
};
