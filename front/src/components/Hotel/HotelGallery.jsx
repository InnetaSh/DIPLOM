import styles from "./HotelGallery.module.css";

export const HotelGallery = ({ images }) => {
    if (!images || images.length < 8)
        return <div>Нужно минимум 8 изображений</div>;

    return (
        <div className={styles.gallery}>
            <div className={styles.row1}>
              
                <img src={images[0]} alt="" className={styles.big} />
                <div className={styles.smallColumn}>
                    <img src={images[1]} alt="" className={styles.small} />
                    <img src={images[2]} alt="" className={styles.small} />
                </div>
            </div>

            <div className={styles.row2}>
                {images.slice(3, 8).map((src, i) => (
                    <img key={i} src={src} alt="" className={styles.gridImg} />
                ))}
            </div>
        </div>
    );
};
