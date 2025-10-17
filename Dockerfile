# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copiamos los proyectos por separado
COPY NoCap_API/NoCap_API.csproj NoCap_API/
COPY NoCap-Abstracions/NoCap-Abstracions.csproj NoCap-Abstracions/
COPY NoCap-Data/NoCap-Data.csproj NoCap-Data/
COPY NoCap-Services/NoCap-Services.csproj NoCap-Services/

# Restauramos dependencias
RUN dotnet restore NoCap_API/NoCap_API.csproj

# Copiamos todo el código
COPY . .

# Publicamos en Release
RUN dotnet publish NoCap_API/NoCap_API.csproj -c Release -o /app/out

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/out .

# Puerto que Render usa
ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000

# Comando para correr la API
ENTRYPOINT ["dotnet", "NoCap_API.dll"]
