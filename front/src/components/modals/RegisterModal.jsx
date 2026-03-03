import React, { useState, useContext, useRef, useEffect } from 'react';
import Select from "react-select";

import { useLanguage } from "../../contexts/LanguageContext.jsx";
import { GoogleLogin } from '@react-oauth/google';
import { useNavigate } from "react-router-dom";
import { useTranslation } from "react-i18next";
import { AuthContext } from "../../contexts/AuthContext.jsx";
import { ApiContext } from "../../contexts/ApiContext.jsx";
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
    const { register, googleAuth } = useContext(AuthContext);
    const { locationApi } = useContext(ApiContext);
    const { language } = useLanguage();
    const contentRef = useRef(null);
    const [hasScroll, setHasScroll] = useState(false);
    const [displayPassword, setDisplayPassword] = useState("");
    const [countries, setCountries] = useState([]);
    const [confirmPassword, setConfirmPassword] = useState("");
    const [displayConfirmPassword, setDisplayConfirmPassword] = useState("");
    const [errors, setErrors] = useState({});


    const [activeButton, setActiveButton] = useState("owner");
    const [isPasswordFocused, setIsPasswordFocused] = useState(false);


    const [formData, setFormData] = useState({
        username: "",
        password: "",
        countryId: null,
        email: "",
        birthDate: null,
        phoneNumber: "",
        postcode: "",
        roleName: ""
    });

    const passwordRules = {
        minLength: formData.password.length >= 4,
        upper: /[A-Z]/.test(formData.password),
        lower: /[a-z]/.test(formData.password),
        number: /\d/.test(formData.password),
    };

    const isPasswordValid =
        passwordRules.minLength &&
        passwordRules.upper &&
        passwordRules.lower &&
        passwordRules.number;

    const isAdult = (birthDate) => {
        if (!birthDate) return false;

        const today = new Date();
        const birth = new Date(birthDate);

        let age = today.getFullYear() - birth.getFullYear();
        const m = today.getMonth() - birth.getMonth();

        if (m < 0 || (m === 0 && today.getDate() < birth.getDate())) {
            age--;
        }

        return age >= 18;
    };

    useEffect(() => {
        const selectedCountry = countries.find(
            c => c.id === formData.countryId
        );

        if (selectedCountry) {
            console.log(selectedCountry);
            setFormData(prev => ({
                ...prev,
                postcode: selectedCountry.countryCode
            }));
            console.log(formData.postcode);
        }
    }, [formData.countryId, countries]);


    const handleConfirmPasswordChange = (e) => {
        const value = e.target.value;

        const newDisplay = value;
        const oldDisplay = displayConfirmPassword;
        const oldPassword = confirmPassword;

        let newPassword = oldPassword;

        if (newDisplay.length > oldDisplay.length) {
            const addedChar = newDisplay[newDisplay.length - 1];
            newPassword += addedChar;
        } else if (newDisplay.length < oldDisplay.length) {
            newPassword = oldPassword.slice(0, newDisplay.length);
        }

        setConfirmPassword(newPassword);

        if (newPassword.length === 0) {
            setDisplayConfirmPassword("");
            return;
        }

        setDisplayConfirmPassword(
            "●".repeat(newPassword.length - 1) + newPassword.slice(-1)
        );

        setTimeout(() => {
            setDisplayConfirmPassword("●".repeat(newPassword.length));
        }, 300);
    };

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
            }, 300);
        } else {
            setFormData(prev => ({ ...prev, [name]: value }));
        }
    };


    useEffect(() => {
        console.log(language)
        locationApi.getCountriesWithCode(language)
            .then(res => {
                setCountries(res.data)
                console.log(res.data)
            })
            .catch(err => console.error("Error loading countries:", err));
    }, [language]);



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


    const handleSubmit = async (e) => {
        e.preventDefault();

        const newErrors = {};

        if (!isPasswordValid) {
            newErrors.password = "Пароль не соответствует требованиям";
        }

        if (formData.password !== confirmPassword) {
            newErrors.confirmPassword = "Пароли не совпадают";
        }

        if (!isAdult(formData.birthDate)) {
            newErrors.birthDate = "Вам должно быть 18 лет или больше";
        }

        if (Object.keys(newErrors).length > 0) {
            setErrors(newErrors);
            return;
        }

        setErrors({});

        console.log({ data: formData });
        console.log({ roleName: activeButton });
        const combinedPhoneNumber = `${formData.postcode} ${formData.phoneNumber}`;

        document.body.style.cursor = "wait";
        try {
            const result = await register({
                username: formData.username,
                countryId: formData.countryId,
                email: formData.email,
                birthDate: new Date(formData.birthDate).toISOString(),
                password: formData.password,
                phoneNumber: combinedPhoneNumber,
                roleName: activeButton
            }
            );
            console.log("Registration success:", result);
            if (result.success) {
                navigate("/");
                setIsModalOpen(false);
            } else {
                alert(result.message);
            }
        } catch (error) {
            console.error("Registration error:", error);
        } finally {
            document.body.style.cursor = "default";
        }
    };

    const countryOptions = countries?.map(country => ({
        value: country.id,
        label: country.title
    }));



    return (
        <div className={styles.registerPage}>
            <IconButtonClose
                size="30"
                className={`closeBtn ${hasScroll ? "withScroll" : ""
                    }`}
                onClick={() => setIsModalOpen(false)}
            />
            <div
                ref={contentRef}
                className={`${styles.registerPage_content} p-25`}
            >

                <span className={`${styles.registerPage__title_wrapper} mb-30  `}>
                    <Text text={t("Auth.register.title")} type="m_700_s_48" />
                </span>
                <span className={`${styles.registerPage__subtitle_wrapper} mb-50`}  >
                    <Text text={t("Auth.register.welcome_new")} type="m_500" />
                </span>


                <form className={`${styles.registerPage__form} gap-30 mt-10`} onSubmit={handleSubmit}>
                    {/* google */}
                    <span className={`${styles.googleButton__wrapper} flex-center btn-w-full mt-10 mb-50`}>
                        <GoogleLogin
                            theme="outline"          // outline | filled_blue | filled_black
                            size="large"             // small | medium | large
                            text="signin_with"       // signin_with | signup_with | continue_with | signin
                            shape="circle"      // rectangular | pill | circle | square
                            logo_alignment="left"    // left | center
                            width="1200"

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
                        className={`${styles.input} btn-h-120  btn-br-r-20 p-10`}
                        required
                    />
                    {/* country */}
                    {/* Country select */}
                    <Select
                        name="countryId"
                        options={countryOptions}
                        value={countryOptions?.find(c => c.value === formData.countryId)}
                        onChange={(selected) =>
                            setFormData(prev => ({
                                ...prev,
                                countryId: selected?.value
                            }))
                        }
                        className={`${styles.input} btn-h-120 btn-br-r-20`}
                        classNamePrefix="countrySelect"
                        placeholder={t("Auth.register.country")}
                    />

                    {/* Email */}
                    <input
                        type="email"
                        name="email"
                        value={formData.email}
                        onChange={handleChange}
                        placeholder={t("Auth.register.email")}
                        className={`${styles.input} btn-h-120  btn-br-r-20 p-10`}
                        required
                    />
                    <input
                        type="date"
                        name="birthDate"
                        value={formData.birthDate || ""}
                        onChange={handleChange}
                        className={`${styles.input} btn-h-120  btn-br-r-20 p-10`}
                        max={new Date().toISOString().split("T")[0]}
                    />
                    {errors.birthDate && (
                        <div style={{ color: "red", fontSize: "14px" }}>
                            {errors.birthDate}
                        </div>
                    )}

                    {/* Phone */}
                    <div className={`${styles.input} ${styles.input_phone} flex-left btn-h-120 btn-w-1165 btn-br-r-20 `}>
                        <div className={styles.phonePrefix}>
                            <input
                                name="phonePrefix"
                                value={formData.postcode}
                                readOnly
                            />
                        </div>
                        <input
                            type="tel"
                            name="phoneNumber"
                            value={formData.phoneNumber}
                            onChange={handleChange}
                            placeholder={t("Auth.register.phone")}
                            className={`${styles.input_phoneNumber} `}
                            required
                        />

                    </div>


                    {/* Password */}
                    <input
                        type="password"
                        name="password"
                        value={displayPassword}
                        onChange={handleChange}
                        placeholder={t("Auth.register.password")}
                        className={`${styles.input} btn-h-120 btn-w-1165 btn-br-r-20 p-10`}
                        autoComplete="new-password"
                        required
                        onFocus={() => setIsPasswordFocused(true)}
                        onBlur={() => setIsPasswordFocused(false)}
                    />
                    {isPasswordFocused && formData.password.length > 0 && (
                        <div className='flex-center btn-w-full gap-20' style={{ fontSize: "19px", marginTop: "5px" }}>
                            <div style={{ color: passwordRules.minLength ? "#28a745" : "#dc3545" }}>
                                • Минимум 8 символов
                            </div>
                            <div style={{ color: passwordRules.upper ? "#28a745" : "#dc3545" }}>
                                • 1 заглавная буква
                            </div>
                            <div style={{ color: passwordRules.lower ? "#28a745" : "#dc3545" }}>
                                • 1 строчная буква
                            </div>
                            <div style={{ color: passwordRules.number ? "#28a745" : "#dc3545" }}>
                                • 1 цифра
                            </div>
                        </div>
                    )}


                    <input
                        type="password"
                        value={displayConfirmPassword}
                        onChange={handleConfirmPasswordChange}
                        placeholder={t("Auth.register.confirm_password")}
                        className={`${styles.input} btn-h-120 btn-w-1165 btn-br-r-20 p-10`}
                        required
                    />
                    {errors.confirmPassword && (
                        <div style={{ color: "red", fontSize: "14px" }}>
                            {errors.confirmPassword}
                        </div>
                    )}


                    <div className={styles.radioButton_wrapper}>
                        <RadioGroup
                            activeButton={activeButton}
                            setActiveButton={setActiveButton}
                        />
                        {/* <RadioButton text={t("Auth.register.owner")} />
                        <RadioButton text={t("Auth.register.client")} /> */}
                    </div>
                    <span className={`${styles.actionButton__wrapper} flex-center mb-30`}>
                        <ActionButton__Primary
                            text={t("Auth.register.registerButton")}
                            type="m_600_s_36"
                            className="btn-w-1165 btn-h-100 btn-br-r-20"
                        />
                    </span>

                </form>
            </div>
        </div>
    );
};
