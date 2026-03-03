import styles from "./HousingPanel_card.module.css";
import { Text } from "../UI/Text/Text.jsx";
import { useTranslation } from "react-i18next";
import { StateButton_Profile } from "../UI/Button/StateButton_Profile.jsx";

export const HousingPanel_card = ({
  id,
  imgSrc,
  title,
  offer,
  onAction,
  hasPending
}) => {

  const { t } = useTranslation();

  const buttons = [ 
    { key: "edit", icon: "menu_btn_edit", text: t("Host.my_housing.menu_btn_edit") },
    { key: "read_reviews", icon: "menu_btn_read_reviews", text: t("Host.my_housing.menu_btn_read_reviews") },
    { key: "booking", icon: "menu_btn_booking", text: t("Host.my_housing.menu_btn_booking") }, 
  ];

  return (
    <div className={styles.hotelCard}>
      <div className={styles.text}>
        <Text text={title} type="m_600_s_20" />
      </div>

      <div className={styles.hotelCard__container}>
        <div className={styles.hotelCard_img}>
          <img src={imgSrc} alt={title} />
        </div>

        <div className={styles.hotelCard_btn}>
          {buttons.map(btn => (
            <StateButton_Profile
              key={btn.key} // 👈 обязательно
              text={
                <>
                  {btn.text}
                  {btn.key === "booking" && hasPending && (
                    <span className={styles.status_warning}>!</span>
                  )}
                </>
              }
              type="m_600_s_20"
              icon_name={btn.icon}
              className="btn-w-full btn-h-39 btn-br-r-20"
              onClick={() => onAction(btn.key, offer)}
            />
          ))}
        </div>
      </div>
    </div>
  );
};