import React, { useState, useContext } from 'react';
import { useTranslation } from "react-i18next";
import { useNavigate } from 'react-router-dom';
import { AuthContext } from "../../contexts/AuthContext";

import { Text } from "../../components/UI/Text/Text.jsx";
import { ActionButton__Primary } from "../../components/UI/Button/ActionButton_Primary.jsx";
import { TextButton } from "../../components/UI/Button/TextButton.jsx";
import { GoogleButton } from '../../components/UI/Button/GoogleButton.jsx';


import "../../styles/globals.css";
import styles from "./LoginPage.module.css";



const handleSearchResults = (results) => {
    console.log('Search results:', results);
};

export const LoginPage = () => {
    const { login } = useContext(AuthContext);
    const navigate = useNavigate();
    const { t } = useTranslation();


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
        <div className={styles.loginPage}>
            <div className={`${styles.loginPage__content} p-25 `}>
                <span className={`${styles.loginPage__title_wrapper} mb-30  `}>
                    <Text text={t("Auth.login.title")} type="m_700" />
                </span>
                <span className={`${styles.loginPage__subtitle_wrapper} mb-50`}  >
                    <Text text={t("Auth.login.welcome_back")} type="m_500" />
                </span>


                <form className={`${styles.loginPage__form} gap-30 mt-10`} onSubmit={handleSubmit}>
                    {/* Username */}
                    <input
                        type="text"
                        name="username"
                        value={formData.username}
                        onChange={handleChange}
                        placeholder={t("Auth.login.signUp")}
                        className={`${styles.input} btn-h-120 btn-w-1165 btn-br-r-20 p-10`}
                        required
                    />

                    {/* Password */}
                    <input
                        type="password"
                        name="password"
                        value={formData.password}
                        onChange={handleChange}
                        placeholder={t("Auth.login.password")}
                        className={`${styles.input} btn-h-120 btn-w-1165 btn-br-r-20 p-10`}
                        required
                    />
                    {/* google */}
                    <span className={`${styles.googleButton__wrapper} flex-center mt-10 mb-50`}>
                        < GoogleButton text={t("Auth.login.google")} className = "btn-w-1165 btn-h-100 btn-br-r-15"/>
                    </span>
                    <span className={`${styles.actionButton__wrapper} flex-center mb-30`}>
                        <ActionButton__Primary type="submit" text={t("Auth.login.loginButton")} className = "btn-w-1165 btn-h-100 btn-br-r-20" />
                    </span>
                    <TextButton text={t("Auth.login.noAccount")}  className = "btn-w-1165 btn-h-100" onClick={() => navigate("/register")} />

                </form>
            </div>
        </div>
    );
};
