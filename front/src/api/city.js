import http from "./http";

export const cityApi = {
  getAll: () => http.get("/city/get-all"),
  getById: (id) => http.get(`/city/get/${id}`),
  create: (data) => http.post("/city/create", data),
  update: (id, data) => http.put(`/city/update/${id}`, data),
  delete: (id) => http.delete(`/city/del/${id}`),
};
