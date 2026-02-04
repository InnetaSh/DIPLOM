import React, { useState, useEffect, useContext } from "react";
import { useTranslation } from "react-i18next";
import { useParams, useLocation } from "react-router-dom";
import { ApiContext } from "../../contexts/ApiContext.jsx";
import { AuthContext } from "../../contexts/AuthContext";

import { Header_Full } from "../../components/Header/Header_Full.jsx";
import { Footer } from "../../components/Footer/Footer.jsx";
import { Image } from "../../components/UI/Image/Image.jsx";
import { Text } from "../../components/UI/Text/Text.jsx"
import { BookingForm } from "../../components/BookingForm/BookingForm.jsx"
import { Loader } from "../../components/Loader/Loader.jsx";

import styles from "./BookingDetailsPage.module.css";

export const BookingDetailsPage = () => {
  const location = useLocation();
  const { offerApi } = useContext(ApiContext);
  const { login } = useContext(AuthContext);

  const [bookingStep, setBookingStep] = useState("details");

  const { t } = useTranslation();


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
    console.log("bookingStep:", bookingStep);
  }, [bookingStep]);

  useEffect(() => {
    if (bookingStep === "loading") {
      const timer = setTimeout(() => setBookingStep("success"), 3000);
      return () => clearTimeout(timer);
    }
  }, [bookingStep]);

  useEffect(() => {
    if (bookingStep === "success") {
      const timer = setTimeout(() => setBookingStep("confirm"), 700); 
      return () => clearTimeout(timer);
    }
  }, [bookingStep]);



  // await api.book();

  // setBookingStep("success");

  // setTimeout(() => {
  //   setBookingStep("confirm");
  // }, 900);


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
    <div className={styles.bookingDetailsPage}>
      <Header_Full
        title={bookingStep === "details" ? t("Booking.booking_title") : ""}
        showFilterBtn={false} />
      <main className={styles.bookingDetailsPage_conteiner}>

        {bookingStep === "details" && (
          <div className="booking-details__container">
            <BookingForm
              setBookingStep={setBookingStep}
            />
          </div>
        )}
        {(bookingStep === "loading" ||
          bookingStep === "success" ||
          bookingStep === "confirm") && (
            <div className={styles.loading__container}>
              <Loader status={bookingStep} />
              {bookingStep !== "confirm" && (
                <Text
                  text={
                    bookingStep === "loading"
                      ? t("Booking.processing")
                      : t("Booking.success")
                  }
                  type="m_500_s_40"
                />
              )}
            </div>
          )}


        {/* {bookingStep === "success" && <BookingSuccess />}
{bookingStep === "error" && <BookingError />} */}

      </main>
      <Footer />
    </div >
  );
};
