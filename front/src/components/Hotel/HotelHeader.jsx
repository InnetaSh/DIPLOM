import styles from "./HotelHeader.module.css";

export const HotelHeader = ({ hotel }) => {
    if (!hotel) return null;

    return (
        <div className={styles.header}>
            <div className={styles.left}>
                
               
                <h1 className={styles.title}>{hotel.title}</h1>

             
                {hotel.rating && (
                    <div className={styles.ratingBlock}>
                        <span className={styles.ratingScore}>{hotel.rating}</span>
                        <span className={styles.ratingText}>
                            {hotel.reviewsCount} отзывов
                        </span>
                    </div>
                )}

                
                {hotel.address && (
                    <div className={styles.address}>
                        📍 {hotel.address}
                    </div>
                )}

                
                {hotel.tags && (
                    <div className={styles.tags}>
                        {hotel.tags.map((tag, i) => (
                            <span key={i} className={styles.tag}>
                                {tag}
                            </span>
                        ))}
                    </div>
                )}
            </div>

            <div className={styles.right}>

            
                <div className={styles.actions}>
                    <button className={styles.shareBtn}>Поделиться</button>
                    <button className={styles.saveBtn}>Сохранить</button>
                </div>

              
                {hotel.price && (
                    <div className={styles.priceBlock}>
                        <div className={styles.priceLabel}>Цена за ночь от</div>
                        <div className={styles.priceValue}>{hotel.price} ₽</div>
                        <div className={styles.priceNote}>с учетом налогов и сборов</div>
                    </div>
                )}

            </div>
        </div>
    );
};
