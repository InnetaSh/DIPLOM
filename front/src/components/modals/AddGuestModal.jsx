// GuestSelector.jsx
import React from "react";
 import "./AddGuestModal.css";
 import { TextButton } from "../UI/Button/TextButton";

const AddGuestModal = ({ guests, setGuests }) => {
  const increment = (type) => {
    setGuests((prev) => ({ ...prev, [type]: prev[type] + 1 }));
  };

  const decrement = (type) => {
    setGuests((prev) => ({
      ...prev,
      [type]: Math.max(
        type === "adults" || type === "rooms" ? 1 : 0,
        prev[type] - 1
      ),
    }));
  };

  return (
    <div className="guest-dropdown">
      {["adults", "children", "rooms"].map((type) => (
        <div key={type} className="guest-row">
          <span className="guest-label">
            {type === "adults"
              ? "Взрослые"
              : type === "children"
              ? "Дети"
              : "Комнаты"}
          </span>
          <div className="guest-controls">
            <TextButton onClick={() => decrement(type)}>-</TextButton>
            <span>{guests[type]}</span>
            <TextButton onClick={() => increment(type)}>+</TextButton>
          </div>
        </div>
      ))}
    </div>
  );
};

export default AddGuestModal;
