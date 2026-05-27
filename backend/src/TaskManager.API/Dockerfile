# ─── Stage 1: Build ───────────────────────────────────────────
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# کپی فایل‌های پروژه
COPY ["backend/src/TaskManager.API/TaskManager.API.csproj", "backend/src/TaskManager.API/"]
COPY ["backend/src/TaskManager.Application/TaskManager.Application.csproj", "backend/src/TaskManager.Application/"]
COPY ["backend/src/TaskManager.Domain/TaskManager.Domain.csproj", "backend/src/TaskManager.Domain/"]
COPY ["backend/src/TaskManager.Infrastructure/TaskManager.Infrastructure.csproj", "backend/src/TaskManager.Infrastructure/"]

# Restore پکیج‌ها
RUN dotnet restore "backend/src/TaskManager.API/TaskManager.API.csproj"

# کپی همه فایل‌ها
COPY . .

# Build
WORKDIR "/src/backend/src/TaskManager.API"
RUN dotnet build "TaskManager.API.csproj" -c Release -o /app/build

# ─── Stage 2: Publish ─────────────────────────────────────────
FROM build AS publish
RUN dotnet publish "TaskManager.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# ─── Stage 3: Runtime ─────────────────────────────────────────
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

# کپی فایل‌های publish شده
COPY --from=publish /app/publish .

# پورت
EXPOSE 8080

# اجرا
ENTRYPOINT ["dotnet", "TaskManager.API.dll"]