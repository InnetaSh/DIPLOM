import { useState } from "react";
import { useTranslation } from "react-i18next";

import { HousingPanel_card } from "./HousingPanel_card.jsx";
import { MyTravelsPanel_active_card } from "./MyTravelsPanel_active_card.jsx";
import { HousingPanel_card_empty } from "./HousingPanel_card_empty.jsx";
import { Text } from "../UI/Text/Text.jsx"
import { StateButton_Profile_OrangOnHover } from "../UI/Button/StateButton_Profile_OrangOnHover.jsx";
import { HostPropertyForm } from "./HostPropertyForm.jsx";
import styles from './HousingPanel.module.css';


export const HousingPanel = () => {
  const { t } = useTranslation();
  const [activeKey, setActiveKey] = useState("1");
  const [showHostelList, setShowHostelList] = useState(true);
  const [showForm, setShowForm] = useState(false);
  const [showHostelId, setShowHostelId] = useState(null);


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
    { id: "1", text: t("Prrofile.HousingPanel.menu_btn_my_housing") },
    { id: "2", text: t("Prrofile.HousingPanel.menu_btn_settings") }
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

        {showHostelList && (


          <div className={styles.cardList__container}>
            {activeKey === "1" &&
              hotelsActive.map(ht => (
                <HousingPanel_card
                  key={ht.id}
                  id={ht.id}
                  title={ht.title}
                  imgSrc={ht.imgSrc}
                  date={ht.date}
                  price={ht.price}
                  onClick={() => console.log(ht.id)}
                  setShowForm={setShowForm}
                  setShowHostelList={setShowHostelList}
                  setShowHostelId={setShowHostelId}

                />
              ))
            }
            <HousingPanel_card_empty />
          </div>
        )}
        {showForm && (
          <HostPropertyForm />

        )}





      </div>
    </div >
  );
};
