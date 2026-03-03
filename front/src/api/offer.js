import http from "./http";


export const offerApi = {
  createOffer: ({ formData, lang }) => {
    return http.post(`/Bff/create/booking-offer?lang=${encodeURIComponent(lang ?? '')}`, formData, {
      headers: {
        'Content-Type': 'application/json'
      }
    });
  },

  createOfferImg: ({ formData, offerId }) =>
    http.post(`/Bff/img/booking-offer/${offerId}/add`, formData, {
      headers: { "Content-Type": "multipart/form-data" },
    }),

  updateOffer: ({ formData, lang }) => {
    return http.post(`/Bff/update/booking-offer?lang=${encodeURIComponent(lang ?? '')}`, formData, {
      headers: {
        'Content-Type': 'application/json'
      }
    });
  },

  searchOffers: ({ startDate, endDate, adults, children, rooms,  userDiscountPercent, lang, cityId,regionId,countryId, paramItemFilters }) => {

    const startIso = new Date(startDate).toISOString();
    const endIso = new Date(endDate).toISOString();

    const params = new URLSearchParams({
      CityId: cityId ? cityId.toString() : -1,
      RegionId: regionId ? regionId.toString() : -1,
      CountryId: countryId ? countryId.toString() : -1,
      StartDate: startIso,
      EndDate: endIso,
      Adults: adults? adults.toString() : "",
      Children: children ? children.toString() :"0",
      Rooms:rooms? rooms.toString() :"",
      userDiscountPercent: (userDiscountPercent || 0).toString(),
      paramItemFilters: (paramItemFilters || "") 
    });

    return http.get(`/Bff/search/offers/${lang}?${params.toString()}`);
  },


  searchId: ({ id, startDate, endDate, adults, children, userDiscountPercent, lang }) => {
    const params = new URLSearchParams({
      StartDate: startDate,   
      EndDate: endDate,
       Adults: adults? adults.toString() : "",
      Children: children ? children.toString() :"0",
      userDiscountPercent: userDiscountPercent.toString(),
    });

    return http.get(
      `/Bff/search/booking-offer/${id}/${lang}?${params.toString()}`
    );
  },


   searchIdByOrderId: ({ offerId, orderId, lang }) => 
   http.get(
      `/Bff/search/booking-offer/${offerId}/${orderId}/${lang}`
    ),


   getPopularOffers: (period, limit, lang) => 
    http.get(`/Bff/statistic/top/${period}/get/offer/${limit}/${lang}`), 
}
