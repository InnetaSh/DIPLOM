import { useNavigate } from "react-router-dom";

import styles from "./HotelCard.module.css";
import { Text } from "../UI/Text/Text.jsx";
import { Link } from "../UI/Text/Link.jsx";
import { PrimaryButton } from "../UI/Button/PrimaryButton.jsx";
import {Image} from "../UI/Image/Image.jsx";

export const HotelCard = ({
    id,
    title,
    image,
    city,
    country,
    distance,
    rating,
    reviews,
    price,
    badges = [],
    onClick,
    onCheckAvailability,
}) => {
     const navigate = useNavigate();

      const handleClick = () => {
        navigate(`/hotel/${id}`);
    };

    return (
         <div 
            className={styles.card} 
            onClick={handleClick} 
            role="button" 
            tabIndex={0} 
            onKeyPress={(e) => {
                if (e.key === 'Enter' || e.key === ' ') handleClick();
            }}
        >

            <div className={styles.card__imageWrapper}>
                <Image src={image} alt={title} type="card" />
            </div>


            <div className={styles.card__content}>

                <div className={styles.card__header}>
                    <Text text={title} type="title" />
                    <div className={styles.card__location}>
                        <Link text={city} to={`/country/${country}/${city}`} type ="link"/>
                        <span> • {distance} км от центра</span>
                    </div>
                </div>


                {badges.length > 0 && (
                    <div className={styles.card__badges}>
                        {badges.map((badge, i) => (
                            <span className={styles.card__badge} key={i}>
                                {badge}
                            </span>
                        ))}
                    </div>
                )}


                <div className={styles.card__details}>
                    <Text text="Апартаменты • Кухня • Завтрак включён" type="small" />
                </div>


                <div className={styles.card__footer}>
                    <div className={styles.card__rating}>
                        <span className={styles.rating__score}>{rating}</span>
                        <span className={styles.rating__text}>{reviews} отзывов</span>
                    </div>

                    <div className={styles.card__priceBlock}>
                        <Text text={`₽ ${price}`} type="bold" />
                        <PrimaryButton onClick={onCheckAvailability}>
                            наличие мест
                        </PrimaryButton>
                    </div>
                </div>
            </div>
        </div>
    );
};
