import http from "./http";

export const userApi = {
  getMe: (lang) =>
    http.get("/User/me/${lang}"),

    updateMe: (userData) => http.put("/User/me/update", userData),
    
    
  updateUser: (id, data) => http.put(`/User/updateUser/${id}`, data),
  deleteUser: (id) => http.delete(`/User/deleteUser/${id}`),
  getAllUsers: () => http.get("/User/get-all"),
  getUserById: (id) => http.get(`/User/get/${id}`),
};
