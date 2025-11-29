import http from "./http";

export const paramsCategoryApi = {
  getAll: () => http.get("/params-category/get-all"),
  getById: (id) => http.get(`/params-category/get/${id}`),
  create: (data) => http.post("/params-category/create", data),
  update: (id, data) => http.put(`/params-category/update/${id}`, data),
  delete: (id) => http.delete(`/params-category/del/${id}`),
};
