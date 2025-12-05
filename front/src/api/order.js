import http from "./http";

export const orderApi = {
  getAll: () => http.get("/Order/get-all"),
  getById: (id) => http.get(`/Order/get/${id}`),
  create: (data) => http.post("/Order/create", data),
  update: (id, data) => http.put(`/Order/update/${id}`, data),
  delete: (id) => http.delete(`/Order/del/${id}`),
};
