import React, { useState, useContext } from "react";
import { useTranslation } from "react-i18next";
import { ApiContext } from "../../contexts/ApiContext.jsx";
import { useLanguage } from "../../contexts/LanguageContext.jsx";
import { AddGuestModal } from "../modals/AddGuestModal.jsx";
import { CitySelector } from "./CitySelector.jsx";
import { DateRangeInput } from "./DateRangeInput";
import { IconSvg } from "../UI/Image/IconSvg.jsx";
import { IconButton_Search } from "../UI/Button/IconButton_Search.jsx";

import styles from "./SearchBar.module.css";

export const SearchBar = ({
  onSearch,
  classNameWidth = "btn-w-960",
  classNameHeight = "btn-h-50",
  className
}) => {
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

    console.log("Initiating search with parameters:", {
      locationId,
      dateRange,
      guests,
      totalGuests,
      language,
    paramItemFilters: {}
    });

    try {
      const response = await offerApi.searchOffers({
       startDate: dateRange.start.toISOString(),
    endDate: dateRange.end.toISOString(),
        guests: totalGuests,
        userDiscountPercent: 5,
        lang: language,
        cityId: locationId,
        paramItemFilters: {} // пустой объект фильтров
      });

      const foundHotels = response.data;
      setHotels(foundHotels);

      if (onSearch) {
        onSearch(
          foundHotels,
          location,
          totalGuests,
          dateRange.start,
          dateRange.end
        );
      }

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
    <div
      className={`${styles.searchBar} ${styles.searchBar_bg_color_dark} ${className} flex-between btn-br-r-20 ${classNameWidth} ${classNameHeight}`}
    >
      <div className={`${styles.searchBar__container} gap-20 flex-center`}>
        <div
          className={`${styles.searchBar__wrapper} btn-br-r-10 btn-h-35 btn-w-276 flex-center`}
        >
          <CitySelector
            value={location}
            onChange={setLocationInfo}
            placeholder={t("Search.city")}
          />
        </div>

        <DateRangeInput
          dateRange={dateRange}
          setDateRange={setDateRange}
        />

        <div
          style={{ position: "relative" }}
          className={`${styles.searchBar__wrapper} btn-br-r-10 btn-h-35 btn-w-276 flex-center`}
        >
          <IconSvg
            name="people"
            size={18}
            className={styles.input_icon}
          />

          <button
            onClick={() => setIsGuestOpen(!isGuestOpen)}
            className={styles.input_guest}
          >
            {`${guests.adults + guests.children} ${t("Search.guests")}`}
          </button>

          {isGuestOpen && (
            <div className="modalOverlay">
              <AddGuestModal
                guests={guests}
                setGuests={setGuests}
                setIsModalOpen={setIsGuestOpen}
              />
            </div>
          )}
        </div>

        <IconButton_Search onClick={handleSearch} icon_name="search" />
      </div>
    </div>
  );
};
