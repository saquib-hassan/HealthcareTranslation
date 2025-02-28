# #Stage 1: Building Angular
# FROM node:20 AS angular-build
# WORKDIR /app
# COPY ./healthcare-translation-app/package*.json ./
# RUN npm install
# COPY ./healthcare-translation-app .
# RUN npm run build -- --configuration=production

# #Stage 2: Building ASP.NET
# FROM mcr.microsoft.com/dotnet/sdk:8.0 AS dotnet-build
# WORKDIR /src
# COPY ./HealthcareTranslationAPI ./HealthcareTranslationAPI
# RUN dotnet restore "./HealthcareTranslationAPI/HealthcareTranslationAPI.csproj"
# RUN dotnet publish "./HealthcareTranslationAPI/HealthcareTranslationAPI.csproj" -c Release -o /app

# #Stage 3: Final Image
# FROM mcr.microsoft.com/dotnet/aspnet:8.0
# WORKDIR /app
# COPY --from=dotnet-build /app .
# COPY --from=angular-build /app/dist/healthcare-translation-app ./wwwroot
# ENTRYPOINT ["dotnet", "HealthcareTranslationAPI.dll"]


# Stage 1: Build Angular
FROM node:20 AS angular-build
WORKDIR /app
COPY healthcare-translation-app/package*.json ./
RUN npm install
COPY healthcare-translation-app .
RUN npm run build -- --configuration=production

# Stage 2: Build ASP.NET
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS dotnet-build
WORKDIR /src
COPY HealthcareTranslationAPI .
RUN dotnet restore "HealthcareTranslationAPI.csproj"
RUN dotnet publish "HealthcareTranslationAPI.csproj" -c Release -o /app

# Final Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
EXPOSE 80 
COPY --from=dotnet-build /app .
COPY --from=angular-build /app/dist/healthcare-translation-app ./wwwroot
ENV ASPNETCORE_ENVIRONMENT=Production
ENTRYPOINT ["dotnet", "HealthcareTranslationAPI.dll"]
