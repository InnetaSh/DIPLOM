import http from "./http";

export const paramItemApi = {
  getAll: () => http.get("/Offer/paramitem/get-all"),
  getById: (id) => http.get(`/Offer/paramitem/get/${id}`),
  create: (data) => http.post("/Offer/paramitem/create", data),
  update: (id, data) => http.put(`/Offer/paramitem/update/${id}`, data),
  delete: (id) => http.delete(`/Offer/paramitem/del/${id}`),
};
