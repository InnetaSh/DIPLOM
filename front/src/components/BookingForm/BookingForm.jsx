import React, { useState, useEffect, useContext } from "react";
import { useTranslation } from "react-i18next";
import { AuthContext } from "../../contexts/AuthContext.jsx";
import { Text } from "../UI/Text/Text.jsx";
import { ImageSvg } from "../UI/Image/ImageSvg.jsx";
import { RadioButton } from "../UI/Button/RadioButton.jsx";
import { ActionButton__Primary } from "../UI/Button/ActionButton_Primary.jsx";
import styles from "./BookingForm.module.css";

export const BookingForm = ({
  price = "7 568",
  setBookingStep
}) => {
  const { user } = useContext(AuthContext);
  const { t } = useTranslation();

  const paymentMethods = [
    { key: "visa", label: t("Booking.payment_visa_mastercard") },
    { key: "paypal", label: t("Booking.payment_paypal") },
    { key: "apple", label: t("Booking.payment_apple_pay") },
    { key: "google", label: t("Booking.payment_google_pay") },
    { key: "onsite", label: t("Booking.payment_on_site") },
  ];

  const cardList = [
    { id: "1", title: "1111 1111 1111 9101", icon_name: "payment_card_1", sizeX: "50", sizeY: "50", imgSrc: "" },
  ];


  const [activePaymentButton, setActivePaymentButton] = useState("");
  const [activeTripPurposeButton, setActiveTripPurposeButton] = useState("owner");
  const [showCardInfo, setShowCardInfo] = useState(false);
  const [isOpenCardNum, setIsOpenCardNum] = React.useState(false);
  const [selectedCard, setSelectedCard] = useState(null);



  const [formData, setFormData] = useState({
    firstName: "",
    lastName: "",
    adults: 1,
    children: 0,
    email: "",
    country: "Украина",
    phonePrefix: "UA +380",
    phoneNumber: "",
    sendConfirmation: false,
    saveData: false,
    mainGuest: "me",
    cardNum: "",
    businessTravel: "no",
    wishes: ""
  });


  useEffect(() => {
    if (user) {
      setFormData((prev) => ({
        ...prev,
        firstName: user.name || "",
        email: user.email || "",
        phoneNumber: user.phoneNumber || "",
      }));
    }
  }, [user]);

  const handleChange = (e) => {
    const { name, value, type, checked } = e.target;
    setFormData((prev) => ({
      ...prev,
      [name]: type === "checkbox" ? checked : value,
    }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
     setBookingStep("loading");
    console.log("Отправка формы:", formData);
  };

  const phonePrefixes = ["UA +380", "RU +7", "US +1", "DE +49"];


  const maskCardNumber = (cardNumber) => {
    return cardNumber
      .replace(/\s/g, "")
      .replace(/\d(?=\d{4})/g, "*")
      .replace(/(.{4})/g, "$1 ")
      .trim();
  };

  const handleCardSelect = (card) => {
    setFormData(prev => ({
      ...prev,
      cardNum: card.title,
    }));
    setSelectedCard(card);
    setIsOpenCardNum(false);
  };


  return (
    <form onSubmit={handleSubmit} className={styles.bookingForm} noValidate>


      <div className={styles.infoBox}>
        <div className="flex-left gap-5">
          <span className={styles.language_notice}>!</span>.
          <Text text={t("Booking.booking_language_notice")} type="m_400_s_14" />
        </div>
        <div className="flex-left gap-5">
          <span className={styles.required_fields}>*</span>.
          <Text text={t("Booking.required_fields_note")} type="m_400_s_14" />
        </div>

      </div>


      <fieldset>
        <div className={styles.form_title__legend} >
          <Text text={t("Booking.guest_data_title")} type="m_600_s_32" />
        </div>
        <div className={styles.input_container} >

          <div className={styles.input_container__grid_2}>
            <label className={styles.bookingForm_label} >
              <legend className={styles.form__legend} >
                <Text text={t("Booking.name_label")} type="m_400_s_20" />
              </legend>
              <input
                type="text"
                name="firstName"
                value={formData.firstName}
                onChange={handleChange}
                placeholder=""
                className={`${styles.input} btn-h-59  btn-br-r-20 p-10`}
                required
              />
            </label>


            <label className={styles.bookingForm_label} >
              <legend className={styles.form__legend} >
                <Text text={t("Booking.name_label")} type="m_400_s_20" />
              </legend>
              <input
                type="text"
                name="lastName"
                value={formData.lastName}
                onChange={handleChange}
                required
                placeholder=""
                className={`${styles.input} btn-h-59  btn-br-r-20 p-10`}
              />
            </label>


            <label className={styles.bookingForm_label} >
              <legend className={styles.form__legend} >
                <Text text={t("Booking.country_city_label")} type="m_400_s_20" />
              </legend>
              <select
                name="country"
                value={formData.country}
                onChange={handleChange}
                className={`${styles.input} btn-h-59  btn-br-r-20 p-10`}
                required
              >
                <option value="Украина">Украина</option>
                <option value="Россия">Россия</option>
                <option value="США">США</option>
                <option value="Германия">Германия</option>
              </select>
            </label>



            <label className={styles.bookingForm_label} >
              <legend className={styles.form__legend} >
                <Text text={t("Booking.country_city_label")} type="m_400_s_20" />
              </legend>
              <select
                name="country"
                value={formData.country}
                onChange={handleChange}
                className={`${styles.input} btn-h-59  btn-br-r-20 p-10`}
                required
              >
                <option value="Украина">Украина</option>
                <option value="Россия">Россия</option>
                <option value="США">США</option>
                <option value="Германия">Германия</option>
              </select>
            </label>
          </div>



          <label className={styles.bookingForm_label} >
            <legend className={styles.form__legend} >
              <Text text={t("Booking.email_label")} type="m_400_s_20" />
            </legend>
            <input
              type="email"
              name="email"
              value={formData.email}
              onChange={handleChange}
              required
              className={`${styles.input} btn-h-59  btn-br-r-20 p-10`}
            />
            <div className="flex-left gap-5">
              <span className={styles.required_fields}>*</span>.
              <Text text={t("Booking.required_email_note")} type="m_400_s_14" />
            </div>
          </label>


          <label className={styles.bookingForm_label} >
            <legend className={styles.form__legend} >
              <Text text={t("Booking.phone_label")} type="m_400_s_20 " />
            </legend>
            <div className={styles.phoneInput}>
              <div className={styles.phonePrefixWrapper}>
                <select
                  name="phonePrefix"
                  value={formData.phonePrefix}
                  onChange={handleChange}
                  className={styles.phonePrefix}
                  required
                >
                  {phonePrefixes.map((p) => (
                    <option key={p} value={p}>
                      {p}
                    </option>
                  ))}
                </select>
                <span className={styles.selectArrow}>▼</span>
              </div>

              <input
                type="tel"
                name="phoneNumber"
                value={formData.phoneNumber}
                onChange={handleChange}
                placeholder="095 123 4567"
                className={`${styles.input} ${styles.phoneNumber} btn-h-59  btn-br-r-20 p-10`}
                required
              />
            </div>




            <div className="flex-left gap-5">
              <span className={styles.required_fields}>*</span>.
              <Text text={t("Booking.required_phone_note")} type="m_400_s_14" />
            </div>
          </label>
        </div>
      </fieldset>


      <div className="flex-left gap-5">
        <input
          type="checkbox"
          name="saveData"
          checked={formData.saveData}
          onChange={handleChange}
        />{" "}
        <Text text={t("Booking.save_data_checkbox")} />
      </div>


      <fieldset  >
        <div className={styles.form_title__legend} >
          <Text text={t("Booking.booking_details_title")} type="m_600_s_32" />
        </div>
        <div className={styles.input_container__grid_2}>
          <label className={styles.bookingForm_label} >
            <legend className={styles.form__legend} >
              <Text text={t("Booking.arrival_date_label")} type="m_400_s_16" />
            </legend>
            <input
              type="text"
              name="firstName"
              value={formData.firstName}
              onChange={handleChange}
              placeholder=""
              className={`${styles.input} btn-h-59  btn-br-r-20 p-10`}
              required
            />
          </label>

          <label className={styles.bookingForm_label} >
            <legend className={styles.form__legend} >
              <Text text={t("Booking.departure_date_label")} type="m_400_s_16" />
            </legend>
            <input
              type="text"
              name="lastName"
              value={formData.lastName}
              onChange={handleChange}
              required
              placeholder=""
              className={`${styles.input} btn-h-59  btn-br-r-20 p-10`}
            />
          </label>


          <label className={styles.bookingForm_label} >
            <legend className={styles.form__legend} >
              <Text text={t("Booking.adults_count_label")} type="m_400_s_16" />
            </legend>
            <div className={styles.numberInput}>
              <button
                type="button"
                className={`${styles.spinButton} ${styles.left}`}
                onClick={() =>
                  setFormData((p) => ({ ...p, adults: Math.max(1, p.adults - 1) }))
                }
              >
                −
              </button>

              <input
                type="number"
                name="adults"
                value={formData.adults}
                readOnly
                className={`${styles.input} ${styles.input_number} btn-h-59 btn-br-r-20 p-10`}
              />

              <button
                type="button"
                className={`${styles.spinButton} ${styles.right}`}
                onClick={() =>
                  setFormData((p) => ({ ...p, adults: p.adults + 1 }))
                }
              >
                +
              </button>
            </div>
          </label>


          <label className={styles.bookingForm_label} >
            <legend className={styles.form__legend} >
              <Text text={t("Booking.children_count_label")} type="m_400_s_16" />
            </legend>
            <div className={styles.numberInput}>
              <button
                type="button"
                className={`${styles.spinButton} ${styles.left}`}
                onClick={() =>
                  setFormData((p) => ({ ...p, children: Math.max(0, p.children - 1) }))
                }
              >
                −
              </button>

              <input
                type="number"
                name="children"
                value={formData.children}
                readOnly
                className={`${styles.input} ${styles.input_number} btn-h-59 btn-br-r-20 p-10`}
              />

              <button
                type="button"
                className={`${styles.spinButton} ${styles.right}`}
                onClick={() =>
                  setFormData((p) => ({ ...p, children: p.children + 1 }))
                }
              >
                +
              </button>
            </div>
          </label>
        </div>
      </fieldset>


      <fieldset >
        <div className={styles.form_title__legend} >
          <Text text={t("Booking.trip_purpose_title")} type="m_600_s_32" />
        </div>
        <div className={styles.input_container__grid_3}>

          <RadioButton
            text={t("Booking.trip_purpose_vacation")}
            active={activeTripPurposeButton === "travel"}
            onClick={() => setActiveTripPurposeButton("travel")}
          />
          <RadioButton
            text={t("Booking.trip_purpose_business")}
            active={activeTripPurposeButton === "business"}
            onClick={() => setActiveTripPurposeButton("business")}
          />




        </div>
        <label className={styles.bookingForm_label} >
          <legend className={styles.form__legend} >
            <Text text={t("Booking.wishes_label")} type="m_400_s_24 " />
          </legend>
          <textarea
            name="wishes"
            value={formData.wishes}
            onChange={handleChange}
            placeholder=""
            className={`${styles.input} ${styles.textarea} btn-br-r-20 p-10`}
            rows={4}
          />
        </label>
      </fieldset>

      <fieldset>
        <div className={styles.form_title__legend} >
          <Text text={t("Booking.payment_method_title")} type="m_600_s_32" />
        </div>
        <div className={styles.input_container__grid_3}>

          {paymentMethods.map((method) => (
            <RadioButton
              key={method.key}
              text={method.label}
              active={activePaymentButton === method.key}
              onClick={() => {
                setActivePaymentButton(method.key)
                setShowCardInfo(true)
              }}
            />
          ))}
        </div>
      </fieldset>

      {showCardInfo && (
        <div className={styles.cardInfo__container}>
          <fieldset>
            <div className={styles.input_card_container}>
              <label className={`${styles.cardForm_label} ${styles.cardForm_wrapper}`} >
                <legend className={styles.form__legend} >
                  <Text text={t("Booking.choise_card")} type="m_400_s_20" />
                </legend>
                {/* <input
                  type="text"
                  name="cardNum"
                  value={formData.cardNum}
                  onChange={handleChange}
                  onFocus={() => setIsOpenCardNum(true)}
                  placeholder=""
                  className={`${styles.input} ${styles.input_card} btn-h-59 btn-br-r-20 p-10`}
                  required
                /> */}

                <div className={styles.input_with_icon}>
                  <input
                    type="text"
                    name="cardNum"
                    value={formData.cardNum}
                    onChange={handleChange}
                    onFocus={() => setIsOpenCardNum(true)}
                    className={`${styles.input} ${styles.input_card} btn-h-59 btn-br-r-20 p-10`}
                    required
                  />

                  {selectedCard && (
                    <div className={styles.input_icon}>
                      <ImageSvg
                        name={selectedCard.icon_name}
                        src={selectedCard.imgSrc}
                        sizeX={selectedCard.sizeX}
                        sizeY={selectedCard.sizeY}
                      />
                    </div>
                  )}
                </div>



                {isOpenCardNum && cardList.length > 0 && (
                  <div className={styles.card_num_wrapper}>
                    {cardList.map(card => (
                      <div
                        key={card.id}
                        className="flex-between gap-100"
                        onClick={() => handleCardSelect(card)}

                        style={{ cursor: "pointer" }}
                      >
                        <Text
                          text={maskCardNumber(card.title)}
                          type="m_500_s_24"
                        />
                        <ImageSvg
                          name={card.icon_name}
                          src={card.imgSrc}
                          sizeX={card.sizeX}
                          sizeY={card.sizeY}
                        />
                      </div>
                    ))}
                  </div>
                )}

              </label>


              <label className={styles.bookingForm_label} >
                <legend className={styles.form__legend} >
                  <Text text={t("Booking.data")} type="m_400_s_20" />
                </legend>
                <input
                  type="text"
                  name="lastName"
                  value={formData.lastName}
                  onChange={handleChange}
                  required
                  placeholder=""
                  className={`${styles.input} btn-h-59  btn-br-r-20 p-10`}
                />
              </label>


              <label className={styles.bookingForm_label} >
                <legend className={styles.form__legend} >
                  <Text text={t("Booking.CVV")} type="m_400_s_20" />
                </legend>
                <input
                  type="text"
                  name="lastName"
                  value={formData.lastName}
                  onChange={handleChange}
                  required
                  placeholder=""
                  className={`${styles.input} btn-h-59  btn-br-r-20 p-10`}
                />

              </label>
            </div>
          </fieldset>
          <div className="flex-between">
            <div className={styles.price__container}>
              <Text text={t("Booking.Price")} type="m_600_s_24" />
              <Text text={`${price}  UAH`} type="m_600_s_24" />
            </div>
            <ActionButton__Primary text={t("hotel_info.more_btn")} className={`light_color_btn_2 btn-w-385 btn-h-59 btn-br-r-20`} onClick={() => { }} />
          </div>
        </div>

      )}
      <span className={`${styles.actionButton__wrapper} flex-center  btn-w-full`}>
        <ActionButton__Primary
          text={t("Booking.submit_button")}
          type="m_700_s_32"
          className="btn-w-860 btn-h-70 btn-br-r-20"
          onClick={() => {
            const handleBooking = async () => {
              setBookingStep("loading");

              // try {
              //   await bookApi(); // запрос
              //   setBookingStep("success");
              // } catch (e) {
              //   setBookingStep("error");
              // }
            };
          }} />
      </span>
    </form >
  );
};
