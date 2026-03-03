
import { Text } from "../UI/Text/Text.jsx";
import { ActionButton__Primary } from "../../components/UI/Button/ActionButton_Primary.jsx";
import { useTranslation } from "react-i18next";
import styles from './Info_components.module.css';

export const MoreOffersSection_card = ({
  className,
  title,
  showText = true,
  text,
  onClick,
}) => {
  const { t } = useTranslation();

  return (
    <div className={`${styles.moreOffersSection_card}  flex-left`}>
      <div
        className={`${styles.moreOffersSection_card__container} ${className}`}
      >
        {showText && (
          <>
            <div className={styles.moreOffersSection_card__title}>
              <Text text={title} type="m_600_s_36" />
            </div>

            <div className={styles.moreOffersSection_card__text}>
              <Text text={text} type="m_400_s_16" />
            </div>

            <div className={styles.moreOffersSection_card__btn}>
              <ActionButton__Primary
                text={t("moreOffersSection.btn")}
                className="btn-br-r-20 btn-w-full btn-h-59"
                onClick={onClick}
              />
            </div>
          </>
        )}
      </div>
    </div>
  );
};
