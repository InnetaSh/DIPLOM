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

import styles from './Header.module.css';

export const Header = ({ isLoginModalOpen = false, setIsLoginModalOpen }) => {
  const navigate = useNavigate();
  const { user } = useContext(AuthContext);
  const [openMenu, setOpenMenu] = useState(false);
  const [isModalLanguageOpen, setIsModalLanguageOpen] = useState(false);

  const { t } = useTranslation();
  const { language, setLanguage } = useLanguage(); // Контекст языка
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
        <div className={`${styles.headerMain_Logo__container} flex-between`}>
          <div className={styles.headerMain__logo}>
            <Logo_Oselya />
          </div>
          <Text text={t("header.subtitle_header_main")} type="m_400_s_32" />
          <div className={`${styles.headerMain__logo__actions_container} flex-center gap-20`}>
            <IconButton__50
              icon_name="user-male"
              onClick={() => setIsLoginModalOpen(prev => !prev)}
              title="User"
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
            {openMenu && (
              <div className={styles.headerMain_sortBtn__dropdown}>
                <MenuModal setIsModalOpen={setOpenMenu} />
              </div>
            )}

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
          </div>
        </div>
      </div>
    </div>
  );
};
