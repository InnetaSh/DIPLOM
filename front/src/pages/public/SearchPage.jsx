import React, { useState, useEffect, useContext, useMemo } from "react";
import { useLocation } from "react-router-dom";
import { useSearchParams } from "react-router-dom";

import { offerApi } from "../../api/offer.js";
import { Header_Full } from "../../components/Header/Header_Full.jsx";

import { Footer } from "../../components/Footer/Footer.jsx";
import { FilterSidebar } from "../../components/Filter/FilterSidebar.jsx";
import { HotelCardList } from "../../components/HotelCard/HotelCardList.jsx";
import { Spinner } from "../../components/UI/Spinner.jsx";
import { ApiContext } from "../../contexts/ApiContext.jsx";
import { useLanguage } from "../../contexts/LanguageContext";

import styles from "./SearchPage.module.css";



export const SearchPage = ({ defaultCityId }) => {
  const { offerApi, paramsCategoryApi,userApi,locationApi } = useContext(ApiContext);
  const { language } = useLanguage();
  const [searchParams] = useSearchParams();

  const cityId = searchParams.get("cityId") || localStorage.getItem("locationId") || null;
  const regionId = searchParams.get("regionId")  || null;
  const countryId = searchParams.get("countryId")  || null;


  const startDateStr = searchParams.get("startDate") || localStorage.getItem("startDate") || new Date().toISOString();
  const endDateStr = searchParams.get("endDate") || localStorage.getItem("endDate") || new Date(Date.now() + 86400000).toISOString(); // завтра

  const adults = Number(searchParams.get("adults") || localStorage.getItem("adults") || 1);
  const children = Number(searchParams.get("children") || localStorage.getItem("children") || 0);
  const rooms = Number(searchParams.get("rooms") || localStorage.getItem("rooms") || 1);

  const paramsStr = searchParams.get("params") || "";

  const paramsFromUrl = {};

  if (paramsStr) {
    paramsStr.split(",").forEach(pair => {
      const [key, value] = pair.split(":");
      if (!isNaN(value)) {
        paramsFromUrl[key] = Number(value);
      } else if (value === "true") {
        paramsFromUrl[key] = true;
      } else if (value === "false") {
        paramsFromUrl[key] = false;
      } else {
        paramsFromUrl[key] = value;
      }
    });
  }

  console.log("paramsFromUrl:", paramsFromUrl);



  const [hotels, setHotels] = useState([]);
  const [filtersData, setFiltersData] = useState([]);
  const [openFilterMenu, setOpenFilterMenu] = useState(false);
  const [loading, setLoading] = useState(false);

  const startDate = useMemo(() => new Date(startDateStr), [startDateStr]);
  const endDate = useMemo(() => new Date(endDateStr), [endDateStr]);
  const [paramsString, setParamsString] = useState("");
  const [params, setParams] = useState(paramsFromUrl);

  const [sortType, setSortType] = useState("recommended");


  const [country, setCountry] = useState("");
  const [region, setRegion] = useState("");
  const [city, setCity] = useState("");
  
  
  
    useEffect(() => {
      const loadCity = async () => {
        try {
          const res = await locationApi.getCityAndCountryById(cityId, language);
          setCity(res.data.title);
          setRegion(res.data.regionTitle);
          setCountry(res.data.countryTitle);
          console.log("Ответ getCity:", res.data, res.data.title);
        } catch (error) {
          console.warn("API getCity недоступен, используется mock");
          setCity("");
        }
      };
  
      loadCity();
    }, [cityId, language]);


  useEffect(() => {
    

    const fetchHotels = async () => {
      setLoading(true);
      document.body.style.cursor = "wait";
const safeCityId = cityId && cityId !== "null" ? Number(cityId) : null;
const safeRegionId = regionId && regionId !== "null" ? Number(regionId) : null;
const safeCountryId = countryId && countryId !== "null" ? Number(countryId) : null;
      try {
        const response = await offerApi.searchOffers({
          cityId: safeCityId,
          regionId: safeRegionId,
  countryId: safeCountryId, 
          startDate: startDate.toISOString(),
          endDate: endDate.toISOString(),   
          adults,
          children,
          rooms,
          userDiscountPercent: 5,
          lang: language,
          paramItemFilters: paramsString,
        });

        setHotels(response.data);
      } catch (error) {
        console.error("Ошибка загрузки:", error);
      } finally {
        setLoading(false);
        document.body.style.cursor = "default";
      }
    };

    fetchHotels();
  }, [cityId, startDate, endDate, adults, children, rooms, language, paramsString]);


  useEffect(() => {
    paramsCategoryApi
      .getAllCategories(language)
      .then((res) => {
        console.log("Ответ API:", res);
        console.log("Данные:", res.data);
        setFiltersData(res.data);
      })
      .catch((err) => {
        console.warn("Ошибка загрузки фильтров", err);
      });
  }, [paramsCategoryApi, language]);


  const handleSearchResults = (foundHotels, newCity, adultsVal, childrenVal, roomsVal, start, end, locId) => {
    setHotels(foundHotels);
    localStorage.setItem("city", newCity);
    localStorage.setItem("locationId", locId);
    localStorage.setItem("adults", adultsVal);
    localStorage.setItem("children", childrenVal);
    localStorage.setItem("rooms", roomsVal);
    localStorage.setItem("startDate", start);
    localStorage.setItem("endDate", end);
    localStorage.setItem("hotels", JSON.stringify(foundHotels));
  };

  const handleSortChange = (type) => {
    setSortType(type);
  };


  const sortedHotels = useMemo(() => {
    const sorted = [...hotels];

    switch (sortType) {
      case "priceAsc":
        return sorted.sort((a, b) => a.price - b.price);

      case "priceDesc":
        return sorted.sort((a, b) => b.price - a.price);

      case "ratingAsc":
        return sorted.sort((a, b) => a.rating - b.rating);

      case "ratingDesc":
        return sorted.sort((a, b) => b.rating - a.rating);

      default:
        return sorted;
    }
  }, [hotels, sortType]);



   const [myHistoryIdList, setMyHistoryIdList] = useState([]);


  useEffect(() => {

    userApi
      .getMyHistoryId(language)
      .then((res) => {
        setMyHistoryIdList(res.data || []);
      })
      .catch(() => {
        setMyHistoryIdList([]);
      })
      .finally(() => {
       
      });
  }, [language]);


  return (
    <div className={styles.searchPage}>
      <Header_Full
        city={city}
        region={region}
        country={country}
        adults={adults}
        rooms={rooms}
        children={children}
        startDate={startDate}
        endDate={endDate}
        params={params}
        openFilterMenu={openFilterMenu}
        setOpenFilterMenu={setOpenFilterMenu}
        handleSearchResults={handleSearchResults}
        handleSortChange={handleSortChange}
      />

      <main>
        {loading ? (
          <Spinner loading={true} />
        ) : (
          <>
            <div className={styles.searchPage__container}>

              <div
                className={styles.searchPage__container__list}
                style={{
                  width: openFilterMenu
                    ? `calc(100% - 424px - 20px)`
                    : "100%",
                  transition: "width 0.2s ease",
                }}
              >
                <HotelCardList
                  hotels={sortedHotels}
                  myHistoryIdList={myHistoryIdList}
                  adults={adults}
                  children={children}
                  startDate={startDate}
                  endDate={endDate}
                />
              </div>
              {openFilterMenu && (
                <aside className={styles.searchPage__filters}>
                  <FilterSidebar
                    city={city}
                    setParamsString={setParamsString}
                    params={params}
                    setParams={setParams}
                    filtersData={filtersData}
                  />
                </aside>
              )}
            </div>
          </>
        )}
      </main>

      <Footer />
    </div>
  );
};
