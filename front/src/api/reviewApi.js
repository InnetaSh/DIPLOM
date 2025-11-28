
import http from "./http";

export const reviewApi = {
  getAll: () => http.get("/review/get-all"),
  getById: (id) => http.get(`/review/get/${id}`),
  create: (data) => http.post("/review/create", data),
  update: (id, data) => http.put(`/review/update/${id}`, data),
  delete: (id) => http.delete(`/review/del/${id}`),
};
