import http from "./http";

export const rentObjParamValueApi = {
  getAll: () => http.get("/rentobjparamvalue/get-all"),
  getById: (id) => http.get(`/rentobjparamvalue/get/${id}`),
  create: (data) => http.post("/rentobjparamvalue/create", data),
  update: (id, data) => http.put(`/rentobjparamvalue/update/${id}`, data),
  delete: (id) => http.delete(`/rentobjparamvalue/del/${id}`),
};
