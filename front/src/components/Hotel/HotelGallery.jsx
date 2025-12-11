import styles from "./HotelGallery.module.css";

export const HotelGallery = ({ images = [] }) => {
    if (!images.length) return <div>Нет изображений</div>;

    const first = images[0];
    const rest = images.slice(1);

    return (
        <div className={styles.gallery}>
            <div className={styles.row1Dynamic}>
                <img src={first} alt="" className={styles.big} />
                {rest.length >= 2 && (
                    <div className={styles.smallColumn}>
                        {rest.slice(0, 2).map((src, i) => (
                            <img key={i} src={src} alt="" className={styles.small} />
                        ))}
                    </div>
                )}
            </div>

            {rest.length > 2 && (
                <div className={styles.row2Dynamic}>
                    {rest.slice(2).map((src, i) => (
                        <img key={i} src={src} alt="" className={styles.gridImg} />
                    ))}
                </div>
            )}

        </div>
    );
};
