import React, { useState, useEffect, useContext } from "react";
import { useNavigate } from "react-router-dom";
import { AuthContext } from "../../contexts/AuthContext";
import { useLanguage } from "../../contexts/LanguageContext";

import { Header } from "../../components/Header/Header.jsx";
import { LoginModal } from "../../components/modals/LoginModal.jsx";
import { RegisterModal } from "../../components/modals/RegisterModal.jsx";
import { Footer } from "../../components/Footer/Footer.jsx";
import { ProfilePageMenu } from "../../components/ProfilePage_components/ProfilePage_menu.jsx";
import { MainPageBg } from "../../components/MainPage_bg/MainPage_bg.jsx";


import styles from "./ProfilePage.module.css";

export const ProfilePage = () => {
  const { user, token, getMe } = useContext(AuthContext);
  const { language } = useLanguage();
  const navigate = useNavigate();

  const [isLoginModalOpen, setIsLoginModalOpen] = useState(false);
  const [isRegisterModalOpen, setIsRegisterModalOpen] = useState(false);


  useEffect(() => {
    if (token) {
      getMe(language);
    }
  }, [language, token]);

  return (
    <div className={styles.profilePage}>
      <Header isLoginModalOpen={isLoginModalOpen} setIsLoginModalOpen={setIsLoginModalOpen} />

      <MainPageBg />
      <main >

        {user ? (
          <ProfilePageMenu user={user} />
        ) : (
          <div className="spinner-wrapper">
            <div className="spinner" />
            <span>Загрузка...</span>
          </div>
        )}


      </main>
      <Footer />
    </div>
  );
};
