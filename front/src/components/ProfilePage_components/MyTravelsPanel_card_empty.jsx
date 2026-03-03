import styles from "./MyTravelsPanel_card.module.css";
import { useTranslation } from "react-i18next";
import { Text } from "../UI/Text/Text.jsx";
import {ImageSvg} from "../UI/Image/ImageSvg.jsx";

import { useNavigate } from "react-router-dom";

export const MyTravelsPanel_card_empty = ({text}) => {
   const { t } = useTranslation();

  return (
    <div className={styles.hotelCard_empty}>
      <ImageSvg name="no_photo" sizeX={198}  sizeY={198}/>
      
        <Text text={text} type=" m_500_s_14" />
     
    </div>
  );
};
