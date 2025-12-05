import React, { useState, useEffect, useContext } from "react";
import { Header } from "../../components/Header/Header.jsx";
import { useParams } from "react-router-dom";
import styles from "./HotelPage.module.css";
import { ApiContext } from "../../contexts/ApiContext.jsx";
import { HotelSectionNav } from "../../components/Hotel/HotelSectionNav.jsx";
import { Breadcrumbs } from "../../components/UI/Text/BreadcrumbsLinks.jsx";
import { HotelHeader } from "../../components/Hotel/HotelHeader.jsx";
import { HotelGallery } from "../../components/Hotel/HotelGallery.jsx";
import { HotelSidebar } from "../../components/Hotel/HotelSidebar.jsx";
import { HotelParamsList } from "../../components/Hotel/HotelParamsList.jsx";
import { BookingCard } from "../../components/Hotel/BookingCard.jsx"
import { DescriptionCard } from "../../components/Hotel/DescriptionCard.jsx";
import {BookingApartmentCard} from"../../components/Hotel/BookingApartmentCard.jsx";

import "../../styles/globals.css";

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
    console.log("HotelPage loaded with ID:", id);
    const { locationApi, offerApi, rentObjApi } = useContext(ApiContext);

    const [hotel, setHotel] = useState({});
    const [offer, setOffer] = useState({});
    const [country, setCountry] = useState("");
    const [city, setCity] = useState("");
    const [region, setRegion] = useState("");
    const [district, setDistrict] = useState("");



    useEffect(() => {
        if (!offerApi) return;

        offerApi.getById(id)
            .then((res) => {
                setOffer(res.data);
                console.log("Loaded offer data:", res.data);
            })
            .catch((err) => console.error("Error loading offer:", err));
    }, [id, offerApi]);


    useEffect(() => {
        if (!rentObjApi || !offer?.rentObj?.id) return;

        rentObjApi.getById(offer.rentObj.id)
            .then((res) => {
                setHotel(res.data);
                console.log("Loaded rent object data:", res.data);
            })
            .catch((err) => console.error("Error loading rent object:", err));
    }, [offer, rentObjApi]);



    useEffect(() => {
        if (!hotel || !hotel.countryId) return;

        locationApi.getLocationTitles({
            countryId: hotel.countryId,
            regionId: hotel.regionId,
            cityId: hotel.cityId,
            districtId: hotel.districtId
        })
            .then((res) => {
                setCountry(res.data.countryTitle);
                setRegion(res.data.regionTitle);
                setCity(res.data.cityTitle);
                setDistrict(res.data.districtTitle);
            })
            .catch((err) => console.error("Error loading titles:", err));
    }, [hotel]);


    const handleSearchResults = (foundHotels, onSearchCity) => {
        console.log("Search results received:", foundHotels, onSearchCity);
    };

    return (
        <div className="search-page">
            <Header onSearchResults={handleSearchResults} />

            <main className="hotel-page__content">
                <Breadcrumbs country={country} region={region} city={city} district={district} last_path={`Предложения для ${hotel?.title || ""}`} />
                <HotelSectionNav sections={sections} />

                <HotelHeader hotel={hotel} />



                <div className="hotel-page__layout">
                    <section className="hotel-page__photo">
                        <HotelGallery images={hotel?.images || []} />
                    </section>

                    <aside className="hotel-page__info">
                        <HotelSidebar
                            hotel={hotel}
                            reviews={hotel?.reviews || []}
                        />
                    </aside>
                </div>

                <HotelParamsList
                    params={hotel?.paramValues || []}
                />
                <BookingCard hotel={hotel} offer={offer} />
                <DescriptionCard hotel={hotel} />
                <BookingApartmentCard hotel={hotel} offer={offer} />
            </main>
        </div>
    );
};
