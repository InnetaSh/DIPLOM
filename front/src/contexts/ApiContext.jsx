import React, { createContext } from "react";
import { authApi } from "../api/auth";
import {userApi} from "../api/userApi";
import { offerApi } from "../api/offer";
import { adminApi } from "../api/admin";
import {attractionApi} from "../api/attraction";
import { orderApi } from "../api/order";
import { rentObjApi } from "../api/rentObject";
import { locationApi } from "../api/location";
import {reviewApi} from "../api/review";
import { paramItemApi } from "../api/paramItem";
import { paramsCategoryApi } from "../api/paramsCategory";
import { rentObjParamValueApi } from "../api/rentObjParamValue";

export const ApiContext = createContext();

export const ApiProvider = ({ children }) => {
  return (
    <ApiContext.Provider
      value={{
        adminApi,
        attractionApi,
        authApi,
        userApi,
        offerApi,
        orderApi,
        locationApi,
        rentObjApi,
        paramItemApi,
        paramsCategoryApi,
        rentObjParamValueApi,
        reviewApi
      }}
    >
      {children}
    </ApiContext.Provider>
  );
};
