import React, { useContext, useState } from "react";
import { AuthContext } from "../../contexts/AuthContext.jsx";
import { useNavigate } from "react-router-dom";
import { useTranslation } from "react-i18next";
import { useLanguage } from "../../contexts/LanguageContext.jsx";

import { Logo_Oselya } from "../Logo/Logo_Oselya.jsx";
import { Text } from "../UI/Text/Text.jsx";
import { Image } from "../UI/Image/Image.jsx";
import { IconButton__50 } from "../UI/Button/IconButton_50.jsx";
import { TextButton } from "../UI/Button/TextButton.jsx";
import { IconWithTextButton } from "../UI/Button/IconWithTextButton.jsx";
import { SecondaryButton } from "../UI/Button/SecondaryButton.jsx";
import { UserMenu } from "./UserMenu.jsx";


import styles from './Header.module.css';

import logo from "../../img/logo/Booking-Emblema.jpg";
import { ReactComponent as PhoneIcon } from "../../img/icons/phone.svg";

export const Header = ({ showLogBtn = true }) => {
  const navigate = useNavigate();

  const { user } = useContext(AuthContext);
  const [openMenu, setOpenMenu] = useState(false);

  const { t } = useTranslation();
  const { language, setLanguage } = useLanguage();

  // Переключаем язык при клике
  const handleLanguageToggle = () => {
    setLanguage(language === "en" ? "uk" : "en");
  };


  return (
    <div className={`${styles.headerMain} flex-center`}>
      <div className={`${styles.headerMain__container} p-t-24  flex-between`} >
        <div className={`${styles.headerMain_Logo__container} flex-between`} >
          <div className={styles.headerMain__logo}>
            <Logo_Oselya />
          </div>
          <Text text={t("header.subtitle_header_main")} type="m_400_s_32" />
          <div className={`${styles.headerMain__logo__actions_container} flex-center mb-20 `}>
            <IconButton__50
              icon_name="user-male"
              onClick={() => console.log("click")}
              title="User"
            />

            <IconButton__50
              icon_src="/img/earth-globe.svg"
              title="Earth"
            />
            <IconButton__50
              icon_name="menu"
              title="User"
              onClick={() => console.log("Связаться с нами clicked")}
            />

            {/* {user ? (
            <div className={styles.user - cabiten__container}>
              <TextButton
                text={t("header.registerProperty")}
                onClick={() => console.log("Register clicked")}
              />
              <div className={styles.user - cabiten__info}>
                <IconWithTextButton
                  icon="👤"
                  text={user.name}
                  textType="bold"
                  onClick={() => setOpenMenu((prev) => !prev)}
                />
                {openMenu && <UserMenu />}
              </div>
            </div>
          ) : (
            showLogBtn && (
              <>
                <SecondaryButton
                  text={t("header.signUp")}
                  onClick={() => navigate("/register")}
                />
                <SecondaryButton
                  text={t("header.signIn")}
                  onClick={() => navigate("/login")}
                />
              </>
            )
          )} */}
          </div>
        </div>
      </div>
    </div>
  );
};
