import React, { useContext, useState } from "react";
import { AuthContext } from "../../contexts/AuthContext.jsx";
import { useNavigate } from "react-router-dom";
import { useTranslation } from "react-i18next";
import { useLanguage } from "../../contexts/LanguageContext.jsx";

import { Logo_Oselya } from "../Logo/Logo_Oselya.jsx";
import { Text } from "../UI/Text/Text.jsx";
import { Breadcrumbs } from "../UI/Text/BreadcrumbsLinks.jsx";
import { SearchBar } from "../../components/SearchBar/SearchBar.jsx";
import { IconButton__50 } from "../UI/Button/IconButton_50.jsx";
import { IconButton__35 } from "../UI/Button/IconButton_35.jsx";
import { ActionButton__Primary } from "../UI/Button/ActionButton_Primary.jsx";
import { SortMenuModal } from "../../components/modals/SortMenuModal.jsx";
import { MenuModal } from "../../components/modals/MenuModal.jsx";
import { LanguageModal } from "../modals/LanguageModal.jsx";

import { LoginModal } from "../../components/modals/LoginModal.jsx";
import { RegisterModal } from "../../components/modals/RegisterModal.jsx";

import styles from './Header.module.css';


export const Header_Full = ({
  showLogBtn = true,
  city = "",
  region = "",
  country = "",
  title = "",
  titleBtn,
  adults,
  children,
  rooms,
  startDate,
  endDate,
  params,
  showFilterBtn = true,
  openFilterMenu = true,
  setOpenFilterMenu = false,
  handleSearchResults,
  handleSortChange
}) => {
  const navigate = useNavigate();

  const { user } = useContext(AuthContext);
  const [openMenu, setOpenMenu] = useState(false);
  const [openSortMenu, setOpenSortMenu] = useState(false);
  const [isModalLanguageOpen, setIsModalLanguageOpen] = useState(false);
  const [isLoginModalOpen, setIsLoginModalOpen] = useState(false);
  const [isRegisterModalOpen, setIsRegisterModalOpen] = useState(false);
  const [currency, setCurrency] = useState("");

  const { t } = useTranslation();
  const { language, setLanguage } = useLanguage();

  const handleLanguageToggle = () => {
    setIsModalLanguageOpen(true);
    setOpenSortMenu(false);
    setIsLoginModalOpen(false);
    setOpenFilterMenu(false);
  };

  const handleMenuToggle = () => {
    setOpenMenu(true);
  };




  return (
    <div className={`${styles.headerMain} ${styles.headerMain_full} flex-center`}>
      <div className={`${styles.headerMain__container} flex-stretch-column`} >
        {openMenu && (
          <div className={styles.headerMain_sortBtn__dropdown}>
            <MenuModal setIsModalOpen={setOpenMenu} />
          </div>
        )}
        <div className={`${styles.headerMain_Logo__container}   flex-between`} >
          <div
            className={`${styles.headerMain__logo} ${styles.headerMain__logo_order}`}
            onClick={() => navigate("/")}
            style={{ cursor: "pointer" }}
          >
            <Logo_Oselya />
          </div>
          <div className={`${styles.searchBar} ${styles.searchBar_order}`}>
            <SearchBar
              city={city}

              params={params}
              onSearch={handleSearchResults}
            />
          </div>
          <div className={`${styles.headerMain__logo__actions_container} ${styles.headerMain__logo__actions_container_order} flex-center gap-20`}>
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
                  setOpenSortMenu(false);
                  setOpenFilterMenu(false);
                  setIsModalLanguageOpen(false);
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
              title="User"
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
        <div className={`${styles.headerMain_breadcrumbs__container} flex-left`} >
          <Breadcrumbs city={city} region={region} country={country} hotelTitle={title} />
        </div>
        <div className={`${styles.headerMain_cityTitle__container} flex-center`} >
          <Text text={title} type="m_700_s_40" />
          {showFilterBtn && (
            <div className={`${styles.headerMain_cityTitle_btn__container} p-r-87  gap-10 flex-right `}>

              <IconButton__35
                icon_src="/img/sorting-icon.svg"
                onClick={() => {
                  setOpenSortMenu((prev) => !prev);
                  setOpenFilterMenu(false);
                  setIsModalLanguageOpen(false);
                }}
              />
              {openSortMenu && (
                <div className={styles.headerMain_sortBtn__dropdown}>
                  <SortMenuModal onSortChange={handleSortChange} />
                </div>
              )}

              <ActionButton__Primary
                text={titleBtn || t('sort.sort_btn')}
                className="btn-w-148 btn-h-35 btn-br-r-10"
                onClick={() => {
                  setOpenFilterMenu((prev) => !prev);
                  setOpenSortMenu(false);
                  setIsModalLanguageOpen(false);
                }}
              />


            </div>
          )}
        </div>
      </div>
    </div>
  );
};

