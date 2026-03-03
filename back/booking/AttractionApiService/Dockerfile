FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["Globals/Globals.csproj", "Globals/"]
#COPY ["booking/AttractionApiService/AttractionApiService.csproj", "booking/AttractionApiService/"]
#COPY ["AttractionApiService/AttractionApiService.csproj", "AttractionApiService/"]
COPY ["AttractionApiService/AttractionApiService.csproj", "AttractionApiService/"]

#RUN dotnet restore "booking/AttractionApiService/AttractionApiService.csproj"
RUN dotnet restore "AttractionApiService/AttractionApiService.csproj"
    
COPY Globals/ Globals/
#COPY booking/AttractionApiService/ ./booking/AttractionApiService/
COPY AttractionApiService/ AttractionApiService/

#WORKDIR "/src/booking/AttractionApiService"
WORKDIR "/src/AttractionApiService"
RUN dotnet build "AttractionApiService.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "AttractionApiService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AttractionApiService.dll"]
