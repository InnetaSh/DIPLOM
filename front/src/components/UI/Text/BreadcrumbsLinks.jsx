import { Link } from "react-router-dom";
import { ApiContext } from "../../../contexts/ApiContext.jsx";
import React, { useState, useEffect, useContext, useMemo } from "react";
import { useLanguage } from "../../../contexts/LanguageContext";
import { useNavigate, useSearchParams } from "react-router-dom";
import { useTranslation } from "react-i18next";
import styles from "./Text.module.css";

export const Breadcrumbs = ({
  country = "",
  region = "",
  city = "",
  district = "",
  hotelTitle = "",
  last_path = ""
}) => {
  const { t } = useTranslation();
  const navigate = useNavigate();
  const { language } = useLanguage();
  const [params] = useSearchParams();
  const { locationApi } = useContext(ApiContext);

  const [countryId, setCountryId] = useState(null);
  const [regionId, setRegionId] = useState(null);

  const cityId = params.get("cityId");
  const urlCountryId = params.get("countryId");
  const urlRegionId = params.get("regionId");

 
  useEffect(() => {
    if (!cityId || cityId === "null") return;

    const loadCity = async () => {
      try {
        const res = await locationApi.getCityAndCountryById(cityId, language);
        setCountryId(res.data.countryId);
        setRegionId(res.data.regionId);
      } catch (e) {
        console.warn("Ошибка получения города");
      }
    };

    loadCity();
  }, [cityId, language]);

  // Даты
  const startDate = params.get("startDate") || new Date().toISOString();
  const endDate =
    params.get("endDate") ||
    new Date(Date.now() + 86400000).toISOString();

  const adults = Number(params.get("adults") || 1);
  const children = Number(params.get("children") || 0);
  const rooms = Number(params.get("rooms") || 1);


  const breadcrumbs = useMemo(() => {
    const arr = [];

    if (cityId && cityId !== "null") {
      if (country) arr.push({ label: country, type: "country" });
      if (region) arr.push({ label: region, type: "region" });
      if (city) arr.push({ label: city, type: "city" });
    } else if (urlRegionId && urlRegionId !== "null") {
      if (country) arr.push({ label: country, type: "country" });
      if (region) arr.push({ label: region, type: "region" });
    } else if (urlCountryId && urlCountryId !== "null") {
      if (country) arr.push({ label: country, type: "country" });
    }

    if (district?.trim()) arr.push({ label: district, type: "district" });
    if (last_path?.trim()) arr.push({ label: last_path, type: "custom" });
    if (hotelTitle?.trim()) arr.push({ label: hotelTitle, type: "custom" });

    return arr;
  }, [
    cityId,
    urlRegionId,
    urlCountryId,
    country,
    region,
    city,
    district,
    last_path,
    hotelTitle
  ]);

  const handleClick = (item) => {
    if (item.type === "home") {
      navigate("/");
      return;
    }

    let newParams = {
      countryId: null,
      regionId: null,
      cityId: null
    };

    if (item.type === "country") {
      newParams.countryId = countryId || urlCountryId;
    }

    if (item.type === "region") {
      newParams.countryId = countryId || urlCountryId;
      newParams.regionId = regionId || urlRegionId;
    }

    if (item.type === "city") {
      newParams.countryId = countryId;
      newParams.regionId = regionId;
      newParams.cityId = cityId;
    }

    const finalParams = {
      ...newParams,
      startDate,
      endDate,
      adults,
      children,
      rooms,
      params: ""
    };

    const searchParams = new URLSearchParams(finalParams);
    navigate(`/search?${searchParams.toString()}`);
  };

  const allItems = [
    { label: t("menu_home"), type: "home" },
    ...breadcrumbs
  ];

  return (
    <div className={styles.breadcrumbs}>
      {allItems.map((item, index) => {
        const isLast = index === allItems.length - 1;

        return (
          <div key={index} className={styles.item}>
            {!isLast ? (
              <Link
                to="#"
                className={styles.breadcrumbs_link}
                onClick={(e) => {
                  e.preventDefault();
                  handleClick(item);
                }}
              >
                {item.label}
              </Link>
            ) : (
              <span className={styles.disabled}>{item.label}</span>
            )}

            {index < allItems.length - 1 && (
              <svg className={styles.icon} width="11" height="15">
                <use href="/img/sprite.svg#breadcrumbs_next_icon" />
              </svg>
            )}
          </div>
        );
      })}
    </div>
  );
};