import http from "./http";

export const orderApi = {
  getAll: () => http.get("/order/get-all"),
  getById: (id) => http.get(`/order/get/${id}`),
  create: (data) => http.post("/order/create", data),
  update: (id, data) => http.put(`/order/update/${id}`, data),
  delete: (id) => http.delete(`/order/del/${id}`),
};
