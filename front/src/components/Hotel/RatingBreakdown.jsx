import styles from "./RatingBreakdown.module.css";
import { Text } from "../UI/Text/Text.jsx";

export const RatingBreakdown = ({ categories }) => {
    if (!categories || Object.keys(categories).length === 0) return null;

    return (
        <div className={styles.wrapper}>
            <Text text="Оценки по категориям" type="bold" />

            <div className={styles.list}>
                {Object.entries(categories).map(([key, value]) => (
                    <div key={key} className={styles.item}>
                        <span className={styles.label}>{key}</span>

                        <div className={styles.progressWrapper}>
                            <div
                                className={styles.progress}
                                style={{ width: `${(value / 10) * 100}%` }}
                            />
                        </div>

                        <span className={styles.value}>{value.toFixed(1)}</span>
                    </div>
                ))}
            </div>
        </div>
    );
};
