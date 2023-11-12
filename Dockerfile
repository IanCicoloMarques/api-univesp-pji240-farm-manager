# Build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
LS
# Copy and restore project files
COPY api-univesp-pji240-farm-manager/api-univesp-pji240-farm-manager.csproj .
LS
RUN dotnet restore

# Copy the entire project and build
COPY . .
LS
RUN dotnet publish -c Release -o out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
FROM base AS final
WORKDIR /app
LS
COPY --from=build /app/out ./

# Expose port 80
EXPOSE 5000

# Set the entry point for the container
LS
ENTRYPOINT ["dotnet", "app/api-univesp-pji240-farm-manager.dll"]