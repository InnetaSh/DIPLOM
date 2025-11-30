import React, { useState, useEffect, useContext } from "react";
import { Header } from "../../components/Header.jsx";
import { useParams } from "react-router-dom";
import styles from "./HotelPage.module.css";
import { ApiContext } from "../../contexts/ApiContext.jsx";



export const HotelPage = () => {
    const { id } = useParams(); 
      const { paramsCategoryApi, offerApi } = useContext(ApiContext); 
   const [filtersData, setFiltersData] = useState([]); 

     useEffect(() => {
    paramsCategoryApi.getAll()
        .then((res) => {
            setFiltersData(res.data);
            console.log("Filters loaded:", res.data);
        })
        .catch((err) => console.error("Error loading filters:", err));
}, [paramsCategoryApi]);


  const handleSearchResults = (foundHotels, onSearchCity) => {
    console.log("Search results received in HomePage:", foundHotels, onSearchCity);
  
  };


    return (
        <div className="search-page">
            <Header onSearchResults={handleSearchResults} />

            <div className={styles.hotelPage}>
                <h1>Страница отеля</h1>
                <p>Отель ID: {id}</p>

                <div className={styles.hotelDetails}>
                    <p>Здесь можно вывести все данные отеля для теста.</p>
                    <ul>
                        <li>Название: Примерный отель {id}</li>
                        <li>Город: Тестовый город</li>
                        <li>Страна: Тестовая страна</li>
                        <li>Цена за ночь: 5000₽</li>
                        <li>Рейтинг: 4.5</li>
                        <li>Отзывы: 23</li>
                    </ul>
                </div>
            </div>
        </div>
    );
};
