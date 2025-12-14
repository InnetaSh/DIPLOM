import React, { useContext, useState } from "react";
import { AuthContext } from "../../contexts/AuthContext";
import { useNavigate } from "react-router-dom";
import { useTranslation } from "react-i18next";
import { useLanguage } from "../../contexts/LanguageContext";

import { Image } from "../UI/Image/Image.jsx";
import { IconButton } from "../UI/Button/IconButton.jsx";
import { TextButton } from "../UI/Button/TextButton.jsx";
import { IconWithTextButton } from "../UI/Button/IconWithTextButton.jsx";
import { SecondaryButton } from "../UI/Button/SecondaryButton.jsx";
import { UserMenu } from "./UserMenu.jsx";

import "../../styles/globals.css";
import "./Header.css";

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
    setLanguage(language === "en" ? "ru" : "en");
  };

  return (
    <div className="header">
      <div className="header-container">
        <div className="header-main">
          <div className="logo-container">
            <Image src={logo} alt="Logo" type="logo" />
          </div>

          <div className="actions-container">
            {/* Кнопка переключения языка */}
            <IconButton
              icon={language.toUpperCase()}
              onClick={handleLanguageToggle}
            />

            <IconButton
              icon={<PhoneIcon />}
              onClick={() => console.log("Связаться с нами clicked")}
            />

            {user ? (
              <div className="user-cabiten__container">
                <TextButton
                  text={t("header.registerProperty")}
                  onClick={() => console.log("Register clicked")}
                />
                <div className="user-cabiten__info">
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
            )}
          </div>
        </div>
      </div>
    </div>
  );
};
