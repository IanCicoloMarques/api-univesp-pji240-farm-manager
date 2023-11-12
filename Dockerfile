# Build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copy and restore project files
COPY api-univesp-pji240-farm-manager/api-univesp-pji240-farm-manager .
RUN dotnet restore

# Copy the entire project and build
COPY . .
RUN dotnet publish -c Release -o out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
FROM base AS final
WORKDIR /app
COPY --from=build /app/out ./

# Expose port 80
EXPOSE 5000

# Set the entry point for the container
ENTRYPOINT ["dotnet", "api-univesp-pji240-farm-manager"]