import { useParams } from 'react-router-dom';
import React, { useState, useEffect, useContext } from "react";
import { useTranslation } from "react-i18next";

import { useNavigate } from "react-router-dom";
import { Header_Full } from "../../components/Header/Header_Full.jsx";
import { AttractionGallery } from "../../components/AttractionCard/AttractionGallery.jsx";
import { Footer } from "../../components/Footer/Footer.jsx";
import { HotelMap } from "../../components/Hotel/HotelMap.jsx";
import {ActionButton__Primary} from "../../components/UI/Button/ActionButton_Primary.jsx";

import { ApiContext } from "../../contexts/ApiContext.jsx";
import { useLanguage } from "../../contexts/LanguageContext";

import styles from "./AttractionPageDetail.module.css";


const Attraction = {
  id: 1,
  slug: 'opera-theatre',
  title: 'Театр опери та балету імені Соломії Крушельницької',
  description: `Львівський оперний театр входить до списку обов’язкового відвідування усіх туристів та гостей міста. Якщо не послухати оперу чи подивитись балет, то точно хоча б оглянути фасад будівлі.
Це один із найгарніших театрів не тільки Львова, а й всієї Європи. До слова, ця будівля була збудована всього лише за три роки і вже у 1900 році в ній було презентовано першу виставу. Ще більше вражає ця дата, якщо уточнити, що для будівництва театру спеціально змінювали природний хід річки Полтви. Тепер вона тече під львівською бруківкою.
Окрім візуальної краси у Львівському оперному театрі можна насолоджуватись високоякісними постановками опер, оперет, балетів: чистим звучанням голосів акторів та довершеними й відточеними рухами балерин та балерунів.
Репертуар театру складають кращі зразки українського та європейського музичного мистецтва: опери «Аїда», «Травіата» Джузеппе Верді, «Кармен» Жоржа Бізе, «Мадам Баттерфляй» Джакомо Пуччіні, «Орфей і Еврідіка» Крістофа Віллібальда Глюка, українська опера «Запорожець за Дунаєм» Семена Гулака – Артемовського; балет «Лебедине озеро» Петра Чайковського, «Жізель» та «Корсар» Адольфа Адана, «Дон Кіхот» Людвіга Мінкуса, «Ромео і Джульєтта» Сергія Прокоф’єва…`,
  images: [
    '/img/city/Kyiv.svg',
    '/img/city/Kyiv.svg',
    '/img/city/Kyiv.svg',
    '/img/city/Kyiv.svg',
    '/img/city/Kyiv.svg',
  ],
};



export const AttractionPageDetail = () => {
  const { attractionApi } = useContext(ApiContext);
  const { language } = useLanguage();
  const navigate = useNavigate();
  const [openCityFilterMenu, setOpenCityFilterMenu] = useState(false);
  const [attraction, setAttraction] = useState({});
  const [imagesList, setImagesList] = useState([]);
  const [loading, setLoading] = useState(true);

  const { attractionSlug } = useParams();
  
  const [attractionId, slug] = attractionSlug.split('-');
  
  const lat = 48.8566;
  const lng = 2.3522;
  const { t } = useTranslation();


  useEffect(() => {
    if (!attractionId) return;

    setLoading(true);

    attractionApi.getById(attractionId, language)
      .then((res) => {
        console.log("attractions" );
        console.log(res.data );
       setAttraction(res.data[0]);
       setImagesList([
      res.data[0].imageUrl_Main,
      res.data[0].imageUrl_1,
      res.data[0].imageUrl_2,
      res.data[0].imageUrl_3,
    ].filter(Boolean));
    console.log( res.data[0].imageUrl_Main);
      })
      .catch((err) => {
        console.error("Error loading attractions:", err);
      })
      .finally(() => {
        setLoading(false);
      });

  }, [attractionId, language]);


  return (
    <div className={styles.cityPage}>
      <Header_Full titleBtn="city" title ={attraction.title} showFilterBtn={false} openFilterMenu={openCityFilterMenu} setOpenFilterMenu={setOpenCityFilterMenu} />

      <main className={styles.hotel_page__content}>
       {imagesList.length > 0 && <AttractionGallery images={imagesList} />}

        <div className={styles.description_container}>
          <div className={styles.text_column}>
            <p>{attraction.description}</p>
          </div>
          <div className={styles.map_column}>
            <div className={`${styles.card_map} flex-left btn-w-full`} >
              {lat && lng ? (
                <HotelMap lat={attraction.latitude} lng={attraction.longitude} minHeight="280"/>
              ) : (
                <div className={styles.mapPlaceholder}>Координаты отсутствуют</div>
              )}
            </div>
            <div className={`flex-center btn-w-full ${styles.btn_container}`}>
              <ActionButton__Primary text ={t("Attraction.find_housing")} className='btn-w-573  btn-h-59 btn-br-r-20'/>
            </div>
          </div>
        </div>
      </main >
      <Footer />


    </div >
  );
};

