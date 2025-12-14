import styles from "./HotelHeader.module.css";
import { PrimaryButton } from "../UI/Button/PrimaryButton";
import {IconButton} from "../UI/Button/IconButton";
import { FiHeart } from "react-icons/fi";

export const HotelHeader = ({ hotel, offer, onClick }) => {
    if (!hotel) return null;
    return (
        <div className={styles.header}>
            <div className={styles.left}>
                
               
                <h1 className={styles.title}>{offer.title}</h1>

             
                {/* {hotel.rating && (
                    <div className={styles.ratingBlock}>
                        <span className={styles.ratingScore}>{hotel.rating}</span>
                        <span className={styles.ratingText}>
                            {hotel.reviewsCount} отзывов
                        </span>
                    </div>
                )} */}

                
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
                    <IconButton icon={<FiHeart />} onClick={() => console.log("Сохранить")}   title="Сохранить" />
                    <PrimaryButton text={"Забронировать"}  onClick={onClick}/>
                    
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
