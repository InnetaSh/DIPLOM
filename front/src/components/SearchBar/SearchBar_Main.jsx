import React, { useState } from "react";
import CitySelector from "./CitySelector.jsx";
import { useTranslation } from "react-i18next";
import { PrimaryButton } from "../UI/Button/PrimaryButton.jsx";
import { AddGuestModal } from "../modals/AddGuestModal.jsx";
import { offerApi } from "../../api/offer.js";
import { DateRangeInput } from "./DateRangeInput.jsx";
import { IconSvg } from "../UI/Image/IconSvg.jsx";
import { IconButton_Search } from "../UI/Button/IconButton_Search.jsx";

import styles from "./SearchBar.module.css";
import { Text } from "../UI/Text/Text.jsx";

export const SearchBar_Main = ({ onSearch, text }) => {
  const [location, setLocation] = useState("");
  const [locationId, setLocationId] = useState(null);
  const [hotels, setHotels] = useState([]);
  const [dateRange, setDateRange] = useState({ start: "", end: "" });
  const [guests, setGuests] = useState({ adults: 1, children: 0, rooms: 1 });
  const [guestsCount, setGuestsCount] = useState(1);
  const [isGuestOpen, setIsGuestOpen] = useState(false);

  // const handleSearch = async () => {
  //   if (!locationId) return alert("Пожалуйста, выберите город");
  //   if (!dateRange.start || !dateRange.end) return alert("Пожалуйста, выберите даты");
  //   console.log("Initiating search with parameters:", {
  //     locationId,
  //     dateRange,
  //     guests,
  //   });
  //   try {
  //     const response = await offerApi.searchMain({
  //       startDate: dateRange.start,
  //       endDate: dateRange.end,
  //       guests: guests.adults + guests.children,
  //       userDiscountPercent: 5,
  //     });

  //     const foundHotels = response.data;
  //     setGuestsCount(guests.adults + guests.children);
  //     setHotels(foundHotels);

  //     if (onSearch) {
  //       onSearch(foundHotels, location, guestsCount, dateRange.start, dateRange.end);
  //     }

  //     console.log("Результаты поиска:", foundHotels);
  //   } catch (error) {
  //     console.error("Ошибка поиска предложений:", error);
  //   }
  // };
  const handleSearch = () => {
    // if (!locationId) return alert("Выберите город");
    // if (!dateRange.start || !dateRange.end) return alert("Выберите даты");

    onSearch({
      city: location,
      cityId: locationId,
      guests: guests.adults + guests.children,
      startDate: dateRange.start,
      endDate: dateRange.end,
    });
  };


  const setLocationInfo = (cityName, cityId) => {
    setLocation(cityName);
    setLocationId(cityId);
    console.log("City ID set to:", cityId);
    console.log("Selected city:", cityName, "with ID:", locationId);
  };
  const { t } = useTranslation();
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

