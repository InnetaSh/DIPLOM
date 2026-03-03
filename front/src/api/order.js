import http from "./http";

export const orderApi = {

  createOrder: ({ formData, lang }) => {

    return http.post(`/Bff/create/booking-order/${encodeURIComponent(lang ?? '')}`, formData, {
      headers: {
        'Content-Type': 'application/json'
      }
    });
  },


  getByOfferId: (offerId, lang) => http.get(`/Bff/offer/${offerId}/orders/${lang}`),
  updateStateOrder: (orderId, orderState) =>
    http.post(`/Bff/update_status/booking/${orderId}`, orderState),


  hasPendingByOfferId: () => http.get(`/User/me/myOffers/orders/has-pending`),
 


  getAll: () => http.get("/Order/get-all"),
  getById: (id) => http.get(`/Order/get/${id}`),
  create: (data) => http.post("/Order/create", data),
  update: (id, data) => http.put(`/Order/update/${id}`, data),
  delete: (id) => http.delete(`/Order/del/${id}`),
};
