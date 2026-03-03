import React from "react";
import { useNavigate } from "react-router-dom";
import { useState, useContext, useEffect } from "react";
import { ApiContext } from "../../contexts/ApiContext.jsx";
import { Text } from "../UI/Text/Text.jsx";
import { Link } from "../UI/Text/Link.jsx";
import { ActionButton__Primary } from "../UI/Button/ActionButton_Primary.jsx";
import { IconSvg } from "../UI/Image/IconSvg.jsx";
import { useTranslation } from "react-i18next";

import styles from "./BookingComponent.module.css";

const paramList = [
    "1 кімната",
    "1 двоспальне ліжко",
    "ванна кімната"
];
export const Booking_card_row = ({
    offerTitle,
    order,
}) => {
    const { t } = useTranslation();
    const navigate = useNavigate();

    const { orderApi } = useContext(ApiContext);



    const statusText = t(`Host.booking.${order.status}`);
     const isPending = order.status === "Pending";
    return (


        <div className={styles.card_row}>
            <div className={styles.colApartment}>
                <Link text={offerTitle} type="m_600_s_20" />

                <div className="flex-between">
                    <Text text={`${t("hotel_info.max_guest")}: `} type="m_500_s_16" />
                    <Text text={order.adults + order.children} type="m_400_s_14" />
                </div>
                <div className="flex-between">
                    <Text text={`${t("hotel_info.price")}: `} type="m_500_s_16" />
                    <Text text={order.orderPrice} type="m_400_s_14" />
                </div>
                <Text text={`${t("Host.booking.Date")}: `} type="m_500_s_16" />
                <Text
                    text={`${order.startDate.slice(0, 10)} - ${order.endDate.slice(0, 10)}`}
                    type="m_400_s_14"
                />

            </div>
            <div className={styles.colApartment}>
                <div className={styles.guestsIcons}>
                    <Text text={order.mainGuestFirstName} type="m_600_s_20" />
                    <Text text={order.mainGuestLastName} type="m_600_s_20" />
                    <Text text={order.clientEmail} type="m_400_s_14" />
                    <Text text={order.clientPhoneNumber} type="m_400_s_14" />
                </div>
            </div>

            <div className={styles.colApartment}>
                <div className={styles.status_wrapper}>
                   
                    <Text text={statusText} type="m_400_s_14" />
                     {isPending && <span className={styles.status_warning}>!</span>}
                </div>
            </div>
            <div className={`${styles.colApartment} ${styles.colBtn}`}>
                <div className={styles.col_btn_container}>
                    <ActionButton__Primary
                        text={t("hotel_info.more_btn")}
                        type="m_500_s_16"
                        className={`light_color_btn btn-w-full btn-h-39 btn-br-r-10`}
                        onClick={() => { }} />
                    <ActionButton__Primary
                        text={t("Host.booking.confirm_order")}
                        type="m_500_s_16"
                        className="btn-w-full btn-h-39 btn-br-r-10"
                        onClick={() =>
                            orderApi.updateStateOrder(order.id, "Confirmed")
                        }
                    />

                </div>
            </div>

        </div>



    );
};
