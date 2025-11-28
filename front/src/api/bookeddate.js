
import http from "./http";

export const bookeddateApi = {
  getAll: () => http.get("/bookeddate/get-all"),
  getById: (id) => http.get(`/bookeddate/get/${id}`),
  create: (data) => http.post("/bookeddate/create", data),
  update: (id, data) => http.put(`/bookeddate/update/${id}`, data),
  delete: (id) => http.delete(`/bookeddate/del/${id}`),
};
