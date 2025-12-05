import React from "react";
import styles from "./BookingApartmentTable.module.css";
import { BookingApartmentCard } from "./BookingApartmentCard.jsx";

export const BookingApartmentTable = ({ hotel, offer }) => {
    if (!hotel || !offer) return null;

    return (
        <div className={styles.tableWrapper}>
            {/* ======= СИНИЙ ХЕДЕР ======= */}
            <div className={styles.headerRow}>
                <div>Тип апартаментов</div>
                <div>Число гостей</div>
                <div>Цена за период</div>
                <div>На ваш выбор</div>
                <div>Выберите</div>
                <div></div>
            </div>

            {/* ======= Строка результата ======= */}
            <BookingApartmentCard hotel={hotel} offer={offer} />
        </div>
    );
};
