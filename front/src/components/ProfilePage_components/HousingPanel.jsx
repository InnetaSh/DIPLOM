import { useState, useContext, useEffect } from "react";
import { useTranslation } from "react-i18next";
import { useNavigate } from "react-router-dom";
import { AuthContext } from "../../contexts/AuthContext.jsx";
import { ApiContext } from "../../contexts/ApiContext.jsx";
import { useLanguage } from "../../contexts/LanguageContext.jsx";


import { HousingPanel_card } from "./HousingPanel_card.jsx";
import { ReviewsComponent } from "./ReviewsComponent.jsx";
import { BookingComponent } from "./BookingComponent.jsx";
import { HousingPanel_card_empty } from "./HousingPanel_card_empty.jsx";
import { Text } from "../UI/Text/Text.jsx"
import { StateButton_Profile_OrangOnHover } from "../UI/Button/StateButton_Profile_OrangOnHover.jsx";
import { HostPropertyForm } from "./HostPropertyForm.jsx";
import styles from './HousingPanel.module.css';


export const HousingPanel = ({ pendingOfferIds }) => {
  const { t } = useTranslation();
  const { getMyOffers } = useContext(AuthContext);
  const { userApi } = useContext(ApiContext);
  const navigate = useNavigate();
  const { language } = useLanguage();

  const [activeKey, setActiveKey] = useState("1");
  const [showHostelList, setShowHostelList] = useState(true);
  const [view, setView] = useState("list");

  const [selectedOffer, setSelectedOffer] = useState([]);

  const [myOffers, setMyOffers] = useState([]);

  const [update, setUpdate] = useState(0);



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



  useEffect(() => {
    document.body.style.cursor = "wait";

    userApi.getMyOffers(language)
      .then(res => {
        setMyOffers(res.data);
        console.log({ MyOffers: res.data });
      })
      .catch(err => console.error("Error loading offers:", err))
      .finally(() => {
        document.body.style.cursor = "default";
      });

  }, [language, view, update]);



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
              onClick={() => {
                setActiveKey(btn.id)
                setView("list");

                //  setSelectedOffer(offer);
              }}
            />
          ))}

        </div>

        {view === "list" && showHostelList && (
          <div className={styles.cardList__container}>
            {activeKey === "1" &&
              myOffers.map(ht => {
                const hasPending = pendingOfferIds.includes(ht.id);

                return (
                  <HousingPanel_card
                    key={ht.id}
                    id={ht.id}
                    title={ht.title}
                    imgSrc={ht.rentObj?.[0]?.images?.[0]?.url}
                    hasPending={hasPending} 
                    onAction={(action, offer) => {
                      setSelectedOffer(ht);
                      setView(action);
                      console.log(action);
                      console.log("selectedOffer");
                      console.log(selectedOffer);
                    }}
                  />
                );
              })
            }
            <HousingPanel_card_empty
              onClick={() => {
                setView("edit")
                setShowHostelList(false)
                console.log("HousingPanel_card_empty")
              }}
            />
          </div>
        )}
        {view === "edit" && selectedOffer && (
          <HostPropertyForm
            hotel={selectedOffer}
            setView={setView}
            setActiveKey={setActiveKey}
            setShowHostelList={setShowHostelList}
            update={update}
            setUpdate={setUpdate} />
        )}

        {view === "reviews" && (
          <ReviewsComponent offer={selectedOffer} />
        )}

        {view === "booking" && (
          <BookingComponent offer={selectedOffer} />
        )}
      </div>
    </div >
  );
};
