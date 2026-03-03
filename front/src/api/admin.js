import http from "./http";

export const adminApi = {
  getUsers: () => http.get(`/User/get-all`),
  getOffers: (lang) => http.get(`/Bff/search/offers/all/${lang}`)
 
};
