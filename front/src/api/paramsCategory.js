import http from "./http";

export const paramsCategoryApi = {
  getAllCategories: (lang) => http.get(`/Bff/params/category/${lang}`),



};
