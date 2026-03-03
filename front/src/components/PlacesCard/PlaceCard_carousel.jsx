import React, { useState, useEffect, useRef, useContext } from 'react';
import { Link } from 'react-router-dom';
import { PlaceCard__Popular } from './PlaceCard__Popular.jsx';
import { IconButtonArrow } from '../UI/Button/IconButton_arrow.jsx';
import styles from './PlaceCard_carousel.module.css';
import { ThemeContext } from "../../contexts/ThemeContext";

export const PlaceCard_carousel = ({ list }) => {
  const viewportRef = useRef(null);
  const { darkMode } = useContext(ThemeContext);

  const CARD_WIDTH = 243;
  const CARD_WIDTH_ACTIVE = 549;
  const GAP = 10;

  const [index, setIndex] = useState(0);
  const [visibleCount, setVisibleCount] = useState(3);
  const [withTransition, setWithTransition] = useState(true);
  const [attractionId, setAttractionId] = useState(null);
  const [slug, setSlug] = useState("");


  useEffect(() => {
    const handleResize = () => {
      if (!viewportRef.current) return;
      const width = viewportRef.current.offsetWidth;

      if (width >= 1760) {
        setVisibleCount(7);
      } else if (width < CARD_WIDTH_ACTIVE + 2 * (CARD_WIDTH + GAP)) {
        setVisibleCount(3);
      } else {
        const maxCount = Math.floor((width + CARD_WIDTH / 2) / (CARD_WIDTH + GAP));
        setVisibleCount(Math.max(maxCount, 3));
      }

      setWithTransition(false);
      requestAnimationFrame(() => setWithTransition(true));
    };

    handleResize();
    window.addEventListener('resize', handleResize);
    return () => window.removeEventListener('resize', handleResize);
  }, []);


  const extendedList = [...list.slice(-visibleCount), ...list, ...list.slice(0, visibleCount)];


  useEffect(() => {
    if (index >= list.length) {
      setTimeout(() => {
        setWithTransition(false);
        setIndex(0);
      }, 400);
    }
    if (index < 0) {
      setTimeout(() => {
        setWithTransition(false);
        setIndex(list.length - 1);
      }, 400);
    }
  }, [index, list.length]);

  useEffect(() => {
    const interval = setInterval(() => setIndex(prev => prev + 1), 15000);
    return () => clearInterval(interval);
  }, []);


  const getOffset = () => {
    const centerIndex = index + visibleCount;
    const viewportWidth = viewportRef.current?.offsetWidth || 0;
    const leftPadding = viewportWidth / 2 - CARD_WIDTH_ACTIVE / 2;
    return centerIndex * (CARD_WIDTH + GAP) - leftPadding;
  };

  return (
    <div className={styles.carousel}>
      <div className={styles.viewport} ref={viewportRef}>
        <div
          className={styles.list}
          style={{
            transform: `translateX(-${getOffset()}px)`,
            transition: withTransition ? 'transform 0.4s ease' : 'none',
            gap: `${GAP}px`,
          }}
        >
          {extendedList.map((item, i) => {
            const centerIndex = index + visibleCount;
            const isActive = i === centerIndex;

            return (
              <Link
                key={`${item.id}-${i}`}
                to={
                  item.slug
                    ? `/attractionDetail/${item.id}-${item.slug.toLowerCase()}`
                    : "#"
                }
                className={`${styles.card} ${isActive ? styles.active : ''}`}
                style={{
                  width: isActive ? CARD_WIDTH_ACTIVE : CARD_WIDTH,
                  flexShrink: 0,
                  transition: 'width 0.3s ease',
                }}
              >
                <PlaceCard__Popular
                  imageSrc={item.imageUrl_Main}
                  title={item.title}
                  variant={isActive ? 'large' : 'default'}
                />
              </Link>
            );

          })}
        </div>
      </div>

      <div className={styles.controls}>
        <IconButtonArrow
          onClick={() => setIndex(prev => prev - 1)}
          className={darkMode ? "btn_arrow_left_dark" : "btn_arrow_left_light"}
        />
        <IconButtonArrow
          onClick={() => setIndex(prev => prev + 1)}
          className={darkMode ? "btn_arrow_right_dark" : "btn_arrow_right_light"}
        />
      </div>
    </div>
  );
};
