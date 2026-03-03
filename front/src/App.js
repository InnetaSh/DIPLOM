
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';

import React, { useState } from 'react';


// Публичные страницы
import {HomePage} from './pages/public/HomePage';
import {SearchPage} from './pages/public/SearchPage';
import {HotelPage} from './pages/public/HotelPage';
import {LoginPage} from './pages/public/LoginPage';
import {RegisterPage} from './pages/public/RegisterPage';
import { CityPage } from './pages/public/CityPage';
import {AttractionPage} from "./pages/public/AttractionPage";
import {Profile_PastHotelPage} from "./pages/user/Profile_PastHotelPage.jsx";
import {BookingDetailsPage} from "./pages/user/BookingDetailsPage.jsx";
import {AttractionCarouselPage} from "./pages/public/AttractionCarouselPage.jsx";
import {AttractionPageDetail} from "./pages/public/AttractionPageDetail.jsx";

import {ProfilePage} from './pages/user/ProfilePage';

import {HostDashboard} from './pages/host/HostDashboard';
import {AdminDashboard} from "./pages/Admin/AdminDashboard.jsx";

// // Админ-панель
// import AdminDashboard from './pages/admin/AdminDashboard';



function App() {
  const [token, setToken] = useState(localStorage.getItem("token"));

  return (
    <Router>
      <Routes>
            {/* Публичные маршруты */}
            <Route path="/" element={<HomePage />} />
            <Route path="/search" element={<SearchPage />} />
            <Route path="/hotel/:id" element={<HotelPage />} />
            <Route path="/login" element={<LoginPage />} />
            <Route path="/register" element={<RegisterPage />} />
            {/* <Route path="/about" element={<AboutPage />} /> */}

            {/* Приватные маршруты */}
            <Route path="/profile" element={<ProfilePage />} />
            <Route path="/profile/trips/past/:offerId/:orderId" element={<Profile_PastHotelPage />} />
            <Route path="/city/:citySlug" element={<CityPage />} />
            <Route path="/attraction" element={<AttractionPage />} />
            <Route path="/attractionByCity/:citySlug" element={<AttractionCarouselPage />} />
            <Route path="/attractionDetail/:attractionSlug" element={<AttractionPageDetail />} />

             <Route path="/booking/:offerId" element={<BookingDetailsPage />} />
            {/* <Route path="/favorites" element={<FavoritesPage />} />
            <Route path="/settings" element={<SettingsPage />} /> */}

            {/* Host (владельцы жилья) */}
            <Route path="/host" element={<HostDashboard />} />
            {/* <Route path="/host/listings" element={<HostListings />} />
            <Route path="/host/listings/new" element={<NewListing />} />
            <Route path="/host/listings/:id/edit" element={<EditListing />} />
            <Route path="/host/bookings" element={<HostBookings />} /> */}

            {/* Admin */}
            <Route path="/admin" element={<AdminDashboard />} />
            {/* <Route path="/admin/users" element={<UsersAdmin />} />
            <Route path="/admin/hotels" element={<HotelsAdmin />} />
            <Route path="/admin/bookings" element={<BookingsAdmin />} /> */}

          </Routes>
        </Router>
        );
}

        export default App;
