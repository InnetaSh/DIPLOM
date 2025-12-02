import styles from './Text.module.css';

export const Text = ({ text, type }) => {
  const className = {
    title: styles.title,
    bolt: styles.bolt_text,
    bold: styles.bold,

    color: styles.color,          
    colorBold: styles.color_bold, 

    middle: styles.middle,
    small: styles.small,
  }[type] || styles.default;

  return <div className={className}>{text}</div>;
};


