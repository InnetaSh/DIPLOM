import React, { useState, useEffect, useContext } from "react";
import { useNavigate } from "react-router-dom";
import { Header } from "../../components/Header/Header.jsx";
import { BunnerHotel } from "../../components/Bunner/Bunner_hotel.jsx";
import { Footer } from "../../components/Footer/Footer.jsx";
import { TwoColumnInfoSection } from "../../components/Info_Components/TwoColumnInfoSection.jsx";
import { MoreOffersSection } from "../../components/Info_Components/MoreOffersSection.jsx";
import { SearchBar_Main } from "../../components/SearchBar/SearchBar_Main.jsx";
import { CityCard_carousel } from "../../components/CityCard/CityCard_carousel.jsx"
import { HotelCardList_Recomented } from "../../components/HotelCard/HotelCardList_Recomented.jsx";
import { More_tour } from "../../components/Info_Components/More_tour";
import {MoreTourWrapper} from "../../components/Info_Components/MoreTourWrapper.jsx";
import { MainPageBg } from "../../components/MainPage_bg/MainPage_bg.jsx";

import { ApiContext } from "../../contexts/ApiContext.jsx";
import { useLanguage } from "../../contexts/LanguageContext";

import styles from "./HomePage.module.css";

const mockFiltersData = [
  {
    id: "accommodation_type",
    title: "filters.accommodation_type.title",
    items: [
      { id: "type_hotel", title: "filters.accommodation_type.hotel", value: "hotel" },
      { id: "type_hostel", title: "filters.accommodation_type.hostel", value: "hostel" },
      { id: "type_studio", title: "filters.accommodation_type.studio", value: "studio" },
      { id: "type_apartment", title: "filters.accommodation_type.apartment", value: "apartment" },
      { id: "type_house", title: "filters.accommodation_type.house", value: "house" },
      { id: "type_room", title: "filters.accommodation_type.room", value: "room" }
    ]
  },
  {
    id: "price",
    title: "filters.price.title",
    items: [
      { id: "from", title: "filters.price.from", value: "wifi" },
      { id: "to", title: "filters.price.to", value: "to" },
    ]
  },
  {
    id: "amenities",
    title: "filters.amenities.title",
    items: [
      { id: "amenity_wifi", title: "filters.amenities.wifi", value: "wifi" },
      { id: "amenity_ac", title: "filters.amenities.air_conditioner", value: "air_conditioner" },
      { id: "amenity_tv", title: "filters.amenities.tv", value: "tv" },
      { id: "amenity_workspace", title: "filters.amenities.workspace", value: "workspace" },
      { id: "amenity_pets", title: "filters.amenities.pets", value: "pets" },
      { id: "amenity_parking", title: "filters.amenities.parking", value: "parking" },
      { id: "amenity_washer", title: "filters.amenities.washer", value: "washer" },
      { id: "amenity_iron", title: "filters.amenities.iron", value: "iron" },
      { id: "amenity_kettle", title: "filters.amenities.kettle", value: "kettle" }
    ]
  },
  {
    id: "housing_features",
    title: "filters.housing_features.title",
    items: [
      { id: "feature_balcony", title: "filters.housing_features.balcony", value: "balcony" },
      { id: "feature_terrace", title: "filters.housing_features.terrace", value: "terrace" },
      { id: "feature_kitchen", title: "filters.housing_features.kitchen", value: "kitchen" },
      { id: "feature_single_bed", title: "filters.housing_features.single_bed", value: "single_bed" },
      { id: "feature_double_bed", title: "filters.housing_features.double_bed", value: "double_bed" }
    ]
  },
  {
    id: "rating",
    title: "filters.rating.title",
    items: [
      { id: "rating_5", title: "filters.rating.5", value: "5" },
      { id: "rating_7", title: "filters.rating.7", value: "7" },
      { id: "rating_9", title: "filters.rating.9", value: "9" },
      { id: "rating_8", title: "filters.rating.8", value: "8" }
    ]
  },
  {
    id: "distance_center",
    title: "filters.distance_center.title",
    items: [
      { id: "distance_1", title: "filters.distance_center.<1km", value: "<1km" },
      { id: "distance_3", title: "filters.distance_center.<3km", value: "<3km" },
      { id: "distance_5", title: "filters.distance_center.<5km", value: "<5km" }
    ]
  },
  {
    id: "booking_rules",
    title: "filters.booking_rules.title",
    items: [
      { id: "rule_free_cancel", title: "filters.booking_rules.free_cancel", value: "free_cancel" },
      { id: "rule_pay_now", title: "filters.booking_rules.pay_now", value: "pay_now" },
      { id: "rule_pay_before", title: "filters.booking_rules.pay_before", value: "pay_before" },
      { id: "rule_pay_place", title: "filters.booking_rules.pay_on_place", value: "pay_on_place" }
    ]
  },
  {
    id: "district",
    title: "filters.district.title",
    items: [
      { id: "district_center", title: "filters.district.center", value: "center" },
      { id: "district_favorite", title: "filters.district.favorite", value: "favorite" },
      { id: "district_market", title: "filters.district.market_square", value: "market_square" },
      { id: "district_svobody", title: "filters.district.svobody_avenue", value: "svobody_avenue" }
    ]
  }
];

const mockHotels = [
  {
    id: 1,
    title: "Готель Київ Центр",
    rentObj: [{ mainImageUrl: "https://picsum.photos/300/200?random=1" }],
    city: "Київ",
    country: "Україна",
    distanceToCenter: 1.2,
    rating: 4.8,
    reviews: 234,
    totalPrice: 2500,
  },
  {
    id: 2,
    title: "Апартаменти Львів Старе Місто",
    rentObj: [{ mainImageUrl: "https://picsum.photos/300/200?random=2" }],
    city: "Львів",
    country: "Україна",
    distanceToCenter: 0.5,
    rating: 4.6,
    reviews: 180,
    totalPrice: 1800,
  },
  {
    id: 3,
    title: "Хостел Одеса Морський",
    rentObj: [{ mainImageUrl: "https://picsum.photos/300/200?random=3" }],
    city: "Одеса",
    country: "Україна",
    distanceToCenter: 2.0,
    rating: 4.2,
    reviews: 95,
    totalPrice: 900,
  },
  {
    id: 4,
    title: "Спа-готель Карпати",
    rentObj: [{ mainImageUrl: "https://picsum.photos/300/200?random=4" }],
    city: "Яремче",
    country: "Україна",
    distanceToCenter: 3.5,
    rating: 4.9,
    reviews: 112,
    totalPrice: 3200,
  },
  {
    id: 5,
    title: "Стильні апартаменти Харків",
    rentObj: [{ mainImageUrl: "https://picsum.photos/300/200?random=5" }],
    city: "Харків",
    country: "Україна",
    distanceToCenter: 1.0,
    rating: 4.5,
    reviews: 140,
    totalPrice: 2000,
  },
  {
    id: 6,
    title: "Затишний будинок у Чернівцях",
    rentObj: [{ mainImageUrl: "https://picsum.photos/300/200?random=6" }],
    city: "Чернівці",
    country: "Україна",
    distanceToCenter: 0.8,
    rating: 4.7,
    reviews: 87,
    totalPrice: 1500,
  },
];



export const HomePage = () => {
  const { paramsCategoryApi } = useContext(ApiContext);
  const { language } = useLanguage();
  const navigate = useNavigate();

  const [hotels, setHotels] = useState(mockHotels);
  const [city, setCity] = useState("");
  const [guests, setGuests] = useState(1);
  const [startDate, setStartDate] = useState("");
  const [endDate, setEndDate] = useState("");
  const [filtersData, setFiltersData] = useState([]);
  const [selectedFilters, setSelectedFilters] = useState({});




  useEffect(() => {
    const savedCity = localStorage.getItem("city");
    const savedGuests = localStorage.getItem("guests");
    const savedStart = localStorage.getItem("startDate");
    const savedEnd = localStorage.getItem("endDate");
    const savedHotels = localStorage.getItem("hotels");

    if (savedCity) setCity(savedCity);
    if (savedGuests) setGuests(Number(savedGuests));
    if (savedStart) setStartDate(savedStart);
    if (savedEnd) setEndDate(savedEnd);
    // if (savedHotels) setHotels(JSON.parse(savedHotels));
    if (savedHotels) setHotels(mockHotels);
  }, []);


  useEffect(() => {
    paramsCategoryApi.getAll(language)
      .then((res) => setFiltersData(res.data))
      .catch(() => {
        console.warn("API недоступен, используется mock");
        setFiltersData(mockFiltersData);
      });
  }, [paramsCategoryApi, language]);


  const handleFilterChange = (category, option) => {
    setSelectedFilters((prev) => {
      const selected = prev[category] || [];
      if (selected.includes(option)) {
        return { ...prev, [category]: selected.filter((v) => v !== option) };
      } else {
        return { ...prev, [category]: [...selected, option] };
      }
    });
  };

  const handleSearchResults = (searchParams) => {
    navigate("/search", { state: searchParams });
  };


  return (
    <div className={styles.homePage}>

      <Header />

      <MainPageBg />
      <main >
        <BunnerHotel />
        <div className="btn-w-full p-t-24 flex-center mb-30">
          <SearchBar_Main
            onSearch={handleSearchResults}
            defaultCity={city}
            defaultGuests={guests}
            defaultStartDate={startDate}
            defaultEndDate={endDate}
          />
        </div>

        <CityCard_carousel />
        <MoreOffersSection />
        <HotelCardList_Recomented
          hotels={hotels}
          guests={guests}

        />
        <TwoColumnInfoSection />
        {/* < More_tour /> */}

        <MoreTourWrapper/>
      </main>
      <Footer />
    </div>
  );
};
