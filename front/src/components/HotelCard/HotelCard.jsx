import { useNavigate } from "react-router-dom";
import { useTranslation } from "react-i18next";

import styles from "./HotelCard.module.css";
import { Text } from "../UI/Text/Text.jsx";
import { Link } from "../UI/Text/Link.jsx";
import { StarIcon } from "./StarIcon.jsx";
import { Image } from "../UI/Image/Image.jsx";
import { IconButton_isFavoritest } from "../UI/Button/IconButton_isFavoritest.jsx";


export const HotelCard = ({
    id,
    title,
    image,
    city,
    cityId,
    country,
    distance,
    rating,
    reviews,
    price,
    startDate,
    endDate,
    adults,
    myHistoryIdList,
    showHeart = true,
    children
}) => {
    const navigate = useNavigate();

    const handleClick = () => {
        navigate(`/hotel/${id}?cityId=${cityId}&checkin=${startDate}&checkout=${endDate}&adults=${adults}&children=${children}`);
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
            {showHeart &&
                <IconButton_isFavoritest hotelId={id} myHistoryIdList={myHistoryIdList} />
            }

            <div className={`${styles.card__imageWrapper} btn-br-r-20 `}>
                <Image src={image} alt={title} type="card" />
            </div>


            <div className={styles.card__container}>
                <Text text={title} type="m_700_s_24" />

                <div className={styles.card__params}>
                    <Text text=" • Кухня" type="m_400_s_14 " />
                    <Text text="• Кухня" type="m_400_s_14 " />
                </div>
                <div className={styles.line}></div>


                <div className={styles.card__details}>
                    <div className={styles.card__details_column}>
                        <div className="flex-center">
                            <div className={styles.right_margin}>
                                <Text text={rating} type="m_400_s_14" />
                            </div>

                            <StarIcon className={styles.star} />
                            {/* <Text text={`${reviews} відгуків`} type="m_400_s_14" /> */}
                        </div>


                        <Link text={city} to={`/country/${country}/${city}`} type="m_400_s_14" />

                    </div>
                    <div className={styles.card__details_column}>
                        <Text text={`${adults + children} ${t("hotel.guestCount")}`} type="m_400_s_14" />
                        <div className="flex-left">
                            <div className={styles.right_margin}>
                                <Text text={t("hotel.from")} type="m_400_s_14" />
                            </div>
                            <Text text={`UAH ${price}`} type="m_700_s_24" />
                        </div>

                    </div>
                </div>



            </div>
        </div>
    );
};
