import React, { useState, useEffect, useContext } from "react";
import { useLocation } from "react-router-dom";
import { offerApi } from "../../api/offer.js";
import { Header_Full } from "../../components/Header/Header_Full.jsx";

import { Footer } from "../../components/Footer/Footer.jsx";
import { TwoColumnInfoSection } from "../../components/Info_Components/TwoColumnInfoSection.jsx";
import { MoreOffersSection } from "../../components/Info_Components/MoreOffersSection.jsx";
import { FilterSidebar } from "../../components/Filter/FilterSidebar.jsx";
import { HotelCardList } from "../../components/HotelCard/HotelCardList.jsx";
import { HotelCardList_Recomented } from "../../components/HotelCard/HotelCardList_Recomented.jsx";
import { MoreTourWrapper } from "../../components/Info_Components/MoreTourWrapper";
import { CityCard_carousel } from "../../components/CityCard/CityCard_carousel.jsx";

import { Text } from "../../components/UI/Text/Text.jsx";
import { ApiContext } from "../../contexts/ApiContext.jsx";
import { useLanguage } from "../../contexts/LanguageContext";

import styles from "./SearchPage.module.css";

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



export const SearchPage = () => {
  const { paramsCategoryApi } = useContext(ApiContext);
  const { language } = useLanguage();
  const { state } = useLocation();

  const [openFilterMenu, setOpenFilterMenu] = useState(false);
  const [hotels, setHotels] = useState(mockHotels);
  const [city, setCity] = useState("");
  const [guests, setGuests] = useState(1);
  const [startDate, setStartDate] = useState(null); // хранить как Date для DatePicker
  const [endDate, setEndDate] = useState(null);
  const [filtersData, setFiltersData] = useState([]);
  const [selectedFilters, setSelectedFilters] = useState({});
  const [locationId, setLocationId] = useState(null);


  useEffect(() => {
    const savedCity = localStorage.getItem("city");
    const savedGuests = localStorage.getItem("guests");
    const savedStart = localStorage.getItem("startDate");
    const savedEnd = localStorage.getItem("endDate");
    const savedHotels = localStorage.getItem("hotels");

    if (savedCity) setCity(savedCity);
    if (savedGuests) setGuests(Number(savedGuests));
    if (savedStart) setStartDate(new Date(savedStart));
    if (savedEnd) setEndDate(new Date(savedEnd));
    if (savedHotels) setHotels(JSON.parse(savedHotels));
  }, []);

  useEffect(() => {
    if (!state) return;

    setCity(state.city || "");
    setLocationId(state.locationId || null);
    setGuests(state.guests || 1);
    setStartDate(state.startDate ? new Date(state.startDate) : null);
    setEndDate(state.endDate ? new Date(state.endDate) : null);


    localStorage.setItem("city", state.city || "");
    localStorage.setItem("guests", state.guests || 1);
    if (state.startDate) localStorage.setItem("startDate", new Date(state.startDate).toISOString());
    if (state.endDate) localStorage.setItem("endDate", new Date(state.endDate).toISOString());
  }, [state]);


  useEffect(() => {
    paramsCategoryApi.getAll(language)
      .then((res) => setFiltersData(res.data))
      .catch(() => {
        console.warn("API недоступен, используется mock");
        setFiltersData(mockFiltersData);
      });
  }, [paramsCategoryApi, language]);


  const handleFilterChange = (category, option) => {
    setSelectedFilters(prev => {
      const selected = prev[category] || [];
      if (selected.includes(option)) {
        return { ...prev, [category]: selected.filter(v => v !== option) };
      } else {
        return { ...prev, [category]: [...selected, option] };
      }
    });
  };

  // Поиск при переходе со страницы с state
  useEffect(() => {
    if (!state || !state.startDate || !state.endDate || !locationId) return;

    const startIso = new Date(state.startDate).toISOString();
    const endIso = new Date(state.endDate).toISOString();

    offerApi.searchOffers({
      startDate: startIso,
      endDate: endIso,
      guests: state.guests,
      userDiscountPercent: 5,
      lang: language,
      cityId: locationId,
      paramItemFilters: {}
    }).then(res => setHotels(res.data))
      .catch(err => console.error("Ошибка поиска предложений:", err));
  }, [state, locationId, language]);



  const handleSearchResults = (foundHotels, onSearchCity, guestCount, start, end, locId) => {
    setCity(onSearchCity);
    setHotels(foundHotels);
    setGuests(guestCount);
    setStartDate(new Date(start));
    setEndDate(new Date(end));
    setLocationId(locId);

    localStorage.setItem("city", onSearchCity);
    localStorage.setItem("guests", guestCount);
    localStorage.setItem("startDate", start);
    localStorage.setItem("endDate", end);
    localStorage.setItem("hotels", JSON.stringify(foundHotels));

    setSelectedFilters({});
  };

  return (
    <div className={styles.searchPage}>

      <Header_Full
        city={city}
        title={city}
        guests={guests}
        startDate={startDate}
        endDate={endDate}
        openFilterMenu={openFilterMenu}
        setOpenFilterMenu={setOpenFilterMenu}

        handleSearchResults={handleSearchResults}
      />

      <main>
        <div className={styles.searchPage__container}>
          <div
            className={styles.searchPage__container__list}
            style={{
              width: openFilterMenu ? `calc(100% - 424px - 20px)` : "100%",
              transition: "width 0.2s ease",
            }}
          >
            <HotelCardList
              hotels={hotels}
              guests={guests}
              startDate={startDate}
              endDate={endDate}
            />
          </div>

          {openFilterMenu && (
            <aside className={styles.searchPage__filters}>
              <FilterSidebar
                filtersData={filtersData}
                selectedFilters={selectedFilters}
                onFilterChange={handleFilterChange}
              />
            </aside>
          )}
        </div>
      </main>

      <Footer />
    </div>
  );
};
