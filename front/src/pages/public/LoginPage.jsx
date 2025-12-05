import React, { useState, useContext } from 'react';
import { useNavigate } from 'react-router-dom';
import { Header } from "../../components/Header/Header.jsx";
import { Text } from "../../components/UI/Text/Text.jsx";
import { AuthContext } from "../../contexts/AuthContext";

import "../../styles/globals.css";
import "./LoginPage.css"; // стили для формы

const handleSearchResults = (results) => {
    console.log('Search results:', results);
};

export const LoginPage = () => {
    const { login } = useContext(AuthContext);
    const navigate = useNavigate();

    const [formData, setFormData] = useState({
        username: "",
        password: ""
    });

    const handleChange = (e) => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value
        });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        const result = await login(formData.username, formData.password);

        if (result.success) {
            navigate("/"); // переходим на главную
        } else {
            alert(result.message);
        }
    };

    return (
        <div className="login-page">
            <Header onSearchResults={handleSearchResults} showLogBtn={false} />

            <div className="login-page__content">
                <Text text="Войдите в аккаунт" type="title" />
                <Text text="Введите ваши учетные данные для входа" type="middle" />

                <form className="login-form" onSubmit={handleSubmit}>
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

                    <button type="submit" className="login-submit-btn">
                        Войти
                    </button>
                </form>
            </div>
        </div>
    );
};
