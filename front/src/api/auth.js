import http from "./http";

export const authApi = {
  login: (username, password) =>
    http.post("/User/login", { username, password }),

  registerClient: (username, email, password, phoneNumber, roleName) =>
    http.post("/User/register/client", {
      username,
      email,
      password,
      phoneNumber,
      roleName
    }),

  registerOwner: (username, email, password, phoneNumber, roleName) =>
    http.post("/User/register/owner", {
      username,
      email,
      password,
      phoneNumber,
      roleName
    }),

  googleAuth: (idToken) =>{
 console.log("Api");
    http.post(
      "/User/google",
      { idToken },
      {
        headers: {
          "Content-Type": "application/json"
        }
      }
    )
  },



  updateUser: (id, data) => http.put(`/User/updateUser/${id}`, data),
  deleteUser: (id) => http.delete(`/User/deleteUser/${id}`),
  getAllUsers: () => http.get("/User/get-all"),
  getUserById: (id) => http.get(`/User/get/${id}`),
};
