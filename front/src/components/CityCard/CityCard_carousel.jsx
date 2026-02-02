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
  { id: 8, slug: 'bukovel', title: 'Буковель', imageSrc: "/img/city/Bukovel.svg" }
];

export const CityCard_carousel = () => {
  const { darkMode } = useContext(ThemeContext);
  const STORAGE_KEY = 'city-carousel-index';

  const classNameArrowLeft = darkMode
    ? "btn_arrow_left_dark"
    : "btn_arrow_left_light";

  const classNameArrowRight = darkMode
    ? "btn_arrow_right_dark"
    : "btn_arrow_right_light";

  const viewportRef = useRef(null);

  const cardWidth = 425;
  const gap = 20;
  const step = cardWidth + gap;

  const [containerWidth, setContainerWidth] = useState(0);
  const [visibleCount, setVisibleCount] = useState(1);
  const [index, setIndex] = useState(() => {
    const saved = sessionStorage.getItem(STORAGE_KEY);
    return saved ? Number(saved) : 1;
  });
  const [withTransition, setWithTransition] = useState(false); // выключаем анимацию при первом рендере

  // ===== Resize =====
  useEffect(() => {
    const updateWidth = () => {
      if (!viewportRef.current) return;
      const width = viewportRef.current.offsetWidth;
      const count = Math.ceil(width / step);

      setContainerWidth(width);
      setVisibleCount(count);

      // безопасное восстановление индекса
      const savedIndex = sessionStorage.getItem(STORAGE_KEY);
      const safeIndex = savedIndex ? Math.max(count, Number(savedIndex)) : count;
      setIndex(safeIndex);

      // сразу включаем плавное перемещение после восстановления
      setWithTransition(false);
      requestAnimationFrame(() => setWithTransition(true));
    };

    updateWidth();
    window.addEventListener('resize', updateWidth);
    return () => window.removeEventListener('resize', updateWidth);
  }, []);

  // ===== Extended list =====
  const extendedList = [
    ...cityList.slice(-visibleCount),
    ...cityList,
    ...cityList.slice(0, visibleCount)
  ];

  // ===== Сохраняем индекс =====
  useEffect(() => {
    sessionStorage.setItem(STORAGE_KEY, index);
  }, [index]);

  // ===== Loop correction =====
  useEffect(() => {
    if (index >= cityList.length + visibleCount) {
      setTimeout(() => {
        setWithTransition(false);
        setIndex(visibleCount);
      }, 400);
    }

    if (index <= 0) {
      setTimeout(() => {
        setWithTransition(false);
        setIndex(cityList.length);
      }, 400);
    }
  }, [index, visibleCount]);

  // ===== Re-enable animation =====
  useEffect(() => {
    if (!withTransition) {
      requestAnimationFrame(() => setWithTransition(true));
    }
  }, [withTransition]);

  // ===== Controls =====
  const handleNext = () => setIndex(prev => prev + 1);
  const handlePrev = () => setIndex(prev => prev - 1);

  // ===== Autoplay =====
  useEffect(() => {
    const interval = setInterval(handleNext, 5000);
    return () => clearInterval(interval);
  }, []);

  const translateX = index * step;

  return (
    <div className={styles.cityCard_carousel}>
      <div className={styles.cityCard_carousel_btn_container}>
        <IconButtonArrow
          onClick={handlePrev}
          className={classNameArrowLeft}
        />
        <Text text="Популярні міста" type="title" />
        <IconButtonArrow
          onClick={handleNext}
          className={classNameArrowRight}
        />
      </div>

      <div className={styles.carouselViewport} ref={viewportRef}>
        <div
          className={styles.cityList}
          style={{
            transform: `translateX(-${translateX}px)`,
            transition: withTransition ? 'transform 0.4s ease' : 'none',
            gap: `${gap}px`
          }}
        >
          {extendedList.map((city, i) => (
            <Link
              key={`${city.id}-${i}`}
              to={`/city/${city.slug}`}
              className={styles.cardLink}
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
