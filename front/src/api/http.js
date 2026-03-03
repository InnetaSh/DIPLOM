// import axios from "axios";
// import { getConfig } from "./config";

// // const API_BASE = "http://localhost:5000"; // URL Gateway
// //const API_BASE = "http://194.61.53.135:5000"; // URL Gateway
// const API_BASE = getConfig().API_BASE;
// console.log("API_BASE:", API_BASE);

// const http = axios.create({
//   baseURL: API_BASE,
//   headers: {
//     "Content-Type": "application/json",
//   },
// });

// http.interceptors.request.use(config => {
//   const token = localStorage.getItem("token");
//   if (token) config.headers.Authorization = `Bearer ${token}`;
//   return config;
// });

// export default http;

import axios from "axios";
import { getConfig } from "./config";


let http = null;

const initHttp = () => {
  if (!http) {
    const { API_BASE } = getConfig();
    console.log("API_BASE =", API_BASE);
    http = axios.create({
      baseURL: API_BASE,
      headers: {
        "Content-Type": "application/json",
      },
    });

    http.interceptors.request.use(config => {
      const token = localStorage.getItem("token");
      if (token) config.headers.Authorization = `Bearer ${token}`;
      return config;
    });
  }
  return http;
};


const proxyHttp = new Proxy({}, {
  get(_, prop) {
    const instance = initHttp();
    return instance[prop];
  }
});

export default proxyHttp;
