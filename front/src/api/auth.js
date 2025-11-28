import http from "./http";

export const authApi = {
  login: (email, password) =>
    http.post("/login", { email, password }),
    
  register: (username, email, password, role) =>
    http.post("/register", { username, email, password, role }),

  updateUser: (id, data) => http.put(`/updateUser/${id}`, data),
  deleteUser: (id) => http.delete(`/deleteUser/${id}`),
  getAllUsers: () => http.get("/user/get-all"),
  getUserById: (id) => http.get(`/user/get/${id}`),
};
