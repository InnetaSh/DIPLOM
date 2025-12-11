import { useNavigate } from "react-router-dom";
import styles from "./HotelCard.module.css";
import { Text } from "../UI/Text/Text.jsx";
import { PrimaryButton } from "../UI/Button/PrimaryButton.jsx";

import { FaBed, FaCouch, FaDoorOpen, FaShower } from "react-icons/fa";
import { MdOutlineBedroomParent } from "react-icons/md";

export const BookingCard = ({ hotel,offer, onCheckAvailability }) => {
    const navigate = useNavigate();

    if (!hotel) return null;

    const {
        type,
        bedroomsCount,
        livingRoomCount,  
        bathroomCount,
        bedsCount,
        freeCancelUntil,
        payLater,
        stars,
        title,
    } = hotel;

const { 
    paymentStatus,
    totalPrice,
    tax,
 } = offer || {};
const taxAmount = tax !== undefined ? (tax * totalPrice) / 100 : 0;
    return (
        <div className={styles.bookingCard}>
            <div className={styles.bookingCard__content}>

                <div className={styles.bookingCard__info}>

                    <div className={styles.card__title}>
                        {stars && <Text text={`${stars}★`} type="middle" />}
                        <Text text={type || "Тип не указан"} type="link" />
                    </div>

                    <div className={styles.card__hotelTitle}>
                        <Text text={title} type="bold" />
                    </div>

                    <div className={styles.card__icons}>
                        {bedroomsCount && (
                            <div className={styles.iconItem}>
                                <FaCouch className={styles.icon} />
                                <Text text={`Спальня:`} type="bold" />
                                 <Text text={` ${bedroomsCount}`} type="small" />
                            </div>
                        )}

                        {livingRoomCount && (
                            <div className={styles.iconItem}>
                                <FaDoorOpen className={styles.icon} />
                                <Text text={`Гостиная: `} type="bold" />
                                 <Text text={`${livingRoomCount}`} type="small" />
                            </div>
                        )}
                        {bedsCount && (
                            <div className={styles.iconItem}>
                                <FaBed className={styles.icon} />
                                <Text text={`Кровать:`} type="bold" />
                                <Text text={` ${bedsCount}`} type="small" />
                            </div>
                        )}
                         {bathroomCount && (
                            <div className={styles.iconItem}>
                                <FaShower className={styles.icon} />
                                <Text text={`Ванная комната:`} type="bold" />
                                <Text text={` ${bathroomCount}`} type="small" />
                            </div>
                        )}
                    </div>

                    {paymentStatus == 0 && (
                        <div className={styles.card__condition}>
                            <Text text="Бесплатная отмена" type="colorBold" />
                            <Text text={`до 00:00`} type="small" />
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
                            text={`₽ ${totalPrice ? totalPrice.toLocaleString() : "—"}`}
                            type="bold"
                        />

                        {tax !== undefined && (
                            <Text
                                text={`+ налоги и сборы (${taxAmount} ₽)`}
                                type="small"
                            />
                        )} 
                        
                        <PrimaryButton
                            onClick={onCheckAvailability}
                            disabled={!totalPrice}
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
