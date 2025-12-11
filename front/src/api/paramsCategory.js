import http from "./http";

export const paramsCategoryApi = {
  getAll: (lang = "en") => http.get(`/bff/params/category/main/${lang}`),



};
