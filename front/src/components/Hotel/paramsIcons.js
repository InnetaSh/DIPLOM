import {
    FaHome,
    FaDog,
    FaWifi,
    FaBath,
    FaShower,
    FaBaby,
    FaSmokingBan,
} from "react-icons/fa";
import { MdBalcony, MdKitchen } from "react-icons/md";
import { PiArrowsOutFill } from "react-icons/pi";

export const hotelParamsIcons = {
    ownHouse: {
        label: "Жильё полностью ваше",
        icon: <FaHome />,
    },
    area: {
        label: "30 м² площадь",
        icon: <PiArrowsOutFill />,
    },
    wifi: {
        label: "Бесплатный Wi-Fi",
        icon: <FaWifi />,
    },
    pets: {
        label: "Можно с питомцами",
        icon: <FaDog />,
    },
    balcony: {
        label: "Балкон",
        icon: <MdBalcony />,
    },
    familyRooms: {
        label: "Семейные номера",
        icon: <FaBaby />,
    },
    nonSmoking: {
        label: "Номера для некурящих",
        icon: <FaSmokingBan />,
    },
    privateBathroom: {
        label: "Собственная ванная комната",
        icon: <FaBath />,
    },
    miniKitchen: {
        label: "Мини-кухня",
        icon: <MdKitchen />,
    },
    shower: {
        label: "Душ",
        icon: <FaShower />,
    },
};
