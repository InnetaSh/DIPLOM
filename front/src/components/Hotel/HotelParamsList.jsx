import { hotelParamsIcons } from "./paramsIcons";
import { HotelParamsItem } from "./HotelParamsItem";
import styles from "./HotelParamsList.module.css";

export const HotelParamsList = ({ params }) => { 
    if (!params || params.length === 0) return null;

    return (
        <div className={styles.list}>
            {params.map((param) => (
                <HotelParamsItem 
                    key={param.id} 
                    title={param.title}
                   
                />
            ))}
        </div>
    );
};
