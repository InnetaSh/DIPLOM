import styles from "./RoomOptionCard.module.css";
import { FaUserFriends, FaCheck, FaBed, FaCouch } from "react-icons/fa";
import { PrimaryButton } from "../UI/Button/PrimaryButton.jsx";
import { Text } from "../UI/Text/Text.jsx";

export const RoomOptionCard = ({ room, onSelect }) => {
    const {
        title,
        recommended,
        guests,
        bedroom,
        livingroom,
        features = [],
        bathroom = [],
        freeCancelUntil,
        payUntil,
        nights,
        price,
        tax,
    } = room;

    return (
        <div className={styles.row}>
          
            <div className={styles.colType}>
                <Text text={title} type="link" />

                {recommended && (
                    <div className={styles.recommended}>
                        Рекомендованный вариант для {recommended}
                    </div>
                )}

                <div className={styles.roomDetails}>
                    {bedroom && (
                        <div className={styles.roomLine}>
                            <FaBed className={styles.icon} />
                            <Text text={`Спальня: ${bedroom}`} type="small" />
                        </div>
                    )}

                    {livingroom && (
                        <div className={styles.roomLine}>
                            <FaCouch className={styles.icon} />
                            <Text text={`Гостиная: ${livingroom}`} type="small" />
                        </div>
                    )}
                </div>

              
                <div className={styles.featuresBlock}>
                    {features.map((feat, i) => (
                        <span key={i} className={styles.featureTag}>
                            {feat.icon} {feat.label}
                        </span>
                    ))}
                </div>

               
                <div className={styles.bathroomBlock}>
                    {bathroom.map((b, i) => (
                        <div key={i} className={styles.checkItem}>
                            <FaCheck className={styles.checkIcon} />
                            <Text text={b} type="small" />
                        </div>
                    ))}
                </div>
            </div>

           
            <div className={styles.colGuests}>
                <FaUserFriends className={styles.guestsIcon} />
                <Text text={`${guests} гостей`} type="small" />
            </div>

           
            <div className={styles.colPrice}>
                <Text text={`₽ ${price.toLocaleString()}`} type="bold" />
                <Text text={`Цена за ${nights} ночи`} type="small" />
                <Text text={`+ налоги и сборы (${tax} ₽)`} type="small" />
            </div>

            
            <div className={styles.colConditions}>
                {freeCancelUntil && (
                    <div className={styles.condition}>
                        <FaCheck className={styles.greenCheck} />
                        <Text
                            text={`Бесплатная отмена до ${freeCancelUntil}`}
                            type="colorBold"
                        />
                    </div>
                )}

                {payUntil && (
                    <div className={styles.condition}>
                        <Text
                            text={`Вы ничего не платите до ${payUntil}`}
                            type="small"
                        />
                    </div>
                )}
            </div>

           
            <div className={styles.colSelect}>
                <select className={styles.select}>
                    <option value="0">0</option>
                    <option value="1">1</option>
                    <option value="2">2</option>
                </select>

                <PrimaryButton onClick={onSelect}>
                    Я бронирую
                </PrimaryButton>

                <Text text="Вы пока ничего не платите" type="small" />
            </div>
        </div>
    );
};
