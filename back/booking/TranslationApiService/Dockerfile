FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["Globals/Globals.csproj", "Globals/"]
#COPY ["booking/TranslationApiService/TranslationApiService.csproj", "booking/TranslationApiService/"]
COPY ["TranslationApiService/TranslationApiService.csproj", "TranslationApiService/"]

#RUN dotnet restore "booking/TranslationApiService/TranslationApiService.csproj"
RUN dotnet restore "TranslationApiService/TranslationApiService.csproj"

COPY Globals/ ./Globals/
#COPY booking/TranslationApiService/ ./booking/TranslationApiService/
COPY TranslationApiService/ ./TranslationApiService/

#WORKDIR "/src/booking/TranslationApiService"
WORKDIR "/src/TranslationApiService"
RUN dotnet build "TranslationApiService.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TranslationApiService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TranslationApiService.dll"]
