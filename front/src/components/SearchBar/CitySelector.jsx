import React, { useContext, useEffect, useState } from "react";
import { ApiContext } from "../../contexts/ApiContext.jsx";
import { useLanguage } from "../../contexts/LanguageContext.jsx";

import { IconSvg } from "../UI/Image/IconSvg.jsx";

import styles from "./SearchBar.module.css";

export const CitySelector = ({
  value,
  onChange,
  classTitle = "btn-h-35 btn-w-276",
  input_classTitle = styles.input_city_txt,
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
    const loadCities = async () => {
      const keyUk = "cities_uk";
      const keyEn = "cities_en";

      let citiesUk = localStorage.getItem(keyUk);
      let citiesEn = localStorage.getItem(keyEn);

      if (!citiesUk) {
        const resUk = await locationApi.getAllCities("uk");
        citiesUk = resUk.data || [];
        localStorage.setItem(keyUk, JSON.stringify(citiesUk));
      } else {
        citiesUk = JSON.parse(citiesUk);
      }

      if (!citiesEn) {
        const resEn = await locationApi.getAllCities("en");
        citiesEn = resEn.data || [];
        localStorage.setItem(keyEn, JSON.stringify(citiesEn));
      } else {
        citiesEn = JSON.parse(citiesEn);
      }

      const merged = Object.values(
        [...citiesUk, ...citiesEn].reduce((acc, city) => {
          const id = city.entityId;

          if (!acc[id]) {
            acc[id] = {
              entityId: id,
              slug: city.slug,
              titles: {}
            };
          }

          citiesUk.forEach(city => {
            if (!acc[city.entityId]) {
              acc[city.entityId] = {
                entityId: city.entityId,
                slug: city.slug,
                titles: {}
              };
            }

            acc[city.entityId].titles.uk = city.title;
          });

          citiesEn.forEach(city => {
            if (!acc[city.entityId]) {
              acc[city.entityId] = {
                entityId: city.entityId,
                slug: city.slug,
                titles: {}
              };
            }

            acc[city.entityId].titles.en = city.title;
          });


          return acc;
        }, {})
      );

      setCities(merged);
    };

    loadCities().catch(console.error);
  }, []);


  useEffect(() => {
    if (!value || cities.length === 0) return;

    const selectedCity = cities.find(c => c.entityId === value);
    if (selectedCity) setSearch(selectedCity.title);
  }, [value, cities]);

  useEffect(() => {
    setSearch(value || "");
  }, [value]);



  const normalize = (str) =>
    str?.toLowerCase().trim();

  const handleChange = (e) => {
    const val = e.target.value;
    setSearch(val);

    if (val.length > 0) {
      const filtered = cities.filter(city =>
        Object.values(city.titles).some(title =>
          normalize(title).startsWith(normalize(val))
        )
      );

      setSuggestions(filtered);
    } else {
      setSuggestions([]);
    }
  };


  const handleSelect = (city) => {
    const title = city.titles[language] || city.titles["uk"];

    setSearch(title);
    setSuggestions([]);

    if (onChange) onChange(title, city.entityId, city.slug);
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
      {/* {suggestions.length > 0 && (
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
      )} */}

      {suggestions.length > 0 && (
        <ul className={styles.suggestions_wrapper}>
          {suggestions.map((city) => (
            <li
              key={city.entityId}
              onClick={() => handleSelect(city)}
              style={{ padding: "5px", cursor: "pointer" }}
            >
              {city.titles[language] || city.titles["uk"]}
            </li>
          ))}

        </ul>
      )}
    </div>
  );
};


