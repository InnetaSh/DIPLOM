import styles from './Image.module.css';

export const Image = ({ src, alt, type }) => {
  const className = {
    logo: styles.logo,
    photo: styles.photo,
    card: styles.card,
    icon: styles.icon,
  }[type] || styles.default;

  return <img className={className} src={src} alt={alt} />;
};


