import React, { useState, useEffect,useContext } from "react";
import { Header } from "../../components/Header/Header.jsx";
import {SearchBar} from"../../components/SearchBar/SearchBar.jsx";
import { Breadcrumbs } from "../../components/UI/Text/BreadcrumbsLinks.jsx";
import { HotelCardList } from "../../components/HotelCard/HotelCardList.jsx";
import { FilterSidebar } from "../../components/Filter/FilterSidebar.jsx";
import { Text } from "../../components/UI/Text/Text.jsx";
import { ApiContext } from "../../contexts/ApiContext.jsx";

import "../../styles/globals.css";

export const SearchPage = () => {
  const { paramsCategoryApi, offerApi } = useContext(ApiContext); 
  const [hotels, setHotels] = useState([]);
  const [city, setCity] = useState("");

  const [filtersData, setFiltersData] = useState([]); 
  const [selectedFilters, setSelectedFilters] = useState({});
  //const [filteredHotels, setFilteredHotels] = useState({});


useEffect(() => {
  paramsCategoryApi.getAll()
    .then((res) => {
      setFiltersData(res.data);      
      console.log("Filters loaded:", res.data);
    })
    .catch((err) => console.error("Error loading filters:", err));
}, [paramsCategoryApi]);



  const handleFilterChange = (category, option) => {
    setSelectedFilters((prev) => {
      const selected = prev[category] || [];
      if (selected.includes(option)) {
        return { ...prev, [category]: selected.filter((v) => v !== option) };
      } else {
        return { ...prev, [category]: [...selected, option] };
      }
    });
  };

  const handleSearchResults = (foundHotels, onSearchCity) => {
    console.log("Search results received in HomePage:", foundHotels, onSearchCity);
    setCity(onSearchCity);
    setHotels(foundHotels);
    setSelectedFilters({});
  };



  return (
    <div className="search-page">
      <Header onSearchResults={handleSearchResults} />
  <SearchBar onSearch={handleSearchResults} text="Найдите жилье для новой поездки"/>
      <main className="search-page__content">
        <Breadcrumbs />

        <div className="search-page__layout">
          <aside className="search-page__filters">
            <FilterSidebar
              filtersData={filtersData}
              selectedFilters={selectedFilters}
              onFilterChange={handleFilterChange}
            />
          </aside>
          <section className="search-page__list">
            {hotels.length !== 0 && (
              <Text text={`${city}: найдено вариантов ${hotels.length}`} type="title" />
            )}

            <HotelCardList hotels={hotels} />
          </section>
        </div>
      </main>
    </div>
  );
};


