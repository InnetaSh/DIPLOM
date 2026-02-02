import { useNavigate } from "react-router-dom";
import { useTranslation } from "react-i18next";

import styles from "./HotelCard_Recomented.module.css";
import { Text } from "../UI/Text/Text.jsx";
import { Link } from "../UI/Text/Link.jsx";
import { StarIcon } from "./StarIcon.jsx";
import { Image } from "../UI/Image/Image.jsx";


export const HotelCard_Recomented = ({
    id,
    title,
     city,
    country,
    image,
    rating,
    price,
    guests,
    onClick,
    onCheckAvailability,
}) => {
    const navigate = useNavigate();

    const handleClick = () => {
        console.log("recomented");
        // navigate(`/hotel/${id}?checkin=${startDate}&checkout=${endDate}&guests=${guests}`);
    };
    const { t } = useTranslation();

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

            <div className={`${styles.card__imageWrapper}`}>
                <Image src={image} alt={title} type="card" />
            </div>


            <div className={styles.card__container}>
                <Text text={title} type="m_700_s_24" />
                <div className={styles.card__details}>
                    <div className="flex-center">
                        <div className={styles.right_margin}>
                            <Text text={rating} type="m_400_s_14" />
                        </div>

                        <StarIcon className={styles.star} />
                        <Link text={city} to={`/country/${country}/${city}`} type="m_400_s_14" />
                    </div>
                </div>

            </div>
        </div>
    );
};
