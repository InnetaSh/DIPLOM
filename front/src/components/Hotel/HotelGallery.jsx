import styles from "./HotelGallery.module.css";
import { Text } from "../UI/Text/Text.jsx";
import { useTranslation } from "react-i18next";

export const HotelGallery = ({ images = [] }) => {
  const { t } = useTranslation();

  const showCenter = images.length >= 1;
  const showLeft = images.length >= 2;
  const showRight = images.length >= 4;


  if (!images.length) return <div>{t("hotel_gallery.no photos")}</div>;
  return (
    <div className={styles.gallery}>
      <div className={styles.gallery__container}>
        {images.length >= 1 && (
          <div className={styles.gallery__columns}>

            {/* Левая колонка */}
            {images.length >= 2 && (
              <div className={styles.gallery__column_container}>
                <div className={styles.gallery__columnItem_first}>
                  <img src={images[1]} alt="" />
                </div>

                {images.length >= 3 && (
                  <div className={styles.gallery__columnItem_second}>
                    <img src={images[2]} alt="" />
                    {images.length > 3 && (
                      <div className={styles.blurOverlay}>
                        <Text text={t("hotel_gallery.all_photos")} type="m_700_s_24" />
                      </div>
                    )}
                  </div>
                )}
              </div>
            )}

            {/* Центр */}
            <div
              className={
                images.length === 1
                  ? styles.gallery__only_center_container
                  : styles.gallery__center_container
              }
            >
              <div className={styles.gallery__center_wrapper}>
                <img src={images[0]} alt="" />
              </div>
            </div>

            {/* Правая колонка */}
            {images.length >= 4 && (
              <div className={styles.gallery__column_container}>
                <div className={styles.gallery__columnItem_first}>
                  <img src={images[3]} alt="" />
                </div>

                {images.length >= 5 && (
                  <div className={styles.gallery__columnItem_second}>
                    <img src={images[4]} alt="" />
                  </div>
                )}
              </div>
            )}

          </div>
        )}

      </div>
    </div >
  );
};
