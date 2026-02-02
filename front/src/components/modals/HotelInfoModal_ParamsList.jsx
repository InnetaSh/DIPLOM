import React from "react";
import { useTranslation } from "react-i18next";
import { Text } from "../UI/Text/Text.jsx";
import { HotelGalleryModal } from "./HotelGalleryModal.jsx";
import { ActionButton__Primary } from "../../components/UI/Button/ActionButton_Primary.jsx";
import { IconButtonClose } from "../../components/UI/Button/IconButton_close.jsx";


import styles from "./HotelModal.module.css";

export const HotelInfoModal_ParamsList = ({ hotel, setIsModalOpen, showBtn = true }) => {
  const { t } = useTranslation();

  return (
    <div className={styles.HotelInfoModal_paramsList__container} >
      <div className={styles.hotelInfoModal__text_container}>
        <div className={styles.hotelInfoModal__text_left}>

          <Text text="Покращенний двомісний номер з одним ліжком" />
          <Text text="1 номер" />
          <Text text="Вид на визначні пам’ятки" />
          <Text text="Вид на місто" />
          <Text text="Власна ванна кімната" />
          <Text text="Телевізор із плоским екраном" />
        </div>
        <div className={styles.hotelInfoModal__text_right}>
          <div className={styles.right_columns_item}>
            <div>
              <Text text="Покращенний двомісний номер з одним ліжком" />
              <Text text="1 номер" />
              <Text text="Вид на визначні пам’ятки" />
              <Text text="Вид на місто" />
              <Text text="Власна ванна кімната" />
              <Text text="Телевізор із плоским екраном" />
            </div>

          </div>
          <div className={styles.right_columns_item}>
            <div>
              <Text text="Покращенний двомісний номер з одним ліжком" />
              <Text text="1 номер" />
              <Text text="Вид на визначні пам’ятки" />
              <Text text="Вид на місто" />
              <Text text="Власна ванна кімната" />
              <Text text="Телевізор із плоским екраном" />
            </div>
            {showBtn && (
              <ActionButton__Primary text={t("Modal.chooseBtn")} className="btn-h-50 btn-w-276 btn-br-r-10" />
            )}
          </div>
        </div>
      </div>
    </div>
  );
}
