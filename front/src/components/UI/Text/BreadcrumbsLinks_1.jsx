import { Link } from "react-router-dom";
import { ApiContext } from "../../../contexts/ApiContext.jsx";
import React, { useState, useEffect, useContext, useMemo } from "react";
import { useLanguage } from "../../../contexts/LanguageContext";
import { useNavigate } from "react-router-dom";

import { useTranslation } from "react-i18next";

import { useSearchParams } from "react-router-dom";
import styles from "./Text.module.css";

export const Breadcrumbs = ({
  country = " ",
  region = " ",
  city = "",
  district,
  hotelTitle,
  last_path = ""
}) => {
  const { t } = useTranslation();
    const navigate = useNavigate();
    const { language } = useLanguage();
  const [paramsFromRoute] = useSearchParams();
    const { locationApi } = useContext(ApiContext);

  const parts = [
    country && country.trim() && {
      label: country,
      to: `/country/${encodeURIComponent(country)}`
    },
    region && region.trim() && {
      label: region,
      to: `/region/${encodeURIComponent(region)}`
    },
    city && city.trim() && {
      label: city,
      to: `/city/${encodeURIComponent(city)}`
    },
    district && district.trim() && {
      label: district,
      to: `/district/${encodeURIComponent(district)}`
    }
  ].filter(Boolean);

  const startDateStr = paramsFromRoute.get("startDate") || localStorage.getItem("startDate") || new Date().toISOString();
  const endDateStr = paramsFromRoute.get("endDate") || localStorage.getItem("endDate") || new Date(Date.now() + 86400000).toISOString(); // завтра

   const adults = Number(paramsFromRoute.get("adults") || 1);
  const children = Number(paramsFromRoute.get("children")  || 0);
  const rooms = Number(paramsFromRoute.get("rooms") || 1);

  const cityId = paramsFromRoute.get("cityId") || null;


  const items = [
    { label: t("menu_home"), to: "/" },
    ...parts
  ];

  if (last_path && last_path.trim()) {
    items.push({ label: last_path, to: null });
  }

  if (hotelTitle && hotelTitle.trim()) {
    items.push({ label: hotelTitle, to: null });
  }
  if (items.length > 0) {
    items[items.length - 1] = {
      ...items[items.length - 1],
      to: null
    };
  }
    const formatLocalDate = (date) => {
    if (!date) return "";
    const y = date.getFullYear();
    const m = String(date.getMonth() + 1).padStart(2, "0");
    const d = String(date.getDate()).padStart(2, "0");
    return `${y}-${m}-${d}`;
  };



    const [countryId, setCountryId] = useState("");
    const [regionId, setRegionId] = useState("");
    
    
    
      useEffect(() => {
        const loadCity = async () => {
          try {
            const res = await locationApi.getCityAndCountryById(cityId, language);
            setRegionId(res.data.regionId);
            setCountryId(res.data.countryId);
            console.log("Ответ getCity:", res.data, res.data.title);
          } catch (error) {
            console.warn("API getCity недоступен, используется mock");
           
          }
        };
    
        loadCity();
      }, [cityId, language]);

  const handleBreadcrumbClick = (item) => {
    let locationIdParam = {};

    if (item.label === country) {
      locationIdParam = {
        countryId: countryId,
        regionId: null,
        cityId: null
      };
    } else if (item.label === region) {
      locationIdParam = {
        countryId: countryId,
        regionId: null,
        cityId: null
      };
    } else if (item.label === city) {
      locationIdParam = {
        countryId: null, 
        regionId: null,
        cityId: cityId
      };
    } else {

      return;
    }

    const combinedParams = {
      ...locationIdParam,
      startDate: startDateStr,
      endDate: endDateStr,
      adults: adults,
      children: children,
      rooms: rooms,
      params: "",
    };

    const searchParams = new URLSearchParams(combinedParams);
    navigate(`/search?${searchParams.toString()}`);
  };

  return (
    <div className={styles.breadcrumbs}>
      {items.map((item, index) => (
        <div key={index} className={styles.item}>
          {item.to ? (
            <Link
              to={item.to}
              className={styles.breadcrumbs_link}
              onClick={(e) => {
                e.preventDefault();
                handleBreadcrumbClick(item);
              }}
            >
              {item.label}
            </Link>
          ) : (
            <span className={styles.disabled}>{item.label}</span>
          )}

          {index < items.length - 1 && (
            <svg className={styles.icon} width="11" height="15">
              <use href="/img/sprite.svg#breadcrumbs_next_icon" />
            </svg>
          )}
        </div>
      ))}
    </div>
  );
};
