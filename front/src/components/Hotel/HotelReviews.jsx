import { useTranslation } from "react-i18next";
import React, { useContext, useState, useEffect } from "react";
import { ApiContext } from "../../contexts/ApiContext.jsx";
import { useLanguage } from "../../contexts/LanguageContext";
import { HotelReviews_comment_card } from "./HotelReviews_comment_card.jsx";
import { HotelReviews_grade_card } from "./HotelReviews_grade_card";
import { Text } from "../UI/Text/Text";
import { IconSvg } from "../UI/Image/IconSvg.jsx";
import { ActionButton__Primary } from "../UI/Button/ActionButton_Primary.jsx";
import { ReviewsModal } from "../modals/ReviewsModal.jsx";


import styles from "./HotelReviews.module.css";

export const HotelReviews = ({
    offerId,
    showBtn = false,
    orderId
}) => {
    const { t } = useTranslation();
    const { reviewApi } = useContext(ApiContext);
    const { language } = useLanguage();
    const [reviews, setReviews] = useState([]);
    const [openReviewsModal, setOpenReviewsModal] = useState(false);

    const hasReviews = reviews.length > 0;


    const fetchReviews = () => {
        document.body.style.cursor = "wait";

        reviewApi.getByOfferId(offerId, language)
            .then(res => {
                setReviews(res.data || []);
                console.log({ Reviews: res.data });
            })
            .catch(err => console.error(err))
            .finally(() => {
                document.body.style.cursor = "default";
            });
    };


    useEffect(() => {
        fetchReviews();
    }, [language]);


    const getAverage = (key) => {
        if (!reviews.length) return 0;

        const sum = reviews.reduce((acc, item) => acc + (item[key] || 0), 0);
        return (sum / reviews.length).toFixed(2);
    };

    const overallAverage = getAverage("overallRating");

    const reviewsList = [
        { id: 1, title: "Prrofile.PastHotel.reviews.overall_rating", grade: overallAverage || "9.1" },
        { id: 2, title: "Prrofile.PastHotel.reviews.staff", grade: getAverage("staff") || "9.1" },
        { id: 3, title: "Prrofile.PastHotel.reviews.cleanliness", grade: getAverage("cleanliness") || "9.2" },
        { id: 4, title: "Prrofile.PastHotel.reviews.comfort", grade: getAverage("comfort") || "9.2" },
        { id: 5, title: "Prrofile.PastHotel.reviews.location", grade: getAverage("location") || "8.8" },
        { id: 6, title: "Prrofile.PastHotel.reviews.value_for_money", grade: getAverage("valueForMoney") || "9.6" },
        { id: 7, title: "Prrofile.PastHotel.reviews.amenities", grade: getAverage("facilities") || "8.9" },

    ];


    return (
        <div className={styles.hotelReviews}>
            {!hasReviews && (
                <div className={styles.no_reviews}>
                    <Text
                        text={t("reviews_modal.no_reviews") || "Еще нет отзывов"}
                        type="m_600_s_32"
                    />

                    {showBtn && (
                        <ActionButton__Primary
                            text={t("Prrofile.PastHotel.reviews.btn_add_reviews")}
                            className="btn-w-276 btn-h-59 btn-br-r-20"
                            onClick={() => setOpenReviewsModal(true)}
                        />
                    )}
                </div>
            )}

            {hasReviews && (
                <>
                    <div className={styles.hotelReviews_container}>
                        <div className={styles.hotelReviews_container__titleWrapper}>
                            <Text
                                text={`${overallAverage ?? "9.00"}`}
                                type="m_600_s_64"
                            />
                            <IconSvg name="star_reviews" size="50" />
                        </div>
                        <div className={styles.hotelReviews_container__deckWrapper}>
                            <Text
                                text={t("reviews.overall_rating")}
                                type="m_700_s_40"
                            />
                        </div>
                    </div>

                    <div className={styles.grade_list__container}>
                        {reviewsList
                            .filter(review => review.id !== 1)
                            .map(reviewItem => (
                                <HotelReviews_grade_card
                                    key={reviewItem.id}
                                    title={reviewItem.title}
                                    grade={reviewItem.grade}
                                />
                            ))}
                    </div>
                </>
            )}
            <div className={styles.comment_list__container}>
                {hasReviews && (
                    <div className={styles.comment_list__grid}>
                        {reviews.map(comment => (
                            <HotelReviews_comment_card
                                key={comment.id}
                                name={comment.userName}
                                coment={comment.title}
                                grade={comment.overallRating?.toFixed(2) ?? "0.00"}
                            />
                        ))}
                    </div>
                )}

                {showBtn && (
                    <div className={styles.comment_list__btn}>
                        <ActionButton__Primary
                            text={t("Prrofile.PastHotel.reviews.btn_add_reviews")}
                            className="btn-w-276 btn-h-59 btn-br-r-20"
                            onClick={() => setOpenReviewsModal(true)}
                        />
                    </div>
                )}
            </div>

            {openReviewsModal && (
                <div className="modalOverlay">
                    <ReviewsModal
                        orderId={orderId}
                        offerId={offerId}
                        setOpenReviewsModal={setOpenReviewsModal}
                        refreshReviews={fetchReviews}
                    />
                </div>
            )}
        </div>
    );
};