import http from "./http";

export const countryApi = {
  getAll: () => http.get("/country/get-all"),
  getById: (id) => http.get(`/country/get/${id}`),
  create: (data) => http.post("/country/create", data),
  update: (id, data) => http.put(`/country/update/${id}`, data),
  delete: (id) => http.delete(`/country/del/${id}`),
};
