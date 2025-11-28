import http from "./http";

export const offerApi = {
  getAll: () => http.get("/offer/get-all"),
  getById: (id) => http.get(`/offer/get/${id}`),
  create: (data) => http.post("/offer/create", data),
  update: (id, data) => http.put(`/offer/update/${id}`, data),
  delete: (id) => http.delete(`/offer/del/${id}`),


  searchMain: ({ city, startDate, endDate, bedroomsCount, userDiscountPercent }) => {
    const params = new URLSearchParams({
      city,
      startDate, 
      endDate,
      bedroomsCount: bedroomsCount.toString(),
      userDiscountPercent: userDiscountPercent.toString(),
    });
    return http.get(`/offer/by-mainparams?${params.toString()}`);
  },
};
