
import { Text } from "../UI/Text/Text.jsx";
import { useTranslation } from "react-i18next";


import styles from "./HotelGalleryModal.module.css";

export const HotelGalleryModal = ({ images = [] }) => {
    const { t } = useTranslation();

  if (!images.length) return <div>{t("hotel_gallery.no photos")}</div>;
  return (
    <div className={styles.gallery}>
      <div className={styles.gallery__container}>
        {images.length >= 5 && (
          <div className={styles.gallery__columns}>

        

            {/* Центр */}
            <div className={styles.gallery__center_container}>
              <div className={styles.gallery__center_wrapper}>
                <img src={images[0]} alt="" />
              </div>
            </div>

            {/* Правая колонка */}
            <div className={styles.gallery__right_container}>
              <div className={styles.gallery__columnItem_first}>
                <img src={images[1]} alt="" />
              </div>
              <div className={styles.gallery__columnItem_second}>
                <div className={styles.second_columns}> 
                   <img src={images[2]} alt="" />
                   <div className={styles.second_columns_blurImg}>
                    <img src={images[3]} alt="" />
                      <div className={styles.blurOverlay}>
                  <Text text={t("Modal.all_photos")} type="m_400_s_16" />
                </div>
                    </div>
                </div>
               
              </div>
            </div>

          </div>
        )}
      </div>
    </div>
  );
};
