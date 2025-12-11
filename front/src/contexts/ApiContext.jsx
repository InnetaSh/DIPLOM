import React, { createContext } from "react";
import { authApi } from "../api/auth";
import { offerApi } from "../api/offer";
import { orderApi } from "../api/order";
import { rentObjApi } from "../api/rentObject";
import { locationApi } from "../api/location";
import { paramItemApi } from "../api/paramItem";
import { paramsCategoryApi } from "../api/paramsCategory";
import { rentObjParamValueApi } from "../api/rentObjParamValue";

export const ApiContext = createContext();

export const ApiProvider = ({ children }) => {
  return (
    <ApiContext.Provider
      value={{
        authApi,
        offerApi,
        orderApi,
        locationApi,
        rentObjApi,
        paramItemApi,
        paramsCategoryApi,
        rentObjParamValueApi
      }}
    >
      {children}
    </ApiContext.Provider>
  );
};
