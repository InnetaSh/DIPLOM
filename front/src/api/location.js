import http from "./http";

export const locationApi = {
  getAll: () => http.get("/Location/get-all"),
  getById: (id) => http.get(`/Location/get/${id}`),
  getAllCities: (id) => http.get(`/Location/get-all-cities/`),
  create: (data) => http.post("/Location/create", data),
  update: (id, data) => http.put(`/Location/update/${id}`, data),
  delete: (id) => http.delete(`/Location/del/${id}`),

  
};
