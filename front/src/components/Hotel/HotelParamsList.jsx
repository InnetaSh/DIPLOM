import { hotelParamsIcons } from "./paramsIcons";
import { HotelParamsItem } from "./HotelParamsItem";
import { Text } from "../UI/Text/Text";
import styles from "./HotelParamsList.module.css";
import { useTranslation } from "react-i18next";

export const HotelParamsList = ({ params }) => {
    const { t } = useTranslation();
    if (!params || params.length === 0) return null;

    return (
        <div className={styles.list}>
            <Text text={t("hotel_params.params")} type="m_600_s_32" />
            <div className={styles.list__container} >
                {params.map((param) => (
                    <HotelParamsItem
                        key={param.id}
                        title={param.title}
                        iconName ={param.iconName}
                        icon={hotelParamsIcons[param.id]}
                    />
                ))}
            </div>
        </div>
    );
};
