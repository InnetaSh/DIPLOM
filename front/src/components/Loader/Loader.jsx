import React, { useEffect, useState } from "react";
import { useTranslation } from "react-i18next";
import { Text } from "../UI/Text/Text.jsx";
import styles from "./Loader.module.css";



export const Loader = ({ status }) => {
    const { t } = useTranslation();
    const [showCheck, setShowCheck] = useState(false);
    const [showConfirmImage, setShowConfirmImage] = useState(false);

    useEffect(() => {
        if (status === "success" || status === "confirm") {
            setShowCheck(false);
            setShowConfirmImage(false);

            const checkTimeout = setTimeout(() => {
                setShowCheck(true);
            }, 700);

            const imageTimeout = setTimeout(() => {
                if (status === "confirm") {
                    setShowConfirmImage(true);
                }
            }, 1000);

            return () => {
                clearTimeout(checkTimeout);
                clearTimeout(imageTimeout);
            };
        } else {
            setShowCheck(false);
            setShowConfirmImage(false);
        }
    }, [status]);




    return (
        <div className={styles.anim_container}>
            {/* SVG goo-фильтр — ОДИН раз */}

            <svg xmlns="http://www.w3.org/2000/svg" style={{ display: "none" }}>
                <defs>
                    <filter id="goo">
                        <feGaussianBlur in="SourceGraphic" stdDeviation="10" result="blur" />
                        <feColorMatrix
                            in="blur"
                            mode="matrix"
                            values="1 0 0 0 0
                      0 1 0 0 0
                      0 0 1 0 0
                      0 0 0 21 -7"
                            result="goo"
                        />
                        <feBlend in="SourceGraphic" in2="goo" />
                    </filter>
                </defs>
            </svg>


            <div
                className={`${styles.confirmImage} ${showConfirmImage ? styles.active : ""}`}
                aria-hidden="true"
            >
                <div className={styles.overlay} />
                <div className={styles.confirmText}>

                    <div className={`${styles.success_msg}`}>
                        <Text text={t("Booking.success_message")} type="m_400_s_24" />
                    </div>
                </div>
            </div>

            <div
                className={`
          ${styles.loader}
          ${status === "success" ? styles.success : ""}
          ${status === "confirm" ? styles.confirm : ""}
        `}
                aria-live="polite"
                aria-busy={status === "loading"}
            >
                <div className={styles.balls}>
                    {[...Array(8)].map((_, i) => (
                        <div
                            key={i}
                            className={styles.loader__ball}
                            style={{
                                animation:
                                    status === "success"
                                        ? `${styles[`flyIn${i + 1}`]} 1.0s forwards ease-in-out ${i * 60}ms`
                                        : status === "confirm"
                                            ? `translate(0,0) scale(0.03)`
                                            : "none",
                            }}

                        />
                    ))}
                    <div
                        className={styles.loader__big_ball}
                        style={{
                            animation:
                                status === "loading"
                                    ? `${styles.bigBallAnim} 2.7s linear infinite`
                                    : "none",
                            transform:
                                status === "success"
                                    ? "translate(0,0) scale(0.7)"
                                    : status === "confirm"
                                        ? "translate(0,0) scale(0.01)"
                                        : undefined,
                            opacity:
                                status === "success"
                                    ? 0
                                    : 1,
                            transition:
                                status === "success" || status === "confirm"
                                    ? "transform 420ms cubic-bezier(.2,.9,.1,1), opacity 420ms ease"
                                    : undefined,
                        }}

                    />
                </div>


                {showCheck && (
                    // <svg className={styles.check} viewBox="0 0 52 52" aria-hidden="true">
                    //     <path d="M14 27 L22 35 L38 18" />
                    // </svg>
                    <div className={styles.check}>

                    </div>
                )}
            </div>
        </div>
    );
};
