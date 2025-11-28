import http from "./http";

export const rentObjApi = {
 
  getAll: () => http.get("/rentobj/get-all"),
  getById: (id) => http.get(`/rentobj/get/${id}`),
  create: (data) => http.post("/rentobj/create", data),
  update: (id, data) => http.put(`/rentobj/update/${id}`, data),
  delete: (id) => http.delete(`/rentobj/del/${id}`),

  // Работа с изображениями
  uploadRentObjectImage: (rentObjId, file) => {
    const formData = new FormData();
    formData.append("file", file);
    return http.post(`/rentobj-image/upload/${rentObjId}`, formData, {
      headers: { "Content-Type": "multipart/form-data" },
    });
  },

  updateRentObjectImage: (imageId, file) => {
    const formData = new FormData();
    formData.append("file", file);
    return http.put(`/rentobj-image/update/${imageId}`, formData, {
      headers: { "Content-Type": "multipart/form-data" },
    });
  },

  deleteRentObjectImage: (imageId) => 
    http.delete(`/rentobj-image/del/${imageId}`),
};
