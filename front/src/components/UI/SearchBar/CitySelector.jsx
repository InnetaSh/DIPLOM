import React, { useContext, useEffect, useState } from "react";
import styles from "./SearchBar.module.css";
import { ApiContext } from "../../../contexts/ApiContext.jsx";

const CitySelector = ({ value, onChange }) => {
  const { locationApi } = useContext(ApiContext); 
  const [cities, setCities] = useState([]);
  const [search, setSearch] = useState(value || ""); // используем value
  const [suggestions, setSuggestions] = useState([]);

  useEffect(() => {
    locationApi.getAllCities().then((res) => {
      setCities(res.data); 
      console.log("Add: cities loaded", res.data);
    });
  }, [locationApi]);


  useEffect(() => {
    setSearch(value || "");
  }, [value]);



  const handleChange = (e) => {
    const value = e.target.value;
    setSearch(value);


    if (value.length > 0) {
      const filtered = cities.filter((city) =>
        city.title.toLowerCase().startsWith(value.toLowerCase())
      );
      setSuggestions(filtered);
    } else {
      setSuggestions([]);
    }
  };

  const handleSelect = (city) => {
    setSearch(city.title);
    setSuggestions([]);
    if (onChange) onChange(city.title, city.id); 
  };

  return (
    <div style={{ position: "relative" }}>
      <input 
        type="text"
        placeholder="Город"
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

export default CitySelector;
