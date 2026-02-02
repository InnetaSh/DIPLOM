import React, { useContext, useState } from "react";
import { useNavigate } from "react-router-dom";
import { Text } from "../UI/Text/Text.jsx";
import { useTranslation } from "react-i18next";

import styles from './Bunner.module.css';

export const BunnerHotel = ({className, text ="bunner.room" }) => {
    const navigate = useNavigate();

  const { t } = useTranslation();


    return (
        <div className={`${styles.bunner} flex-center`}>
            <div className={`${styles.bunner__container} ${styles.bunner__container_img_room}`}>
                <Text text={t(text)} type="m_400_s_150" />
            </div>
        </div>
    );
};

