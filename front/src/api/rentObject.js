import http from "./http";

export const rentObjApi = {
 
  getAll: () => http.get("/Offer/rentobj/get-all"),
  getById: (id) => http.get(`/Offer/rentobj/get/${id}`),
  create: (data) => http.post("/Offer/rentobj/create", data),
  update: (id, data) => http.put(`/Offer/rentobj/update/${id}`, data),
  delete: (id) => http.delete(`/Offer/rentobj/del/${id}`),

  // Работа с изображениями
  uploadRentObjectImage: (rentObjId, file) => {
    const formData = new FormData();
    formData.append("file", file);
    return http.post(`/Offer/rentobj-image/upload/${rentObjId}`, formData, {
      headers: { "Content-Type": "multipart/form-data" },
    });
  },

  updateRentObjectImage: (imageId, file) => {
    const formData = new FormData();
    formData.append("file", file);
    return http.put(`/Offer/rentobj-image/update/${imageId}`, formData, {
      headers: { "Content-Type": "multipart/form-data" },
    });
  },

  deleteRentObjectImage: (imageId) => 
    http.delete(`/Offer/rentobj-image/del/${imageId}`),
};
