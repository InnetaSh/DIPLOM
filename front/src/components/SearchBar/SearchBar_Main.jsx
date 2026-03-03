import React, { useState, useContext } from "react";
import { useTranslation } from "react-i18next";
import { useLanguage } from "../../contexts/LanguageContext.jsx";
import { CitySelector } from "./CitySelector.jsx";

import { AddGuestModal } from "../modals/AddGuestModal.jsx";
import { ApiContext } from "../../contexts/ApiContext.jsx";
import { DateRangeInput } from "./DateRangeInput.jsx";
import { IconSvg } from "../UI/Image/IconSvg.jsx";
import { IconButton_Search } from "../UI/Button/IconButton_Search.jsx";

import styles from "./SearchBar.module.css";
import { Text } from "../UI/Text/Text.jsx";

export const SearchBar_Main = ({ onSearch, text }) => {

  const { t } = useTranslation();
  const { offerApi } = useContext(ApiContext);
  const { language } = useLanguage();
  const [location, setLocation] = useState("");
  const [locationId, setLocationId] = useState(null);
  const [hotels, setHotels] = useState([]);
  const [dateRange, setDateRange] = useState({ start: "", end: "" });

  const [guests, setGuests] = useState({
    rooms: 1,
    adults: 2,
    children: 0,
  });

  const [isGuestOpen, setIsGuestOpen] = useState(false);



 const handleSearch = async () => {
  if (!locationId) return alert("Пожалуйста, выберите город");
  if (!dateRange.start || !dateRange.end)
    return alert("Пожалуйста, выберите даты");

  const totalGuests = guests.adults + guests.children;

  // Формируем объект параметров поиска
  const searchParams = {
    city: location,
    locationId,
    guests: totalGuests,
    startDate: dateRange.start,
    endDate: dateRange.end,
  };

  // Сохраняем в localStorage
  localStorage.setItem("city", searchParams.city);
  localStorage.setItem("locationId", searchParams.locationId);
  localStorage.setItem("guests", searchParams.guests);
  localStorage.setItem("startDate", searchParams.startDate.toISOString());
  localStorage.setItem("endDate", searchParams.endDate.toISOString());

  try {
    // Отправляем запрос к API
    const response = await offerApi.searchOffers({
      startDate: dateRange.start.toISOString(),
      endDate: dateRange.end.toISOString(),
      guests: totalGuests,
      userDiscountPercent: 5,
      lang: language,
      cityId: locationId,
      paramItemFilters: {},
    });

    const foundHotels = response.data;
    setHotels(foundHotels);

    // Передаем результаты на SearchPage через callback
    if (onSearch) onSearch(searchParams);

    console.log("Результаты поиска:", foundHotels);
  } catch (error) {
    console.error("Ошибка поиска предложений:", error);
  }
};


  const setLocationInfo = (cityName, cityId) => {
    setLocation(cityName);
    setLocationId(cityId);
  };

  return (
    <div className={`${styles.searchBar} ${styles.searchBar_bg_color_dark} flex-left btn-w-1451 btn-h-106 btn-br-r-20 gap-20 `}>
      <div className={`${styles.searchBar__container} ${styles.searchBar__container_main} gap-20 `}>
        <div className={`${styles.searchBar__wrapper} btn-br-r-10 btn-h-72 flex-center`}>
          <CitySelector
            value={location}
            classTitle="btn-h-70 btn-w-425"
            input_classTitle="p-l-80"
            icon_title="city_big"
            icon_size="48"
            placeholder={t("Search.city")}
            onChange={setLocationInfo} />
        </div>

        <DateRangeInput
          dateRange={dateRange}
          icon_title="calendar_big"
          icon_size="50"
          classTitle={`btn-h-70 `}
          setDateRange={setDateRange}
        />

        <div style={{ position: "relative" }} className={`${styles.searchBar__wrapper} btn-br-r-10 btn-h-70 btn-w-425 flex-center`}>
          <IconSvg
            name="people_big"
            size={45}
            className={styles.input_icon}
          />
          <button
            onClick={() => setIsGuestOpen(!isGuestOpen)}
            className={styles.input_guest}
          >
            {`${guests.adults + guests.children} ${t("Search.guests")}`}
          </button>
          {isGuestOpen &&
            <div className="modalOverlay">
              <AddGuestModal
                guests={guests}
                setGuests={setGuests}
                setIsModalOpen={setIsGuestOpen}
              />
            </div>
          }
        </div>

        <IconButton_Search onClick={handleSearch} icon_name="search_big" size="48" classTitle="btn-br-r-20 btn-h-72 btn-w-72" />
      </div>
    </div >
  );
}
/* Rectangle 449 */

