// AddGuestModal.jsx
import React from "react";
import { useTranslation } from "react-i18next";
import { Text } from "../UI/Text/Text.jsx";
import { CounterButton } from "../UI/Button/CounterButton.jsx";
import { ActionButton__Primary } from "../UI/Button/ActionButton_Primary.jsx";
import { IconButtonClose } from "../UI/Button/IconButton_close.jsx";
import styles from "./AddGuestModal.module.css";

export const AddGuestModal = ({ guests, setGuests, setIsModalOpen }) => {
  const { t } = useTranslation();

  const updateGuest = (key, value) => {
    setGuests(prev => {
      const updatedGuests = {
        ...prev,
        [key]: value,
      };

      return {
        ...updatedGuests,
        totalGuests:
          (updatedGuests.adults || 0) +
          (updatedGuests.children || 0),
      };
    });
  };

  return (
    <div className={styles.addGuestModal}>
      <IconButtonClose onClick={() => setIsModalOpen(false)} />

      <div className="btn-w-562 btn-h-94">
        <Text
          text={t("Search.search_title_modal")}
          type="m_700_s_32"
        />
      </div>

      <div className="flex-center-column gap-10 btn-w-full">
        <div className={styles.modal__container}>
          <Text text={t("Search.hotel_number")} type="m_700_s_20" />
          <CounterButton
            value={guests.rooms}
            onChange={(val) => updateGuest("rooms", val)}
          />
        </div>

        <div className={styles.modal__container}>
          <Text text={t("Search.adults")} type="m_700_s_20" />
          <CounterButton
            value={guests.adults}
            onChange={(val) => updateGuest("adults", val)}
          />
        </div>

        <div className={styles.modal__container}>
          <div className="flex-left-column">
            <Text text={t("Search.children")} type="m_700_s_20" />
            <Text
              text={t("Search.from_0_to_17")}
              type="m_400_s_14"
            />
          </div>
          <CounterButton
            value={guests.children}
            onChange={(val) => updateGuest("children", val)}
          />
        </div>
      </div>

      <div className={styles.modal__container}>
        <Text
          text={t("Search.trip_with_animal")}
          type="m_700_s_20"
        />
      </div>

      <ActionButton__Primary
        className="btn-w-276 btn-h-44 btn-br-r-20"
        text={t("Search.searh_btn")}
        onClick={() => setIsModalOpen(false)}
      />
    </div>
  );
};
