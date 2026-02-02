import React, { createContext, useState, useEffect } from "react";

export const ThemeContext = createContext();

export const ThemeProvider = ({ children }) => {
  // const [darkMode, setDarkMode] = useState(() => {
  //   return (
  //     localStorage.getItem("darkMode") === "true" ||
  //     window.matchMedia("(prefers-color-scheme: dark)").matches
  //   );
  // });
  const [darkMode, setDarkMode] = useState(false);


 useEffect(() => {
  if (darkMode) {
    document.body.setAttribute("data-theme", "dark");
  } else {
    document.body.removeAttribute("data-theme");
  }
  localStorage.setItem("darkMode", darkMode);
}, [darkMode]);


  const toggleTheme = () => setDarkMode((prev) => !prev);

  return (
    <ThemeContext.Provider value={{ darkMode, toggleTheme }}>
      {children}
    </ThemeContext.Provider>
  );
};
