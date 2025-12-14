import React, { useState, useEffect, useContext } from "react";
import { Header } from "../../components/Header/Header.jsx";
import { useParams, useLocation } from "react-router-dom";
import styles from "./HotelPage.module.css";
import { ApiContext } from "../../contexts/ApiContext.jsx";
import { HotelSectionNav } from "../../components/Hotel/HotelSectionNav.jsx";
import { Breadcrumbs } from "../../components/UI/Text/BreadcrumbsLinks.jsx";
import { HotelHeader } from "../../components/Hotel/HotelHeader.jsx";
import { HotelGallery } from "../../components/Hotel/HotelGallery.jsx";
import { HotelSidebar } from "../../components/Hotel/HotelSidebar.jsx";
import { BookingCard } from "../../components/Hotel/BookingCard.jsx";
import { DescriptionCard } from "../../components/Hotel/DescriptionCard.jsx";
import { BookingApartmentCard } from "../../components/Hotel/BookingApartmentCard.jsx";

import { useNavigate } from "react-router-dom";
import { useTranslation } from "react-i18next";

export const HotelPage = () => {
  const navigate = useNavigate();
  const { t } = useTranslation();

  const handleClickBooking = () => {
    navigate(`/bookingdetails/${id}?checkin=${startDate}&checkout=${endDate}&guests=${guests}`, {
      state: {
        hotel,
        offer
      }
    });
  }

const sections = [
  { id: "overview", label: t("hotel.sections.overview") },
  { id: "prices", label: t("hotel.sections.prices") },
  { id: "services", label: t("hotel.sections.services") },
  { id: "conditions", label: t("hotel.sections.conditions") },
  { id: "important", label: t("hotel.sections.important") },
  { id: "reviews", label: t("hotel.sections.reviews") },
];


  const { id } = useParams();
  const location = useLocation();
  const queryParams = new URLSearchParams(location.search);

  const startDate = queryParams.get("checkin");
  const endDate = queryParams.get("checkout");
  const guests = queryParams.get("guests");

  const { offerApi } = useContext(ApiContext);

  const [hotel, setHotel] = useState({});
  const [offer, setOffer] = useState({});
  const [images, setImages] = useState([]);
  const [paramValues, setParamValues] = useState([]);

  useEffect(() => {
    if (!offerApi) return;
    if (!id) return;
    offerApi
      .searchId({
        id,
        cityId: id,
        startDate,
        endDate,
        guests,
        userDiscountPercent: 5,
      })
      .then((res) => {
        const data = res.data[0];
        setOffer(data);
        setHotel(data.rentObj[0]);
        setImages(data.rentObj[0]?.imagesUrl || []);
        setParamValues(data.rentObj[0]?.paramValues || []);
        console.log("Loaded offer data:", res.data[0]);
        console.log("Loaded offer rentObj:",
          res.data[0].rentObj[0]);
        console.log("Loaded img rentObj:", res.data[0].rentObj[0].imagesUrl);
        console.log("Loaded param rentObj:", res.data[0].rentObj[0].paramValues);
      })
      .catch((err) => console.error("Error loading offer:", err));
  }, [id, offerApi, startDate, endDate, guests]);

  return (
    <div className="search-page">
      <Header />
      <div>{t("hello")}</div>
      <main className="hotel-page__content">
        <Breadcrumbs
          country={offer.countryTitle}
          region={offer.regionTitle}
          city={offer.cityTitle}
          district={offer.districtTitle}
          last_path={`Предложения для ${offer?.title || ""}`}
        />
        <HotelSectionNav sections={sections} />
        <HotelHeader hotel={hotel} offer={offer} onClick={handleClickBooking} />

        <div className="hotel-page__layout">
          <section className="hotel-page__photo">
            <HotelGallery images={images} />
          </section>

          <aside className="hotel-page__info">
            <HotelSidebar hotel={hotel} reviews={hotel?.reviews || []} />
          </aside>
        </div>

        <div id="services">
          {/* <HotelParamsList params={paramValues} /> */}
        </div>

        <BookingCard hotel={hotel} offer={offer} />
        <DescriptionCard hotel={hotel} />
        <div id="prices">
          <BookingApartmentCard hotel={hotel} offer={offer} />
        </div>
      </main>
    </div>
  );
};
