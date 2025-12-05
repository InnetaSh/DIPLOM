import http from "./http";

export const locationApi = {
  getAll: () => http.get("/Location/get-all"),
  getById: (id) => http.get(`/Location/get/${id}`),
  getAllCities: () => http.get(`/Location/get-all-cities/`),
  create: (data) => http.post("/Location/create", data),
  update: (id, data) => http.put(`/Location/update/${id}`, data),
  delete: (id) => http.delete(`/Location/del/${id}`),

  getCountryTitle: (id) => http.get(`/Location/get-country-title/${id}`),  
  getRegionTitle: (id) => http.get(`/Location/get-region-title/${id}`),  
  getCityTitle: (id) => http.get(`/Location/get-city-title/${id}`),  
  getDistrictTitle: (id) => http.get(`/Location/get-city-title/${id}`), 
  getLocationTitles: (data) => http.post(`/Location/get-location-titles`, data),

};
