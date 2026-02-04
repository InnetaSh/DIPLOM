import React from "react";
import {Text} from "../Text/Text.jsx"
import styles from "./Button.module.css";

type ButtonProps = {
  text: string;
  text_2?: string;
  type?: string;
  type_2?: string;
  onClick?: () => void;
  disabled?: boolean;
  className?: string;
};

export const AnimatedButton = ({
  text,
  text_2,
  type,
  type_2,
  onClick,
  disabled,
  className,
}: ButtonProps) => {
  return (
    <div className={styles.container}>
      <div className={styles.center}>
        <button
          className={`${styles.btn} ${className || ""}`}
          onClick={onClick}
          disabled={disabled}
        >
          <svg
            width="180"
            height="60"
            viewBox="0 0 180 60"
            className={styles.border}
            xmlns="http://www.w3.org/2000/svg"
          >
            <polyline
              points="179,1 179,59 1,59 1,1 179,1"
              className={styles.bgLine}
            />
            <polyline
              points="179,1 179,59 1,59 1,1 179,1"
              className={styles.hlLine}
            />
          </svg>
          <div className={styles.textContainer}>
            <Text text={text} type={type} />
            {text_2 && <Text text={text_2} type={type_2} />}
          </div>
        </button>
      </div>
    </div>
  );
};
