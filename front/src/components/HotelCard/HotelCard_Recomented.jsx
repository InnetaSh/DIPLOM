import { useNavigate } from "react-router-dom";
import { useTranslation } from "react-i18next";

import styles from "./HotelCard_Recomented.module.css";
import { Text } from "../UI/Text/Text.jsx";
import { Link } from "../UI/Text/Link.jsx";
import { StarIcon } from "./StarIcon.jsx";
import { Image } from "../UI/Image/Image.jsx";



export const HotelCard_Recomented = ({
    id,
    cityId,
    title,
    city,
    country,
    image,
    rating,
    onClick,
}) => {
    const navigate = useNavigate();

    const handleClick = () => {
        const today = new Date();
        const tomorrow = new Date(today);
        tomorrow.setDate(today.getDate() + 1);

        const formatDate = (date) =>
            date.toISOString().split("T")[0];

        const startDate = formatDate(today);
        const endDate = formatDate(tomorrow);
        const adults = 1;
        const children = 0;

        navigate(
            `/hotel/${id}?cityId=${cityId}&checkin=${startDate}&checkout=${endDate}&adults=${adults}&children=${children}`
        );
    };

    return (
        <div
            onClick={handleClick}
             className={styles.card}
            role="button"
            tabIndex={0}
            onKeyDown={(e) => {
                if (e.key === "Enter" || e.key === " ") {
                    e.preventDefault(); 
                    handleClick();
                }
            }}
        >

            <div className={`${styles.card__imageWrapper}`}>
                <Image src={image} alt={title} type="card" />
            </div>
            <div className={styles.card__container}>
                <div className="flex-center btn-w-full bht-h-full">
                    <Text text={title} type="m_700_s_24" />
                </div>
                <div className={styles.card__details}>
                    <div className={`${styles.right_margin} flex-left`}>
                        <Text text={rating} type="m_400_s_14" />
                        <StarIcon className={styles.star} />
                    </div>
                    <Link text={city} to={`/country/${country}/${city}`} type="m_400_s_14" />
                </div>

            </div>
        </div>
    );
};
