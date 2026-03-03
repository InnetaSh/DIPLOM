import { useParams } from 'react-router-dom';
import React, { useState, useEffect, useContext } from "react";
import { useNavigate } from "react-router-dom";
import { Header_Full } from "../../components/Header/Header_Full.jsx";
import { Footer } from "../../components/Footer/Footer.jsx";
import { ActionButton__Primary } from "../../components/UI/Button/ActionButton_Primary.jsx";
import {Text} from "../../components/UI/Text/Text.jsx";
import { PlaceCard_carousel } from "../../components/PlacesCard/PlaceCard_carousel.jsx";
import { useLanguage } from "../../contexts/LanguageContext";


import { ApiContext } from "../../contexts/ApiContext.jsx";

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


export const CityPage = () => {
  const { citySlug } = useParams();
  const [city, setCity] = useState(null);

  const { locationApi } = useContext(ApiContext);
  const navigate = useNavigate();
  const [openCityFilterMenu, setOpenCityFilterMenu] = useState(false);

  const [isModalOpen, setIsModalOpen] = useState(true);

  const { language } = useLanguage();

  const [id, slug] = citySlug.split('-');

  console.log(id);
  console.log(slug);

  const cityId = Number(id);

  useEffect(() => {
    const loadOffers = async () => {
      try {
        const res = await locationApi.getCityById(cityId, language);
        setCity(res.data[0]);
        console.log("Ответ PopularCity:", res.data[0]);
        console.log("Данные:", res.data);
      } catch (error) {
        console.warn("API недоступен, используется mock");
        setCity(cityData);
      }
    };

    loadOffers();
  }, [language]);






  if (!city) return <div>Місто не знайдено</div>;

  return (
    <div className={styles.cityPage}>
      <Header_Full titleBtn="city" title={city.title} openFilterMenu={openCityFilterMenu} setOpenFilterMenu={setOpenCityFilterMenu} />

      <main className={styles.hotel_page__content}>
        <div className="container-fluid">
          <div className="row g-4  align-items-stretch">
            <div className="col-lg-7">
              <div className="mb-3">
                <img
                  src={city?.imageUrl_Main}
                  className={`img-fluid rounded-4 w-100 ${styles.city_img_main}`}
                  alt={city?.title}
                />
              </div>

              <div className="row g-3">

                <div className="col-6">
                  <div className="row g-3">
                    {[city?.imageUrl_1, city?.imageUrl_2]
                      .filter(Boolean)
                      .map((img, index) => (
                        <div className="col-12" key={index}>
                          <img
                            src={img}
                            className={`img-fluid rounded-4 w-100 ${styles.city_img_small}`}
                            alt={city?.title}
                          />
                        </div>
                      ))}
                  </div>
                </div>


                {city?.imageUrl_3 && (
                  <div className="col-6">
                    <img
                      src={city.imageUrl_3}
                      className="img-fluid rounded-4 w-100 h-100 object-fit-cover"
                      alt={city?.title}
                    />
                  </div>
                )}
              </div>

            </div>

            <div className="col-lg-5 d-flex flex-column ">
              <div>
                <Text text="Трохи з історії" type="m_600_s_24"/>
                <p >{city?.description}</p>

                <Text text="Архітектурне та культурне надбання" type="m_600_s_24"/>
                <p>{city?.history}</p>
              </div>

              <div className="mt-auto d-flex justify-content-center">
                <ActionButton__Primary
                  className={`btn btn-warning px-5 btn-h-59 btn-br-r-20 ${styles.btn_search}`}
                  onClick={() => navigate(`/offers/${city?.id}`)}
                  text="Знайти житло"
                  type="m_600_s_24"
                />
              </div>
            </div>


          </div>
        </div>
        {/* <PlaceCard_carousel list={attractionList} /> */}
      </main>
      <Footer />


    </div>
  );
};

