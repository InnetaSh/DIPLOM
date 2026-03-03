import { useState } from "react";


import styles from "./StarRating.module.css";

export const StarRating = ({ value, onChange }) => {
  const [hovered, setHovered] = useState(0);

  const currentValue = value / 2; // 0–10 → 0–5

  return (
    <div className={styles.starRating}>
      {Array.from({ length: 5 }).map((_, index) => {
        const starValue = index + 1;
        const isActive = hovered
          ? starValue <= hovered
          : starValue <= currentValue;

        return (
          <img
            key={index}
            src={
              isActive
                ? "/img/icon/orange_star.svg"
                : "/img/icon/grey_star.svg"
            }
            alt="star"
            width={20}
            style={{ cursor: "pointer", transition: "0.2s" }}
            onClick={() => onChange(starValue * 2)}
            onMouseEnter={() => setHovered(starValue)}
            onMouseLeave={() => setHovered(0)}
          />
        );
      })}
    </div>
  );
};