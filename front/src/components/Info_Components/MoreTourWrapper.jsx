import { useEffect, useState } from "react";
import { More_tour } from "./More_tour";
import styles from "./MoreTourWrapper.module.css";

const BASE_WIDTH = 1920;
const BASE_HEIGHT = 1712;

export const MoreTourWrapper = () => {
  const [scale, setScale] = useState(1);

  useEffect(() => {
    const resize = () => {
      setScale(window.innerWidth / BASE_WIDTH);
    };
    resize();
    window.addEventListener("resize", resize);
    return () => window.removeEventListener("resize", resize);
  }, []);

  return (
    <div
      className={styles.more_tour_outer}
      style={{
        height: `${BASE_HEIGHT * scale}px`, 
      }}
    >
      <div
        className={styles.more_tour}
        style={{
          transform: `scale(${scale})`,
          transformOrigin: "top center",
        }}
      >
        <More_tour />
      </div>
    </div>
  );
};
