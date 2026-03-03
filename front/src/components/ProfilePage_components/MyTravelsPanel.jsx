import { useState, useEffect, useContext } from "react";
import { ApiContext } from "../../contexts/ApiContext.jsx";
import { useTranslation } from "react-i18next";
import { useLanguage } from "../../contexts/LanguageContext";

import { MyTravelsPanel_card } from "./MyTravelsPanel_card.jsx";
import { MyTravelsPanel_active_card } from "./MyTravelsPanel_active_card.jsx";
import { MyTravelsPanel_card_empty } from "./MyTravelsPanel_card_empty.jsx";
import { Text } from "../UI/Text/Text.jsx"
import { StateButton_Profile_OrangOnHover } from "../UI/Button/StateButton_Profile_OrangOnHover.jsx";
import { Spinner } from "../UI/Spinner.jsx";
import styles from './MyTravelsPanel.module.css';


export const MyTravelsPanel = ({ isActivePanel }) => {
  const { t } = useTranslation();
  const { userApi } = useContext(ApiContext);
  const { language } = useLanguage();
  const [activeKey, setActiveKey] = useState("1");
  const [myTrip, setMyTrip] = useState([]);
  const [loading, setLoading] = useState(false);

  const fetchTrips = () => {
    setLoading(true);
    userApi.getMyTrip(language)
      .then((res) => {
        setMyTrip(res.data);
        console.log(res.data);
      })
      .catch(() => setMyTrip([]))
      .finally(() => setLoading(false));
  };

  useEffect(() => {
    if (!isActivePanel) return;
    fetchTrips();
  }, [isActivePanel, language]);


  const formatDate = (isoString) => {
    if (!isoString) return "";
    const date = new Date(isoString);
    return new Intl.DateTimeFormat(language, { day: "2-digit", month: "2-digit", year: "numeric" }).format(date);
  };


  const activeTrips = myTrip.filter(t => ["Pending", "Confirmed", "Paid"].includes(t.status));
  const pastTrips = myTrip.filter(t => t.status === "Completed");
  const cancelledTrips = myTrip.filter(t => ["Cancelled", "Rejected"].includes(t.status));


  const buttons = [
    { id: "1", text: t("Prrofile.my_travel.active") },
    { id: "2", text: t("Prrofile.my_travel.past") },
    { id: "3", text: t("Prrofile.my_travel.cancelled") },
  ];

  return (
    <div className={styles.myTravelPanel}>
      {loading ? (
        <Spinner loading={true} />
      ) : (

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


          <div className={styles.container_card}>
            {activeKey === "1" &&
              (activeTrips.length === 0 ?
                <MyTravelsPanel_card_empty
                  text={t("Prrofile.no_active_travel")}
                /> :
                activeTrips.map(ht => (
                  <MyTravelsPanel_active_card
                    key={ht.offerId}
                    title={ht.title}
                    imgSrc={ht.mainImageUrl}
                    date={`${formatDate(ht.startDate)} - ${formatDate(ht.endDate)}`}
                    price={ht.totalPrice}
                    onClick={() => console.log(ht.title)}
                  />
                ))
              )
            }

            {activeKey === "2" &&
              (pastTrips.length === 0 ?
                <MyTravelsPanel_card_empty
                  text={t("Prrofile.no_past_travel")}
                /> :
                <div className={styles.container_card}>
                  {pastTrips.map(ht => (
                    <MyTravelsPanel_card
                      key={ht.offerId}
                      title={ht.title}
                      imgSrc={ht.mainImageUrl}
                      offerId={ht.offerId}
                      orderId={ht.orderId}
                      onClick={() => console.log(ht.title)}
                    />
                  ))}
                </div>
              )
            }

            {activeKey === "3" &&
              (cancelledTrips.length === 0 ?
                <MyTravelsPanel_card_empty
                  text={t("Prrofile.no_cancelled_travel")}
                /> :
                <div className={styles.container_card}>
                  {cancelledTrips.map(ht => (
                    <MyTravelsPanel_card
                      key={ht.offerId}
                      title={ht.title}
                      imgSrc={ht.mainImageUrl}
                      tripId={ht.offerId}
                      onClick={() => console.log(ht.title)}
                    />
                  ))}
                </div>
              )
            }


          </div>
        </div>
      )}
    </div >
  );
};
