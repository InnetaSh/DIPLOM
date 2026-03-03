import React, { useState, useEffect, useRef, useContext } from 'react';
import { useTranslation } from "react-i18next";

import { Link } from 'react-router-dom';
import { useLanguage } from "../../contexts/LanguageContext";
import { ThemeContext } from "../../contexts/ThemeContext";
import { CityCard__Popular } from './CityCard__Popular.jsx';
import { Text } from '../UI/Text/Text.jsx';
import { IconButtonArrow } from '../UI/Button/IconButton_arrow.jsx';
import { ApiContext } from "../../contexts/ApiContext.jsx";

import styles from './CityCard_carousel.module.css';

const citiesListMock = [
  { id: 1, slug: 'kyiv', title: 'Київ', imageSrc: "/img/city/Kyiv.svg" },
  { id: 2, slug: 'odesa', title: 'Одеса', imageSrc: "/img/city/Odesa.svg" },
  { id: 3, slug: 'lviv', title: 'Львів', imageSrc: "/img/city/Lviv.svg" },
  { id: 4, slug: 'bukovel', title: 'Буковель', imageSrc: "/img/city/Bukovel.svg" },
  { id: 5, slug: 'kyiv', title: 'Київ', imageSrc: "/img/city/Kyiv.svg" },
  { id: 6, slug: 'odesa', title: 'Одеса', imageSrc: "/img/city/Odesa.svg" },
  { id: 7, slug: 'lviv', title: 'Львів', imageSrc: "/img/city/Lviv.svg" },
  { id: 8, slug: 'bukovel', title: 'Буковель', imageSrc: "/img/city/Bukovel.svg" },
];

const TEN_MINUTES = 1 * 60 * 1000; // 10 минут в мс

export const CityCard_carousel = () => {
  const { locationApi } = useContext(ApiContext);
  const { darkMode } = useContext(ThemeContext);
  const viewportRef = useRef(null);
  const { language } = useLanguage();
  const { t } = useTranslation();

  const CARD_WIDTH = 425;
  const GAP = 20;

  const [index, setIndex] = useState(0);
  const [visibleCount, setVisibleCount] = useState(3);
  const [withTransition, setWithTransition] = useState(true);
  const [citiesList, setCitiesList] = useState([]);

  // useEffect(() => {
  //   const loadOffers = async () => {
  //     try {
  //       const res = await locationApi.getPopularCities("week", 10, language);
  //       setCitiesList(res.data);
  //       console.log("Ответ setCitiesList:", res.data);
  //       console.log("Данные:", res.data);
  //     } catch (error) {
  //       console.warn("API недоступен, используется mock");
  //       setCitiesList(citiesListMock);
  //     }
  //   };

  //   loadOffers();
  // }, [language]);


  useEffect(() => {
    const loadCities = async () => {
      try {
        const res = await locationApi.getPopularCities("week", 10, language);
        setCitiesList(res.data);
        localStorage.setItem("popularCities", JSON.stringify(res.data));
        localStorage.setItem("popularCitiesTimestamp", Date.now().toString());
        console.log("Данные обновлены из API:", res.data);
      } catch (error) {
        console.warn("API недоступен, используем mock");
        setCitiesList(citiesListMock);
      }
    };

    const cachedData = localStorage.getItem("popularCities");
    const timestamp = Number(localStorage.getItem("popularCitiesTimestamp") || 0);

    if (cachedData && Date.now() - timestamp < TEN_MINUTES) {
      setCitiesList(JSON.parse(cachedData));
      console.log("Данные загружены из кэша:", JSON.parse(cachedData));
    } else {
      loadCities();
    }


    const interval = setInterval(() => {
      loadCities();
    }, TEN_MINUTES);

    return () => clearInterval(interval);
  }, [language]);



  useEffect(() => {
    const handleResize = () => {
      if (!viewportRef.current) return;
      const width = viewportRef.current.offsetWidth;

      const maxCount = Math.floor(
        (width + CARD_WIDTH / 2) / (CARD_WIDTH + GAP)
      );

      setVisibleCount(Math.max(maxCount, 1));

      setWithTransition(false);
      requestAnimationFrame(() => setWithTransition(true));
    };

    handleResize();
    window.addEventListener('resize', handleResize);
    return () => window.removeEventListener('resize', handleResize);
  }, []);


  const extendedList = [
    ...citiesList.slice(-visibleCount),
    ...citiesList,
    ...citiesList.slice(0, visibleCount),
  ];


  useEffect(() => {
    if (index >= citiesList.length) {
      setTimeout(() => {
        setWithTransition(false);
        setIndex(0);
      }, 400);
    }

    if (index < 0) {
      setTimeout(() => {
        setWithTransition(false);
        setIndex(citiesList.length - 1);
      }, 400);
    }
  }, [index]);


  useEffect(() => {
    const interval = setInterval(() => {
      setIndex(prev => prev + 1);
    }, 5000);

    return () => clearInterval(interval);
  }, []);


  const getOffset = () => {
    const centerIndex = index + visibleCount;
    const viewportWidth = viewportRef.current?.offsetWidth || 0;
    const leftPadding = viewportWidth / 2 - CARD_WIDTH / 2;

    return centerIndex * (CARD_WIDTH + GAP) - leftPadding;
  };

  const classNameArrowLeft = darkMode
    ? "btn_arrow_left_dark"
    : "btn_arrow_left_light";

  const classNameArrowRight = darkMode
    ? "btn_arrow_right_dark"
    : "btn_arrow_right_light";

  return (
    <div className={styles.cityCard_carousel}>
      <div className={styles.cityCard_carousel_btn_container}>
        <IconButtonArrow
          onClick={() => setIndex(prev => prev - 1)}
          className={classNameArrowLeft}
        />
        <Text
          text={t("header.popular_cities")}
          type="title"
        />
        <IconButtonArrow
          onClick={() => setIndex(prev => prev + 1)}
          className={classNameArrowRight}
        />
      </div>

      <div className={styles.carouselViewport} ref={viewportRef}>
        <div
          className={styles.cityList}
          style={{
            transform: `translateX(-${getOffset()}px)`,
            transition: withTransition ? 'transform 0.4s ease' : 'none',
            gap: `${GAP}px`,
          }}
        >
          {extendedList.length > 0 ? (
            extendedList.map((city, i) => {
              const cityPath = `/city/${city.id}-${city.slug.toLowerCase()}`;
              return (
                <Link
                  key={`${city.id}-${i}`}
                  to={cityPath}
                  className={styles.cardLink}
                  style={{ width: CARD_WIDTH, flexShrink: 0 }}
                >
                  <CityCard__Popular
                    imageSrc={city.imageUrl_Main}
                    title={city.title}
                  />
                </Link>
              );
            })
          ) : (
            <div>Данные о городах недоступны</div>
          )}

        </div>
      </div>
    </div>
  );
};
