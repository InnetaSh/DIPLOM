import { useState, useContext, useRef, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { useTranslation } from "react-i18next";

import { Text } from "../UI/Text/Text.jsx"
import {ImageSvg } from "../UI/Image/ImageSvg.jsx";

import styles from './PaymentInfoPanel.module.css';


export const PaymentInfoPanel_card = ({card}) => {
  return (

    <div className={`${styles.panel__form} gap-30 mt-10`} >
      <div className={styles.card_input}>
        <Text text={card.number} type="m_500" />
        <ImageSvg src="/img/card_payment.svg" sizeX="139px" sizeY="89px"/>
      </div>
    </div>
  );
};
