import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import { useTranslation } from "react-i18next";
import { DateInputWithIcon } from "./DateInputWithIcon";

import styles from "./SearchBar.module.css";

export const DateRangeInput = ({ 
    dateRange,
    icon_title,
    icon_size ,
    classTitle = "btn-h-35 btn-w-276",
     setDateRange }) => {
    const { t } = useTranslation();
    

    return (
        <div className={`${styles.searchBar__wrapper} ${classTitle} btn-br-r-10 `}>
            <DatePicker
                selectsRange
                startDate={dateRange.start}
                endDate={dateRange.end}
                onChange={([start, end]) =>
                    setDateRange({ start, end })
                }
                placeholderText={t("DateRangeInput.date")}
                dateFormat="dd.MM.yyyy"
                customInput={<DateInputWithIcon 
                    classTitle ={classTitle} 
                    icon_title = {icon_title}
                    icon_size = {icon_size} />}
            />
        </div>
    );
};
