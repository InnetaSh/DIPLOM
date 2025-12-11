import http from "./http";

export const locationApi = {
  getAllCities: (lang = "en") => http.get(`/bff/city/get-all-translations/${lang}`),


  getCountryTitle: (id) => http.get(`/Location/get-country-title/${id}`),
  getRegionTitle: (id) => http.get(`/Location/get-region-title/${id}`),
  getCityTitle: (id) => http.get(`/Location/get-city-title/${id}`),
  getDistrictTitle: (id) => http.get(`/Location/get-city-title/${id}`),
  getLocationTitles: (data) => http.post(`/Location/get-location-titles`, data),

};
