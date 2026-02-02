import React from "react";
import { useTranslation } from "react-i18next";
import { Text } from "../UI/Text/Text.jsx";
import { HotelGalleryModal } from "./HotelGalleryModal.jsx";
import { ActionButton__Primary } from "../../components/UI/Button/ActionButton_Primary.jsx";
import { IconButtonClose } from "../../components/UI/Button/IconButton_close.jsx";
import { HotelInfoModal_ParamsList } from "./HotelInfoModal_ParamsList.jsx";

import styles from "./HotelModal.module.css";

export const HotelInfoModal = ({ images, hotel, setIsModalOpen }) => {
  const { t } = useTranslation();

  return (
    <div className={styles.hotelInfoModal} >
      <IconButtonClose onClick={() => setIsModalOpen(false)} />
      <HotelGalleryModal images={images} />
      <HotelInfoModal_ParamsList />
    </div>
  );
}
