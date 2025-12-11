import React, { useContext, useState } from "react";
import { AuthContext } from "../../contexts/AuthContext";
import { Image } from "../UI/Image/Image.jsx";
import { IconButton } from "../UI/Button/IconButton.jsx";
import { TextButton } from "../UI/Button/TextButton.jsx";
import {IconWithTextButton} from "../UI/Button/IconWithTextButton.jsx"
import { SecondaryButton } from "../UI/Button/SecondaryButton.jsx";
import { Text } from "../../components/UI/Text/Text.jsx"
import {UserMenu} from "./UserMenu.jsx"
import { useNavigate } from "react-router-dom";

import "../../styles/globals.css";
import "./Header.css";

import logo from "../../img/logo/Booking-Emblema.jpg";
import { ReactComponent as PhoneIcon } from "../../img/icons/phone.svg";


export const Header = ({ showLogBtn = true }) => {
  const navigate = useNavigate();
  const { user } = useContext(AuthContext);

  const [openMenu, setOpenMenu] = useState(false);
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
            <IconButton
              icon={<PhoneIcon />}
              onClick={() => console.log("Связаться с нами clicked")}
            />

            {user ? (
              <div className="user-cabiten__container">
                <TextButton text="Зарегистрировать свой объект" onClick={() => console.log("Зарегистрировать clicked")} />
                <div className="user-cabiten__info">

                  <IconWithTextButton
                    icon="👤"
                    text={user.name}
                    textType ="bold"
                    onClick={() => setOpenMenu(prev => !prev)}
                  />

                  {openMenu && <UserMenu />}
                </div>
              </div>
            ) : (

              showLogBtn && (
                <>
                  <SecondaryButton
                    text="Зарегистрироваться"
                    onClick={() => navigate("/register")}
                  />
                  <SecondaryButton
                    text="Войти в аккаунт"
                    onClick={() => navigate("/login")}
                  />
                </>
              )
            )}
          </div>
        </div>



      </div>
    </div>
  );
};
