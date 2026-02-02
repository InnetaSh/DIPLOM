import React, { useState, useContext, useRef, useEffect } from 'react';

import { useNavigate } from "react-router-dom";
import { useTranslation } from "react-i18next";
import { AuthContext } from "../../contexts/AuthContext.jsx";

import { Text } from "../UI/Text/Text.jsx";
import { ActionButton__Primary } from "../UI/Button/ActionButton_Primary.jsx";
import { IconButtonClose } from "../../components/UI/Button/IconButton_close.jsx";
import { GoogleButton } from '../UI/Button/GoogleButton.jsx';
import { RadioGroup } from '../UI/Button/RadioGroup.jsx';

import "../../styles/globals.css";
import styles from "./RegisterModal.module.css";

const handleSearchResults = (results) => {
    console.log('Search results:', results);
};



export const RegisterModal = ({ setIsModalOpen }) => {
    const navigate = useNavigate();
    const { t } = useTranslation();
    const { register } = useContext(AuthContext);

    const contentRef = useRef(null);
    const [hasScroll, setHasScroll] = useState(false);

    const [formData, setFormData] = useState({
        username: "",
        password: "",
        email: "",
        phoneNumber: "",
        roleName: "Client"
    });


    useEffect(() => {
        const el = contentRef.current;
        if (!el) return;

        const checkScroll = () => {
            setHasScroll(el.scrollHeight > el.clientHeight);
        };

        checkScroll();
        window.addEventListener("resize", checkScroll);

        return () => window.removeEventListener("resize", checkScroll);
    }, []);




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
                formData.country,
                formData.email,
                formData.password,
                formData.phoneNumber
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
        <div className={styles.registerPage}>
            <IconButtonClose
                className={`closeBtn ${hasScroll ? "withScroll" : ""
                    }`}
                onClick={() => setIsModalOpen(false)}
            />
            <div
                ref={contentRef}
                className={`${styles.registerPage_content} p-25`}
            >

                <span className={`${styles.registerPage__title_wrapper} mb-30  `}>
                    <Text text={t("Auth.register.title")} type="m_700" />
                </span>
                <span className={`${styles.registerPage__subtitle_wrapper} mb-50`}  >
                    <Text text={t("Auth.register.welcome_new")} type="m_500" />
                </span>


                <form className={`${styles.registerPage__form} gap-30 mt-10`} onSubmit={handleSubmit}>
                    {/* google */}
                    <span className={`${styles.googleButton__wrapper} flex-center mt-10 mb-50`}>
                        < GoogleButton text={t("Auth.register.google")} className="btn-w-1165 btn-h-100 btn-br-r-15" />
                    </span>

                    <div className={`${styles.line_wrapper} gap-12`}>
                        <div className={`${styles.line} ${styles.left} `}>
                            <div className={styles.circle}></div>
                        </div>
                        <Text text={t("Auth.register.or")} type="text_m_500_s_40" />
                        <div className={`${styles.line} ${styles.right}`}>
                            <div className={styles.circle}></div>
                        </div>
                    </div>

                    {/* Username */}
                    <input
                        type="text"
                        name="username"
                        value={formData.username}
                        onChange={handleChange}
                        placeholder={t("Auth.register.name")}
                        className={`${styles.input} btn-h-120 btn-w-1165 btn-br-r-20 p-10`}
                        required
                    />
                    {/* country */}
                    <input
                        type="text"
                        name="country"
                        value={formData.country}
                        onChange={handleChange}
                        placeholder={t("Auth.register.country")}
                        className={`${styles.input} btn-h-120 btn-w-1165 btn-br-r-20 p-10`}
                        required
                    />
                    {/* Email */}
                    <input
                        type="email"
                        name="email"
                        value={formData.email}
                        onChange={handleChange}
                        placeholder={t("Auth.register.email")}
                        className={`${styles.input} btn-h-120 btn-w-1165 btn-br-r-20 p-10`}
                        required
                    />
                    {/* Phone */}
                    <input
                        type="tel"
                        name="phoneNumber"
                        value={formData.phoneNumber}
                        onChange={handleChange}
                        placeholder={t("Auth.register.phone")}
                        className={`${styles.input} btn-h-120 btn-w-1165 btn-br-r-20 p-10`}
                        required
                    />

                    {/* Password */}
                    <input
                        type="password"
                        name="password"
                        value={formData.password}
                        onChange={handleChange}
                        placeholder={t("Auth.register.password")}
                        className={`${styles.input} btn-h-120 btn-w-1165 btn-br-r-20 p-10`}
                        required
                    />
                    <div className={styles.radioButton_wrapper}>
                        <RadioGroup />
                        {/* <RadioButton text={t("Auth.register.owner")} />
                        <RadioButton text={t("Auth.register.client")} /> */}
                    </div>
                    <span className={`${styles.actionButton__wrapper} flex-center mb-30`}>
                        <ActionButton__Primary type="submit" text={t("Auth.register.registerButton")} className="btn-w-1165 btn-h-100 btn-br-r-20" />
                    </span>

                </form>
            </div>
        </div>
    );
};
