import { useState, useContext, useRef, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { useTranslation } from "react-i18next";
import { AuthContext } from "../../contexts/AuthContext.jsx";
import { ApiContext } from "../../contexts/ApiContext.jsx";
import { useLanguage } from "../../contexts/LanguageContext.jsx";

import { Text } from "../UI/Text/Text.jsx"
import { StateButton__Filter } from "../UI/Button/StateButton_Filter.jsx";
import { ActionButton__Primary } from "../UI/Button/ActionButton_Primary.jsx";

import styles from './AccountPanel.module.css';

const handleSearchResults = (results) => {
    console.log('Search results:', results);
};


export const AccountPanel = ({ user }) => {
    const { updateMe } = useContext(AuthContext);
    const { locationApi } = useContext(ApiContext);
    const navigate = useNavigate();
    const { language } = useLanguage();
    const { t } = useTranslation();


    const contentRef = useRef(null);
    const [hasScroll, setHasScroll] = useState(false);
    const [countries, setCountries] = useState([]);


    const [formData, setFormData] = useState({
        id: 0,
        username: "",
        password: "",
        email: "",
        phoneNumber: "",
        birthDate: null,
        countryId: 0,
        discount: 0,
        roleName: "",
        token: ""
    });


    useEffect(() => {
        console.log(language)
        locationApi.getAllCountries(language)
            .then(res => {
                setCountries(res.data)
                console.log(res.data)
            })
            .catch(err => console.error("Error loading countries:", err));
    }, [language]);



    useEffect(() => {
        if (!user || !Array.isArray(countries)) return;

        const userCountry = countries.find(c => c.id === user.countryId);

        setFormData({
            id: user.id,
            username: user.username || "",
            lastname: user.lastname || "",
            password: "",
            email: user.email || "",
            phoneNumber: user.phoneNumber || "",
            birthDate: user.birthDate ? new Date(user.birthDate).toISOString() : null,
            countryId: user.countryId || 0,
            discount: user.discount || 0,
            roleName: user.roleName || "",
            token: user.token || ""
        });
    }, [user, countries]);





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




    const handleCityChange = (cityTitle, cityId) => {
        setFormData(prev => ({
            ...prev,
            countryId: cityId
        }));
    };


    const handleChange = (e) => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value
        });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        console.log("Sending to server:", formData);
        const result = await updateMe(formData);
        if (result.success) {
            alert("Данные обновлены");
        } else {
            alert(result.message);
        }
    };


    return (
        <div className={styles.accountPanel}>
            <div className={styles.accountPanel__container}>
                <div className={`${styles.accountPanel_btn} flex-between`}>
                    <StateButton__Filter
                        text={t("Prrofile.AccountPanel.myself_info")}
                        icon_name=""
                        className="btn-orange btn-w-fit-content btn-h-btn-h-50 btn-br-r-20"

                        onClick={() => console.log("2www")}
                    />
                    {/* <Text text={t("Prrofile.AccountPanel.Security_settings")} type="m_500_s_24" /> */}
                </div>

                <form className={`${styles.accountPanel__form} gap-30 mt-10`} onSubmit={handleSubmit}>
                    {/* Username */}
                    <Text text={t("Prrofile.AccountPanel.name")} type="m_400_s_16" />
                    <input
                        type="text"
                        name="username"
                        value={formData.username}
                        onChange={handleChange}
                        placeholder=""
                        className={`${styles.input} btn-h-59  btn-br-r-20 p-10`}
                        required
                    />
                      <Text text={t("Prrofile.AccountPanel.lastname")} type="m_400_s_16" />
                    <input
                        type="text"
                        name="lastname"
                        value={formData.lastname}
                        onChange={handleChange}
                        placeholder=""
                        className={`${styles.input} btn-h-59  btn-br-r-20 p-10`}
                        required
                    />
                    {/* birthday */}
                    <Text text={t("Prrofile.AccountPanel.birthday")} type="m_400_s_16" />
                    <input
                        type="date"
                        name="birthDate"
                        value={formData.birthDate ? formData.birthDate.split("T")[0] : ""}
                        onChange={e =>
                            setFormData(prev => ({
                                ...prev,
                                birthDate: e.target.value
                            }))
                        }
                        className={`${styles.input} btn-h-59  btn-br-r-20 p-10`}
                        required
                    />
                    {/* Email */}
                    <Text text={t("Prrofile.AccountPanel.email")} type="m_400_s_16" />
                    <input
                        type="email"
                        name="email"
                        value={formData.email}
                        onChange={handleChange}
                        placeholder=""
                        className={`${styles.input} btn-h-59  btn-br-r-20 p-10`}
                        required
                    />
                    {/* Phone */}
                    <Text text={t("Prrofile.AccountPanel.phone")} type="m_400_s_16" />
                    <input
                        type="tel"
                        name="phoneNumber"
                        value={formData.phoneNumber}
                        onChange={handleChange}
                        placeholder=""
                        className={`${styles.input} btn-h-59  btn-br-r-20 p-10`}
                        required
                    />

                    {/* country */}
                    <Text text={t("Prrofile.AccountPanel.country")} type="m_400_s_16" />
                    <select
                        name="countryId"
                        value={formData.countryId || ""}
                        onChange={e => {
                            const selectedId = Number(e.target.value);
                            const selectedCountry = countries.find(c => c.id === selectedId);
                            setFormData(prev => ({
                                ...prev,
                                countryId: selectedId,
                                countryTitle: selectedCountry ? selectedCountry.title : ""
                            }));
                        }}
                        className={`${styles.input} btn-h-59 btn-br-r-20 p-10`}
                        required
                    >
                        <option value="" disabled>{t("Prrofile.AccountPanel.select_country")}</option>
                        {countries?.map(country => (
                            <option key={country.id} value={country.id}>
                                {country.title}
                            </option>
                        ))}
                    </select>


                    <span className={`${styles.actionButton__wrapper} flex-center mb-30`}>
                        <ActionButton__Primary
                            type="m_700_s_24"
                            text={t("Prrofile.AccountPanel.btn_continue")}
                            className="btn-w-447 btn-h-59 btn-br-r-20" />
                    </span>

                </form>
            </div>
        </div>
    );
};
