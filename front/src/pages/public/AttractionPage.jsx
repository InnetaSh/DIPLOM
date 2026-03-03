import { useParams } from 'react-router-dom';
import React, { useState, useEffect, useContext } from "react";
import { useTranslation } from "react-i18next";
import { useNavigate } from "react-router-dom";

import { Header_Full } from "../../components/Header/Header_Full.jsx";
import { Footer } from "../../components/Footer/Footer.jsx";
import { IconButton_Search } from "../../components/UI/Button/IconButton_Search.jsx";
import { ApiContext } from "../../contexts/ApiContext.jsx";
import { useLanguage } from "../../contexts/LanguageContext";
import { CitySelector } from "../../components/SearchBar/CitySelector.jsx";


import styles from "./AttractionPage.module.css";

export const AttractionPage = () => {
  const { paramsCategoryApi } = useContext(ApiContext);
  const { language } = useLanguage();
  const navigate = useNavigate();
  const [openCityFilterMenu, setOpenCityFilterMenu] = useState(false);

  const [isModalOpen, setIsModalOpen] = useState(true);

  const [locationId, setLocationId] = useState(null);
  const cityId =  null;
  const cityName = "";
  const [location, setLocation] = useState(cityName);
  const [slug, setSlug] = useState("");

  const lat = 48.8566;
  const lng = 2.3522;
  const { t } = useTranslation();

  useEffect(() => {
    if (cityId) {
      setLocationId(cityId);
      const storedCityName = localStorage.getItem("city");
      if (storedCityName) setLocation(storedCityName);
    }
  }, [cityId]);


  const setLocationInfo = (cityName, cityId,slug) => {
    setLocation(cityName);
    setLocationId(cityId);
    setSlug(slug);
  };


  const handleSearchClick = () => {
    if (!locationId || !slug) return;

  const cityPath = `/attractionByCity/${locationId}-${slug.toLowerCase()}`;
  navigate(cityPath);
  };

  return (
    <div className={styles.attraction_page}>
      <Header_Full titleBtn="city" title={t("attraction.title")} showFilterBtn={false} openFilterMenu={openCityFilterMenu} setOpenFilterMenu={setOpenCityFilterMenu} />

      <main className={styles.attraction_page__content}>
        <section className="container-fluid my-5">
          <div className="row align-items-start g-4">


            <div className="col-lg-5">
              <div
                className="  rounded-4 w-100 d-flex flex-column"
                style={{ gap: "55px" }}
              >
                <div className="mb-3">
                  <div className="mb-3">
                    <div className={`input-group  ${styles.search_form}`}
                      style={{ border: '1px solid #ced4da', borderRadius: '0.375rem' }}>
                      <div
                        className={`${styles.searchBar__wrapper} btn-br-r-10 btn-h-35  flex-center`}
                      >
                        <div className={`form-control border-0`}>
                          <CitySelector
                            value={location}
                            onChange={setLocationInfo}
                            placeholder={t("Search.city")}
                          />
                        </div>
                      </div>

                      <div
                        className={`  ${styles.search_btn}`}
                        type="button"
                        aria-label="search"
                        
                        onClick={handleSearchClick}
                        onMouseEnter={e => e.currentTarget.style.backgroundColor = 'transparent'}  
                        onMouseLeave={e => e.currentTarget.style.backgroundColor = 'transparent'}
                      >
                        <IconButton_Search icon_name="search"  />
                      </div>
                    </div>
                  </div>

                </div>
                <p className="mb-4">
                  Відкривай для себе нові незабутні локації! Пізнавай разом з нами
                  багату історію України та всього світу, подорожуй у кращі місця
                  та знаходь найкраще житло у визначних локаціях.
                </p>

              </div>
            </div>
            <div className="col-lg-7">
              <div style={{
                height: "454px",
                width: "100%",
                overflow: "hidden",
                borderRadius: "20px"
              }}>
                <img
                  src="img/attractions/default.svg"
                  alt="Атракція"
                  style={{
                    width: "100%",
                    height: "100%",
                    objectFit: "cover",
                    display: "block"
                  }}
                />
              </div>
            </div>

          </div>
        </section>
      </main >
      <Footer />


    </div >
  );
};

