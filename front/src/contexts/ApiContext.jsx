import React, { createContext } from "react";
import { authApi } from "../api/auth";
import { offerApi } from "../api/offer";
import { orderApi } from "../api/order";
import { countryApi } from "../api/country";
import { cityApi } from "../api/city";
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
        countryApi,
        cityApi,
        paramItemApi,
        paramsCategoryApi,
        rentObjParamValueApi
      }}
    >
      {children}
    </ApiContext.Provider>
  );
};
