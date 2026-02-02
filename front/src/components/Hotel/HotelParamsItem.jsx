import { Text } from "../UI/Text/Text";
import styles from "./HotelParamsItem.module.css";

export const HotelParamsItem = ({  title}) => {
    // if (!param) return null;

    return (
        <div className={styles.item}>
            <Text text={title} type="m_400_s_16" />
            {/* <span className={styles.icon}>{param.icon}</span>
            <span className={styles.label}>{param.label}</span> */}
        </div>
    );
};
