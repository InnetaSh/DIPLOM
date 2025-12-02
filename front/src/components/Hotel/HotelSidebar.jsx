import { useMemo } from "react";
import styles from "./HotelSidebar.module.css";

export const HotelSidebar = ({ hotel }) => {

    const getRatingLabel = (rating) => {
        if (rating >= 9) return "Потрясающе";
        if (rating >= 8.5) return "Отлично";
        if (rating >= 8) return "Очень хорошо";
        if (rating >= 7) return "Хорошо";
        return "Нормально";
    };

    const ratingLabel = hotel ? getRatingLabel(hotel.rating) : null;

    const randomReview = useMemo(() => {
        if (!hotel || !hotel.reviews || hotel.reviews.length === 0) return null;
        return hotel.reviews[Math.floor(Math.random() * hotel.reviews.length)];
    }, [hotel]);

    // 🔥 Проверка после вызовов хуков!
    if (!hotel) return null;

    return (
        <aside className={styles.sidebar}>

            <div className={styles.ratingBlock}>
                <div className={styles.score}>{hotel.rating}</div>
                <div className={styles.label}>
                    {ratingLabel}
                    <div className={styles.reviewCount}>
                        {hotel.reviewsCount} отзывов
                    </div>
                </div>
            </div>

            {hotel.highlights && (
                <div className={styles.highlights}>
                    <h4>Популярные удобства</h4>
                    <ul>
                        {hotel.highlights.map((h, i) => (
                            <li key={i}>{h}</li>
                        ))}
                    </ul>
                </div>
            )}

            {randomReview && (
                <div className={styles.reviewBox}>
                    <h4>Отзывы гостей</h4>
                    <div className={styles.reviewText}>
                        “{randomReview.text}”
                    </div>
                    <div className={styles.reviewAuthor}>
                        — {randomReview.author}
                    </div>
                </div>
            )}

            <div className={styles.mapBlock}>
                <h4>Расположение</h4>
                <div className={styles.mapPlaceholder}>
                    Карта (map placeholder)
                </div>
            </div>

        </aside>
    );
};
