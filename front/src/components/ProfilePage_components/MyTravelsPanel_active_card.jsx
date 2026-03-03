import styles from "./MyTravelsPanel_active_card.module.css";
import { useTranslation } from "react-i18next";
import { StateButton_Profile } from "../UI/Button/StateButton_Profile.jsx";
import { Text } from "../UI/Text/Text.jsx";

export const MyTravelsPanel_active_card = ({ title, date, price, imgSrc, onClick }) => {
   const { t } = useTranslation();

  return (
    <div className={styles.hotelCard}>
      <img src={imgSrc} alt={title} />
      <div className={styles.container_left}>
        <Text text={title} type="m_700_s_32" />
        <Text text={date} type="m_400_s_24" />
        <div  className={styles.container_btn}>
          <div className={styles.container_price}>
            <Text text={`UAH  ${price}`} type="m_700_s_20" />
          </div>
          <StateButton_Profile
            text={t("Prrofile.Reservation_management")}
            type ="m_500_s_20"
            icon_name=""
            className={` ${styles.hotelCard_btn}  btn-br-r-20`}
            onClick={() => console.log("Управління  бронюванням")}
          />
        </div>

      </div>
    </div>
  );
};
