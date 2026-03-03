
import { useTranslation } from "react-i18next";
import { Text } from "../UI/Text/Text.jsx";
import { Image } from "../UI/Image/Image.jsx";
import styles from "./PlaceCard__Popular.module.css";

export const PlaceCard__Popular = ({
    title,
    imageSrc,
}) => {
    const { t } = useTranslation();

    const handleClick = () => {
        console.log("CityCard__Popular");
    };

    return (
        <div
            className={styles.card}
            onClick={handleClick}
            role="button"
            tabIndex={0}
            onKeyDown={(e) => {
                if (e.key === "Enter" || e.key === " ") handleClick();
            }}>
            <div className={styles.card_container} >
                <Image src={imageSrc} alt={t(title)} type="card" />
                <div className={styles.blurOverlay}>
                    <Text text={title} type="m_700_s_24" />
                </div>
            </div>

        </div>
    );
};
