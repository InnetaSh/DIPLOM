import http from "./http";

export const offerApi = {
  getAll: () => http.get("/Offer/get-all"),
  getById: (id) => http.get(`/Offer/get/${id}`),
  create: (data) => http.post("/Offer/create", data),
  update: (id, data) => http.put(`/Offer/update/${id}`, data),
  delete: (id) => http.delete(`/Offer/del/${id}`),


  searchMain: ({ cityId, startDate, endDate, bedroomsCount, userDiscountPercent }) => {
    const params = new URLSearchParams({
      cityId,
      startDate, 
      endDate,
      bedroomsCount: bedroomsCount.toString(),
      userDiscountPercent: userDiscountPercent.toString(),
    });
    return http.get(`/Offer/by-mainparams?${params.toString()}`);
  },
};
