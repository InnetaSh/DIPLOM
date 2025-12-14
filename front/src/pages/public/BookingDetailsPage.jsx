import React, { useState, useEffect, useContext } from "react";
import { useParams, useLocation } from "react-router-dom";
import { ApiContext } from "../../contexts/ApiContext.jsx";
import { AuthContext } from "../../contexts/AuthContext";

import { Header } from "../../components/Header/Header.jsx";
import { Image } from "../../components/UI/Image/Image.jsx";
import { Text } from "../../components/UI/Text/Text.jsx"
import { BookingForm } from "../../components/BookingForm/BookingForm.jsx"

import styles from "./BookingDetailsPage.css";

export const BookingDetailsPage = () => {
  const location = useLocation();
  const { offerApi } = useContext(ApiContext);


  const initialHotel = location.state?.hotel || null;
  const initialOffer = location.state?.offer || null;

  const { id } = useParams();
  const [hotel, setHotel] = useState(initialHotel);
  const [offer, setOffer] = useState(initialOffer);
  const [images, setImages] = useState(initialHotel?.imagesUrl || []);
  const [paramValues, setParamValues] = useState(initialHotel?.paramValues || []);
  const [offerTitle, setOfferTitle] = useState("");


  const queryParams = new URLSearchParams(location.search);
  const startDate = queryParams.get("checkin");
  const endDate = queryParams.get("checkout");
  const guests = queryParams.get("guests");


  const start = new Date(startDate);
  const end = new Date(endDate);
  const diffTime = end - start;
  const diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24));
  console.log("Количество дней:", diffDays);

  const mainImg = images[0];

  useEffect(() => {
    if (initialOffer) return;

    if (!offerApi || !id) return;

    offerApi
      .searchId({
        id,
        cityId: id,
        startDate,
        endDate,
        guests,
        userDiscountPercent: 5,
      })
      .then((res) => {
        const data = res.data[0];

        setOffer(data);
        setHotel(data.rentObj[0]);
        setOfferTitle(data.title);
        setImages(data.rentObj[0]?.imagesUrl || []);
        setParamValues(data.rentObj[0]?.paramValues || []);
        console.log("Loaded offer:", data);
        console.log("Loaded hotel:", data.rentObj[0]);
      })
      .catch((err) => console.error("Error loading offer:", err));
  }, [id, offerApi, startDate, endDate, guests]);

  return (
    <div className="booking-details-page">
      <Header />
      <main className="booking-details-page__content">
        <div className="booking-details-page__layout">
          <div className="offer-details__info">
            <div className="card__imageWrapper">
              <Image src={mainImg} alt={offerTitle} type="card" />
            </div>
            <Text text="{offerTitle}" type="bold" />
            {offer && (
              <>
                <Text text={hotel.address} type="middle" />

                <Text text="Детали вашего бронирования" type="bold" />
                <div className="time-details">
                  <div className="checkin-time">
                    <Text text="Заезд" type="middle" />
                    <Text text={startDate} type="bold" />
                    <Text text={offer.checkInTime} type="middle" />
                  </div>
                  <div className="checkout-time ">
                    <Text text="Отъезд" type="middle" />
                    <Text text={endDate} type="bold" />
                    <Text text={offer.checkOutTime} type="middle" />
                  </div>
                </div>
              </>
            )}

            <Text text="Вы выбрали:" type="middle" />
            <Text text={`${diffDays} дни, ${guests} гостей`} type="bold" />
            <Text text="Детали цены" type="bold" />
          </div>

          <div className="booking-details__container">
            <BookingForm />
          </div>
        </div>

      </main>
    </div >
  );
};
