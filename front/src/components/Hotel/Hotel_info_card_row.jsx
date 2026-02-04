import React from "react";
import { useNavigate } from "react-router-dom";
import { Text } from "../UI/Text/Text.jsx";
import { Link } from "../UI/Text/Link.jsx";
import { ActionButton__Primary } from "../UI/Button/ActionButton_Primary.jsx";
import { IconSvg } from "../UI/Image/IconSvg.jsx";
import { useTranslation } from "react-i18next";

import styles from "./Hotel_info_card.module.css";

const paramList = [
    "1 кімната",
    "1 двоспальне ліжко",
    "ванна кімната"
];
export const Hotel_info_card_row = ({ hotel, offer }) => {
    const { t } = useTranslation();
    const navigate = useNavigate();
    if (!hotel || !offer) return null;

    return (


        <div className={styles.card_row}>
            <div className={styles.colApartment}>
                <img src={hotel.image || "/img/hotel_info/hotel_2.jpg"} alt={hotel.title}></img>
            </div>
            <div className={styles.colApartment}>
                <div className={styles.guestsIcons}>
                    <IconSvg name="user" alt="user icon" size="36" />
                    <IconSvg name="user" alt="user icon" size="36" />
                </div>
            </div>

            <div className={styles.colApartment}>
                <div className={styles.colApartment_container}>
                    <div className={styles.old_price}>
                        <span className="diagonalStrike">
                            <Text text="UAH 9 460" type="m_400_s_14" />
                        </span>
                        {/* UAH {offer.totalPrice?.toLocaleString("uk-UA")} */}
                    </div>
                    <div className={styles.new_price}>
                        <Text text="UAH 7 568" type="m_700_s_32" />
                        {/* UAH {offer.totalPrice?.toLocaleString("uk-UA")} */}
                    </div>

                    <div className={styles.tax_info}>
                        <Text text={t("hotel_info.tax")} type="m_400_s_14" />
                    </div>
                    <div className={styles.sale}>
                        <div className={styles.discount}>
                            <Text text="20%" type=" m_500_s_18" />
                        </div>
                        <div className={styles.discount_info}>
                            <Text text={t("hotel_info.sale_promotion")} type="m_500_s_18" />
                        </div>
                    </div>
                </div>
            </div>
            <div className={styles.colApartment}>
                <div className={styles.colApartment_container}>
                    <div className={styles.title}>
                        <Text text={t("hotel_info.deskr")} type="m_600_s_20" />
                    </div>
                    <div className={styles.paramList}>
                        {paramList.map((param, index) => (
                            <div key={index} className={styles.paramItem}>
                                <Text text={param} type="m_400_s_16" />
                            </div>
                        ))}
                    </div>
                </div>
            </div>
            <div className={`${styles.colApartment} ${styles.colBtn}`}>
                <div className={styles.col_btn_container}>
                    <ActionButton__Primary text={t("hotel_info.more_btn")} className={`light_color_btn btn-w-385 btn-h-70 btn-br-r-10`} onClick={() => { }} />
                    <ActionButton__Primary 
                    text={t("hotel_info.booking")}
                     className="btn-w-385 btn-h-70 btn-br-r-10"
                          onClick={() => navigate("/booking")} />
                </div>
            </div>

        </div>



    );
};
