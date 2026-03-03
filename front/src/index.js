import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import "./i18n";
import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";
import App from './App';
import reportWebVitals from './reportWebVitals';
import { AuthProvider } from './contexts/AuthContext';
import { ThemeProvider } from './contexts/ThemeContext';
import { ApiProvider } from './contexts/ApiContext';
import { LanguageProvider } from "./contexts/LanguageContext";
import { GoogleOAuthProvider } from '@react-oauth/google';
import { loadConfig } from "./api/config";

// Aouth
//123721973387-7i3rs06c8iui5lrb805f22o0k2s6gk1o.apps.googleusercontent.com => id
//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 => secret

loadConfig().then(() => {
  const root = ReactDOM.createRoot(document.getElementById('root'));
  root.render(
    <ApiProvider>
      <ThemeProvider>
        <AuthProvider>
          <LanguageProvider>
            <GoogleOAuthProvider clientId="123721973387-7i3rs06c8iui5lrb805f22o0k2s6gk1o.apps.googleusercontent.com">
              <App />
            </GoogleOAuthProvider>
          </LanguageProvider>
        </AuthProvider>
      </ThemeProvider>
    </ApiProvider>
  );
});

// const root = ReactDOM.createRoot(document.getElementById('root'));
// root.render(
//   <ApiProvider>
//     <ThemeProvider>
//       <AuthProvider>
//         <LanguageProvider>
//           <GoogleOAuthProvider clientId="123721973387-7i3rs06c8iui5lrb805f22o0k2s6gk1o.apps.googleusercontent.com">
//           <App />
//           </GoogleOAuthProvider>
//         </LanguageProvider>
//       </AuthProvider>
//     </ThemeProvider>
//   </ApiProvider>
// );


// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
