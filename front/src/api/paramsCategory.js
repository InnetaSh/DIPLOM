import http from "./http";

export const paramsCategoryApi = {
  getAll: () => http.get("/paramcategory/get-all"),
  getById: (id) => http.get(`/paramcategory/get/${id}`),
  create: (data) => http.post("/paramcategory/create", data),
  update: (id, data) => http.put(`/paramcategory/update/${id}`, data),
  delete: (id) => http.delete(`/paramcategory/del/${id}`),
};
