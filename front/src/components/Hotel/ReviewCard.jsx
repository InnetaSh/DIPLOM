import styles from "./Review.module.css";
import { Text } from "../UI/Text/Text.jsx";
import { Link } from "../UI/Text/Link.jsx";
import { RatingBreakdown } from "./RatingBreakdown.jsx"

export const ReviewCard = ({ hotel }) => {
    if (!hotel) return null;

    const rating = hotel.rating || 0;
    const reviews = hotel.reviews || [];

    const getRatingLabel = (rating) => {
        if (rating >= 9) return "Потрясающе";
        if (rating >= 8.5) return "Отлично";
        if (rating >= 8) return "Очень хорошо";
        if (rating >= 7) return "Хорошо";
        return "Нормально";
    };

    const ratingLabel = getRatingLabel(rating);

    return (
        <div>
            <div className={styles.review}>

                <Text text="Отзывы гостей" type="bold" />

                <div className={styles.topRow}>
                    <div className={styles.ratingIcon}>{rating}</div>

                    <div className={styles.ratingTextBlock}>
                        <Text text={ratingLabel} type="bold" />

                        <Link
                            text={`${reviews.length} отзывов`}
                            type="grey_link"
                        />
                    </div>
                </div>

                <Link text="Читать все отзывы" type="link" />
            </div>
            <RatingBreakdown categories = {hotel}/>
        </div>
    );
};
