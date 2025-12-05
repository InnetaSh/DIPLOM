
import http from "./http";

export const bookeddateApi = {
  getAll: () => http.get("/Order/bookeddate/get-all"),
  getById: (id) => http.get(`/Order/bookeddate/get/${id}`),
  create: (data) => http.post("/Order/bookeddate/create", data),
  update: (id, data) => http.put(`/Order/bookeddate/update/${id}`, data),
  delete: (id) => http.delete(`/Order/bookeddate/del/${id}`),
};
