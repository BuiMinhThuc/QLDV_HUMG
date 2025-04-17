# Sử dụng image .NET SDK để build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy solution và project files
COPY ["BigProject.csproj", "./"]
RUN dotnet restore "BigProject.csproj"

# Copy toàn bộ source code
COPY . .

# Build ứng dụng
RUN dotnet build "BigProject.csproj" -c Release -o /app/build

# Publish ứng dụng
FROM build AS publish
RUN dotnet publish "BigProject.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app

# Cài đặt curl cho healthcheck
RUN apt-get update && \
    apt-get install -y curl && \
    rm -rf /var/lib/apt/lists/*

# Tạo thư mục cho Data Protection Keys và certificates
RUN mkdir -p /app/keys && \
    chmod 700 /app/keys && \
    mkdir -p /https && \
    chmod 700 /https

# Tắt telemetry
ENV DOTNET_CLI_TELEMETRY_OPTOUT=1

# Cấu hình Data Protection với đường dẫn cố định
ENV ASPNETCORE_DATA_PROTECTION_KEYSDIR=/app/keys

# Cấu hình môi trường
ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://+:8080;https://+:8443
ENV ASPNETCORE_HTTPS_PORT=8443
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx
ENV ASPNETCORE_Kestrel__Certificates__Default__Password=YourSecurePassword123!

# Cấu hình CORS
ENV CORS__Origins=*
ENV CORS__Headers=*
ENV CORS__Methods=*
ENV CORS__AllowCredentials=true

# Cấu hình logging
ENV Logging__LogLevel__Default=Information
ENV Logging__LogLevel__Microsoft.AspNetCore=Warning

# Copy published files
COPY --from=publish /app/publish .

# Tạo volume cho Data Protection Keys và certificates
VOLUME ["/app/keys", "/https"]

# Expose ports
EXPOSE 8080
EXPOSE 8443

# Cấu hình healthcheck
HEALTHCHECK --interval=30s --timeout=3s --start-period=5s --retries=3 \
    CMD curl -f http://localhost:8080/health || exit 1

ENTRYPOINT ["dotnet", "BigProject.dll"] 