import React from "react";
import { useTranslation } from "react-i18next";
import { useContext } from "react";
import { ThemeContext } from "../../contexts/ThemeContext";
import { footerLinks } from '../../data/footerLinks.js';
import { Logo_Oselya__footer } from '../Logo/Logo_Oselya_footer.jsx';

import { Logo_Oselya } from "../Logo/Logo_Oselya.jsx";
import { Link } from "../UI/Text/Link.jsx"
import { Text } from "../UI/Text/Text.jsx"
import { IconButton__68 } from "../UI/Button/IconButton_68.jsx"
import styles from './Footer.module.css';

export const Footer = () => {
  const { t } = useTranslation();

  const { darkMode } = useContext(ThemeContext);

  const classFooter_bg = darkMode
    ? "bg_img__dark"
    : "bg_img__light";

  return (
    <footer className={`${styles.footer}  ${classFooter_bg}`}>
      <div className={styles.logo}><Logo_Oselya /></div>
      <div className={styles.footer__columns}>
        {Object.entries(footerLinks).map(([section, links]) => (
          <div className={styles.footer__column} key={section}>
            <Text type="m_700_s_40" text={t(`footer.${section}.title`)} />
            <ul>
              {links.map(({ label, href }) => (
                <li key={label}>
                  <Link type="m_400_s_20" to={href} text={t(label)} />
                </li>
              ))}
            </ul>
          </div>
        ))}

        <div className={styles.footer__column}>
          <Text type="m_700_s_40" text={t('footer.contacts.title')} />
          <p><Link type="m_400_s_20" to="mailto:oselya.dom@gmail.com" text="oselya.dom@gmail.com" /></p>
          <p><Link type="m_400_s_20" to="tel:+380508372273" text="+380 (50) 837 2273" /></p>
          <div className={styles.footer__socials}>

            <IconButton__68
              icon_src="/img/Telegram App.svg"
              title="User"
              onClick={() => console.log("Telegram App")}
            />
            <IconButton__68
              icon_src="/img/Instagram.svg"
              title="User"
              onClick={() => console.log("Instagram")}
            />
            <IconButton__68
              icon_src="/img/WhatsApp.svg"
              title="User"
              onClick={() => console.log("WhatsApp")}
            />
          </div>
        </div>
        <div className={styles.footer__column}>
          <Text type="m_700_s_40" text={t('footer.app.title')} />
          <div className={styles.footer__column_logo}>
            <div >
              <p><Link type="m_400_s_20" to="mailto:oselya.dom@gmail.com" text={t('footer.app.android')} /></p>
              <p><Link type="m_400_s_20" to="mailto:oselya.dom@gmail.com" text={t('footer.app.ios')} /></p>

            </div>
            <div className={styles.footer__app_button}>
              <Logo_Oselya__footer />
            </div>
          </div>
        </div>
      </div>
    </footer>
  );
};
