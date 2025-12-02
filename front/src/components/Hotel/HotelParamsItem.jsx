import styles from "./HotelParamsItem.module.css";

export const HotelParamsItem = ({ param }) => {
    if (!param) return null;

    return (
        <div className={styles.item}>
            <span className={styles.icon}>{param.icon}</span>
            <span className={styles.label}>{param.label}</span>
        </div>
    );
};
