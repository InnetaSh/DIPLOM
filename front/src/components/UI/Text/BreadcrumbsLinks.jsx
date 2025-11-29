import { Link, useLocation } from "react-router-dom";
import { FiChevronRight } from "react-icons/fi";
import styles from "./Text.module.css";

export const Breadcrumbs = () => {
  const location = useLocation();

  const parts = location.pathname.split("/").filter(Boolean);

  const items = [
    { label: "Главная", to: "/" },

    ...parts.map((part, index) => {
      const path = "/" + parts.slice(0, index + 1).join("/");
      return {
        label: decodeURIComponent(part),
        to: path,
      };
    }),
  ];

  if (parts.length >= 1) {
    items.push({ label: "Результаты поиска", to: null });
  }

  return (
    <div className={styles.breadcrumbs}>
      {items.map((item, index) => (
        <div key={index} className={styles.item}>
          {item.to ? (
            <Link to={item.to} className={styles.link}>
              {item.label}
            </Link>
          ) : (
            <span className={styles.disabled}>{item.label}</span>
          )}

          {index < items.length - 1 && (
            <FiChevronRight className={styles.icon} />
          )}
        </div>
      ))}
    </div>
  );
};
