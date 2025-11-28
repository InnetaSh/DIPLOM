import http from "./http";

export const paramItemApi = {
  getAll: () => http.get("/paramitem/get-all"),
  getById: (id) => http.get(`/paramitem/get/${id}`),
  create: (data) => http.post("/paramitem/create", data),
  update: (id, data) => http.put(`/paramitem/update/${id}`, data),
  delete: (id) => http.delete(`/paramitem/del/${id}`),
};
