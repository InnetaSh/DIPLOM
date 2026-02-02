export const IconSvg = ({
  name,          // для sprite: "user-male"
  src,           // для img: "/img/earth-globe.svg"
  size = 24,
  alt = "",
  className = "",
}) => {
  // SVG sprite
  if (name) {
    return (
      <svg
        width={size}
        height={size}
        className={className}
        fill="currentColor"
        aria-hidden={!alt}
        role="img"
      >
        <use href={`/img/sprite.svg#${name}`} />
      </svg>
    );
  }

  // Обычное изображение
  if (src) {
    return (
      <img
        src={src}
        width={size}
        height={size}
        alt={alt}
        className={className}
      />
    );
  }

  return null;
};
