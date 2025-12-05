import styles from "./HotelParamsItem.module.css";

export const HotelParamsItem = ({  title}) => {
    // if (!param) return null;

    return (
        <div className={styles.item}>
            <div>{title}</div>
            {/* <span className={styles.icon}>{param.icon}</span>
            <span className={styles.label}>{param.label}</span> */}
        </div>
    );
};
