import { useState } from "react";
import { useTranslation } from "react-i18next";

import { AccountPanel_card } from "./AccountPanel_card.jsx";
import { Text } from "../UI/Text/Text.jsx"
import { StateButton_Profile } from "../UI/Button/StateButton_Profile.jsx";

import styles from './AccountPanel.module.css';


export const HelpPanel = () => {
  const { t } = useTranslation();

  const hotels = [
    { id: "1", imgSrc: "/img/hotel_info/hotel_1.jpg", title: "Jam Hotel Hnatyuka" },
    { id: "2", imgSrc: "/img/hotel_info/hotel_2.jpg", title: "Нота Бене Лофт" },
    { id: "3", imgSrc: "/img/hotel_info/hotel_3.jpg", title: "Urban Hotel" },
    { id: "4", imgSrc: "/img/hotel_info/hotel_4.jpg", title: "Atmosfera Hotel" },
    { id: "5", imgSrc: "/img/hotel_info/hotel_5.jpg", title: "DREAM Hostel Lviv" },
    { id: "6", imgSrc: "/img/hotel_info/hotel_6.jpg", title: "AUSTRIAN APART HOTEL" }

  ];


  return (
    <div className={styles.accountPanel}>
      <div className={styles.accountPanel__container}>
        <div className={styles.container_btn}>


        </div>
        <div className={styles.container_card}>
          {hotels.map(ht => (
            <AccountPanel_card
              key={ht.id}
              title={ht.title}
              imgSrc={ht.imgSrc}

              onClick={() => console.log(ht.title)}

            />
          ))}
        </div>
      </div>
    </div>
  );
};
