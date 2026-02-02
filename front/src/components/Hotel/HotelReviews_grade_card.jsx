import React from "react";
import { Text } from "../UI/Text/Text.jsx";
import { IconSvg } from "../UI/Image/IconSvg.jsx";
import { useTranslation } from "react-i18next";

import styles from "./HotelReviews.module.css";


export const HotelReviews_grade_card = ({ title, grade }) => {
    const { t } = useTranslation();

    return (
        <div className={`${styles.grade_card} btn-br-r-20`}>
            <div className={styles.grade_card_container}>
                <Text text={grade} type="m_600_s_40" />
                <IconSvg name="star_reviews_small" alt="icon" size="35" />
            </div>
            <Text text={t(title)} type="m_500_s_18" />
        </div >
    );
};
