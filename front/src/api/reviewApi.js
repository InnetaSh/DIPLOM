
import http from "./http";

export const reviewApi = {
  getAll: () => http.get("/Offer/review/get-all"),
  getById: (id) => http.get(`/Offer/review/get/${id}`),
  create: (data) => http.post("/Offer/review/create", data),
  update: (id, data) => http.put(`/Offer/review/update/${id}`, data),
  delete: (id) => http.delete(`/Offer/review/del/${id}`),
};
