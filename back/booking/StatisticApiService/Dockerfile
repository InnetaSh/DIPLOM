FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["Globals/Globals.csproj", "Globals/"]
#COPY ["booking/StatisticApiService/StatisticApiService.csproj", "booking/StatisticApiService/"]
COPY ["StatisticApiService/StatisticApiService.csproj", "StatisticApiService/"]

#RUN dotnet restore "booking/StatisticApiService/StatisticApiService.csproj"
RUN dotnet restore "StatisticApiService/StatisticApiService.csproj"

COPY Globals/ Globals/
#COPY booking/StatisticApiService/ ./booking/StatisticApiService/
COPY StatisticApiService/ StatisticApiService/

#WORKDIR "/src/booking/StatisticApiService"
WORKDIR "/src/StatisticApiService"
RUN dotnet build "StatisticApiService.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "StatisticApiService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StatisticApiService.dll"]
