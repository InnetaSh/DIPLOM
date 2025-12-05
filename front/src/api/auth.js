import http from "./http";

export const authApi = {
  login: (email, password) =>
    http.post("/User/login", { email, password }),
    
  register: (username, email, password, role) =>
    http.post("/User/register", { username, email, password, role }),

  updateUser: (id, data) => http.put(`/User/updateUser/${id}`, data),
  deleteUser: (id) => http.delete(`/User/deleteUser/${id}`),
  getAllUsers: () => http.get("/User/get-all"),
  getUserById: (id) => http.get(`/User/get/${id}`),
};
