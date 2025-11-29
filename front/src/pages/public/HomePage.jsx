import React, { useState, useEffect,useContext } from "react";
import { Header } from "../../components/Header.jsx";
import { Breadcrumbs } from "../../components/UI/Text/BreadcrumbsLinks.jsx";
import { HotelCardList } from "../../components/HotelCard/HotelCardList.jsx";
import { FilterSidebar } from "../../components/Filter/FilterSidebar.jsx";
import { Text } from "../../components/UI/Text/Text.jsx";
import { ApiContext } from "../../contexts/ApiContext.jsx";

import "../../styles/globals.css";

const HomePage = () => {
  const { paramsCategoryApi } = useContext(ApiContext); 
  const [hotels, setHotels] = useState([]);
  const [city, setCity] = useState("");

  const [filtersData, setFiltersData] = useState([]); // массив категорий с items
  const [selectedFilters, setSelectedFilters] = useState({});


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

  const filteredHotels = hotels.filter((hotel) => {
    return Object.entries(selectedFilters).every(([category, values]) => {
      if (!values.length) return true;
      return values.includes(hotel[category]);
    });
  });

  return (
    <div className="search-page">
      <Header onSearchResults={handleSearchResults} />

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
            {filteredHotels.length !== 0 && (
              <Text text={`${city}: найдено вариантов ${filteredHotels.length}`} type="title" />
            )}

            <HotelCardList hotels={filteredHotels} />
          </section>
        </div>
      </main>
    </div>
  );
};

export default HomePage;
