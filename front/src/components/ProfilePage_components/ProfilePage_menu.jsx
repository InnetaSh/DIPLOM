import { useState, useEffect } from "react";
import { useTranslation } from "react-i18next";

import { Logo_Oselya_128 } from "../Logo/Logo_Oselya_128.jsx";
import { Text } from "../UI/Text/Text.jsx"
import { StateButton_Profile } from "../UI/Button/StateButton_Profile.jsx";
import { AccountPanel } from "./AccountPanel.jsx"
import { MyTravelsPanel } from "./MyTravelsPanel.jsx"
import { PaymentInfoPanel } from "./PaymentInfoPanel.jsx"
import { HelpPanel } from "./HelpPanel.jsx"
import { PrivacyPanel } from "./PrivacyPanel.jsx"
import {MessagePanel} from "./MessagePanel.jsx";
import {HousingPanel} from "./HousingPanel.jsx";
import styles from './ProfilePage_menu.module.css';



export const ProfilePageMenu = ({ user }) => {
  const { t } = useTranslation();

  
  const [account, setAccount] = useState(user ? user.roleName : null);
  const [activeKey, setActiveKey] = useState("account");


  useEffect(() => {
    if (user) {
      setAccount(user.roleName);
    }
  }, [user]);

  if (!user) {
    return null; 
  }

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
    { key: "logout", icon: "menu_btn_logout", text: t("Prrofile.menu_btn_logout") },
  ];

  const buttons = [
    ...baseButtons,
    ...(account === "Owner" ? hostOnlyButtons : []),
    ...commonBottomButtons,
  ];

  const renderRightPanel = (activeKey) => {
    switch (activeKey) {
      case "account": return <AccountPanel user={user} />;
      case "travels": return <MyTravelsPanel />;
      case "payment": return <PaymentInfoPanel />;
      case "help": return <HelpPanel />;
      case "housing": return <HousingPanel />;
      case "privacy": return <PrivacyPanel />;
      case "message": return <MessagePanel />;
      default: return null;
    }
  };

  return (
    <div className={styles.profilePageMenu}>
      <div className={styles.logo}><Logo_Oselya_128 /></div>
      <div className={styles.profilePageMenu__title}>
        <Text text={t("Prrofile.title")} type="m_600_s_40" />
      </div>
      <div className={styles.profilePageMenu__container}>
        <div className={styles.profilePageMenu__columns}>
          <div className={styles.profilePageMenu__column_left}>
            {buttons.map(btn => (
              <StateButton_Profile
                key={btn.key}
                text={btn.text}
                icon_name={btn.icon}
                className="btn-w-425 btn-h-60 btn-br-r-20"
                isActive={activeKey === btn.key}
                onClick={() => setActiveKey(btn.key)}
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
