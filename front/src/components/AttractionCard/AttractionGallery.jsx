
import { Text } from "../UI/Text/Text.jsx";
import { useTranslation } from "react-i18next";

import styles from "./AttractionGallery.module.css";

export const AttractionGallery = ({ images = [] }) => {
    const { t } = useTranslation();

  if (!images.length) return <div>{t("hotel_gallery.no photos")}</div>;
  return (
    <div className={styles.gallery}>
      <div className={styles.gallery__container}>
        {images.length >=4 && (
          <div className={styles.gallery__columns}>

            <div className={styles.gallery__left_container}>
              <div className={styles.gallery__center_wrapper}>
                <img src={images[0]} alt="" />
              </div>
            </div>

            <div className={styles.gallery__center_container}>
              <div className={styles.gallery__center_wrapper}>
                <img src={images[1]} alt="" />
              </div>
            </div>

            <div className={styles.gallery__column_container}>
              <div className={styles.gallery__columnItem_first}>
                <img src={images[2]} alt="" />
              </div>
              <div className={styles.gallery__columnItem_second}>
                <img src={images[3]} alt="" />
              </div>
            </div>

          </div>
        )}
      </div>
    </div>
  );
};
