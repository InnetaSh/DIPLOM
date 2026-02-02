import { useState, useContext, useRef, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { useTranslation } from "react-i18next";

import { Text } from "../UI/Text/Text.jsx"
import { IconButton_card_payment } from "../UI/Button/IconButton_card_payment.jsx";
import { ActionButton__Primary } from "../UI/Button/ActionButton_Primary.jsx";
import { ImageSvg } from "../UI/Image/ImageSvg.jsx";
import styles from './PaymentInfoPanel.module.css';

const cards = [
  { id: "1", icon_name: "payment_card_1", sizeX: "50", sizeY: "50", imgSrc: "" },
  { id: "2", icon_name: "payment_card_2", sizeX: "50", sizeY: "50", imgSrc: "" },
  { id: "3", icon_name: "payment_card_3", sizeX: "45", sizeY: "44", imgSrc: "" },
  { id: "4", icon_name: "", sizeX: "50", sizeY: "50", imgSrc: "img/card_google.svg" },
  { id: "5", icon_name: "payment_card_5", sizeX: "80", sizeY: "29", imgSrc: "" },
];


export const PaymentInfoPanel_add_card = ({
  setOpenAddCardPanel,
  setOpenPaymentPanel
}) => {
  const { t } = useTranslation();
  const [selectedCard, setSelectedCard] = useState(null);

  return (

    <div className={`${styles.panel__form} gap-30 mt-10`} >
      <div className="mb-50 btn-w-full flex-left">
        <Text text={t("Prrofile.PaymentInfoPanel.Add_card_for_payment")} type="m_500_s_32" />
      </div>
      <div className={`flex-left-column btn-w-full`}>
        <div className={styles.input_title__container}>
          <Text text={t("Prrofile.AccountPanel.name")} type="m_400_s_16" />
        </div>

        <input
          type="text"
          name="username"
          placeholder=""
          className={`${styles.add_card_input} mt-20 btn-w-full  btn-h-60  btn-br-r-20 p-10`}
          required
        />
        <div className={styles.input_title__container}>
          <Text text={t("Prrofile.PaymentInfoPanel.Select_Method_of_payment")} type="m_400_s_16" />
        </div>
        <div className={styles.card_icon__container}>
          {cards.map(card => (
            <IconButton_card_payment
              key={card.id}
              icon_name={card.icon_name}
              sizeX={card.sizeX}
              sizeY={card.sizeY}
              icon_src={card.imgSrc}
              onClick={() => setSelectedCard(card)}
              isSelected={selectedCard?.id === card.id}
            />
          ))}
        </div>

        <div className={styles.input_card_number__wrapper}>
          <div className={styles.input_title__container}>
            <Text text={t("Prrofile.PaymentInfoPanel.Number_card")} type="m_400_s_16" />
          </div>
          <div className={`${styles.input_with_icon} btn-h-60`}>
            <input
              type="text"
              name="cardNumber"
              placeholder=""
              className={`${styles.add_card_input} mb-50 btn-w-full btn-h-60 btn-br-r-20 p-10`}
              required
            />
            {selectedCard && (
              <div className={styles.selected_card_icon__container}>
                <ImageSvg
                  name={selectedCard.icon_name}
                  sizeX={selectedCard.sizeX}
                  sizeY={selectedCard.sizeY}
                  src={selectedCard.imgSrc}
                  alt="Selected card"
                  className={styles.selected_card_icon}
                />
              </div>
            )}

          </div>
        </div>
      </div>

      <div className={styles.input_card_info__container}>

        <div className={`{styles.container__column_item} flex-column`}>
          <div className={`flex-center btn-w-full`}>
            <Text text={t("Prrofile.PaymentInfoPanel.Cw")} type="m_400_s_20" />
          </div>
          <input
            type="text"
            name="cw"
            placeholder="378"
            className={`${styles.add_card_input} ${styles.add_card_input_center} btn-w-134 btn-h-60  btn-br-r-20 p-10`}
            required
          />
        </div>

        <div className={`{styles.container__column_item} flex-column`}>
          <div className={`flex-center btn-w-full`}>
            <Text text={t("Prrofile.PaymentInfoPanel.DataTime")} type="m_400_s_20" />
          </div>
          <input
            type="text"
            name="cw"
            placeholder="378"
            className={`${styles.add_card_input} ${styles.add_card_input_center} btn-w-151 btn-h-60  btn-br-r-20 p-10`}
            required
          />
        </div>

      </div>
      <div className={styles.bottom_btn__container}>
        <label className={styles.checkbox}>
          <input type="checkbox" />
          <span className={styles.checkmark} />
          <span className={styles.labelText}>
            {t("Prrofile.PaymentInfoPanel.SaveCardInfo")}
          </span>
        </label>
        <ActionButton__Primary
          className="btn-br-r-20 btn-h-60 btn-w-293"
          text={t("Prrofile.PaymentInfoPanel.Save")}
          onClick={() => {
            setOpenAddCardPanel(false);
            setOpenPaymentPanel(true);
          }}
        />
      </div>

    </div >
  );
};
