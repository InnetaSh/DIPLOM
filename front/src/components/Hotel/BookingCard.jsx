import { useNavigate } from "react-router-dom";
import styles from "./HotelCard.module.css";
import { Text } from "../UI/Text/Text.jsx";
import { PrimaryButton } from "../UI/Button/PrimaryButton.jsx";

import { FaBed, FaCouch, FaDoorOpen } from "react-icons/fa";
import { MdOutlineBedroomParent } from "react-icons/md";

export const BookingCard = ({ hotel, onCheckAvailability }) => {
    const navigate = useNavigate();

    if (!hotel) return null;

    const {
        type,
        bedroom,
        livingroom,
        freeCancelUntil,
        payLater,
        totalprice,
        tax,
        stars,
        title,
    } = hotel;

    return (
        <div className={styles.card}>
            <div className={styles.card__content}>

                <div className={styles.card__info}>

                    <div className={styles.card__title}>
                        {stars && <Text text={`${stars}★`} type="middle" />}
                        <Text text={type || "Тип не указан"} type="link" />
                    </div>

                    <div className={styles.card__hotelTitle}>
                        <Text text={title} type="bold" />
                    </div>

                    <div className={styles.card__icons}>
                        {bedroom && (
                            <div className={styles.iconItem}>
                                <MdOutlineBedroomParent className={styles.icon} />
                                <Text text={`Спальня: ${bedroom}`} type="small" />
                            </div>
                        )}

                        {livingroom && (
                            <div className={styles.iconItem}>
                                <FaCouch className={styles.icon} />
                                <Text text={`Гостиная: ${livingroom}`} type="small" />
                            </div>
                        )}
                    </div>

                    {freeCancelUntil && (
                        <div className={styles.card__condition}>
                            <Text text="Бесплатная отмена" type="colorBold" />
                            <Text text={`до ${freeCancelUntil}`} type="small" />
                        </div>
                    )}

                    {payLater && (
                        <div className={styles.card__condition}>
                            <Text text="Вы ничего не платите до" type="small" />
                            <Text text={payLater} type="small" />
                        </div>
                    )}
                </div>

             
                <div className={styles.card__booking}>
                    <div className={styles.card__priceBlock}>
                        
                        <Text
                            text={`₽ ${totalprice ? totalprice.toLocaleString() : "—"}`}
                            type="bold"
                        />

                        {tax !== undefined && (
                            <Text
                                text={`+ налоги и сборы (${tax} ₽)`}
                                type="small"
                            />
                        )} 
                        
                        <PrimaryButton
                            onClick={onCheckAvailability}
                            disabled={!totalprice}
                        >
                            Забронировать
                        </PrimaryButton>

                        <Text
                            text="Вы пока ничего не платите"
                            type="small"
                        />
                    </div>
                </div>
            </div>
        </div>
    );
};
