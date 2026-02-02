import { MapContainer, TileLayer, Marker, Popup } from "react-leaflet";
import { Text } from "../UI/Text/Text.jsx";
import L from "leaflet";
import "leaflet/dist/leaflet.css";

import styles from "./HotelMap.module.css";

delete L.Icon.Default.prototype._getIconUrl;
L.Icon.Default.mergeOptions({
  iconRetinaUrl:
    "https://unpkg.com/leaflet@1.9.4/dist/images/marker-icon-2x.png",
  iconUrl:
    "https://unpkg.com/leaflet@1.9.4/dist/images/marker-icon.png",
  shadowUrl:
    "https://unpkg.com/leaflet@1.9.4/dist/images/marker-shadow.png",
});

export const HotelMap = ({
  lat,
  lng,
  hotelName,
  minHeight = 466, 
}) => {
  if (!lat || !lng) return null;

  return (
    <div
      className={styles.hotel_map}
      style={{ minHeight: `${minHeight}px`, height: "100%", display: "flex", flexDirection: "column" }}
    >
      {hotelName && (
        <div className={styles.mapContainer_adress}>
          <Text text="adress" type="m_400_s_20" />
        </div>
      )}
      <div style={{ flex: 1, minHeight: 0 }}>
        <MapContainer
          center={[lat, lng]}
          zoom={15}
          scrollWheelZoom={false}
          className={styles.mapContainer}
        >
          <TileLayer
            attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a>'
            url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
          />
          <Marker position={[lat, lng]}>
            <Popup>{hotelName}</Popup>
          </Marker>
        </MapContainer>
      </div>
    </div>
  );
};
