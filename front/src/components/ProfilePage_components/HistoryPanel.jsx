import { useState, useEffect, useRef, useContext } from "react";
import { ApiContext } from "../../contexts/ApiContext.jsx";
import { useTranslation } from "react-i18next";
import { ThemeContext } from "../../contexts/ThemeContext";
import { useLanguage } from "../../contexts/LanguageContext";

import { History_card } from "./History_card.jsx";
import { MyTravelsPanel_card_empty } from "./MyTravelsPanel_card_empty.jsx";
import { IconButtonArrow } from "../UI/Button/IconButton_arrow.jsx";

import styles from "./HistoryPanel.module.css";

export const HistoryPanel = ({ isHistoryPanel }) => {
  const { t } = useTranslation();
  const { userApi } = useContext(ApiContext);
  const { language } = useLanguage();
  const { darkMode } = useContext(ThemeContext);

  const [index, setIndex] = useState(0);
  const [activeKey, setActiveKey] = useState("1");
  const [myHistory, setMyHistory] = useState([]);
  const [columnWidth, setColumnWidth] = useState(0);

  const viewportRef = useRef(null);
  const [columns, setColumns] = useState(3);


  useEffect(() => {
    const calculateLayout = () => {
      if (!viewportRef.current) return;

      const screenWidth = window.innerWidth;
      const totalWidth = viewportRef.current.offsetWidth;
      const gap = 20;

      let cols;
      if (screenWidth < 1550) {
        cols = 1;
      } else if (screenWidth < 1830) {
        cols = 2;
      } else {
        cols = 3;
      }
      setColumns(cols);

      const width = (totalWidth - gap * (cols - 1)) / cols;
      setColumnWidth(width + gap);
    };

    calculateLayout();
    window.addEventListener("resize", calculateLayout);

    return () => window.removeEventListener("resize", calculateLayout);
  }, []);

  // useEffect(() => {
  // if (!isHistoryPanel) return;

  // document.body.style.cursor = "wait";

  // let isMounted = true;

  //   userApi
  //     .getMyHistory(language)
  //     .then((res) => {
  //       if (isMounted) setMyHistory(res.data || []);
  //     })
  //     .catch(() => {
  //       if (isMounted) setMyHistory([]);
  //     })
  //     .finally(() => {
  //       if (isMounted) {
  //         document.body.style.cursor = "default";
  //       }
  //     });

  //   return () => {
  //     isMounted = false;
  //     document.body.style.cursor = "default";
  //   };

  // }, [isHistoryPanel, language]);
  // 

  useEffect(() => {
    if (!isHistoryPanel) return;
    setMyHistory(mockHistory);
  }, [isHistoryPanel]);

  const mockHistory = [
    {
      offerId: 1,
      title: "Trip to Paris",
      mainImageUrl: "https://picsum.photos/400/300?random=1",
      IsFavorites: true,
    },
    {
      offerId: 2,
      title: "Weekend in Rome",
      mainImageUrl: "https://picsum.photos/400/300?random=2",
      IsFavorites: false,
    },
    {
      offerId: 3,
      title: "Berlin Adventure",
      mainImageUrl: "https://picsum.photos/400/300?random=3",
      IsFavorites: true,
    },
    {
      offerId: 4,
      title: "Barcelona Escape",
      mainImageUrl: "https://picsum.photos/400/300?random=4",
      IsFavorites: false,
    },
    {
      offerId: 5,
      title: "Amsterdam Lights",
      mainImageUrl: "https://picsum.photos/400/300?random=5",
      IsFavorites: false,
    },
    {
      offerId: 6,
      title: "Prague Old Town",
      mainImageUrl: "https://picsum.photos/400/300?random=6",
      IsFavorites: true,
    },
    {
      offerId: 7,
      title: "Vienna City Break",
      mainImageUrl: "https://picsum.photos/400/300?random=7",
      IsFavorites: false,
    },
  ];

  const displayedHistory =
    activeKey === "2"
      ? myHistory.filter((item) => item.IsFavorites)
      : myHistory;


  // useEffect(() => {
  //   const calculateWidth = () => {
  //     if (!viewportRef.current) return;

  //     const totalWidth = viewportRef.current.offsetWidth;
  //     const gap = 20;
  //     const width = (totalWidth - gap * 2) / 3;

  //     setColumnWidth(width + gap);
  //   };

  //   calculateWidth();
  //   window.addEventListener("resize", calculateWidth);

  //   return () => window.removeEventListener("resize", calculateWidth);
  // }, []);


  const totalColumns = Math.ceil(displayedHistory.length / 2);
  const visibleColumns = columns;
  const maxIndex = Math.max(0, totalColumns - visibleColumns);


  useEffect(() => {
    setIndex(0);
  }, [displayedHistory.length]);


  const handlePrev = () => {
    setIndex((prev) => Math.max(prev - 1, 0));
  };

  const handleNext = () => {
    setIndex((prev) => Math.min(prev + 1, maxIndex));
  };

  const classNameArrowLeft = darkMode
    ? "btn_arrow_left_dark"
    : "btn_arrow_left_light";

  const classNameArrowRight = darkMode
    ? "btn_arrow_right_dark"
    : "btn_arrow_right_light";


  return (
    <div className={styles.historyPanel}>
      <div className={styles.historyPanel__container}>
        <div className={styles.carouselViewport} ref={viewportRef}>
          <div
            className={styles.container_card}
            style={{
              transform: `translateX(-${index * columnWidth}px)`,
              "--column-width": `${columnWidth - 20}px`
            }}
          >
            {displayedHistory.length === 0 ? (
              <MyTravelsPanel_card_empty
                text={
                  activeKey === "2"
                    ? t("Prrofile.no_favorites")
                    : t("Prrofile.no_history")
                }
              />
            ) : (
              displayedHistory.map((ht) => (
                <History_card
                  key={ht.offerId}
                  title={ht.title}
                  imgSrc={ht.mainImageUrl}
                  onClick={() => console.log(ht.title)}
                />
              ))
            )}
          </div>
        </div>

        <div className={styles.carousel_btn_container}>
          <IconButtonArrow
            onClick={handlePrev}
            className={classNameArrowLeft}
            disabled={index === 0}
          />

          <IconButtonArrow
            onClick={handleNext}
            className={classNameArrowRight}
            disabled={index === maxIndex}
          />
        </div>
      </div>
    </div>
  );
};
