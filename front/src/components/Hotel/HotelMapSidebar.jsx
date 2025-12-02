import React, { useMemo } from "react";
import { MapContainer, TileLayer, Marker, Popup } from "react-leaflet";
import MarkerClusterGroup from "react-leaflet-markercluster";
import L from "leaflet";
import "leaflet/dist/leaflet.css";
import "react-leaflet-markercluster/dist/styles.min.css";
import styles from "./HotelMapSidebar.module.css";

// Иконка выбранного отеля
const hotelIcon = new L.Icon({
  iconUrl: "https://cdn-icons-png.flaticon.com/512/684/684908.png",
  iconSize: [35, 35],
});

// Иконка достопримечательностей и соседних отелей
const attractionIcon = new L.Icon({
  iconUrl: "https://cdn-icons-png.flaticon.com/512/252/252025.png",
  iconSize: [28, 28],
});

// Функция для расчета расстояния между координатами (метры)
const getDistanceFromLatLonInMeters = (lat1, lon1, lat2, lon2) => {
  const R = 6371000; // Радиус Земли в метрах
  const dLat = (lat2 - lat1) * Math.PI / 180;
  const dLon = (lon2 - lon1) * Math.PI / 180;
  const a =
    Math.sin(dLat / 2) * Math.sin(dLat / 2) +
    Math.cos(lat1 * Math.PI / 180) *
      Math.cos(lat2 * Math.PI / 180) *
      Math.sin(dLon / 2) * Math.sin(dLon / 2);
  const c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
  return R * c; // расстояние в метрах
};

// Вычисление соседних отелей
const getNearbyHotels = (hotel, allHotels, radius = 500) => {
  return allHotels.filter((h) => {
    if (h.name === hotel.name) return false; // исключаем сам отель
    const distance = getDistanceFromLatLonInMeters(
      hotel.location.lat,
      hotel.location.lng,
      h.location.lat,
      h.location.lng
    );
    return distance <= radius;
  });
};

export const HotelMapSidebar = ({ hotel, allHotels = [], nearbyAttractions = [] }) => {
  if (!hotel?.location) return null;

  const nearbyHotels = useMemo(() => getNearbyHotels(hotel, allHotels, 500), [hotel, allHotels]);

  const { lat, lng } = hotel.location;

  return (
    <div className={styles.sidebarContainer}>
      {/* Карта */}
      <div className={styles.mapWrapper}>
        <MapContainer center={[lat, lng]} zoom={15} style={{ height: "400px", width: "100%" }}>
          <TileLayer
            url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
            attribution="&copy; OpenStreetMap contributors"
          />

          {/* Маркер выбранного отеля */}
          <Marker position={[lat, lng]} icon={hotelIcon}>
            <Popup>
              <strong>{hotel.name}</strong>
              <br />
              {hotel.address}
            </Popup>
          </Marker>

          {/* Кластеризация достопримечательностей и соседних отелей */}
          <MarkerClusterGroup>
            {nearbyAttractions.map((place, i) => (
              <Marker key={`attr-${i}`} position={[place.lat, place.lng]} icon={attractionIcon}>
                <Popup>
                  <strong>{place.name}</strong>
                  <br />
                  {place.description || ""}
                </Popup>
              </Marker>
            ))}

            {nearbyHotels.map((h, i) => (
              <Marker key={`hotel-${i}`} position={[h.location.lat, h.location.lng]} icon={attractionIcon}>
                <Popup>
                  <strong>{h.name}</strong>
                  <br />
                  {h.address}
                </Popup>
              </Marker>
            ))}
          </MarkerClusterGroup>
        </MapContainer>
      </div>

      {/* Список соседних отелей справа */}
      <div className={styles.nearbyList}>
        <h4>Отели рядом</h4>
        {nearbyHotels.length === 0 && <div>Нет отелей поблизости</div>}
        {nearbyHotels.map((h, i) => (
          <div key={i} className={styles.nearbyItem}>
            <strong>{h.name}</strong>
            <div>{h.address}</div>
          </div>
        ))}
      </div>
    </div>
  );
};
