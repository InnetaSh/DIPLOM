
import React, { useState, useContext, useEffect } from "react";
import { useTranslation } from "react-i18next";
import { ApiContext } from "../../contexts/ApiContext.jsx";
import { useLanguage } from "../../contexts/LanguageContext";
import { Text } from "../UI/Text/Text.jsx";
import { ImageSvg } from "../UI/Image/ImageSvg.jsx";
import { HotelCardList } from "../../components/HotelCard/HotelCardList.jsx";
import { Spinner } from "../../components/UI/Spinner.jsx";
import { IconButton_SearchRound } from "../UI/Button/IconButton_SearchRound.jsx";

import styles from './AdminInfoPanel.module.css';

export const AdminInfoPanel = ({ type = "users" }) => {
  const { t } = useTranslation();
  const { adminApi } = useContext(ApiContext);
  const { language } = useLanguage();

  const [hotels, setHotels] = useState([]);
  const [users, setUsers] = useState([]);
  const [loadingHotels, setLoadingHotels] = useState(false);
  const [loadingUsers, setLoadingUsers] = useState(false);


  const mockHotels = [
    {
      id: 1,
      title: "Готель Сонячний",
      rentObj: [
        {
          mainImageUrl: "/img/hotel_ref/1.jpg",
          cityId: 101,
        },
      ],
      country: "Україна",
      cityTitle: "Київ",
      distanceToCenter: 2.5,
      rating: 4.7,
      reviews: 124,
      totalPrice: 1500,
    },
    {
      id: 2,
      title: "Готель Морський Бриз",
      rentObj: [
        {
          mainImageUrl: "/img/hotel_ref/2.jpg",
          cityId: 102,
        },
      ],
      country: "Україна",
      cityTitle: "Одеса",
      distanceToCenter: 1.2,
      rating: 4.3,
      reviews: 98,
      totalPrice: 1800,
    },
    {
      id: 3,
      title: "Готель Гірський Вітер",
      rentObj: [
        {
          mainImageUrl: "/img/hotel_ref/3.jpg",
          cityId: 103,
        },
      ],
      country: "Україна",
      cityTitle: "Буковель",
      distanceToCenter: 0.5,
      rating: 4.9,
      reviews: 210,
      totalPrice: 2200,
    },
    {
      id: 4,
      title: "Готель Львівський Романтик",
      rentObj: [
        {
          mainImageUrl: "/img/hotel_ref/4.jpg",
          cityId: 104,
        },
      ],
      country: "Україна",
      cityTitle: "Львів",
      distanceToCenter: 0.8,
      rating: 4.6,
      reviews: 76,
      totalPrice: 1300,
    },
  ];


  useEffect(() => {

    const fetchHotels = async () => {
      setLoadingHotels(true);
      try {
        const response = await adminApi.getOffers(
          language
        );
        setHotels(response.data);
        console.log(" загрузка hotels:");
        console.log(response.data);
      } catch (error) {
        console.error("Ошибка загрузки hotels:", error);
        setHotels(mockHotels);
      } finally {
        setLoadingHotels(false);
      }
    };
    fetchHotels();
  }, [language]);


  useEffect(() => {
    const fetchHotels = async () => {
      setLoadingUsers(true);
      try {
        const response = await adminApi.getUsers(
          language
        );
        setUsers(response.data);
        console.log(" загрузка users:");
        console.log(response.data);
      } catch (error) {
        console.error("Ошибка загрузки users:", error);
      } finally {
        setLoadingUsers(false);
      }
    };
    fetchHotels();
  }, [language]);



  return (
    <div className={styles.userInfoPanel}>
      <div className={styles.userInfoPanel_header}>
        <div className={styles.userInfoPanel_title_container}>
          <div className={`${styles.userInfoPanel_title} flex-center`}>
            {type === "users" && (
              <Text text={t("admin.menu.users")} type="m_700_s_32" />
            )}
            {type === "hotels" && (
              <Text text={t("admin.menu.offers")} type="m_700_s_32" />
            )}
          </div>
          <div className={`${styles.userInfoPanel_line} flex-center`}>
            <div className={`${styles.line_wrapper} gap-12`}>
              <div className={`${styles.line} ${styles.left} `}>
                <div className={`${styles.circle_left} ${styles.circle}`}></div>
                <div className={`${styles.circle_right} ${styles.circle}`}></div>
              </div>
            </div>
          </div>
        </div>
        <div className={styles.userInfoPanel_input}>
          <div className={`${styles.input_container} btn-h-60 btn-w-full btn-br-r-20`}>
            <input
              type="text"
              name="login"
              placeholder={t("admin.input_label")}
              className={`${styles.input} btn-h-60  p-10`}
              required
            />
            <IconButton_SearchRound
              classTitle={styles.search_btn}
            />
          </div>

          <div className={styles.btn_white}>
            <ImageSvg src="/img/icon/sortBtn.svg" />
            <Text text={t("admin.sort_btn")} type="m_600_s_24" />
          </div>
        </div>
      </div>

      {type === "users" && (
        loadingUsers ? (
          <Spinner loading={true} />
        ) : (
          <div className={styles.list__user_info} >
            {users?.map((user) => (
              <div key={user.id} className={styles.list_item}>
                <div className={styles.list_left}>
                  <Text text={user.username} type="m_700_s_24" />
                  <Text text={user.countryTitle || "—"} type="m_500_s_20" />
                  <div>
                    <Text text={user.phoneNumber || "—"} type="m_500_s_16" />
                    <Text text={user.email} type="m_500_s_16" />
                  </div>
                </div>

                <div className={styles.list_right}>
                  <div className={styles.btn_green}>
                    <ImageSvg src="/img/icon/sms.svg" />
                    <Text text={t("admin.write")} type="m_500_s_16" />
                  </div>

                  <div className={styles.btn_red}>
                    <ImageSvg src="/img/icon/blocked.svg" />
                    <Text text={t("admin.blocked")} type="m_500_s_16" />
                  </div>
                </div>
              </div>
            ))}

          </div>
        )
      )}

      {
        type === "hotels" && (
          loadingHotels ? (
            <Spinner loading={true} />
          ) : (
            <div className={styles.list__hotel_info}>
              <HotelCardList
                hotels={hotels}
                adults={1}
                children={0}
                startDate={new Date("2026-03-01")}
                endDate={new Date("2026-03-05")}
                showHeart={false}
              />
            </div>
          ))
      }


    </div >
  );
};
