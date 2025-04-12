# Stage 1: Build the ASP.NET Core app
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS service-build
WORKDIR /app/compareusers
COPY CompareUsers/*.csproj ./
RUN dotnet restore
COPY CompareUsers/. .
RUN dotnet publish -c Release -o out

# Stage 3: Combine and Serve Both
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

# Copy the ASP.NET Core build output
COPY --from=service-build /app/compareusers/out ./

# Expose the port for the API
EXPOSE 80

# Run the ASP.NET Core API
ENTRYPOINT ["dotnet", "CompareUsers.dll"]