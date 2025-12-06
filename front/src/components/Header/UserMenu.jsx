import { useNavigate } from "react-router-dom";
import { ReactComponent as UserIcon } from "../../img/icons/user.svg";
import { ReactComponent as BagIcon } from "../../img/icons/bag.svg";
import { ReactComponent as GeniusIcon } from "../../img/icons/genius.svg";
import { ReactComponent as WalletIcon } from "../../img/icons/wallet.svg";
import { ReactComponent as ReviewsIcon } from "../../img/icons/reviews.svg";
import { ReactComponent as HeartIcon } from "../../img/icons/heart.svg";
import { ReactComponent as LogoutIcon } from "../../img/icons/logout.svg";

import "./Header.css";

export const UserMenu = ({ onLogout }) => {
  const navigate = useNavigate();

  const menuItems = [
    { text: "Мой аккаунт", icon: <UserIcon />, path: "/profile" },
    { text: "Бронирования и поездки", icon: <BagIcon />, path: "/bookings" },
    { text: "Программа лояльности Genius", icon: <GeniusIcon />, path: "/genius-program" },
    { text: "Вознаграждения и Кошелек", icon: <WalletIcon />, path: "/rewards-wallet" },
    { text: "Отзывы", icon: <ReviewsIcon />, path: "/reviews" },
    { text: "Сохранённое", icon: <HeartIcon />, path: "/saved" },
  ];

  return (
    <div className="user-menu">
      {menuItems.map(({ text, icon, path }) => (
        <button
          key={text}
          className="user-menu-item"
          onClick={() => navigate(path)}
        >
          <span className="user-menu-icon">{icon}</span>
          {text}
        </button>
      ))}

      <button className="user-menu-item logout" onClick={onLogout}>
        <span className="user-menu-icon">
          <LogoutIcon />
        </span>
        Выйти
      </button>
    </div>
  );
};