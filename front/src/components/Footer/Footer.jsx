import React from "react";
import { useTranslation } from "react-i18next";
import { footerLinks } from '../../data/footerLinks.js';
import { Logo_Oselya__footer } from '../Logo/Logo_Oselya_footer.jsx';

import { Logo_Oselya_64 } from "../Logo/Logo_Oselya_64.jsx";
import { Link } from "../UI/Text/Link.jsx"
import { Text } from "../UI/Text/Text.jsx"
import { IconButton__68 } from "../UI/Button/IconButton_68.jsx"
import styles from './Footer.module.css';

export const Footer = () => {
  const { t } = useTranslation();

  return (
    <footer className={styles.footer}>
      <svg className={styles.footer__svg} viewBox="0 0 1920 445" preserveAspectRatio="xMidYMid slice">
        <path d="M0 132.88C0 132.88 287.5 0 324.25 0C361 0 581 122.106 648.5 132.88C716 143.654 1920 132.88 1920 132.88V445H0V132.88Z" fill="#EDE5D1" />
        <g transform="translate(228 54)">
          <foreignObject width="300" height="150">
            <div xmlns="http://www.w3.org/1999/xhtml" className={styles.footer__logo_wrapper}>
              <Logo_Oselya_64 />
            </div>
          </foreignObject>
        </g>
      </svg>



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
          <p><Link type="m_400_s_20" to="mailto:oselya.dom@gmail.com" text={t('footer.app.android')} /></p>
          <p><Link type="m_400_s_20" to="mailto:oselya.dom@gmail.com" text={t('footer.app.ios')} /></p>
          <div className={styles.footer__app_button}>
            <Logo_Oselya__footer />
          </div>
        </div>
      </div>
    </footer>
  );
};
