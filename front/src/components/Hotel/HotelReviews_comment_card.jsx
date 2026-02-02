import React, { useRef } from "react";
import { Text } from "../UI/Text/Text.jsx";
import { IconSvg } from "../UI/Image/IconSvg.jsx";
import { useTranslation } from "react-i18next";

import styles from "./HotelReviews.module.css";

// 🎨 Цвета для аватара
const COLORS = ["#A73FA0", "#3A3996", "#B23033", "#378A48"];


const shuffleArray = (array) => [...array].sort(() => Math.random() - 0.5);

const getStarsCount = (grade) => {
    if (!grade) return 0;
    return Math.ceil(Number(grade) / 2);
};

export const HotelReviews_comment_card = ({ name, coment, grade }) => {
    const { t } = useTranslation();

    const colorsRef = useRef(shuffleArray(COLORS));
    const indexRef = useRef(0);

    const getNextColor = () => {
        if (indexRef.current >= colorsRef.current.length) {
            colorsRef.current = shuffleArray(COLORS);
            indexRef.current = 0;
        }
        return colorsRef.current[indexRef.current++];
    };

    const avatarColor = getNextColor();
    const filledStars = getStarsCount(grade);

    return (
        <div className={`${styles.comment_card} btn-br-r-20`}>
            <div className={styles.comment_card_container}>
                <div className="flex-left gap-20">
                    <div
                        className={styles.comment_card__title_icon}
                        style={{ backgroundColor: avatarColor }}
                    >
                        <Text
                            text={name ? name.charAt(0).toUpperCase() : ""}
                            type="m_600_s_24"
                        />
                    </div>

                    <div className={`${styles.comment_card__title_name} flex-left-column`}>
                        <Text text={name} type="m_700_s_24" />

                        <div className={styles.stars}>
                            {Array.from({ length: 5 }).map((_, index) => (
                                <IconSvg
                                    key={index}
                                    src={
                                        index < filledStars
                                            ? "/img/icon/orange_star.svg"
                                            : "/img/icon/grey_star.svg"
                                    }
                                    alt="star"
                                    size="16"
                                />
                            ))}
                        </div>
                    </div>
                </div>


                <div className={`${styles.comment_card_comment}`}>
                    <p className="text_m_500">{coment}</p>
                </div>


            </div>

           
        </div>
    );
};
