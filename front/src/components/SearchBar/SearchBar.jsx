import React, { useState, useEffect, useContext } from "react";
import { useSearchParams } from "react-router-dom";
import { useTranslation } from "react-i18next";
import { useNavigate } from "react-router-dom";
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
   params = {},
  classNameWidth = "btn-w-960",
  classNameHeight = "btn-h-50",
  className
}) => {
  const { t } = useTranslation();
  const { offerApi } = useContext(ApiContext);

  const { language } = useLanguage();
  const navigate = useNavigate();

  const [searchParams] = useSearchParams();
  const cityId = searchParams.get("cityId") || localStorage.getItem("locationId") || null;
  const cityName =  "";
  const adults = Number(searchParams.get("adults") || localStorage.getItem("adults") || 1);
  const children = Number(searchParams.get("children") || localStorage.getItem("children") || 0);
  const rooms = Number(searchParams.get("rooms") || localStorage.getItem("rooms") || 1);

  const parseLocalDate = (str) => {
    if (!str) return null;
    const parts = str.split("-");
    if (parts.length !== 3) return null;
    const [year, month, day] = parts.map(Number);
    if (!year || !month || !day) return null;
    return new Date(year, month - 1, day); 
  };

  const today = new Date();

  const startDateStr =
    searchParams.get("startDate") ||
    localStorage.getItem("startDate") ||
    `${today.getFullYear()}-${String(today.getMonth() + 1).padStart(2, '0')}-${String(today.getDate()).padStart(2, '0')}`;

  const endDateStr =
    searchParams.get("endDate") ||
    localStorage.getItem("endDate") ||
    `${today.getFullYear()}-${String(today.getMonth() + 1).padStart(2, '0')}-${String(today.getDate() + 1).padStart(2, '0')}`;

  const [dateRange, setDateRange] = useState({
    start: parseLocalDate(startDateStr),
    end: parseLocalDate(endDateStr),
  });


  console.log("Time-");
  console.log({ startDateStr, endDateStr, dateRange });
  console.log({ dateRange });
  const [location, setLocation] = useState("");
  const [locationId, setLocationId] = useState(null);
  const [slug, setSlug] = useState("");
  const [hotels, setHotels] = useState([]);

console.log({locationT: location, locationId, slug});


  // useEffect(() => {
  //   if (cityId) {
  //     setLocationId(cityId);
  //     const storedCityName = localStorage.getItem("city");
  //     if (storedCityName) setLocation(storedCityName);
  //   }
  // }, [cityId]);



  const [guests, setGuests] = useState({
    rooms: rooms,
    adults: adults,
    children: children,
  });

  const [isGuestOpen, setIsGuestOpen] = useState(false);

  const formatLocalDate = (date) => {
    if (!date) return "";
    const y = date.getFullYear();
    const m = String(date.getMonth() + 1).padStart(2, "0");
    const d = String(date.getDate()).padStart(2, "0");
    return `${y}-${m}-${d}`;
  };

  const handleSearch = () => {
    if (!locationId) {
      alert("Пожалуйста, выберите город");
      return;
    }

    if (!dateRange.start || !dateRange.end) {
      alert("Пожалуйста, выберите даты");
      return;
    }

    const combinedParams = {
      cityId: locationId,
        countryId: null,
      regionId: null,
      startDate: formatLocalDate(dateRange.start),
      endDate: formatLocalDate(dateRange.end),
      adults: guests.adults,
      children: guests.children,
      rooms: guests.rooms,
      params: Object.entries(params)
        .map(([key, val]) => `${key}:${val}`)
        .join(","),
    };

    const searchParams = new URLSearchParams(combinedParams);
    navigate(`/search?${searchParams.toString()}`);

  };


  const setLocationInfo = (cityName, cityId, slug) => {
    setLocation(cityName);
    setLocationId(cityId);
    setSlug(slug);
  };

 


  return (
    <div
      className={`${styles.searchBar} ${styles.searchBar_bg_color_dark}   ${styles.searchBar_txt} ${className} flex-between btn-br-r-20 ${classNameWidth} ${classNameHeight}`}
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
          icon_title="calendar"
          icon_size={18}
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
            className={`${styles.input_guest} ${styles.input_guest_txt}`}
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
