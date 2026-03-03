import React, { useState, useEffect, useContext } from "react";
import { useTranslation } from "react-i18next";
import { useNavigate } from "react-router-dom";

import { useParams, useLocation, useSearchParams  } from "react-router-dom";
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
    const { user, token } = useContext(AuthContext);

  const [bookingStep, setBookingStep] = useState("details");

  const { t } = useTranslation();


  const initialHotel = location.state?.hotel || null;
  const initialOffer = location.state?.offer || null;
const navigate = useNavigate();


  const [hotel, setHotel] = useState(initialHotel);
  const [offer, setOffer] = useState(initialOffer);
  const [images, setImages] = useState(initialHotel?.imagesUrl || []);
  const [paramValues, setParamValues] = useState(initialHotel?.paramValues || []);
  const [offerTitle, setOfferTitle] = useState("");


 const { offerId } = useParams();

  const [searchParams] = useSearchParams();

  const startDate = searchParams.get("startDate");
  const endDate = searchParams.get("endDate");
  const adults = Number(searchParams.get("adults"));
  const children = Number(searchParams.get("children"));
  const price = Number(searchParams.get("price"));

  console.log({
    user,
    startDate,
    endDate,
    adults,
    children,
    price,
  });

const { id } = useParams();
  const start = new Date(startDate);
  const end = new Date(endDate);
  const diffTime = end - start;
  const diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24));
  console.log("Количество дней:", diffDays);

  const mainImg = images[0];
  console.log("Hotel ID:", id);
  useEffect(() => {
    console.log("bookingStep:", bookingStep);
  }, [bookingStep]);

  // useEffect(() => {
  //   if (bookingStep === "loading") {
  //     const timer = setTimeout(() => setBookingStep("success"), 3000);
  //     return () => clearTimeout(timer);
  //   }
  // }, [bookingStep]);

  useEffect(() => {
    if (bookingStep === "success") {
      const timer = setTimeout(() => setBookingStep("confirm"), 700); 
      return () => clearTimeout(timer);
    }
  }, [bookingStep]);


  useEffect(() => {
  if (bookingStep === "confirm") {
    const timer = setTimeout(() => {
      navigate("/"); 
    }, 15000); 

    return () => clearTimeout(timer); 
  }
}, [bookingStep, navigate]);

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
