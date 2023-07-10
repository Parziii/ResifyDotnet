#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Resify.Services.RestaurantsAPI/Resify.Services.RestaurantsAPI.csproj", "Resify.Services.RestaurantsAPI/"]
RUN dotnet restore "Resify.Services.RestaurantsAPI/Resify.Services.RestaurantsAPI.csproj"
COPY . .
WORKDIR "/src/Resify.Services.RestaurantsAPI"
RUN dotnet build "Resify.Services.RestaurantsAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Resify.Services.RestaurantsAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Resify.Services.RestaurantsAPI.dll"]