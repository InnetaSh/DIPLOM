import React, { useState } from "react";
import styles from "./ReviewList.module.css";
import { Text } from "../UI/Text/Text.jsx";
import { LinkTextItem } from "../UI/Text/Link.jsx";

// Можно подключить любую SVG
import { ReactComponent as UserIcon } from "../../assets/icons/user.svg";

export const ReviewList = ({ reviews = [] }) => {
    const latestReviews = reviews.slice(-3).reverse();
    const [expanded, setExpanded] = useState(null);

    const trimText = (text, wordLimit = 20) => {
        const words = text.split(" ");
        if (words.length <= wordLimit) return text;
        return words.slice(0, wordLimit).join(" ") + "...";
    };

    return (
        <div className={styles.wrapper}>
            <Text
                text="Что понравилось гостям, которые здесь проживали"
                type="bold"
            />

            <div className={styles.reviewContainer}>
                {latestReviews.map((item, index) => {
                    const isOpen = expanded === index;

                    return (
                        <div className={styles.reviewCard} key={index}>
                            {/* Шапка отзыва */}
                            <div className={styles.header}>
                                <div className={styles.userIcon}>
                                    <UserIcon />
                                </div>

                                <div className={styles.userInfo}>
                                    <Text text={item.userName} type="bold" />
                                    <Text text={item.country} type="small" />
                                </div>
                            </div>

                            {/* Текст отзыва */}
                            <div className={styles.textBlock}>
                                <Text
                                    text={
                                        isOpen
                                            ? item.text
                                            : trimText(item.text, 20)
                                    }
                                    type="middle"
                                />
                            </div>

                            {/* Подробнее / скрыть */}
                            {!isOpen && item.text.split(" ").length > 20 && (
                                <LinkTextItem
                                    text="Подробнее..."
                                    type="link"
                                    onClick={() => setExpanded(index)}
                                />
                            )}

                            {isOpen && (
                                <LinkTextItem
                                    text="Скрыть"
                                    type="link"
                                    onClick={() => setExpanded(null)}
                                />
                            )}
                        </div>
                    );
                })}
            </div>
        </div>
    );
};
