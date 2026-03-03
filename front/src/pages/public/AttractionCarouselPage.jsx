import { useParams } from 'react-router-dom';
import React, { useState, useEffect, useContext } from "react";
import { useTranslation } from "react-i18next";

import { useNavigate } from "react-router-dom";
import { Header_Full } from "../../components/Header/Header_Full.jsx";
import { Footer } from "../../components/Footer/Footer.jsx";
import { PlaceCard_carousel } from "../../components/PlacesCard/PlaceCard_carousel.jsx"
import { ApiContext } from "../../contexts/ApiContext.jsx";
import { useLanguage } from "../../contexts/LanguageContext";
import { Spinner } from "../../components/UI/Spinner.jsx";

import styles from "./AttractionCarouselPage.module.css";


export const AttractionCarouselPage = () => {
  const { attractionApi } = useContext(ApiContext);
   const { citySlug } = useParams();

  const [cityId, slug] = citySlug.split('-');

  console.log(cityId);
  console.log(slug);

  const { language } = useLanguage();
  const navigate = useNavigate();
  const [openCityFilterMenu, setOpenCityFilterMenu] = useState(false);
  const [attractions, setAttractions] = useState([]);
  const [loading, setLoading] = useState(true);
  const [isModalOpen, setIsModalOpen] = useState(true);

  
  const { t } = useTranslation();

  useEffect(() => {
    if (!cityId) return;

    setLoading(true);

    attractionApi.getByCity(cityId, language)
      .then((res) => {
        console.log("attractions" );
        console.log(res.data );
        setAttractions(res.data || []);
      })
      .catch((err) => {
        console.error("Error loading attractions:", err);
      })
      .finally(() => {
        setLoading(false);
      });

  }, [cityId, language]);


  return (
    <div className={styles.cityPage}>
      <Header_Full titleBtn="city" title={t("attraction.title")} showFilterBtn={false} openFilterMenu={openCityFilterMenu} setOpenFilterMenu={setOpenCityFilterMenu} />

      <main className={styles.hotel_page__content}>
        {loading ? (
          <Spinner loading={true} />
        ) : (
          <PlaceCard_carousel list={attractions} />
        )}

      </main >
      <Footer />


    </div >
  );
};

