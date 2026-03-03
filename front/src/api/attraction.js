import http from "./http";

export const attractionApi = {
  getByCity: (cityId, lang) => http.get(`/Bff/attractions/get/byCityId/${cityId}/${lang}`),
  getById: (id, lang) => http.get(`/Bff/attractions/get/${id}/${lang}`)
 
};
