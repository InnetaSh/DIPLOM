import React, { useContext } from "react";
import { useTranslation } from "react-i18next";
import { Text } from "../UI/Text/Text.jsx";
import { ImageSvg } from "../UI/Image/ImageSvg.jsx";
import { IconButtonClose } from "../UI/Button/IconButton_close.jsx";
import { ThemeContext } from "../../contexts/ThemeContext.jsx"; 

import styles from "./Menu.module.css";

export const MenuModal = ({ setIsModalOpen }) => {
  const { t } = useTranslation();
  const { darkMode, toggleTheme } = useContext(ThemeContext); 

  const btnList = [
    { id: "1", imgName: "menu_color_tema", theme: "light", title: t("menu.light_tema"), sizeX: "40", sizeY: "40" },
    { id: "2", imgName: "menu_color_tema", theme: "dark", title: t("menu.dark_tema"), sizeX: "40", sizeY: "40" },
    { id: "3", imgName: "menu_about_us", title: t("menu.about_us"), sizeX: "15", sizeY: "40" },
    { id: "4", imgName: "menu_help", title: t("menu.help"), sizeX: "40", sizeY: "40" },
    { id: "5", imgName: "menu_contacts", title: t("menu.Contacts"), sizeX: "40", sizeY: "50" },
    { id: "6", imgName: "menu_booking", title: t("menu.Booking"), sizeX: "40", sizeY: "38" }
  ];

  return (
    <div className={styles.container}>
      <IconButtonClose onClick={() => setIsModalOpen(false)} />
      <div className={styles.container_title}>
        <div className={styles.container_menu_icon}>
          <ImageSvg sizeX={30} sizeY={30} name="menu" />
        </div>
        <Text text={t("menu.menu_title")} type="m_700_s_48" />
      </div>
      <div className={styles.menuList}>
        {btnList.map(btn => {
      
          if (btn.theme === "dark" && darkMode) return null;
          if (btn.theme === "light" && !darkMode) return null;

          return (
            <button
              key={btn.id}
              className={styles.menulist_btn}
              onClick={() => {
                if (btn.theme) toggleTheme(); 
                setIsModalOpen(false);
              }}
            >
              <div className={styles.container__list_icon}>
                <ImageSvg
                  sizeX={btn.sizeX}
                  sizeY={btn.sizeY}
                  name={btn.imgName}
                />
              </div>
              <Text text={btn.title} type="m_500_s_24" />

            </button>
          );
        })}
      </div>
    </div>
  );
};
