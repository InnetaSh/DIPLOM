
import styles from "./Text.module.css";

export const Link = ({ text, to,type }) => {
  const className = {
    m_300: styles.text_m_300,
    m_400: styles.text_m_400,
    m_400_s_20: styles.text_m_400_s_20 ,
    m_400_s_32: styles.text_m_400_s_32,
    m_500: styles.text_m_500,
    m_500_s_40: styles.text_m_500_s_40,
    m_600: styles.text_m_600,
     m_600_s_32: styles.text_m_600_s_32,
    m_600_s_48: styles.text_m_600_s_48,
    m_700: styles.text_m_700,
    m_700_s_40: styles.text_m_700_s_40,
    roboto_400: styles.text_roboto_400,
    roboto_500: styles.text_roboto_500,
    cagliostro_400: styles.text_cagliostro_400,
    cagliostro_400_s_64:styles.text_cagliostro_400_s_64,
    inter: styles.text_inter,

    title: styles.title,
    bolt: styles.bolt_text,
    bold: styles.bold,

    color: styles.color,          
    colorBold: styles.color_bold, 

    middle: styles.middle,
    small: styles.small,
  }[type] || styles.default;
  return (
    <a className={`${styles.link} ${className}`} href={to}>
      {text}
    </a>
  );
};



