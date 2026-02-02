export const ImageSvg = ({
  name,          // для sprite: "user-male"
  src,           // для img: "/img/earth-globe.svg"
  sizeX = 24,
  sizeY = 24,
  alt = "",
  className = "",
}) => {
  // SVG sprite
  if (name) {
    return (
      <svg
        width={sizeX}
        height={sizeY}
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
        width={sizeX}
        height={sizeY}
        alt={alt}
        className={className}
      />
    );
  }

  return null;
};
