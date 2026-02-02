import { useState } from "react";
import { useTranslation } from "react-i18next";

import { MyTravelsPanel_card } from "./MyTravelsPanel_card.jsx";
import { MyTravelsPanel_active_card } from "./MyTravelsPanel_active_card.jsx";
import { MyTravelsPanel_card_empty } from "./MyTravelsPanel_card_empty.jsx";
import { Text } from "../UI/Text/Text.jsx"
import { StateButton_Profile_OrangOnHover } from "../UI/Button/StateButton_Profile_OrangOnHover.jsx";

import styles from './MyTravelsPanel.module.css';


export const MyTravelsPanel = () => {
  const { t } = useTranslation();
  const [activeKey, setActiveKey] = useState("1");



  const hotelsActive = [
    { id: "1", imgSrc: "/img/hotel_info/hotel_1.jpg", title: "Jam Hotel Hnatyuka", date: "07.01.2026 -12.01-2026", price: "UAH 7 568" },
  ]
  const hotelsPast = [
    { id: "1", imgSrc: "/img/hotel_info/hotel_1.jpg", title: "Jam Hotel Hnatyuka" },
    { id: "2", imgSrc: "/img/hotel_info/hotel_2.jpg", title: "Нота Бене Лофт" },
    { id: "3", imgSrc: "/img/hotel_info/hotel_3.jpg", title: "Urban Hotel" },
    { id: "4", imgSrc: "/img/hotel_info/hotel_4.jpg", title: "Atmosfera Hotel" },
    { id: "5", imgSrc: "/img/hotel_info/hotel_5.jpg", title: "DREAM Hostel Lviv" },
    { id: "6", imgSrc: "/img/hotel_info/hotel_6.jpg", title: "AUSTRIAN APART HOTEL" }

  ];
  const hotelsCancelled = [

  ];

  const buttons = [
    { id: "1", text: t("Prrofile.my_travel.active") },
    { id: "2", text: t("Prrofile.my_travel.past") },
    { id: "3", text: t("Prrofile.my_travel.cancelled") },
  ];

  return (
    <div className={styles.myTravelPanel}>
      <div className={styles.myTravelPanel__container}>
        <div className={styles.container_btn}>
          {buttons.map(btn => (
            <StateButton_Profile_OrangOnHover
              key={btn.id}
              text={btn.text}
              icon_name=""
              className={`btn-w-fit-content btn_brdr_1 btn-h-60 btn-br-r-20 ${activeKey === btn.id ? "active" : ""
                }`}
              isActive={activeKey === btn.id}
              onClick={() => setActiveKey(btn.id)}
            />
          ))}

        </div>



        {activeKey === "1" &&
          hotelsActive.map(ht => (
            <MyTravelsPanel_active_card
              key={ht.id}
              title={ht.title}
              imgSrc={ht.imgSrc}
              date={ht.date}
              price={ht.price}
              onClick={() => console.log(ht.title)}
            />
          ))
        }

        {activeKey === "2" &&
          (hotelsPast.length === 0 ? (
            <MyTravelsPanel_card_empty />
          ) : (
            <div className={styles.container_card}>
              {hotelsPast.map(ht => (
                <MyTravelsPanel_card
                  key={ht.id}
                  title={ht.title}
                  imgSrc={ht.imgSrc}
                  tripId={ht.id}
                  onClick={() => console.log(ht.title)}
                />
              ))
              }

            </div>
          ))
        }

        {activeKey === "3" &&
          (hotelsCancelled.length === 0 ? (
            <MyTravelsPanel_card_empty />
          ) : (
            <div className={styles.container_card}>
              {hotelsCancelled.map(ht => (
                <MyTravelsPanel_card
                  key={ht.id}
                  title={ht.title}
                  imgSrc={ht.imgSrc}
                  tripId={ht.id}
                  onClick={() => console.log(ht.title)}
                />
              ))
              }
            </div>
          ))
        }



      </div>
    </div >
  );
};
