import React, { useState } from "react";
import CitySelector from "./CitySelector.jsx";
import styles from "./SearchBar.module.css";
import { PrimaryButton } from "../UI/Button/PrimaryButton.jsx";
import AddGuestModal from "../modals/AddGuestModal.jsx";
import { offerApi } from "../../api/offer.js";
import {Text} from "../UI/Text/Text.jsx";

export const  SearchBar=({ onSearch, text })=> {
  const [location, setLocation] = useState("");
  const [locationId, setLocationId] = useState(null);
  const [hotels, setHotels] = useState([]);
  const [dateRange, setDateRange] = useState({ start: "", end: "" });
  const [guests, setGuests] = useState({ adults: 1, children: 0, rooms: 1 });
  const [guestsCount, setGuestsCount] = useState(1);
  const [isGuestOpen, setIsGuestOpen] = useState(false);

  const handleSearch = async () => {
    if (!locationId) return alert("Пожалуйста, выберите город");
    if (!dateRange.start || !dateRange.end) return alert("Пожалуйста, выберите даты");
    console.log("Initiating search with parameters:", {
      locationId,
      dateRange,
      guests,
    });
    try {
      const response = await offerApi.searchMain({
        startDate: dateRange.start,
        endDate: dateRange.end,
        guests: guests.adults + guests.children,
        userDiscountPercent: 5,
      });

      const foundHotels = response.data;
      setGuestsCount(guests.adults + guests.children);
      setHotels(foundHotels);

      if (onSearch) {
        onSearch(foundHotels, location,guestsCount, dateRange.start, dateRange.end);
      }

      console.log("Результаты поиска:", foundHotels);
    } catch (error) {
      console.error("Ошибка поиска предложений:", error);
    }
  };

  const setLocationInfo = (cityName, cityId) => {
    setLocation(cityName);
    setLocationId(cityId);
    console.log("City ID set to:", cityId);
    console.log("Selected city:", cityName, "with ID:", locationId);
  };

  return (
    <div className={styles.searchBar}>
  <Text text ={text} type ="bold"/>
      <div className={styles.searchBarContainer}>
        <div className={`${styles.inputGroup} ${styles.input_wrapper}`}>
          <CitySelector value={location} onChange={setLocationInfo} />
        </div>

        <div className={`${styles.inputGroup} ${styles.input_wrapper}`}>
          <input
            className={styles.input_item}
            type="date"
            value={dateRange.start}
            onChange={(e) => setDateRange(prev => ({ ...prev, start: e.target.value }))}
          />
          <span>—</span>
          <input
            className={styles.input_item}
            type="date"
            value={dateRange.end}
            onChange={(e) => setDateRange(prev => ({ ...prev, end: e.target.value }))}
          />
        </div>

        <div className={`${styles.inputGroup} ${styles.input_wrapper}`}>
          <button
            onClick={() => setIsGuestOpen(!isGuestOpen)}
            className={styles.input_item}
          >
            {guests.adults} взрослых, {guests.children} детей, {guests.rooms} комнат
          </button>
          {isGuestOpen && <AddGuestModal guests={guests} setGuests={setGuests} />}
        </div>

        <PrimaryButton onClick={handleSearch}>Найти</PrimaryButton>
      </div>
    </div>
  );
}
