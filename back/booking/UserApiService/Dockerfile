# Stage 1: Base runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Stage 2: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy solution and csproj files
COPY ["booking.sln", "booking/"]
COPY ["Globals/Globals.csproj", "Globals/"]
#COPY ["booking/UserApiService/UserApiService.csproj", "booking/UserApiService/"]
#COPY ["booking/OfferApiService/OfferApiService.csproj", "booking/OfferApiService/"]
#COPY ["booking/OrderApiService/OrderApiService.csproj", "booking/OrderApiService/"]
#RUN dotnet restore "booking/UserApiService/UserApiService.csproj"
COPY ["UserApiService/UserApiService.csproj", "UserApiService/"]
COPY ["OfferApiService/OfferApiService.csproj", "OfferApiService/"]
COPY ["OrderApiService/OrderApiService.csproj", "OrderApiService/"]
RUN dotnet restore "UserApiService/UserApiService.csproj"

# Copy all source
COPY . .
#WORKDIR "/src/booking/UserApiService"
WORKDIR "/src/UserApiService"
RUN dotnet build "UserApiService.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Stage 3: Publish
FROM build AS publish
RUN dotnet publish "UserApiService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Stage 4: Final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Install curl
RUN apt-get update && apt-get install -y curl && rm -rf /var/lib/apt/lists/*

HEALTHCHECK --interval=30s --timeout=3s --start-period=10s --retries=3 \
  CMD curl --fail http://localhost:8080/health || exit 1

ENTRYPOINT ["dotnet", "UserApiService.dll"]
