import http from "./http";

export const offerApi = {
 
  searchMain: ({ startDate, endDate, guests, userDiscountPercent, lang = "en"}) => {
  const params = new URLSearchParams({
    startDate,
    endDate,
    guests: guests.toString(),
    userDiscountPercent: userDiscountPercent.toString()
  });

  return http.get(`/Bff/search/main/${lang}?${params.toString()}`);
},

searchId: ({ id, cityId, startDate, endDate, guests, userDiscountPercent, lang = "en" }) => {
    const params = new URLSearchParams({
        cityId,
        startDate,
        endDate,
        guests: guests.toString(),
        userDiscountPercent: userDiscountPercent.toString()
    });
    return http.get(`/bff/search/booking/${id}/${lang}?${params.toString()}`);
},

};
