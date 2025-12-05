import http from "./http";

export const rentObjParamValueApi = {
  getAll: () => http.get("/Offer/rentobjparamvalue/get-all"),
  getById: (id) => http.get(`/Offer/rentobjparamvalue/get/${id}`),
  create: (data) => http.post("/Offer/rentobjparamvalue/create", data),
  update: (id, data) => http.put(`/Offer/rentobjparamvalue/update/${id}`, data),
  delete: (id) => http.delete(`/Offer/rentobjparamvalue/del/${id}`),
};
