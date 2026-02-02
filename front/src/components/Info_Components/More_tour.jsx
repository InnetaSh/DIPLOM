import { useNavigate } from "react-router-dom";
import { useTranslation } from "react-i18next";
import { More_tour_card } from "./More_tour_card.jsx";
import { Text } from "../UI/Text/Text.jsx";
import { Logo_Oselya_64 } from "../Logo/Logo_Oselya_64.jsx";

import styles from "./More_tour.module.css";

const info_tour = [
    {
        id: 1,
        textKey: "more_tour.italy",
        imageSrc: "/img/main_page/italy.svg",
        className_Container: `${styles.container_italy}`,
        className_Rotation: `${styles.rotation_italy}`
    },
    {
        id: 2,
        textKey: "more_tour.spain",
        imageSrc: "/img/main_page/spain.svg",
        className_Container: `${styles.container_spain}`,
        className_Rotation: `${styles.rotation_spain}`
    },
    {
        id: 3,
        textKey: "more_tour.poland",
        imageSrc: "/img/main_page/poland.svg",
        className_Container: `${styles.container_poland}`,
        className_Rotation: `${styles.rotation_poland}`
    },
    {
        id: 4,
        textKey: "more_tour.france",
        imageSrc: "/img/main_page/france.svg",
        className_Container: `${styles.container_france}`,
        className_Rotation: `${styles.rotation_france}`
    },
    {
        id: 5,
        textKey: "more_tour.czech_republic",
        imageSrc: "/img/main_page/czech_republic.svg",
        className_Container: `${styles.container_czech_republic}`,
        className_Rotation: `${styles.rotation_czech_republic}`
    },
    {
        id: 6,
        textKey: "more_tour.germany",
        imageSrc: "/img/main_page/germany.svg",
        className_Container: `${styles.container_germany}`,
        className_Rotation: `${styles.rotation_germany}`
    }
];

export const More_tour = () => {
    const navigate = useNavigate();

    const imageSrc = "/img/main_page/info_tour.svg";
    const { t } = useTranslation();

    return (
        <div className={styles.more_tour_outer}>
        <div className={styles.more_tour}>
            <div className={styles.more_tour__container}>
                <div className={styles.imageCard}>

                    <img
                        src={imageSrc}
                        alt="Building"
                        className={styles.image}
                    />

                </div>
                {info_tour.map((tour) => (
                    <More_tour_card
                        key={tour.id}
                        imageSrc={tour.imageSrc}
                        textKey={tour.textKey}
                        className_Rotation={tour.className_Rotation}
                        className_Container={tour.className_Container}
                    />
                ))}
                <div className={styles.title_wrapper}>
                    <Text
                        type="m_700_s_40"
                        text={
                            <span className={styles.title_inner}>
                                <span className={styles.inline_logo}>
                                    <Logo_Oselya_64 />
                                </span>
                                {t("more_tour.title")}
                            </span>
                        }
                    />
                </div>

                <div className={styles.note_wrapper}>
                    <Text
                        text={t("more_tour.note")}
                        type="m_700_s_40"
                        className={styles.note}
                    />
                </div>

            </div>
        </div>
        </div>
    );
};
