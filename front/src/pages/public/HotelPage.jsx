import React, { useState, useEffect, useContext } from "react";
import { useTranslation } from "react-i18next";
import { useNavigate } from "react-router-dom";
import { ApiContext } from "../../contexts/ApiContext.jsx";
import { useLanguage } from "../../contexts/LanguageContext.jsx"
import { Spinner } from "../../components/UI/Spinner.jsx";
import { useParams, useLocation } from "react-router-dom";

import { Header_Full } from "../../components/Header/Header_Full.jsx";
import { HotelReviews } from "../../components/Hotel/HotelReviews.jsx";
import { HotelGallery } from "../../components/Hotel/HotelGallery.jsx";
import { Hotel_info_card } from "../../components/Hotel/Hotel_info_card.jsx";
import { HotelDescription } from "../../components/Hotel/Hotel_description.jsx";
import { HotelParamsList } from "../../components/Hotel/HotelParamsList.jsx";
import { HotelMap } from "../../components/Hotel/HotelMap.jsx";
import { Footer } from "../../components/Footer/Footer.jsx";
import { HotelInfoModal } from "../../components/modals/HotelInfoModal.jsx";
import { Link } from "../../components/UI/Text/Link.jsx";

import styles from "./HotelPage.module.css";

const imagesList = [
  "/img/hotel_info/hotel_1.jpg",
  "/img/hotel_info/hotel_2.jpg",
  "/img/hotel_info/hotel_3.jpg",
  "/img/hotel_info/hotel_4.jpg",
  "/img/hotel_info/hotel_5.jpg",
  "/img/hotel_info/hotel_6.jpg",
  "/img/hotel_info/hotel_7.jpg",
  "/img/hotel_info/hotel_8.jpg"
];

const dummyParams = [
  { id: 1, title: "Free Wi-Fi" },
  { id: 2, title: "Parking" },
  { id: 3, title: "Swimming Pool" },
  { id: 4, title: "Fitness Center" },
  { id: 5, title: "Spa Services" },
  { id: 6, title: "Restaurant" },
];

export const HotelPage = () => {
  const navigate = useNavigate();
  const { language } = useLanguage();
  const { t } = useTranslation();
  const [loading, setLoading] = useState(false);

  const handleClickBooking = () => {
    navigate(`/bookingdetails/${id}?checkin=${startDate}&checkout=${endDate}&adults=${adults}&children=${children}`, {
      state: {
        hotel,
        offer
      }
    });
  }

  const sections = [
    { id: "overview", label: t("hotel.sections.overview") },
    { id: "prices", label: t("hotel.sections.prices") },
    { id: "services", label: t("hotel.sections.services") },
    { id: "conditions", label: t("hotel.sections.conditions") },
    { id: "important", label: t("hotel.sections.important") },
    { id: "reviews", label: t("hotel.sections.reviews") },
  ];
  const hotelDescriptionText = `Інформація про цей готель
Зручне розташування: Готель Jam Hotel Staroyevreyska у Львові пропонує зручне розташування з близькістю до основних визначних пам'яток. Бернардинський монастир знаходиться за 4 хвилини ходьби, а площа Ринок — за 2 хвилини. Латинський кафедральний собор розташований за 300 метрів, а Вірменський кафедральний собор — за 400 метрів від готелю.
Комфортабельне розміщення: У номерах є власна ванна кімната з душем, феном та паркетною підлогою. Додаткові вигоди включають телевізор, електричний чайник, шафу та робочий стіл. Для задоволення різних потреб гостей передбачені сімейні номери та дивани-ліжка.
Зручності: Гості можуть користуватися безкоштовним Wi-Fi у громадських зонах, платним трансфером та цілодобовою стійкою реєстрації. Для тих, хто воліє дослідити місто на двох колесах, передбачено велосипедне паркування.
Местные достопримечательности: В окрестностях есть каток, который обеспечивает развлечения для посетителей.`;

  const location = useLocation();

  const { id } = useParams();
  const queryParams = new URLSearchParams(location.search);
  const startDate = queryParams.get("checkin");
  const endDate = queryParams.get("checkout");
  const adults = queryParams.get("adults");
  const children = queryParams.get("children");
  const cityId = queryParams.get("cityId");

  const { offerApi } = useContext(ApiContext);

  const [hotel, setHotel] = useState({});
  const [offer, setOffer] = useState({});
  const [images, setImages] = useState([]);
  const [paramValues, setParamValues] = useState([]);
  const [isModalOpen, setIsModalOpen] = useState(false);


  useEffect(() => {
    console.log({ hotelId: id })
  });

  const reviews = [
    { id: 1, title: "reviews.overall_rating", grade: "9.1" },
    { id: 2, title: "reviews.staff", grade: "9.3" },
    { id: 3, title: "reviews.cleanliness", grade: "9.2" },
    { id: 4, title: "reviews.comfort", grade: "9.2" },
    { id: 5, title: "reviews.location", grade: "8.8" },
    { id: 6, title: "reviews.value_for_money", grade: "9.6" },
    { id: 7, title: "reviews.amenities", grade: "8.9" },

  ];

  const comments = [
    { id: 1, name: "Olena", grade: "7.1", review: "Все супер, не вистачало за цю ціну одноразових щіток почистити зуби, і одноразових тапок, а так все чисто постіль без плям і приємно пахне, бонусом нам написали, що ми можемо заселитися на годину раніше, рекомендую!" },
    { id: 2, name: "Maxim", grade: "9.1", review: "Величезне спасибі за наявність праски та дошки для прасування, в наш час рідко зустрінеш таке навіть у п'ятизіркових готелях. Також приємно наявність фена. В іншому нам теж усе сподобалося. Тихе, чисте місце." },
    { id: 3, name: "Oleg", grade: "7.9", review: "Сподобалася повна автономність заселення та виселення з номера, без контактів із людьми, зустрічей та очікувань. Номер чистий і комфортний, є все необхідне, нічого додаткового не потребували. Вигляд з вікна був красивий!" },
    { id: 4, name: "Iruna", grade: "8.5", review: "У номері є все необхідне! Чисто!!Є і фен, і праска, і навіть кавоварка. Номер чистий і комфортний, є все необхідне, нічого додаткового не потребували. Вигляд з вікна був красивий!" },
  ];



  useEffect(() => {
    if (!offerApi || !id) return;

    const fetchOffer = async () => {
      setLoading(true);
      document.body.style.cursor = "wait";
      try {
        const res = await offerApi.searchId({
          id,
          lang: language,
          startDate: new Date(startDate).toISOString(),
          endDate: new Date(endDate).toISOString(),
          adults,
          children,
          userDiscountPercent: 0,
        });

        const data = res.data[0];

        setOffer(data);
        setHotel(data?.rentObj?.[0]);
        setImages(data?.rentObj?.[0]?.imagesUrl || []);
        setParamValues(data?.rentObj?.[0]?.paramValues || []);

        console.log("Loaded offer data:", data);
        console.log("Loaded offer rentObj:", data?.rentObj?.[0]);
        console.log("Loaded img rentObj:", data?.rentObj?.[0]?.imagesUrl);
        console.log("Loaded param rentObj:", data?.rentObj?.[0]?.paramValues);

      } catch (err) {
        console.error("Error loading offer:", err);
      } finally {
        setLoading(false);
        document.body.style.cursor = "default";
      }
    };

    fetchOffer();
  }, [id, offerApi, startDate, endDate, adults, children, language]);



  const lat = 48.8566;
  const lng = 2.3522;

  return (
    <div className={styles.hotelPage}>
      <Header_Full title={offer.title} showFilterBtn={false} />
      <main className={styles.hotel_page__content}>
        {loading ? (
          <Spinner loading={true} />
        ) : (
          <>
            <div className="flex-center btn-w-full">
              <HotelGallery images={images} />
            </div>

            <div className={`${styles.description_with_map} flex-center btn-w-full gap-20 btn-h-656`}>
              <div className={styles.description}>
                <HotelDescription text={offer?.description || hotelDescriptionText} />
              </div>

              <div className={`${styles.card_map} flex-left btn-w-full btn-h-full`}>
                {hotel?.latitude && hotel?.longitude ? (
                  <HotelMap
                    lat={hotel.latitude}
                    lng={hotel.longitude}
                    hotelName={offer?.title}
                    hotel_address={`${offer?.countryTitle}, ${offer?.cityTitle}, ${hotel?.street} ${hotel?.houseNumber}`}
                    minHeight="252"
                    showAddress={true}
                  />
                ) : (
                  <div className={styles.mapPlaceholder}>Координаты отсутствуют</div>
                )}
              </div>
            </div>

            <div className="flex-left btn-w-full">
              <Link text={t("hotel.info_about_owner")} type="m_600_s_32" />
            </div>

            <div className="flex-left btn-w-full">
              <HotelParamsList params={paramValues} />
            </div>

            <div id="prices" className="flex-left btn-w-full gap-20 btn-h-656">
              <Hotel_info_card
                hotel={hotel}
                offer={offer}
                startDate={startDate}
                endDate={endDate}
                adults={adults}
                children={children}
              />
            </div>

            <HotelReviews
              showBtn={false}
              orderId={hotel.id}
              offerId={offer.id}
            />
          </>
        )}
      </main>

      <Footer />

      {isModalOpen && (
        <div className="modalOverlay">
          <HotelInfoModal images={images} setIsModalOpen={setIsModalOpen} />
        </div>
      )}
    </div>
  );
};
