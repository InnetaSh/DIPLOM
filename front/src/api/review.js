
import http from "./http";

export const reviewApi = {

 createReview: ({ orderId, offerId, formData, lang }) => {
  return http.post(
    `/Bff/user/orders/${orderId}/${offerId}/reviews/create/${encodeURIComponent(lang ?? '')}`,
    formData,
    {
      headers: {
        'Content-Type': 'application/json'
      }
    }
  );
},

 getByOfferId: (offerId, lang) => http.get(`/Bff/review/offerId/${offerId}/${lang}`),


  getAll: () => http.get("/Offer/review/get-all"),
  getById: (id) => http.get(`/Offer/review/get/${id}`),
  create: (data) => http.post("/Offer/review/create", data),
  update: (id, data) => http.put(`/Offer/review/update/${id}`, data),
  delete: (id) => http.delete(`/Offer/review/del/${id}`),
};
