import { useTranslation } from "react-i18next";
import { useState, useContext, useEffect } from "react";

import { useLanguage } from "../../contexts/LanguageContext.jsx";
import { Booking_card_row } from "./Booking_card_row";
import { ApiContext } from "../../contexts/ApiContext.jsx";
import { Text } from "../UI/Text/Text";

import styles from "./BookingComponent.module.css";


const paramList = [
    "1 кімната",
    "1 двоспальне ліжко",
    "ванна кімната"
];


export const BookingComponent = ({
    hotel,
    offer,
    startDate,
    endDate,
    adults,
    children
}) => {
    const { t } = useTranslation();
    const { orderApi } = useContext(ApiContext);
    const { language } = useLanguage();
    const [orders, setOrders] = useState([]);


    useEffect(() => {
        document.body.style.cursor = "wait";

        orderApi.getByOfferId(offer.id, language)
            .then(res => {
                setOrders(res.data);
                console.log({ Orders: res.data });
            })
            .catch(err => console.error("Error loading offers:", err))
            .finally(() => {
                document.body.style.cursor = "default";
            });

    }, [language]);



    if (!offer) return null;

    return (
        <div className={styles.hotel_info_card}>
            <div className={styles.hotel_info_card_container}>
                <div className={styles.line}></div>
                <div className={styles.card_wrapper}>

                    <div className={styles.card_header}>
                        <div className={styles.headerRow}>
                            <Text text={t("Host.booking.apartment")} type="m_500" />
                        </div>
                        <div className={styles.headerRow}>
                            <Text text={t("Host.booking.user")} type="m_500" />
                        </div>
                        <div className={styles.headerRow}>
                            <Text text={t("Host.booking.Status")} type="m_500" />
                        </div>


                    </div>
                    <div className={styles.booking_card_row}>
                        {orders.map(order => (
                            <Booking_card_row
                                order={order}
                                offerTitle={offer.title}
                            />
                        ))}
                    </div>

                </div>
                <div className={styles.line}></div>
            </div>

        </div >

    );
};
