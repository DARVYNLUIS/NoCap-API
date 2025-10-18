# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copiar archivos de proyecto
COPY NoCap-Abstracions/NoCap-Abstracions.csproj NoCap-Abstracions/
COPY NoCap-Data/NoCap-Data.csproj NoCap-Data/
COPY NoCap-Services/NoCap-Services.csproj NoCap-Services/
COPY NoCap_API/NoCap_API.csproj NoCap_API/

# Restaurar dependencias
RUN dotnet restore NoCap_API/NoCap_API.csproj

# Copiar el resto del código
COPY . .

# Publicar en Release
RUN dotnet publish NoCap_API/NoCap_API.csproj -c Release -o /app/out

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/out .

# Render usa el puerto 10000
ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000

ENTRYPOINT ["dotnet", "NoCap_API.dll"]
