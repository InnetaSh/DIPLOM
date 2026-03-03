import http from "./http";

export const userApi = {
  getMe: (lang) => http.get(`/User/me/${lang}`),
  getMyOffers: (lang) => http.get(`/User/me/offers/${lang}`),
  getMyTrip: (lang) => http.get(`/User/me/orders/${lang}`),
  
  setMyHistory: (offerId) => http.post(`/Bff/me/offer/isfavorite/add/${offerId}`), 
  getMyHistory: (lang) => http.get(`/Bff/me/history/get/offers/${lang}`), 

  getMyHistoryId: (lang) => http.get(`/Bff/me/history/get/offersId/${lang}`), 
  
  
  updateMe: (userData) => http.put("/User/me/update", userData),
    
    
  updateUser: (id, data) => http.put(`/User/updateUser/${id}`, data),
  deleteUser: (id) => http.delete(`/User/deleteUser/${id}`),
  getAllUsers: () => http.get("/User/get-all"),
  getUserById: (id) => http.get(`/User/get/${id}`),
};
