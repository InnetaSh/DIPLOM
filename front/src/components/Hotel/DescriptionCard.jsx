import { useNavigate } from "react-router-dom";
import styles from "./HotelCard.module.css";
import { Text } from "../UI/Text/Text.jsx";
import { PrimaryButton } from "../UI/Button/PrimaryButton.jsx";

import { FaHeart, FaCity, FaEye, FaThumbsUp } from "react-icons/fa";

export const DescriptionCard = ({ hotel, onCheckAvailability }) => {
    const navigate = useNavigate();

    if (!hotel) return null;

    const {
        description,
        nights,
        advantages = [],
        apartmentFeatures = [],
        totalprice,
    } = hotel;

    return (
        <div className={styles.card}>
            <div className={styles.card__content}>

       
                <div className={styles.card__info}>
                    <div className={styles.card__hotelTitle}>
                        <Text text={description || "Описание временно недоступно"} type="middle" />
                    </div>
                </div>

            
                <div className={styles.card__booking}>
                    <div className={styles.card__priceBlock}>

                        <Text
                            text="Преимущества этого варианта"
                            type="bold"
                        />

                       
                        {nights && (
                            <div className={styles.optionRow}>
                                <FaThumbsUp className={styles.icon} />
                                <Text
                                    text={`Идеально подходит, чтобы остановиться на ${nights} ночей`}
                                    type="small"
                                />
                            </div>
                        )}

                
                        {advantages.length > 0 && (
                            <div className={styles.optionColumn}>
                                {advantages.map((adv, i) => (
                                    <div key={i} className={styles.optionRow}>
                                        <FaHeart className={styles.icon} />
                                        <Text text={adv} type="small" />
                                    </div>
                                ))}
                            </div>
                        )}

                       
                        {apartmentFeatures.length > 0 && (
                            <div className={styles.optionColumn}>
                                <Text text="В апартаментах:" type="bold" />

                                {apartmentFeatures.map((ft, i) => (
                                    <div key={i} className={styles.optionRow}>
                                        <FaCity className={styles.icon} />
                                        <Text text={ft} type="small" />
                                    </div>
                                ))}
                            </div>
                        )}

                       
                        <PrimaryButton
                            onClick={onCheckAvailability}
                            disabled={!totalprice}
                        >
                            Забронировать
                        </PrimaryButton>

                    </div>
                </div>
            </div>
        </div>
    );
};
