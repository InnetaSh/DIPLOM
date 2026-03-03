import React, { useState, useContext, useRef, useEffect } from 'react';
import { GoogleLogin } from '@react-oauth/google';
import { useTranslation } from "react-i18next";
import { useNavigate } from 'react-router-dom';
import { AuthContext } from "../../contexts/AuthContext.jsx";

import { Text } from "../UI/Text/Text.jsx";
import { ActionButton__Primary } from "../UI/Button/ActionButton_Primary.jsx";
import { TextButton } from "../UI/Button/TextButton.jsx";
import { GoogleButton } from '../UI/Button/GoogleButton.jsx';
import { IconButtonClose } from "../../components/UI/Button/IconButton_close.jsx";

import "../../styles/globals.css";
import styles from "./LoginModal.module.css";

export const LoginModal = ({ setIsModalOpen, setIsRegisterModalOpen }) => {
    const { login, googleAuth } = useContext(AuthContext);
    const navigate = useNavigate();
    const { t } = useTranslation();
    const contentRef = useRef(null);
    const [hasScroll, setHasScroll] = useState(false);

    const [formData, setFormData] = useState({ login: "", password: "" });
    const [displayPassword, setDisplayPassword] = useState("");

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
        const { name, value } = e.target;
        console.log({

            password: formData.password,
        });

        if (name === "password") {
            const newDisplay = value;
            const oldDisplay = displayPassword;
            const oldPassword = formData.password;
            let newPassword = oldPassword;

            if (newDisplay.length > oldDisplay.length) {
                const addedChar = newDisplay[newDisplay.length - 1];
                newPassword += addedChar;
            }
            else if (newDisplay.length < oldDisplay.length) {
                newPassword = oldPassword.slice(0, newDisplay.length);
            }

            setFormData(prev => ({ ...prev, password: newPassword }));
            if (newPassword.length === 0) {
                setDisplayPassword("");
                return;
            }
            setDisplayPassword("●".repeat(newPassword.length - 1) + newPassword.slice(-1));

            setTimeout(() => {
                setDisplayPassword("●".repeat(newPassword.length));
            }, 400);
        } else {
            setFormData(prev => ({ ...prev, [name]: value }));
        }
    };

const handleSubmit = async (e) => {
    e.preventDefault();
    document.body.style.cursor = "wait";

    try {
        const result = await login(formData.login, formData.password);

        if (result.success) {
            const roleName = result.response.data.roleName;

            if (roleName === "SuperAdmin") {
                navigate("/admin");
            } else {
                setIsModalOpen(false);
            }
        } else {
            alert(result.message);
        }

    } catch (error) {
        console.error(error);
        alert("Ошибка сервера");
    } finally {
        document.body.style.cursor = "default";
    }
};





return (
    <div className={styles.loginPage}>
        <IconButtonClose
            className={`closeBtn ${hasScroll ? "withScroll" : ""
                }`}
            onClick={() => setIsModalOpen(false)}
        />
        <div
            ref={contentRef}
            className={`${styles.loginPage__content} p-25`}>
            <span className={`${styles.loginPage__title_wrapper} mb-30`}>
                <Text text={t("Auth.login.title")} type="m_700_s_48" />
            </span>
            <span className={`${styles.loginPage__subtitle_wrapper} mb-50`}>
                <Text text={t("Auth.login.welcome_back")} type="m_500" />
            </span>

            <form className={`${styles.loginPage__form} gap-30 mt-10`} onSubmit={handleSubmit}>
                {/* Username */}
                <input
                    type="text"
                    name="login"
                    value={formData.login}
                    onChange={handleChange}
                    placeholder={t("Auth.login.signUp")}
                    className={`${styles.input} btn-h-120 btn-br-r-20 p-10`}
                    required
                />

                <input
                    type="text"
                    name="password"
                    value={displayPassword}
                    onChange={handleChange}
                    placeholder={t("Auth.login.password")}
                    className={`${styles.input} btn-h-120  btn-br-r-20 p-10`}
                    autoComplete="new-password"
                    required
                />
                <div className={`${styles.line_wrapper} gap-12`}>
                    <div className={`${styles.line} ${styles.left} `}>
                        <div className={styles.circle}></div>
                    </div>
                    <Text text={t("Auth.register.or")} type="text_m_500_s_40" />
                    <div className={`${styles.line} ${styles.right}`}>
                        <div className={styles.circle}></div>
                    </div>
                </div>

                <span className={`${styles.googleButton__wrapper} flex-center btn-w-full mt-10 mb-50`}>
                    <GoogleLogin
                        theme="outline"          // outline | filled_blue | filled_black
                        size="large"             // small | medium | large
                        text="signin_with"       // signin_with | signup_with | continue_with | signin
                        shape="circle"      // rectangular | pill | circle | square
                        logo_alignment="left"    // left | center
                        width="900"

                        onSuccess={async (credentialResponse) => {
                            console.log("Google login");
                            const rez = credentialResponse.credential
                            console.log(rez);
                            const result = await googleAuth(credentialResponse.credential);

                            if (result.success) {
                                setIsModalOpen(false);
                            } else {
                                alert(result.message);
                            }
                        }}
                        onError={() => console.log("Login Failed")}
                    />
                </span>

                <span className={`${styles.actionButton__wrapper} flex-center mb-30`}>
                    <ActionButton__Primary type="m_600_s_36" text={t("Auth.login.loginButton")} className="btn-w-full btn-h-100 btn-br-r-20" />
                </span>

                <TextButton text={t("Auth.login.noAccount")}
                    className="btn-w-960 btn-h-100"
                    onClick={() => {
                        setIsRegisterModalOpen(true);
                        setIsModalOpen(false);
                    }}
                />
            </form>
        </div>
    </div>
);
};
