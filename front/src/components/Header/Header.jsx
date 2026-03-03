import React, { useContext, useState, useEffect } from "react";
import { AuthContext } from "../../contexts/AuthContext";
import { useNavigate } from "react-router-dom";
import { useTranslation } from "react-i18next";
import { useLanguage } from "../../contexts/LanguageContext";

import { Logo_Oselya } from "../../components/Logo/Logo_Oselya.jsx";
import { Text } from "../../components/UI/Text/Text.jsx";
import { IconButton__50 } from "../UI/Button/IconButton_50.jsx";
import { MenuModal } from "../../components/modals/MenuModal.jsx";
import { LanguageModal } from "../modals/LanguageModal.jsx";

import { LoginModal } from "../../components/modals/LoginModal.jsx";
import { RegisterModal } from "../../components/modals/RegisterModal.jsx";

import styles from './Header.module.css';

export const Header = () => {
  const navigate = useNavigate();
  const { user } = useContext(AuthContext);
  const [openMenu, setOpenMenu] = useState(false);
  const [isModalLanguageOpen, setIsModalLanguageOpen] = useState(false);
  const [isLoginModalOpen, setIsLoginModalOpen] = useState(false);
  const [isRegisterModalOpen, setIsRegisterModalOpen] = useState(false);

  const { t } = useTranslation();
  const { language, setLanguage } = useLanguage();
  const [currency, setCurrency] = useState("");

  const handleLanguageToggle = () => {
    setIsModalLanguageOpen(true);
  };

  const handleMenuToggle = () => {
    setOpenMenu(true);
  };


  useEffect(() => {
    console.log("Language changed:", language);
  }, [language]);

  return (
    <div className={`${styles.headerMain} ${styles.headerMain_small} flex-center`}>
      <div className={`${styles.headerMain__container} ${styles.headerMain__container_small} p-t-24 flex-between`}>
        {openMenu && (
          <div className={styles.headerMain_sortBtn__dropdown}>
            <MenuModal setIsModalOpen={setOpenMenu} />
          </div>
        )}
        <div className={`${styles.headerMain_Logo__container} flex-between`}>
          <div
            className={`${styles.headerMain__logo} ${styles.headerMain__logo_order}`}
            onClick={() => navigate("/")}
            style={{ cursor: "pointer" }}
          >
            <Logo_Oselya />
          </div>
          <Text text={t("header.subtitle_header_main")} type="m_400_s_32" />
          <div className={`${styles.headerMain__logo__actions_container} flex-center gap-20`}>

            <IconButton__50
              icon_name="user-home"
              onClick={() => navigate("/")}
              title="User"
            />


            <IconButton__50
              icon_name="user-male"
              title="User"
              onClick={() => {
                if (user) {
                  navigate("/profile");
                } else {
                  setIsLoginModalOpen(true);
                }
              }}
            />

            <IconButton__50
              icon_src="/img/earth-globe.svg"
              title="Earth"
              onClick={handleLanguageToggle}
            />

            <IconButton__50
              icon_name="menu"
              title="Menu"
              onClick={handleMenuToggle}
            />


            {isModalLanguageOpen && (
              <div className="modalOverlay">
                <LanguageModal
                  setIsModalOpen={setIsModalLanguageOpen}
                  setLanguage={(lang) => {
                    setLanguage(lang);
                    // setIsModalLanguageOpen(false);
                  }}
                  setCurrency={setCurrency}
                />
              </div>
            )}
            {isLoginModalOpen && (
              <div className="modalOverlay">
                <LoginModal
                  setIsModalOpen={setIsLoginModalOpen}
                  setIsRegisterModalOpen={setIsRegisterModalOpen} />
              </div>
            )}
            {isRegisterModalOpen && (
              <div className="modalOverlay">
                <RegisterModal setIsModalOpen={setIsRegisterModalOpen} />
              </div>
            )}
          </div>
        </div>
      </div>
    </div>
  );
};
