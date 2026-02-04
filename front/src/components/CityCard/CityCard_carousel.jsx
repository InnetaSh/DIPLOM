import React, { useState, useEffect, useRef, useContext } from 'react';
import { Link } from 'react-router-dom';
import { ThemeContext } from "../../contexts/ThemeContext";
import { CityCard__Popular } from './CityCard__Popular.jsx';
import { Text } from '../UI/Text/Text.jsx';
import { IconButtonArrow } from '../UI/Button/IconButton_arrow.jsx';
import styles from './CityCard_carousel.module.css';

const cityList = [
  { id: 1, slug: 'kyiv', title: 'Київ', imageSrc: "/img/city/Kyiv.svg" },
  { id: 2, slug: 'odesa', title: 'Одеса', imageSrc: "/img/city/Odesa.svg" },
  { id: 3, slug: 'lviv', title: 'Львів', imageSrc: "/img/city/Lviv.svg" },
  { id: 4, slug: 'bukovel', title: 'Буковель', imageSrc: "/img/city/Bukovel.svg" },
  { id: 5, slug: 'kyiv', title: 'Київ', imageSrc: "/img/city/Kyiv.svg" },
  { id: 6, slug: 'odesa', title: 'Одеса', imageSrc: "/img/city/Odesa.svg" },
  { id: 7, slug: 'lviv', title: 'Львів', imageSrc: "/img/city/Lviv.svg" },
  { id: 8, slug: 'bukovel', title: 'Буковель', imageSrc: "/img/city/Bukovel.svg" },
];

export const CityCard_carousel = () => {
  const { darkMode } = useContext(ThemeContext);
  const viewportRef = useRef(null);

  const CARD_WIDTH = 425;
  const GAP = 20;

  const [index, setIndex] = useState(0);
  const [visibleCount, setVisibleCount] = useState(3);
  const [withTransition, setWithTransition] = useState(true);

  // ===== Resize (аналог PlaceCard) =====
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

  // ===== Extended list =====
  const extendedList = [
    ...cityList.slice(-visibleCount),
    ...cityList,
    ...cityList.slice(0, visibleCount),
  ];

  // ===== Loop correction =====
  useEffect(() => {
    if (index >= cityList.length) {
      setTimeout(() => {
        setWithTransition(false);
        setIndex(0);
      }, 400);
    }

    if (index < 0) {
      setTimeout(() => {
        setWithTransition(false);
        setIndex(cityList.length - 1);
      }, 400);
    }
  }, [index]);

  // ===== Autoplay =====
  useEffect(() => {
    const interval = setInterval(() => {
      setIndex(prev => prev + 1);
    }, 5000);

    return () => clearInterval(interval);
  }, []);

  // ===== Offset (ключевая часть) =====
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
        <Text text="Популярні міста" type="title" />
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
          {extendedList.map((city, i) => (
            <Link
              key={`${city.id}-${i}`}
              to={`/city/${city.slug}`}
              className={styles.cardLink}
              style={{ width: CARD_WIDTH, flexShrink: 0 }}
            >
              <CityCard__Popular
                imageSrc={city.imageSrc}
                title={city.title}
              />
            </Link>
          ))}
        </div>
      </div>
    </div>
  );
};
