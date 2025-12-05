import React from "react";
import styles from "./BookingApartmentCard.module.css";

export const BookingApartmentCard = ({ hotel, offer }) => {
    if (!hotel || !offer) return null;

    return (
        <div className={styles.wrapper}>
            {/* ======= 1. Тип апартаментов ======= */}
            <div className={styles.colType}>
                <div className={styles.headerRow}>
                    <div>Тип апартаментов</div>
                </div>
                <h3 className={styles.title}>{hotel.title}</h3>

                <div className={styles.recommend}>
                    Рекомендованный вариант для {offer.maxGuests} гостей
                </div>

                <div className={styles.details}>
                    <div><b>Спальня:</b> {hotel.bedroomsCount} спальня, {hotel.bedsCount} кровати</div>
                    <div><b>Ванные комнаты:</b> {hotel.bathroomCount}</div>

                    <div className={styles.badges}>
                        <span>Апартаменты целиком</span>
                        <span>{hotel.area} кв. м</span>
                        <span>Этаж: {hotel.floor}/{hotel.totalFloors}</span>
                        {hotel.hasBabyCrib && <span>Детская кроватка</span>}
                    </div>

                    {hotel.paramValues?.length > 0 && (
                        <ul className={styles.params}>
                            {hotel.paramValues.map((p) => (
                                <li key={p.id}>{p.paramItemTitle}</li>
                            ))}
                        </ul>
                    )}
                </div>
            </div>

            {/* ======= 2. Кол-во гостей ======= */}
            <div className={styles.colType}>
                <div className={styles.headerRow}>
                    <div>Число гостей</div>
                </div>
                <div className={styles.colGuests}>
                    <div className={styles.guestsIcons}>
                        {"👤".repeat(offer.maxGuests)}
                    </div>
                </div>
            </div>

            {/* ======= 3. Цена ======= */}
            <div className={styles.colType}>
                <div className={styles.headerRow}>
                    <div>Цена за период</div>
                </div>
                <div className={styles.colPrice}>
                    <div className={styles.price}>
                        UAH {offer.totalPrice?.toLocaleString("uk-UA")}
                    </div>
                    <div className={styles.tax}>
                        + налоги и сборы (UAH {offer.taxAmount ?? 0})
                    </div>
                </div>
            </div>

            {/* ======= 4. Условия ======= */}
            <div className={styles.colType}>
                <div className={styles.headerRow}>
                    <div>На ваш выбор</div>
                </div>
                <div className={styles.colOptions}>
                    <div className={styles.greenText}>
                        ✓ Бесплатная отмена до {new Date().toLocaleDateString("ru-RU")}
                    </div>
                    <div className={styles.smallText}>
                        Вы ничего не платите до {new Date().toLocaleDateString("ru-RU")}
                    </div>
                </div>
            </div>

            {/* ======= 5. Выбор количества ======= */}
            <div className={styles.colType}>
                <div className={styles.headerRow}>
                    <div>Выберите</div>
                </div>
                <div className={styles.colSelect}>
                    <select>
                        <option value="0">0</option>
                        <option value="1">1</option>
                    </select>
                </div>
            </div>

            {/* ======= 6. Бронирование ======= */}
            <div className={styles.colType}>
                <div className={styles.headerRow}>
                    <div></div>
                </div>
                <div className={styles.colBook}>
                    <button className={styles.bookBtn}>Я бронирую</button>
                    <div className={styles.smallText}>Вы пока ничего не платите</div>
                </div>
            </div>
        </div>
    );
};
