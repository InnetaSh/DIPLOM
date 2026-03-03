import React, { useState, useContext } from "react";
import { useTranslation } from "react-i18next";
import { useNavigate } from "react-router-dom";
import { useLanguage } from "../../contexts/LanguageContext.jsx";
import { CitySelector } from "./CitySelector.jsx";

import { AddGuestModal } from "../modals/AddGuestModal.jsx";
import { ApiContext } from "../../contexts/ApiContext.jsx";
import { Spinner } from "../UI/Spinner.jsx";
import { DateRangeInput } from "./DateRangeInput.jsx";
import { IconSvg } from "../UI/Image/IconSvg.jsx";
import { IconButton_Search } from "../UI/Button/IconButton_Search.jsx";

import styles from "./SearchBar.module.css";
import { Text } from "../UI/Text/Text.jsx";

export const SearchBar_Main = () => {

  const { t } = useTranslation();
  const { offerApi } = useContext(ApiContext);
  const { language } = useLanguage();
  const navigate = useNavigate();
  const [location, setLocation] = useState("");
  const [locationId, setLocationId] = useState(null);
  const [hotels, setHotels] = useState([]);
  const [dateRange, setDateRange] = useState({ start: "", end: "" });
  const [slug, setSlug] = useState("");
  const [guests, setGuests] = useState({
    rooms: 1,
    adults: 1,
    children: 0,
  });

  const [isGuestOpen, setIsGuestOpen] = useState(false);
  const [loading, setLoading] = useState(false);

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

    const params = new URLSearchParams({
      cityId: locationId,
      countryId: null,
      regionId: null,
      startDate: formatLocalDate(dateRange.start),
      endDate: formatLocalDate(dateRange.end),
      adults: guests.adults,
      children: guests.children,
      rooms: guests.rooms,
    });

    navigate(`/search?${params.toString()}`);
  };



  const setLocationInfo = (cityName, cityId, slug) => {
    setLocation(cityName);
    setLocationId(cityId);
    setSlug(slug);
  };


  return (
    <div className={`${styles.searchBar} ${styles.searchBar_bg_color_dark}  ${styles.searchBar_Main_txt} flex-left btn-w-1451 btn-h-106 btn-br-r-20 gap-20 `}>
      <Spinner loading={loading} />
      <div className={`${styles.searchBar__container} ${styles.searchBar__container_main} gap-20 `}>
        <div className={`${styles.searchBar__wrapper} btn-br-r-10 btn-h-72 flex-center`}>
          <CitySelector
            value={location}
            classTitle="btn-h-70 btn-w-425 "
            input_classTitle={`${styles.input_city_Main_txt}`}
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
          input_className={`${styles.input_date_title_Main_txt}`}
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
            className={`${styles.input_guest} ${styles.input_guest_Main_txt}`}
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

        <IconButton_Search onClick={handleSearch} icon_name="search_big" size="48" classTitle="btn-br-r-20 btn-h-72 btn-w-72 btn_search_border" />
      </div>
    </div >
  );
}


