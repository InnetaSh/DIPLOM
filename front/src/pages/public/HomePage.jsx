import React from "react";
import {Header} from "../../components/Header.jsx";

const HomePage = () => {
  return (
    <div className="home-page">
      <Header />

      {/* Основное содержимое страницы */}
      <main className="main-content">
        <h1>Добро пожаловать на главную страницу</h1>
        <p>Здесь будет контент вашего сайта.</p>
        {/* Можно добавить SearchBar отдельно, если нужно */}
      </main>
    </div>
  );
};

export default HomePage;
