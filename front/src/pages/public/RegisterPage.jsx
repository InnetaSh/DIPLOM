import React, { useState, useContext } from 'react';
import { useNavigate } from "react-router-dom";
import { Header } from "../../components/Header/Header.jsx";
import { Text } from "../../components/UI/Text/Text.jsx";


import { AuthContext } from "../../contexts/AuthContext";

import "../../styles/globals.css";
import "./RegisterPage.css";

const handleSearchResults = (results) => {
    console.log('Search results:', results);
};

export const RegisterPage = () => {
    const navigate = useNavigate();
    const { register } = useContext(AuthContext);
    const [formData, setFormData] = useState({
        username: "",
        password: "",
        email: "",
        phoneNumber: "",
        roleName: "Client"
    });

    const handleChange = (e) => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value
        });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            const result = await register(
                formData.username,
                formData.email,
                formData.password,
                formData.phoneNumber,
                formData.roleName
            );
            console.log("Registration success:", result);
            if (result.success) {
                navigate("/");
            } else {
                alert(result.message);
            }
        } catch (error) {
            console.error("Registration error:", error);
        }
    };


    return (
        <div className="register-page">
            <Header onSearchResults={handleSearchResults} showLogBtn={false} />

            <div className="register-page__content">
                <Text text="Создайте аккаунт" type="title" />
                <Text
                    text="Введите данные, чтобы зарегистрироваться на Booking.com"
                    type="middle"
                />

                <form className="register-form" onSubmit={handleSubmit}>

                    {/* Email */}
                    <Text text="Адрес электронной почты" type="bold" />
                    <input
                        type="email"
                        name="email"
                        value={formData.email}
                        onChange={handleChange}
                        className="input"
                        required
                    />

                    {/* Username */}
                    <Text text="Имя пользователя" type="bold" />
                    <input
                        type="text"
                        name="username"
                        value={formData.username}
                        onChange={handleChange}
                        className="input"
                        required
                    />

                    {/* Phone */}
                    <Text text="Номер телефона" type="bold" />
                    <input
                        type="tel"
                        name="phoneNumber"
                        value={formData.phoneNumber}
                        onChange={handleChange}
                        className="input"
                        required
                    />

                    {/* Password */}
                    <Text text="Пароль" type="bold" />
                    <input
                        type="password"
                        name="password"
                        value={formData.password}
                        onChange={handleChange}
                        className="input"
                        required
                    />

                    {/* Role
                    <Text text="Роль пользователя" type="bold" />
                    <select
                        name="roleName"
                        value={formData.roleName}
                        onChange={handleChange}
                        className="input"
                        required
                    >
                        <option value="">Выберите роль</option>
                        <option value="USER">Owner</option>
                        <option value="HOST">Client</option>
                    </select> */}

                    <button type="submit" className="register-submit-btn">
                        Зарегистрироваться
                    </button>
                </form>
            </div>
        </div>
    );
};
