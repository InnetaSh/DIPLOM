import http from "./http";

export const locationApi = {
  getAllCities: (lang ) => http.get(`/Translation/city/get-all-translations/${lang}`),
  getAllCountries: (lang ) => http.get(`/Translation/country/get-all-translations/${lang}`),

  getFullCountries: (lang ) => http.get(`/Bff/get/allCountries/${lang}`),
  getCountriesWithCode: (lang ) => http.get(`/Bff/get/countries/countriesCode/${lang}`),


  getAllRegions: (lang ) => http.get(`/Translation/region/get-all-translations/${lang}`),
  getAllDistricts: (lang ) => http.get(`/Translation/district/get-all-translations/${lang}`),

 getPopularCities: (period, limit, lang) => http.get(`/Bff/statistic/top/${period}/get/city/${limit}/${lang}`), 
 getCityById: (id, lang) => http.get(`/Bff/location/get/city/${id}/${lang}`), 

 getCityAndCountryById: (id, lang) => http.get(`/Bff/city/country/get-translations/${id}/${lang}`), 


  getCountryTitle: (id) => http.get(`/Location/get-country-title/${id}`),
  getRegionTitle: (id) => http.get(`/Location/get-region-title/${id}`),
  getCityTitle: (id) => http.get(`/Location/get-city-title/${id}`),
  getDistrictTitle: (id) => http.get(`/Location/get-city-title/${id}`),
  getLocationTitles: (data) => http.post(`/Location/get-location-titles`, data),

};
