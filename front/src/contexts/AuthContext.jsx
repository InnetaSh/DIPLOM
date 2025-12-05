import React, { createContext, useState, useEffect } from 'react';
import { jwtDecode } from "jwt-decode";
import http from "../api/http";
import axios from 'axios';

export const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
  const [user, setUser] = useState(null);
  const [token, setToken] = useState(null);

  useEffect(() => {
    const storedToken = localStorage.getItem('token');

    if (storedToken) {
      try {
        const decoded = jwtDecode(storedToken);

        if (decoded.exp * 1000 > Date.now()) {
          setUser({
            id: decoded.sub,
            email: decoded.email,
            name: decoded.name,
            role: decoded.role,
          });

          setToken(storedToken);
        } else {
          logout();
        }
      } catch (err) {
        logout();
      }
    }
  }, []);

 
  const login = async (username, password) => {
    try {
      const response = await http.post("/User/login", { username, password });
      const jwt = response.data.token;

      const decoded = jwtDecode(jwt);

      const userData = {
        id: decoded.sub,
        email: decoded.email,
        name: decoded.name,
        role: decoded.role,
      };

      localStorage.setItem('token', jwt);
      setToken(jwt);
      setUser(userData);

      return { success: true };
    } catch (error) {
      return { success: false, message: 'Неверные данные' };
    }
  };


  const register = async (username, email, password, phoneNumber, roleName) => {
    try {
      const response = await http.post("/User/register", {
        username,
        email,
        password,
        phoneNumber,
        roleName
      });

      const jwt = response.data.token;

      const decoded = jwtDecode(jwt);

      const userData = {
        id: decoded.sub,
        email: decoded.email,
        name: decoded.username,
        role: decoded.roleName,
      };

      localStorage.setItem("token", jwt);
      setToken(jwt);
      setUser(userData);

      return { success: true };
    } catch (error) {
      console.error("Register error:", error);
      return { success: false, message: "Ошибка регистрации" };
    }
  };


  const logout = () => {
    localStorage.removeItem('token');
    setToken(null);
    setUser(null);
  };

  return (
    <AuthContext.Provider value={{ user, token, login, register, logout }}>
      {children}
    </AuthContext.Provider>
  );
};
