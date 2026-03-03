import React, { useContext, useEffect, useState } from "react";
import { ApiContext } from "../../contexts/ApiContext.jsx";
import { useLanguage } from "../../contexts/LanguageContext.jsx";

import { IconSvg } from "../UI/Image/IconSvg.jsx";

import styles from "./SearchBar.module.css";

export const CitySelector = ({
  value,
  onChange,
  classTitle = "btn-h-35 btn-w-276",
  input_classTitle = "p-l-50",
  icon_title = "city",
  icon_size = "18",
  placeholder
}) => {
  const { locationApi } = useContext(ApiContext);
  const { language } = useLanguage();
  const [cities, setCities] = useState([]);
  const [search, setSearch] = useState(value || ""); // используем value
  const [suggestions, setSuggestions] = useState([]);

  useEffect(() => {
    locationApi.getAllCities(language)
      .then((res) => {
        setCities(res.data || []);
        console.log("cities loaded:", res.data);
      })
      .catch((err) => {
        console.error("Error loading cities:", err);
      });
  }, []);

  useEffect(() => {
    if (!value || cities.length === 0) return;

    const selectedCity = cities.find(c => c.entityId === value);
    if (selectedCity) setSearch(selectedCity.title);
  }, [value, cities]);

  useEffect(() => {
    setSearch(value || "");
  }, [value]);



 const handleChange = (e) => {
    const val = e.target.value;
    setSearch(val);

    if (val.length > 0) {
      const filtered = cities.filter(city =>
        city.title.toLowerCase().startsWith(val.toLowerCase())
      );
      setSuggestions(filtered);
    } else {
      setSuggestions([]);
    }
  };

  
  const handleSelect = (city) => {
    setSearch(city.title);
    setSuggestions([]);
    if (onChange) onChange(city.title, city.entityId);
  };

  return (
    <div style={{ position: "relative" }} className={`${styles.searchBar__container} ${classTitle} btn-br-r-10  flex-between `}>
      <IconSvg
        name={icon_title}
        size={icon_size}
        className={styles.input_icon}
      />
      <input
        type="text"
        placeholder={placeholder}
        className={`${styles.input_city} ${input_classTitle} btn-h-35`}
        value={search}
        onChange={handleChange}
      />
      {suggestions.length > 0 && (
        <ul className={styles.suggestions_wrapper}>
          {suggestions.map((city) => (
            <li
              key={city.id}
              onClick={() => handleSelect(city)}
              style={{ padding: "5px", cursor: "pointer" }}
            >
              {city.title}
            </li>
          ))}
        </ul>
      )}
    </div>
  );
};


