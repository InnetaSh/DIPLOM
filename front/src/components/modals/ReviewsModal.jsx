import { useState, useContext } from "react";
import { useTranslation } from "react-i18next";
import { ApiContext } from "../../contexts/ApiContext.jsx";
import { useLanguage } from "../../contexts/LanguageContext.jsx";
import { StarRating } from "./StarRating";
import { Text } from "../UI/Text/Text.jsx";
import { ActionButton__Primary } from "../UI/Button/ActionButton_Primary.jsx";
import { IconButtonClose } from "../UI/Button/IconButton_close.jsx";

import styles from "./ReviewsModal.module.css";

export const ReviewsModal = ({
    orderId,
    offerId,
    setOpenReviewsModal,
    refreshReviews
}) => {
    const { t } = useTranslation();
    const { reviewApi } = useContext(ApiContext);
    const { language } = useLanguage();

    const [form, setForm] = useState({
        comment: "",
        staff: 0,
        facilities: 0,
        cleanliness: 0,
        comfort: 0,
        valueForMoney: 0,
        location: 0,
        createdAt: new Date().toISOString(),
        isApproved: true
    });

    const updateField = (field, value) => {
        setForm(prev => ({
            ...prev,
            [field]: value
        }));
    };




//     const checkTextWithAI = async (text) => {
//   try {
//     const response = await fetch("https://api.openai.com/v1/moderations", {
//       method: "POST",
//       headers: {
//         "Content-Type": "application/json",
//         "Authorization": `Bearer ${process.env.REACT_APP_OPENAI_API_KEY}`
//       },
//       body: JSON.stringify({
//         input: text,
//         model: "omni-moderation-latest"
//       })
//     });

//     const result = await response.json();
//     // result.results[0] содержит категории: hate, sexual, violence и т.д.
//     const flagged = result.results[0].flagged;

//     return !flagged; // true если текст безопасный
//   } catch (error) {
//     console.error("AI moderation error:", error);
//     return false; 
//   }
// };


// const handleSubmit = async () => {
//     const text = form.comment;

//     if (!text || text.length < 10) {
//         alert("Отзыв слишком короткий");
//         return;
//     }

//     document.body.style.cursor = "wait";

//     const isSafe = await checkTextWithAI(text);

//     if (!isSafe) {
//         alert("Ваш отзыв содержит недопустимые слова или фразы. Пожалуйста, исправьте его.");
//         document.body.style.cursor = "default";
//         return;
//     }

   
//     reviewApi.createReview({
//         orderId,
//         offerId,
//         formData: form,
//         lang: language
//     })
//       .then(res => {
//         refreshReviews();
//         setOpenReviewsModal(false);
//       })
//       .catch(err => console.error("Error creating review:", err))
//       .finally(() => {
//         document.body.style.cursor = "default";
//       });
// };

    const handleSubmit = () => {
        console.log(form);
        document.body.style.cursor = "wait";

        reviewApi.createReview({
            orderId: orderId,
            offerId: offerId,
            formData: form,
            lang: language
        })
            .then(res => {
                console.log("Review created:", res.data);
                refreshReviews();
                setOpenReviewsModal(false);
            })
            .catch(err => console.error("Error creating review:", err))
            .finally(() => {
                document.body.style.cursor = "default";
            });
    };

    return (
        <div className={styles.reviev_modal}>
            <IconButtonClose
                onClick={() => setOpenReviewsModal(false)}
            />
            <div className={styles.reviev_modal__container}>

                <div className="flex-center btn-w-full">
                    < Text
                        text={t("reviews_modal.leave_review")}
                        type="m_700_s_48"
                    />
                </div>
                <div className="flex-left btn-w-full">
                    < Text
                        text={t("reviews_modal.leave_review")}
                        type="m_600_s_36"
                    />
                </div>
                <div className={styles.container__stars}>
                    <div className={styles.container__stars_item}>
                        < Text
                            text={t("reviews_modal.staff")}
                            type="m_400_s_32"
                        />
                        <StarRating
                            value={form.staff}
                            onChange={(val) => updateField("staff", val)}
                        />
                    </div>

                    <div className={styles.container__stars_item}>
                        < Text
                            text={t("reviews_modal.cleanliness")}
                            type="m_400_s_32"
                        />
                        <StarRating
                            value={form.cleanliness}
                            onChange={(val) => updateField("cleanliness", val)}
                        />
                    </div>

                    <div className={styles.container__stars_item}>
                        < Text
                            text={t("reviews_modal.comfort")}
                            type="m_400_s_32"
                        />
                        <StarRating
                            value={form.comfort}
                            onChange={(val) => updateField("comfort", val)}
                        />
                    </div>

                    <div className={styles.container__stars_item}>
                        < Text
                            text={t("reviews_modal.facilities")}
                            type="m_400_s_32"
                        />
                        <StarRating
                            value={form.facilities}
                            onChange={(val) => updateField("facilities", val)}
                        />
                    </div>

                    <div className={styles.container__stars_item}>
                        < Text
                            text={t("reviews_modal.value_for_money")}
                            type="m_400_s_32"
                        />
                        <StarRating
                            value={form.valueForMoney}
                            onChange={(val) => updateField("valueForMoney", val)}
                        />
                    </div>

                    <div className={styles.container__stars_item}>
                        < Text
                            text={t("reviews_modal.location")}
                            type="m_400_s_32"
                        />
                        <StarRating
                            value={form.location}
                            onChange={(val) => updateField("location", val)}
                        />
                    </div>
                </div>
                <label>
                    <legend className={styles.form__legend} >
                        <Text text={t("reviews_modal.text")} type="m_400_s_24 " />
                    </legend>
                    <textarea
                        name="text"
                        value={form.comment}
                        onChange={(e) =>
                            updateField("comment", e.target.value)
                        }
                        placeholder=""
                        className={`${styles.input} ${styles.textarea} btn-br-r-20 p-10`}
                        rows={7}
                    />
                </label>

                <ActionButton__Primary
                    onClick={handleSubmit}
                    className="btn-w-276 btn-h-70 btn-br-r-20"
                    text={t("reviews_modal.submit")}
                />
            </div>
        </div >
    );
};