import { useParams } from 'react-router-dom';
import React, { useState, useEffect, useContext } from "react";
import { useNavigate } from "react-router-dom";
import { Header_Full } from "../../components/Header/Header_Full.jsx";
import { Footer } from "../../components/Footer/Footer.jsx";
import { PlaceCard_carousel } from "../../components/PlacesCard/PlaceCard_carousel.jsx"

import { ApiContext } from "../../contexts/ApiContext.jsx";
import { useLanguage } from "../../contexts/LanguageContext";

import styles from "./CityPage.module.css";


const cityData = {
    kyiv: {
        title: 'Київ',
        description: 'Столиця України, культурний та історичний центр.',
        image: '/img/city/Kyiv.svg'
    },
    odesa: {
        title: 'Одеса',
        description: 'Місто біля Чорного моря.',
        image: '/img/city/Odesa.svg'
    },
    lviv: {
        title: 'Львів',
        description: 'Місто кави та старовинної архітектури.',
        image: '/img/city/Lviv.svg'
    },
    bukovel: {
        title: 'Буковель',
        description: 'Популярний гірськолижний курорт.',
        image: '/img/city/Bukovel.svg'
    }
};


const attractionList = [
  {
    id: 1,
    slug: 'opera-theatre',
    title: 'Театр опери та балету ім. Соломії Крушельницької',
    imageSrc: '/img/attractions/SolomiyaKrushelnytska.jpg'
  },
  {
    id: 2,
    slug: 'latin-cathedral',
    title: 'Латинський кафедральний собор',
    imageSrc: '/img/attractions/beer.jpg'
  },
  {
    id: 3,
    slug: 'ivano-frankivsk-museum',
    title: 'Музей Івана Франка',
    imageSrc: '/img/attractions/block_203281.jpg'
  },
  {
    id: 4,
    slug: 'high-castle',
    title: 'Високий Замок',
     imageSrc: '/img/attractions/ElżbietaChurch.jpg'
  },
  {
    id: 5,
    slug: 'italian-courtyard',
    title: 'Італійський дворик',
    imageSrc: '/img/attractions/ItalianCourtyard.jpg'
  },
   {
    id: 6,
    slug: 'latin-cathedral',
    title: 'Латинський кафедральний собор',
    imageSrc: '/img/attractions/lviv-opera.jpg'
  },
  {
    id: 7,
    slug: 'ivano-frankivsk-museum',
    title: 'Музей Івана Франка',
    imageSrc: '/img/attractions/opera1.jpg'
  },
];


export const CityPage = () => {
    const { paramsCategoryApi } = useContext(ApiContext);
    const { language } = useLanguage();
    const navigate = useNavigate();
    const { citySlug } = useParams();
    const city = cityData[citySlug];
    const [openCityFilterMenu,setOpenCityFilterMenu] = useState(false);

      const [isModalOpen, setIsModalOpen] = useState(true);


      
    if (!city) return <div>Місто не знайдено</div>;

    return (
        <div className={styles.cityPage}>
            <Header_Full  titleBtn="city" openFilterMenu={openCityFilterMenu} setOpenFilterMenu={setOpenCityFilterMenu} />
           
            <main className={styles.hotel_page__content}>
              
                  <PlaceCard_carousel list = {attractionList}/>
            </main>
            <Footer />

            
        </div>
    );
};

