import React, { useState, useEffect, useContext } from "react";
import { Header } from "../../components/Header.jsx";
import { useParams } from "react-router-dom";
import styles from "./HotelPage.module.css";
import { ApiContext } from "../../contexts/ApiContext.jsx";
import { HotelSectionNav } from "../../components/Hotel/HotelSectionNav.jsx";
import { Breadcrumbs } from "../../components/UI/Text/BreadcrumbsLinks.jsx";
import { HotelHeader } from "../../components/Hotel/HotelHeader.jsx";
import { HotelSidebar } from "../../components/Hotel/HotelSidebar.jsx";
import {HotelParamsList} from "../../components/Hotel/HotelParamsList.jsx";
import {BookingCard} from "../../components/Hotel/BookingCard.jsx"

export const HotelPage = () => {
    const sections = [
        { id: "overview", label: "Обзор" },
        { id: "prices", label: "Информация о стоимости" },
        { id: "services", label: "Удобства и услуги" },
        { id: "conditions", label: "Условия размещения" },
        { id: "important", label: "Важно знать" },
        { id: "reviews", label: "Отзывы" },
    ];

    const { id } = useParams();
    const { paramsCategoryApi, offerApi } = useContext(ApiContext);

    const [hotel, setHotel] = useState({});

    useEffect(() => {
        offerApi.getById(id)
            .then((res) => {
                setHotel(res.data);
                console.log("Hotel loaded:", res.data);
            })
            .catch((err) => console.error("Error loading hotel:", err));
    }, [id, offerApi]);

    const handleSearchResults = (foundHotels, onSearchCity) => {
        console.log("Search results received:", foundHotels, onSearchCity);
    };

    return (
        <div className="search-page">
            <Header onSearchResults={handleSearchResults} />

            <main className="hotel-page__content">
                <Breadcrumbs last_path={`Отель: ${hotel?.title || ""}`} />
                <HotelSectionNav sections={sections} />

                <HotelHeader hotel={hotel} />

                <div className="hotel-page__layout">
                    <section className="hotel-page__photo">
                        <h1>Страница отеля</h1>
                        <p>Отель ID: {id}</p>
                    </section>

                    <aside className="hotel-page__info">
                        <HotelSidebar
                            hotel={hotel}
                            reviews={hotel?.rentobj?.reviews || []}
                        />
                    </aside>
                </div>

                <HotelParamsList
                    params={hotel?.rentobj?.rentobjparamvalue || []}
                />

            </main>
        </div>
    );
};
