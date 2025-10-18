# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copiar archivos de proyecto (usa los nombres exactos del sistema)
COPY NoCap-Abstracions/NoCap-Abstracions.csproj NoCap-Abstracions/
COPY NoCap-Data/NoCap-Data.csproj NoCap-Data/
COPY NoCap-Services/NoCap-Services.csproj NoCap-Services/
COPY NoCap-API/NoCap-API.csproj NoCap-API/

# Restaurar dependencias
RUN dotnet restore NoCap-API/NoCap-API.csproj

# Copiar todo el código
COPY . .

# Publicar en Release
RUN dotnet publish NoCap-API/NoCap-API.csproj -c Release -o /app/out

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/out .

# Puerto que Render usa
ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000

# Comando para correr la API
ENTRYPOINT ["dotnet", "NoCap-API.dll"]
