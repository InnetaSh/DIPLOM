import React, { useState, useEffect, useContext } from "react";
import { useNavigate } from "react-router-dom";
import { useTranslation } from "react-i18next";
import { AuthContext } from "../../contexts/AuthContext";
import { useLanguage } from "../../contexts/LanguageContext";

import { StateButton_Profile } from "../../components/UI/Button/StateButton_Profile.jsx";
import { Header_Admin } from "../../components/Header/Header_Admin.jsx";
import { LoginModal } from "../../components/modals/LoginModal.jsx";
import { RegisterModal } from "../../components/modals/RegisterModal.jsx";
import { Footer } from "../../components/Footer/Footer.jsx";
import { ProfilePageMenu } from "../../components/ProfilePage_components/ProfilePage_menu.jsx";
import { MainPageBg } from "../../components/MainPage_bg/MainPage_bg.jsx";
import { Text } from "../../components/UI/Text/Text.jsx";
import { AdminMenuItem } from "../../components/AdminComponents/AdminMenuItem.jsx";
import { AdminInfoPanel } from "../../components/AdminComponents/AdminInfoPanel.jsx";

import styles from "./AdminDashboard.module.css";


export const AdminDashboard = () => {
  const { user, token, getMe } = useContext(AuthContext);
  const { language } = useLanguage();
  const navigate = useNavigate();
  const { t } = useTranslation();
  const [typePanel, setTypePanel] = useState("users");

  const buttons = [
    { id: "users", type: "users", icon: "/img/icon/admin_users_btn.svg", text: t("admin.menu.users") },
    { id: "offers", type: "hotels", icon: "/img/icon/admin_offers_btn.svg", text: t("admin.menu.offers") },
    { id: "reviews", icon: "/img/icon/admin_reviews_btn.svg", text: t("admin.menu.reviews") },
    { id: "settings", icon: "/img/icon/admin_settings_btn.svg", text: t("admin.menu.settings") },
    { id: "tools", icon: "/img/icon/admin_tools_btn.svg", text: t("admin.menu.tools") },
    { id: "contacts", icon: "/img/icon/admin_contacts_btn.svg", text: t("admin.menu.contacts") },
  ];


  const [isLoginModalOpen, setIsLoginModalOpen] = useState(false);
  const [isRegisterModalOpen, setIsRegisterModalOpen] = useState(false);
  const [activeId, setActiveId] = useState("users");


  useEffect(() => {
    if (token) {
      getMe(language);
    }
  }, [language, token]);





  return (
    <div className={styles.adminDashboard}>
      <Header_Admin isLoginModalOpen={isLoginModalOpen} setIsLoginModalOpen={setIsLoginModalOpen} />

      <MainPageBg />
      <main >
        <div className={styles.adminDashboard__container}>
          <div className={styles.adminDashboard__columns}>
            <div className={styles.adminDashboard__column_left}>
              {buttons.map(btn => (
                <AdminMenuItem
                  key={btn.id}
                  label={btn.text}
                  iconName={btn.icon}
                  active={btn.id === activeId}
                  onClick={() => {
                    setActiveId(btn.id);
                    setTypePanel(btn.type)
                  }}
                />
              ))}
            </div>
            <div className={styles.adminDashboard__column_right}>
              <AdminInfoPanel type={typePanel} />
            </div>
          </div>
        </div>

        {/* {user ? (
          <AdminPageMenu user={user} />
        ) : (
          <div className="spinner-wrapper">
            <div className="spinner" />
            <span>Загрузка...</span>
          </div>
        )} */}


      </main>
      <Footer />
    </div>
  );
};
