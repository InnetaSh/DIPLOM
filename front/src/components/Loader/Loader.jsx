import React from "react";
import styles from "./Loader.module.css";

export const Loader = () => {
    return (
        <>

            <svg xmlns="http://www.w3.org/2000/svg" version="1.1" style={{ display: "none" }}>
                <defs>
                    <filter id="goo">
                        <feGaussianBlur in="SourceGraphic" result="blur" stdDeviation="10"></feGaussianBlur>
                        <feColorMatrix
                            in="blur"
                            mode="matrix"
                            values="1 0 0 0 0 0 1 0 0 0 0 0 1 0 0 0 0 0 21 -7"
                            result="goo"
                        ></feColorMatrix>
                        <feBlend in2="goo" in="SourceGraphic" result="mix"></feBlend>
                    </filter>
                </defs>
            </svg>

            <div className={styles.loader}>
                <div className={styles.loader__ball}></div>
                <div className={styles.loader__ball}></div>
                <div className={styles.loader__ball}></div>
                <div className={styles.loader__ball}></div>
                <div className={styles.loader__ball}></div>
                <div className={styles.loader__ball}></div>
                <div className={styles.loader__ball}></div>
                <div className={styles.loader__ball}></div>
                <div className={styles.loader__big_ball}></div>
            </div>
        </>
    );
};


