import React, { useState, useEffect, useContext } from "react";
import { useNavigate } from "react-router-dom";
import { Header } from "../../components/Header/Header.jsx";
import { LoginModal } from "../../components/modals/LoginModal.jsx";
import { RegisterModal } from "../../components/modals/RegisterModal.jsx";
import { Footer } from "../../components/Footer/Footer.jsx";
import {ProfilePageMenu} from "../../components/ProfilePage_components/ProfilePage_menu.jsx";
import { MainPageBg } from "../../components/MainPage_bg/MainPage_bg.jsx";

import { ApiContext } from "../../contexts/ApiContext.jsx";
import { useLanguage } from "../../contexts/LanguageContext.jsx";

import styles from "./HostDashboard.module.css";



export const HostDashboard = () => {

  const { language } = useLanguage();
  const navigate = useNavigate();

  const [isLoginModalOpen, setIsLoginModalOpen] = useState(false);
  const [isRegisterModalOpen,setIsRegisterModalOpen] = useState(false);



  return (
    <div className={styles.profilePage}>
      {isLoginModalOpen && (
        <div className="modalOverlay">
          <LoginModal 
          setIsModalOpen ={setIsLoginModalOpen}
          setIsRegisterModalOpen = {setIsRegisterModalOpen}/>
        </div>
      )}
       {isRegisterModalOpen && (
        <div className="modalOverlay">
          <RegisterModal setIsModalOpen ={setIsRegisterModalOpen}/>
        </div>
      )}
      <Header isLoginModalOpen={isLoginModalOpen} setIsLoginModalOpen={setIsLoginModalOpen}/>

      <MainPageBg />
      <main >
       
<ProfilePageMenu account = "host"/>
       
       
   
      </main>
      <Footer />
    </div>
  );
};
