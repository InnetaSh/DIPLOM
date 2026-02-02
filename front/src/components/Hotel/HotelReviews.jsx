import { useTranslation } from "react-i18next";

import { HotelReviews_comment_card } from "./HotelReviews_comment_card.jsx";
import { HotelReviews_grade_card } from "./HotelReviews_grade_card";
import { Text } from "../UI/Text/Text";
import { IconSvg } from "../UI/Image/IconSvg.jsx";
import { ActionButton__Primary } from "../UI/Button/ActionButton_Primary.jsx";



import styles from "./HotelReviews.module.css";




export const HotelReviews = ({ reviews, comments , showBtn = false}) => {
    const { t } = useTranslation();
    if (!reviews || reviews.length === 0) return null;
    const overallReview = reviews[0];

    return (
        <div className={styles.hotelReviews}>
            <div className={styles.hotelReviews_container} >
                <div className={styles.hotelReviews_container__titleWrapper}>
                    <Text
                        text={`${overallReview?.grade || "9.1"}`}
                        type="m_600_s_64"
                    />
                    <IconSvg name="star_reviews" size="50" />
                </div>
                <div className={styles.hotelReviews_container__deckWrapper}>
                    <Text text={t("reviews.overall_rating")} type="m_700_s_40" />
                </div>
            </div>

            <div className={styles.grade_list__container}>
                {reviews
                    .filter(review => review.id !== 1)
                    .map(review => (
                        <HotelReviews_grade_card
                            key={review.id}
                            title={review.title}
                            grade={review.grade}
                        />
                    ))}
            </div>
            <div className={styles.comment_list__container}>
                {comments
                    .map(comment => (
                        <HotelReviews_comment_card
                            key={comment.id}
                            name={comment.name}
                            coment={comment.review}
                            grade={comment.grade}
                        />
                    ))}
                <div className={styles.comment_list__btn} >
                    <div className="flex-center gap-174 btn-h-full">
                        <ActionButton__Primary
                            text={t("reviews.btn")}
                            className="btn-w-276 btn-h-59 btn-br-r-20"
                        />
                        {showBtn && (
                            <ActionButton__Primary
                                text={t("Prrofile.PastHotel.reviews.btn_add_reviews")}
                                className="btn-w-276 btn-h-59 btn-br-r-20"
                            />
                        )}
                    </div>
                </div>
            </div>

        </div >
    );
};
