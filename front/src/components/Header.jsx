import React from "react";
import { Image } from "./UI/Image/Image.jsx";
import { IconButton } from "./UI/Button/IconButton.jsx";
import { TextButton } from "./UI/Button/TextButton.jsx";
import { SecondaryButton } from "./UI/Button/SecondaryButton.jsx";
import SearchBar from "../components/UI/SearchBar/SearchBar.jsx";

import "../styles/globals.css";
import "./Header.css";

import logo from "../img/logo/Booking-Emblema.jpg";

export const Header = ({ onSearchResults }) => {
  return (
    <div className="header">
      <div className="header-container">
        <div className="header-main">
          <div className="logo-container">
            <Image src={logo} alt="Logo" type="logo" />
          </div>

          <div className="actions-container">
            <IconButton icon="UAH" onClick={() => console.log("Menu clicked")} />
            <IconButton icon="EN" onClick={() => console.log("EN clicked")} />
            <IconButton icon="Связаться" onClick={() => console.log("Связаться с нами clicked")} />
            <TextButton text="Зарегистрировать свой объект" onClick={() => console.log("Зарегистрировать clicked")} />
            <SecondaryButton text="Зарегистрироваться" onClick={() => console.log("Зарегистрироваться clicked")} />
            <SecondaryButton text="Войти в аккаунт" onClick={() => console.log("Войти в аккаунт clicked")} />
          </div>
        </div>

       
        <div className="search-bar">
          <SearchBar onSearch={onSearchResults} />
        </div>
      </div>
    </div>
  );
};
