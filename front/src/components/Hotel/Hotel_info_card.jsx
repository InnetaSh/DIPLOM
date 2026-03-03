import React from "react";
import { Text } from "../UI/Text/Text.jsx";
import { Link } from "../UI/Text/Link.jsx";
import { ActionButton__Primary } from "../UI/Button/ActionButton_Primary.jsx";
import { Hotel_info_card_row } from "./Hotel_info_card_row.jsx";
import { useTranslation } from "react-i18next";

import styles from "./Hotel_info_card.module.css";

const paramList = [
    "1 кімната",
    "1 двоспальне ліжко",
    "ванна кімната"
];
export const Hotel_info_card = ({
    hotel,
    offer,
    startDate,
    endDate,
    adults,
    children
}) => {
    const { t } = useTranslation();
    if (!hotel || !offer) return null;

    return (
        <div className={styles.hotel_info_card}>
            <div className={styles.hotel_info_card_container}>
                <div className={styles.line}></div>
                <div className={styles.card_wrapper}>

                    <div className={styles.card_header}>
                        <div className={styles.headerRow}>
                            <Text text={t("hotel_info.type_apartment")} type="m_500" />
                        </div>
                        <div className={styles.headerRow}>
                            <Text text={t("hotel_info.max_guest")} type="m_500" />
                        </div>
                        <div className={styles.headerRow}>
                            <Text text={t("hotel_info.price")} type="m_500" />
                        </div>
                        <div className={styles.headerRow}>
                            <Text text={t("hotel_info.apartment")} type="m_500" />
                        </div>
                    </div>
                    <Hotel_info_card_row
                        hotel={hotel}
                        offer={offer}
                        startDate={startDate}
                        endDate={endDate}
                        adults={adults}
                        children={children}
                    />
                        <Hotel_info_card_row
                        hotel={hotel}
                        offer={offer}
                        startDate={startDate}
                        endDate={endDate}
                         adults={adults}
                        children={children}
                    />

                </div>
                <div className={styles.line}></div>
                <div className={styles.footerRow}>
                    <div className={styles.footerLink}>
                        <Link text={t("hotel_info.expand")} href="#" type="m_600_s_32" />
                    </div>

                </div>
            </div>

        </div >

    );
};
