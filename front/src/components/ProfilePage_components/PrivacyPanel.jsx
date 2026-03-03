import { useTranslation } from "react-i18next";
import styles from './PrivacyPanel.module.css';

export const PrivacyPanel = () => {
  const { t } = useTranslation();

  const privacyItems = [
    { id: 1, title: "Сбор данных", description: "Мы собираем только необходимые данные для работы сервиса." },
    { id: 2, title: "Использование информации", description: "Ваши данные используются для обработки заказов и улучшения сервиса." },
    { id: 3, title: "Передача третьим лицам", description: "Мы не передаем ваши личные данные третьим лицам без вашего согласия." },
    { id: 4, title: "Безопасность", description: "Все данные защищены и хранятся в зашифрованном виде." },
  ];

  return (
    <div className={styles.privacyPanel}>
      <div className={styles.privacyPanel__container}>
        <h2 className={styles.privacyPanel_title}>Политика конфиденциальности</h2>
        <div className={styles.container_card}>
          {privacyItems.map(item => (
            <div key={item.id} className={styles.privacyCard}>
              <h4 className={styles.privacyCard_title}>{item.title}</h4>
              <p className={styles.privacyCard_desc}>{item.description}</p>
            </div>
          ))}
        </div>
      </div>
    </div>
  );
};
