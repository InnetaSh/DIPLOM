import { useState, useEffect } from "react";
import { useTranslation } from "react-i18next";
import { useLanguage } from "../../contexts/LanguageContext";

import { Text } from "../UI/Text/Text.jsx";
import { ImageSvg } from "../UI/Image/ImageSvg.jsx";
import { StateButton_Profile_OrangOnHover } from "../UI/Button/StateButton_Profile_OrangOnHover.jsx";
import { IconButtonClose } from "../UI/Button/IconButton_close.jsx";

import styles from './LanguageModal.module.css';


export const LanguageModal = (
  {
    setIsModalOpen,
    setLanguage,
    setCurrency
  }) => {
  const { t } = useTranslation();
  const [activeKey, setActiveKey] = useState("1");
  const [activeLanguage, setActiveLanguage] = useState(null);
  const [activeCurrency, setActiveCurrency] = useState("1");
const { language } = useLanguage();

useEffect(() => {
  const currentLang = LanguageList.find(lang => lang.name === language);
  if (currentLang) {
    setActiveLanguage(currentLang.id);
  }
}, [language]);


  const LanguageList = [
    { id: "1", imgName: "language_Ukraine", imgSrc: "", title: "Українська", name: "uk" },
    { id: "2", imgName: "", imgSrc: "img/language/language_English(UK).svg", title: "English(UK)", name: "en" },
    { id: "3", imgName: "", imgSrc: "img/language/language_English(US).svg", title: "English(US)", name: "en" },
    { id: "4", imgName: "language_Français", imgSrc: "", title: "Français", name: "en" },
    { id: "5", imgName: "", imgSrc: "img/language/language_Еspañol.svg", title: "Еspañol", name: "en" },
    { id: "6", imgName: "language_Іtaliano", imgSrc: "", title: "Іtaliano", name: "en" },
    { id: "7", imgName: "language_Deutsch", imgSrc: "", title: "Deutsch", name: "en" },
    { id: "8", imgName: "language_Рolski", imgSrc: "", title: "Рolski", name: "en" },
    { id: "9", imgName: "", imgSrc: "img/language/language_Türk.svg", title: "Türk", name: "en" },

  ];
  const currencyList = [
    { id: "1", title: t("languageModal.Ukrainian_hryvnia_UAH"), text: "UAH" },
    { id: "2", title: t("languageModal.Pound_GBP"), text: "GBP" },
    { id: "3", title: t("languageModal.dollar_USA"), text: "USA" },
    { id: "4", title: t("languageModal.Euro_EUR"), text: "EUR" },
    { id: "5", title: t("languageModal.Polish_zloty_PLN"), text: "PLN" },
    { id: "6", title: t("languageModal.Turkish_lira_TRY"), text: "TRY" }
  ];

  const buttons = [
    { id: "1", text: t("languageModal.language") },
    { id: "2", text: t("languageModal.currency") }
  ];

  return (
    <div className={styles.languageModal}>
      <div className={styles.languageModal__container}>
        <IconButtonClose onClick={() => setIsModalOpen(false)} />
        <div className={`${styles.container_btn}`}>
          {buttons.map(btn => (
            <StateButton_Profile_OrangOnHover
              key={btn.id}
              text={btn.text}
              icon_name=""
              type="m_700_s_32"
              className={`btn-w-fit-content btn_brdr_1 btn-h-60 btn-br-r-20 ${activeKey === btn.id ? "active" : ""
                }`}
              isActive={activeKey === btn.id}
              onClick={() => setActiveKey(btn.id)}
            />
          ))}

        </div>



        {activeKey === "1" &&
          <>
            <div className={styles.container_language}>
              {LanguageList.map(lang => (
                <button
                  key={lang.id}
                  onClick={() => {
                    setLanguage(lang.name);
                    setActiveLanguage(lang.id);
                  }}
                  className={`
                    ${activeLanguage === lang.id ? styles.btn_active : ''}
                  `}
                >
                  <ImageSvg
                    sizeX={24}
                    sizeY={24}
                    name={lang.imgName}
                    src={lang.imgSrc}
                    className={styles.container_language__icon}
                  />
                  <Text
                    text={lang.title}
                    type="m_700_s_20"
                  />
                </button>
              ))}
            </div>

          </>
        }

        {activeKey === "2" &&
          <div className={styles.container_currency}>
            {currencyList.map(c => (
              <button
                key={c.id}
                onClick={() => {
                  setCurrency(c.title);
                  setActiveCurrency(c.id);
                }}
                className={`
                  ${activeCurrency === c.id ? styles.btn_active : ''}
                `}
              >
                <Text text={c.title} type="m_700_s_20" />
                <Text text={c.text} type="m_700_s_20" />
              </button>
            ))}
          </div>
        }
    

      </div>
    </div >
  );
};
