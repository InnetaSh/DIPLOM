import http from "./http";

export const paramsCategoryApi = {
  getAll: () => http.get("/Offer/params-category/get-all"),
  getById: (id) => http.get(`/Offer/params-category/get/${id}`),
  create: (data) => http.post("/Offer/params-category/create", data),
  update: (id, data) => http.put(`/Offer/params-category/update/${id}`, data),
  delete: (id) => http.delete(`/Offer/params-category/del/${id}`),
};
