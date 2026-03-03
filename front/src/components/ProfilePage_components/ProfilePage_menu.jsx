import { useState, useEffect, useContext } from "react";
import { useTranslation } from "react-i18next";
import { useNavigate } from "react-router-dom";
import { ApiContext } from "../../contexts/ApiContext.jsx";
import { AuthContext } from "../../contexts/AuthContext.jsx";
import { ThemeContext } from "../../contexts/ThemeContext";
import { useLanguage } from "../../contexts/LanguageContext.jsx";

import { Logo_Oselya_128 } from "../Logo/Logo_Oselya_128.jsx";
import { Text } from "../UI/Text/Text.jsx";
import { StateButton_Profile } from "../UI/Button/StateButton_Profile.jsx";
import { AccountPanel } from "./AccountPanel.jsx";
import { MyTravelsPanel } from "./MyTravelsPanel.jsx";
import { PaymentInfoPanel } from "./PaymentInfoPanel.jsx";
import { HelpPanel } from "./HelpPanel.jsx";
import { PrivacyPanel } from "./PrivacyPanel.jsx";
import { HistoryPanel } from "./HistoryPanel.jsx";
import { MessagePanel } from "./MessagePanel.jsx";
import { HousingPanel } from "./HousingPanel.jsx";
import styles from './ProfilePage_menu.module.css';

export const ProfilePageMenu = ({ user }) => {
  const { t } = useTranslation();
  const navigate = useNavigate();
  const { logout } = useContext(AuthContext);
  const { orderApi } = useContext(ApiContext);
  const { language } = useLanguage();

  const [account, setAccount] = useState(user ? user.roleName : null);
  const [activeKey, setActiveKey] = useState("account");
  const [hasPendingByOfferId, setHasPendingByOfferId] = useState([]);

  const { darkMode } = useContext(ThemeContext);

  const classFooter_bg = darkMode
    ? "bg_img__dark"
    : "bg_img__light";

  useEffect(() => {
    if (user) {
      setAccount(user.roleName);
    }
  }, [user]);


  const baseButtons = [
    { key: "account", icon: "menu_btn_account", text: t("Prrofile.menu_btn_account") },
    { key: "travels", icon: "menu_btn_my_travels", text: t("Prrofile.menu_btn_my_travels") },
    { key: "payment", icon: "menu_btn_payment_info", text: t("Prrofile.menu_btn_payment_info") },
  ];

  const hostOnlyButtons = [
    { key: "housing", icon: "menu_btn_housing", text: t("Prrofile.menu_btn_my_housing") },
  ];

  const commonBottomButtons = [
    { key: "help", icon: "menu_btn_help", text: t("Prrofile.menu_btn_help") },
    { key: "privacy", icon: "menu_btn_privacy", text: t("Prrofile.menu_btn_privacy") },
    { key: "history", icon: "menu_btn_history", text: t("Prrofile.menu_btn_history") },
    { key: "logout", icon: "menu_btn_logout", text: t("Prrofile.menu_btn_logout") },
  ];

  const buttons = [
    ...baseButtons,
    ...(account === "Owner" ? hostOnlyButtons : []),
    ...commonBottomButtons,
  ];

  const renderRightPanel = (key) => {
    switch (key) {
      case "account": return <AccountPanel user={user} />;
      case "travels": return <MyTravelsPanel isActivePanel={true} />;
      case "payment": return <PaymentInfoPanel />;
      case "help": return <HelpPanel />;
      case "housing": return <HousingPanel pendingOfferIds={hasPendingByOfferId} />
      case "privacy": return <PrivacyPanel />;
      case "history": return <HistoryPanel isHistoryPanel={true} />;
      case "message": return <MessagePanel />;
      default: return null;
    }
  };

  const handleButtonClick = async (key) => {
    if (key === "logout") {
      const result = await logout();
      navigate("/");
    } else {
      setActiveKey(key);
    }
  };

  useEffect(() => {
    document.body.style.cursor = "wait";

    orderApi.hasPendingByOfferId()
      .then(res => {
        setHasPendingByOfferId(res.data);
        console.log({ hasPendingByOfferId: res.data });
      })
      .catch(err => console.error("Error loading offers:", err))
      .finally(() => {
        document.body.style.cursor = "default";
      });

  }, [language]);


  if (!user) {
    return null;
  }
  const firstLetter = user?.username?.charAt(0).toUpperCase() || "";
  return (
    <div className={`${styles.profilePageMenu} ${classFooter_bg}`}>
      {/* <div className={styles.logo}><Logo_Oselya_128 /></div> */}
      <div className={styles.logo}>
        <div
          className={styles.card__title_icon}
        >
          <Text text={firstLetter} type="m_600_s_24" />
        </div>
         <Text text={user?.username} type="m_600_s_24" />
        <Text text={`${user?.lastname || ""}`} type="m_600_s_24" />
      </div>
     
      <div className={styles.profilePageMenu__title}>
        <Text text={t("Prrofile.title")} type="m_600_s_40" />
      </div>
      <div className={styles.profilePageMenu__container}>
        <div className={styles.profilePageMenu__columns}>
          <div className={styles.profilePageMenu__column_left}>
            {buttons.map(btn => (
              <StateButton_Profile
                key={btn.key}
                icon_name={btn.icon}
                className="btn-w-425 btn-h-60 btn-br-r-20"
                isActive={activeKey === btn.key}
                onClick={() => handleButtonClick(btn.key)}
                text={
                  <>
                    {btn.text}
                    {btn.key === "housing" && hasPendingByOfferId.length > 0 && (
                      <span className={styles.status_warning}>!</span>
                    )}
                  </>
                }
              />
            ))}
          </div>
          <div className={styles.profilePageMenu__column_right}>
            {renderRightPanel(activeKey)}
          </div>
        </div>
      </div>
    </div>
  );
};
