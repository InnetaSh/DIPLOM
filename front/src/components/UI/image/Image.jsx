import styles from './Image.module.css';

const Image = ({ src, alt, type }) => {
  const className = {
    logo: styles.logo,
    photo: styles.photo,
    icon: styles.icon,
  }[type] || styles.default;

  return <img className={className} src={src} alt={alt} />;
};

export default Image;
