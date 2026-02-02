import { useState, useContext, useRef, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { useTranslation } from "react-i18next";
import { AuthContext } from "../../contexts/AuthContext.jsx";

import { AccountPanel_card } from "./AccountPanel_card.jsx";
import { Text } from "../UI/Text/Text.jsx"
import { StateButton__Filter } from "../UI/Button/StateButton_Filter.jsx";


import { ActionButton__Primary } from "../UI/Button/ActionButton_Primary.jsx";
import { IconButtonClose } from "../../components/UI/Button/IconButton_close.jsx";
import { GoogleButton } from '../UI/Button/GoogleButton.jsx';
import { RadioGroup } from '../UI/Button/RadioGroup.jsx';

import styles from './AccountPanel.module.css';


const handleSearchResults = (results) => {
    console.log('Search results:', results);
};


export const AccountPanel = () => {

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
                formData.birthday,
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
        <div className={styles.accountPanel}>
             <div className={styles.accountPanel__container}>
            <div className={`${styles.accountPanel_btn} flex-between`}>
                <StateButton__Filter
                    text={t("Prrofile.AccountPanel.myself_info")}
                    icon_name=""
                    className="btn-orange btn-w-fit-content btn-h-btn-h-50 btn-br-r-20"

                    onClick={() => console.log("2www")}
                />
                <Text text={t("Prrofile.AccountPanel.Security_settings")} type="m_500_s_24" />
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
                    {/* birthday */}
                       <Text text={t("Prrofile.AccountPanel.birthday")} type="m_400_s_16" />
                    <input
                        type="text"
                        name="birthday"
                        value={formData.birthday}
                        onChange={handleChange}
                        placeholder=""
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
                    <input
                        type="text"
                        name="country"
                        value={formData.country}
                        onChange={handleChange}
                        placeholder=""
                        className={`${styles.input} btn-h-59  btn-br-r-20 p-10`}
                        required
                    />

                    <span className={`${styles.actionButton__wrapper} flex-center mb-30`}>
                        <ActionButton__Primary type="submit" text={t("Prrofile.AccountPanel.btn_continue")} className="btn-w-447 btn-h-59 btn-br-r-20" />
                    </span>

                </form>
            </div>
        </div>
    );
};
