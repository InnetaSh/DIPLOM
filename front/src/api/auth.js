import http from "./http";

export const authApi = {
  login: (username, password) =>
    http.post("/User/login", { username, password }),
    
    register: (username, email, password, phoneNumber, roleName) =>
    http.post("/User/register", {
      username,
      email,
      password,
      phoneNumber,
      roleName
    }),

  updateUser: (id, data) => http.put(`/User/updateUser/${id}`, data),
  deleteUser: (id) => http.delete(`/User/deleteUser/${id}`),
  getAllUsers: () => http.get("/User/get-all"),
  getUserById: (id) => http.get(`/User/get/${id}`),
};
