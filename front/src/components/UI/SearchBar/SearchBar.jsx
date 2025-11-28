import React, { useState } from "react";
import CitySelector from "./CitySelector.jsx";

import styles from "./SearchBar.module.css";
import { PrimaryButton } from "../Button/PrimaryButton.jsx";
import AddGuestModal from "../../modals/AddGuestModal.jsx";
import { offerApi } from "../../../api/offer.js"; 

export default function SearchBar({ onSearch }) {
  const [location, setLocation] = useState(""); 
  const [dateRange, setDateRange] = useState({ start: "", end: "" });
  const [guests, setGuests] = useState({ adults: 1, children: 0, rooms: 1 });
  const [isGuestOpen, setIsGuestOpen] = useState(false);

const handleSearch = async () => {
  if (!location) {
    alert("Пожалуйста, выберите город");
    return;
  }
  if (!dateRange.start || !dateRange.end) {
    alert("Пожалуйста, выберите даты");
    return;
  }

  try {
    const response = await offerApi.searchMain({
      city: location,
      startDate: dateRange.start,
      endDate: dateRange.end,
      bedroomsCount: guests.adults + guests.children,
      userDiscountPercent: 0, 
    });

    console.log("Результат поиска предложений:", response.data); 

    if (onSearch) onSearch(response.data);
  } catch (error) {
    console.error("Ошибка поиска предложений:", error);
  }
};

  return (
    <div className={styles.searchBar}>
      <div className={`${styles.inputGroup} ${styles.input_wrapper}`}>
        <CitySelector value={location} onChange={setLocation} />
      </div>

      <div className={`${styles.inputGroup} ${styles.input_wrapper}`}>
        <input
          className={styles.input_item}
          type="date"
          value={dateRange.start}
          onChange={(e) =>
            setDateRange((prev) => ({ ...prev, start: e.target.value }))
          }
        />
        <span>—</span>
        <input
          className={styles.input_item}
          type="date"
          value={dateRange.end}
          onChange={(e) =>
            setDateRange((prev) => ({ ...prev, end: e.target.value }))
          }
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
  );
}
