
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';

import React, { useState } from 'react';


// Публичные страницы
import {HomePage} from './pages/public/HomePage';
import {SearchPage} from './pages/public/SearchPage';
import {HotelPage} from './pages/public/HotelPage';
import {LoginPage} from './pages/public/LoginPage';
import {RegisterPage} from './pages/public/RegisterPage';

import ProfilePage from './pages/user/ProfilePage';


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
             {/*<Route path="/bookings" element={<BookingsPage />} />
            <Route path="/booking/:id" element={<BookingDetailsPage />} />
            <Route path="/favorites" element={<FavoritesPage />} />
            <Route path="/settings" element={<SettingsPage />} /> */}

            {/* Host (владельцы жилья) */}
            {/* <Route path="/host" element={<HostDashboard />} />
            <Route path="/host/listings" element={<HostListings />} />
            <Route path="/host/listings/new" element={<NewListing />} />
            <Route path="/host/listings/:id/edit" element={<EditListing />} />
            <Route path="/host/bookings" element={<HostBookings />} /> */}

            {/* Admin */}
            {/* <Route path="/admin" element={<AdminDashboard />} />
            <Route path="/admin/users" element={<UsersAdmin />} />
            <Route path="/admin/hotels" element={<HotelsAdmin />} />
            <Route path="/admin/bookings" element={<BookingsAdmin />} /> */}

          </Routes>
        </Router>
        );
}

        export default App;
