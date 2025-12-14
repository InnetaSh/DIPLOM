import React, { useState, useEffect, useContext } from "react";
import { AuthContext } from "../../contexts/AuthContext.jsx"; // путь проверь

export const BookingForm = () => {
  const { user } = useContext(AuthContext);

  const [formData, setFormData] = useState({
    firstName: "",
    lastName: "",
    email: "",
    country: "Украина",
    phonePrefix: "UA +380",
    phoneNumber: "",
    sendConfirmation: false,
    saveData: false,
    mainGuest: "me",
    businessTravel: "no",
  });

  // Автозаполнение из user (только имя полностью)
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
    console.log("Отправка формы:", formData);
    // TODO: отправить на сервер
  };

  const phonePrefixes = ["UA +380", "RU +7", "US +1", "DE +49"];

  return (
    <form onSubmit={handleSubmit} className="booking-form" noValidate>
      <h2>Введите свои данные</h2>

      <div className="info-box">
        <p>
          <strong>
            Почти готово! Просто заполните обязательные поля <span style={{ color: "red" }}>*</span>.
          </strong>
        </p>
        <p>
          Пожалуйста, укажите свои данные латинскими буквами, чтобы сотрудники объекта размещения смогли их понять
        </p>
      </div>

      {/* Имя (заполняется из user.Username) */}
      <label>
        Имя (латиницей) <span style={{ color: "red" }}>*</span><br />
        <input
          type="text"
          name="firstName"
          value={formData.firstName}
          onChange={handleChange}
          required
          placeholder="Имя"
        />
      </label>

      {/* Фамилия (пустая) */}
      <label>
        Фамилия (латиницей) <span style={{ color: "red" }}>*</span><br />
        <input
          type="text"
          name="lastName"
          value={formData.lastName}
          onChange={handleChange}
          required
          placeholder="Фамилия"
        />
      </label>

      {/* Email */}
      <label>
        Электронный адрес <span style={{ color: "red" }}>*</span><br />
        <input
          type="email"
          name="email"
          value={formData.email}
          onChange={handleChange}
          required
          placeholder="email@example.com"
        />
        <small>На этот адрес будет отправлено подтверждение бронирования</small>
      </label>

      {/* Страна */}
      <label>
        Страна/регион <span style={{ color: "red" }}>*</span><br />
        <select
          name="country"
          value={formData.country}
          onChange={handleChange}
          required
        >
          <option value="Украина">Украина</option>
          <option value="Россия">Россия</option>
          <option value="США">США</option>
          <option value="Германия">Германия</option>
        </select>
      </label>

      {/* Телефон */}
      <label>
        Телефон <span style={{ color: "red" }}>*</span><br />
        <div style={{ display: "flex", gap: "0.5rem" }}>
          <select
            name="phonePrefix"
            value={formData.phonePrefix}
            onChange={handleChange}
            required
          >
            {phonePrefixes.map((p) => (
              <option key={p} value={p}>
                {p}
              </option>
            ))}
          </select>

          <input
            type="tel"
            name="phoneNumber"
            value={formData.phoneNumber}
            onChange={handleChange}
            required
            placeholder="095 123 4567"
          />
        </div>
        <small>Для подтверждения бронирования и возможности связаться с вами при необходимости</small>
      </label>

      <label>
        <input
          type="checkbox"
          name="sendConfirmation"
          checked={formData.sendConfirmation}
          onChange={handleChange}
        />{" "}
        Да, отправьте мне бесплатное электронное подтверждение (рекомендуется)
      </label>

      <label>
        <input
          type="checkbox"
          name="saveData"
          checked={formData.saveData}
          onChange={handleChange}
        />{" "}
        Сохранить новые данные в аккаунте
      </label>

      <fieldset>
        <legend>Кто основной гость? (необязательно)</legend>

        <label>
          <input
            type="radio"
            name="mainGuest"
            value="me"
            checked={formData.mainGuest === "me"}
            onChange={handleChange}
          />{" "}
          Я
        </label>

        <label>
          <input
            type="radio"
            name="mainGuest"
            value="other"
            checked={formData.mainGuest === "other"}
            onChange={handleChange}
          />{" "}
          Другой человек
        </label>
      </fieldset>

      <fieldset>
        <legend>Путешествуете по работе? (необязательно)</legend>

        <label>
          <input
            type="radio"
            name="businessTravel"
            value="yes"
            checked={formData.businessTravel === "yes"}
            onChange={handleChange}
          />{" "}
          Да
        </label>

        <label>
          <input
            type="radio"
            name="businessTravel"
            value="no"
            checked={formData.businessTravel === "no"}
            onChange={handleChange}
          />{" "}
          Нет
        </label>
      </fieldset>

      <button type="submit">Забронировать</button>
    </form>
  );
};
