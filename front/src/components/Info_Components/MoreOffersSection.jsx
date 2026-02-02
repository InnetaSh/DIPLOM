import React from "react";
import { useTranslation } from "react-i18next";
import { footerLinks } from '../../data/footerLinks.js';
import { Logo_Oselya__footer } from '../Logo/Logo_Oselya_footer.jsx';

import { Logo_Oselya_128 } from "../Logo/Logo_Oselya_128.jsx";
import { Link } from "../UI/Text/Link.jsx"
import { Text } from "../UI/Text/Text.jsx"
import { ActionButton__Primary } from "../UI/Button/ActionButton_Primary.jsx";
import { MoreOffersSection_card } from "./MoreOffersSection_card.jsx"

import styles from './Info_components.module.css';

export const MoreOffersSection = () => {
  const { t } = useTranslation();


  return (
    <div className={styles.moreOffersSection}>
      <div className="flex-center btn-w-full p-20 mb-30 ">
        <Text text={t("moreOffersSection.title")} type="title" />
      </div>

      <div className={styles.moreOffersSection_content}>

        <div className={styles.moreOffersSection__grid}>
          <MoreOffersSection_card
            showText={false}
            className={styles.moreOffersSection_card__container_left} />
          <MoreOffersSection_card
            title={t("moreOffersSection.right_column.title")}
            text={t("moreOffersSection.right_column.text")} />
          <MoreOffersSection_card
            title={t("moreOffersSection.left_column.title")}
            text={t("moreOffersSection.left_column.text")} />
          <MoreOffersSection_card
            showText={false}
            className={styles.moreOffersSection_card__container_right} />
        </div>
      </div>
    </div >
  );
};
