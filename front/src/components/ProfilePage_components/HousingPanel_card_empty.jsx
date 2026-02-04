import styles from "./HousingPanel_card.module.css";
import { useTranslation } from "react-i18next";
import { Text } from "../UI/Text/Text.jsx";
import { ActionButton__Secondary } from "../UI/Button/ActionButton_Secondary.jsx";

import { useNavigate } from "react-router-dom";

export const HousingPanel_card_empty = () => {
  const { t } = useTranslation();

  return (
    <div className={`${styles.hotelCard}`}>
      <div className={`${styles.hotelCard_empty} flex-center`}>

        <ActionButton__Secondary
          className="btn-br-r-10"
          text={t("Prrofile.HousingPanel.menu_btn_add_housing")}
        type ="m_500"
        />
      </div>




    </div>
  );
};
