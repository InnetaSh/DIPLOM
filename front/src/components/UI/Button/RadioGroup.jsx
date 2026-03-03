import React, { useState } from "react";
import { RadioButton } from "./RadioButton";
import { useTranslation } from "react-i18next";

export const RadioGroup = ({activeButton,setActiveButton}) => {
  const { t } = useTranslation();

  

  return (
    <div className="radioButton_wrapper">
      <RadioButton
        text={t("Auth.register.owner")}
        active={activeButton === "owner"}
        onClick={() => setActiveButton("owner")}
      />
      <RadioButton
        text={t("Auth.register.client")}
        active={activeButton === "client"}
        onClick={() => setActiveButton("client")}
      />
    </div>
  );
};
