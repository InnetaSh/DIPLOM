import http from "./http";

export const offerApi = {

  searchOffers: ({ startDate, endDate, guests, userDiscountPercent, lang, cityId, paramItemFilters }) => {
    // Форматируем даты в ISO
    const startIso = new Date(startDate).toISOString();
    const endIso = new Date(endDate).toISOString();

    const params = new URLSearchParams({
      CityId: cityId.toString(),
      StartDate: startIso,
      EndDate: endIso,
      Guests: guests.toString(),
      userDiscountPercent: (userDiscountPercent || 0).toString(),
      paramItemFilters: JSON.stringify(paramItemFilters || {}) // всегда передаём строку
    });

    return http.get(`/Bff/search/offers/${lang}?${params.toString()}`);
  },


  searchId: ({ id, startDate, endDate, guests, userDiscountPercent, lang }) => {
    const params = new URLSearchParams({
      startDate,
      endDate,
      guests: guests.toString(),
      userDiscountPercent: userDiscountPercent.toString(),
    });

    return http.get(
      `/Bff/search/booking-offer/${id}/${lang}?${params.toString()}`
    );
  }
}