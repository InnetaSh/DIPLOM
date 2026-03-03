import React, { useState, useEffect, useContext } from "react";
import { Header_Full } from "../../components/Header/Header_Full.jsx";
import { useParams, useLocation } from "react-router-dom";

import { Text } from "../../components/UI/Text/Text.jsx";
import { ImageSvg } from "../../components/UI/Image/ImageSvg.jsx";
import { ApiContext } from "../../contexts/ApiContext.jsx";
import { HotelReviews } from "../../components/Hotel/HotelReviews.jsx";
import { HotelGallery } from "../../components/Hotel/HotelGallery.jsx";
import { HotelDescription } from "../../components/Hotel/Hotel_description.jsx";
import { HotelParamsList } from "../../components/Hotel/HotelParamsList.jsx";
import { HotelMap } from "../../components/Hotel/HotelMap.jsx";
import { Footer } from "../../components/Footer/Footer.jsx";
import { ActionButton__Primary } from "../../components/UI/Button/ActionButton_Primary.jsx";
import { HotelInfoModal_ParamsList } from "../../components/modals/HotelInfoModal_ParamsList.jsx";
import { useNavigate } from "react-router-dom";
import { useTranslation } from "react-i18next";
import { Spinner } from "../../components/UI/Spinner.jsx";

import styles from "./Profile_PastHotelPage.module.css";


const hotelMock =
{
  id: 1,
  title: "Urban Hotel",
  hotelDescriptionText: `Інформація про цей готель
      Зручне розташування: Готель Jam Hotel Staroyevreyska у Львові пропонує зручне розташування з близькістю до основних визначних пам'яток. Бернардинський монастир знаходиться за 4 хвилини ходьби, а площа Ринок — за 2 хвилини. Латинський кафедральний собор розташований за 300 метрів, а Вірменський кафедральний собор — за 400 метрів від готелю.
      Комфортабельне розміщення: У номерах є власна ванна кімната з душем, феном та паркетною підлогою. Додаткові вигоди включають телевізор, електричний чайник, шафу та робочий стіл. Для задоволення різних потреб гостей передбачені сімейні номери та дивани-ліжка.
      Зручності: Гості можуть користуватися безкоштовним Wi-Fi у громадських зонах, платним трансфером та цілодобовою стійкою реєстрації. Для тих, хто воліє дослідити місто на двох колесах, передбачено велосипедне паркування.
      Местные достопримечательности: В окрестностях есть каток, который обеспечивает развлечения для посетителей.`,
  adress: "вул. Наукова, 61",
  data: "10.11.2025 -15.11-2025",
  price: "6 282",
  imagesList: [
    "/img/hotel_info/hotel_1.jpg",
    "/img/hotel_info/hotel_2.jpg",
    "/img/hotel_info/hotel_3.jpg",
    "/img/hotel_info/hotel_4.jpg",
    "/img/hotel_info/hotel_5.jpg",
    "/img/hotel_info/hotel_6.jpg",
    "/img/hotel_info/hotel_7.jpg",
    "/img/hotel_info/hotel_8.jpg"
  ],
  comments: [
    { id: 1, name: "Olena", grade: "7.1", review: "Все супер, не вистачало за цю ціну одноразових щіток почистити зуби, і одноразових тапок, а так все чисто постіль без плям і приємно пахне, бонусом нам написали, що ми можемо заселитися на годину раніше, рекомендую!" },
    { id: 2, name: "Maxim", grade: "9.1", review: "Величезне спасибі за наявність праски та дошки для прасування, в наш час рідко зустрінеш таке навіть у п'ятизіркових готелях. Також приємно наявність фена. В іншому нам теж усе сподобалося. Тихе, чисте місце." },
    { id: 3, name: "Oleg", grade: "7.9", review: "Сподобалася повна автономність заселення та виселення з номера, без контактів із людьми, зустрічей та очікувань. Номер чистий і комфортний, є все необхідне, нічого додаткового не потребували. Вигляд з вікна був красивий!" },
    { id: 4, name: "Iruna", grade: "8.5", review: "У номері є все необхідне! Чисто!!Є і фен, і праска, і навіть кавоварка. Номер чистий і комфортний, є все необхідне, нічого додаткового не потребували. Вигляд з вікна був красивий!" },
  ],
  reviews: [
    { id: 1, title: "Prrofile.PastHotel.reviews.overall_rating", grade: "9.1" },
    { id: 2, title: "Prrofile.PastHotel.reviews.staff", grade: "9.3" },
    { id: 3, title: "Prrofile.PastHotel.reviews.cleanliness", grade: "9.2" },
    { id: 4, title: "Prrofile.PastHotel.reviews.comfort", grade: "9.2" },
    { id: 5, title: "Prrofile.PastHotel.reviews.location", grade: "8.8" },
    { id: 6, title: "Prrofile.PastHotel.reviews.value_for_money", grade: "9.6" },
    { id: 7, title: "Prrofile.PastHotel.reviews.amenities", grade: "8.9" },

  ],
}


const dummyParams = [
  { id: 1, title: "Free Wi-Fi" },
  { id: 2, title: "Parking" },
  { id: 3, title: "Swimming Pool" },
  { id: 4, title: "Fitness Center" },
  { id: 5, title: "Spa Services" },
  { id: 6, title: "Restaurant" },
];

export const Profile_PastHotelPage = () => {

  const navigate = useNavigate();
  const { t } = useTranslation();

  const handleClickBooking = () => { console.log("click") }

  const sections = [
    { id: "overview", label: t("hotel.sections.overview") },
    { id: "prices", label: t("hotel.sections.prices") },
    { id: "services", label: t("hotel.sections.services") },
    { id: "conditions", label: t("hotel.sections.conditions") },
    { id: "important", label: t("hotel.sections.important") },
    { id: "reviews", label: t("hotel.sections.reviews") },
  ];

  const { offerId, orderId } = useParams();

  const { offerApi } = useContext(ApiContext);

  const [hotelData, setHotelData] = useState(hotelMock);

  const [offer, setOffer] = useState({});
  const [images, setImages] = useState([]);
  const [paramValues, setParamValues] = useState([]);
  const [isModalOpen, setIsModalOpen] = useState(true);



  useEffect(() => {
    if (hotelData.imagesList) {
      setImages(hotelData.imagesList);
    }
  }, [hotelData]);


useEffect(() => {
  if (!offerId) return;

  setLoading(true);
  document.body.style.cursor = "wait";

  offerApi
    .searchIdByOrderId({
      offerId,
      orderId,
      lang: "uk",
    })
    .then((res) => {
      const data = res.data[0];

      setOffer(data);
      setHotelData(data?.rentObj?.[0]);
      setImages(data?.rentObj?.[0]?.imagesUrl || []);
      setParamValues(data?.rentObj?.[0]?.paramValues || []);

      console.log("Loaded offer data:", data);
    })
    .catch((err) => {
      console.error("Error loading offer:", err);
    })
    .finally(() => {
      setLoading(false);
      document.body.style.cursor = "default";
    });

}, [offerId, orderId]);


  const lat = 48.8566;
  const lng = 2.3522;
   const [loading, setLoading] = useState(false);

  return (
    <div className={styles.hotelPage}>
      <Header_Full title={t("Prrofile.PastHotel.title_page")} showFilterBtn={false} />
      <main className={styles.hotel_page__content}>
        {loading ? (
          <Spinner loading={true} />
        ) : (
          <>
            <div className="flex-left-column  btn-w-full gap-20">
              <div className="flex-left btn-w-full">
                <Text text={offer.title} type="m_700_s_40" />
              </div>
              <div className="flex-between btn-w-full">
                <div className="flex-left btn-w-fit-content gap-5">
                  <ImageSvg name="localization" sizeX={24} sizeY={31} />
                  <Text text={hotelData.adress} type="m_400_s_24" />
                </div>
                <div className="flex-left btn-w-fit-content gap-20">
                  <ImageSvg name="calendar_middle" sizeX={36} sizeY={36} />
                  <Text
                    text={offer.startDate?.split("T")[0]}
                    type="m_500_s_36"
                  />
                  <Text
                    text={"-"}
                    type="m_500_s_36"
                  />
                  <Text
                    text={offer.endDate?.split("T")[0]}
                    type="m_500_s_36"
                  />
                </div>
              </div>



              <div className="flex-center btn-w-full">
                <HotelGallery images={images} />
              </div>
            </div>
            <div className="flex-right btn-w-full">
              <ActionButton__Primary
                className={`flex-between  btn-h-101 btn-br-r-20 ${styles.btn_price}`}
                text={t("Prrofile.PastHotel.price")}
                text_2={`UAH ${offer.totalPrice}`}
                type="m_700_s_48"
                type_2="m_700_s_48"
              />
            </div>
            <HotelDescription text={offer?.description || hotelData.hotelDescriptionText} />

            <div className="flex-left btn-w-full" >
              <HotelParamsList params={paramValues} />
            </div>
            <div id="prices" className="flex-center btn-w-full gap-20 btn-h-656">
              <div className={styles.info_card}>
                <HotelInfoModal_ParamsList hotel={hotelData} showBtn={false} />
              </div>

              <div className={`${styles.card_map} flex-left btn-w-full btn-h-full `} >
                {lat && lng ? (

                  <HotelMap lat={hotelData.latitude} lng={hotelData.longitude} minHeight="280" />) : (
                  <div className={styles.mapPlaceholder}>Координаты отсутствуют</div>
                )}
              </div>
            </div>


            <HotelReviews
              showBtn={true}
              orderId={orderId}
              offerId={offerId}

            />

          </>
        )}
      </main>
      <Footer />


    </div>
  );
};
