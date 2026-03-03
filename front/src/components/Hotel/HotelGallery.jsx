import styles from "./HotelGallery.module.css";
import { Text } from "../UI/Text/Text.jsx";
import { useTranslation } from "react-i18next";

export const HotelGallery = ({ images = [] }) => {
    const { t } = useTranslation();

  if (!images.length) return <div>{t("hotel_gallery.no photos")}</div>;
  return (
    <div className={styles.gallery}>
      <div className={styles.gallery__container}>
        {images.length >= 1 && (
          <div className={styles.gallery__columns}>

            {/* Левая колонка */}
            <div className={styles.gallery__column_container}>
              <div className={styles.gallery__columnItem_first}>
                <img src={images[1]} alt="" />
              </div>

              <div className={styles.gallery__columnItem_second}>
                <img src={images[2]} alt="" />
                <div className={styles.blurOverlay}>
                  <Text text={t("hotel_gallery.all_photos")} type="m_700_s_24" />
                </div>
              </div>
            </div>

            {/* Центр */}
            <div className={styles.gallery__center_container}>
              <div className={styles.gallery__center_wrapper}>
                <img src={images[0]} alt="" />
              </div>
            </div>

            {/* Правая колонка */}
            <div className={styles.gallery__column_container}>
              <div className={styles.gallery__columnItem_first}>
                <img src={images[3]} alt="" />
              </div>
              <div className={styles.gallery__columnItem_second}>
                <img src={images[4]} alt="" />
              </div>
            </div>

          </div>
        )}
      </div>
    </div>
  );
};
