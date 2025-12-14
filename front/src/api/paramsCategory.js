import http from "./http";

export const paramsCategoryApi = {
  getAll: (lang) => http.get(`/bff/params/category/main/${lang}`),



};
