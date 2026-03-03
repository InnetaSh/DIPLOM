import { Text } from "../UI/Text/Text";
import { useContext } from "react";
import { ThemeContext } from "../../contexts/ThemeContext";
import { ImageSvg } from "../UI/Image/ImageSvg";
import styles from "./HotelParamsItem.module.css";

export const HotelParamsItem = ({ title, iconName }) => {
    // if (!param) return null;
    const { darkMode } = useContext(ThemeContext);

    const themeFolder = darkMode
        ? "dark_tema"
        : "light_tema";


    const src = `img/icon_params/${themeFolder}/${iconName}.svg`;

    const hasIcon = Boolean(iconName);

    return (
        <div className={styles.item}>
            <ImageSvg
                {...(hasIcon && { iconSrc: src })}
            />
            <Text text={title} type="m_400_s_16" />
            {/* <span className={styles.icon}>{param.icon}</span>
            <span className={styles.label}>{param.label}</span> */}
        </div>
    );
};
