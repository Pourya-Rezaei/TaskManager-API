# TaskManager API

یک سیستم مدیریت وظایف ساخته‌شده با ASP.NET Core و Clean Architecture.

---

## پیش‌نیازها

قبل از شروع، این ابزارها باید روی سیستم نصب باشند:

| ابزار | نسخه | لینک دانلود |
|-------|-------|-------------|
| .NET SDK | 10.0 | https://dotnet.microsoft.com/download |
| Docker Desktop | آخرین نسخه | https://www.docker.com/products/docker-desktop |
| Git | آخرین نسخه | https://git-scm.com |

---

## روش اول — اجرا با Docker (پیشنهادی)

ساده‌ترین روش — نیازی به نصب SQL Server نیست.

```bash
# ۱. کلون کردن پروژه
git clone <repository-url>
cd TaskManager

# ۲. ساخت فایل environment
cp .env.example .env

# ۳. اجرا
docker compose up
```

بعد از اجرا:
- **Swagger UI:** http://localhost:5000
- **Health Check:** http://localhost:5000/health

برای متوقف کردن:
```bash
docker compose down
```

برای متوقف کردن و حذف داده‌ها:
```bash
docker compose down -v
```

---

## روش دوم — اجرا بدون Docker

### پیش‌نیاز اضافه
- SQL Server (هر نسخه‌ای)

### مراحل

**۱. کلون کردن پروژه**
```bash
git clone <repository-url>
cd TaskManager
```

**۲. تنظیم Connection String**

فایل `src/TaskManager.API/appsettings.Development.json` را باز کن و Connection String را تنظیم کن:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=TaskManagerDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

**۳. نصب EF Tools (اگه نصب نیست)**
```bash
dotnet tool install --global dotnet-ef
```

**۴. Restore پکیج‌ها**
```bash
dotnet restore
```

**۵. اجرا**
```bash
dotnet run --project src/TaskManager.API
```

Migration و Seed Data به صورت خودکار اجرا می‌شوند.

بعد از اجرا:
- **Swagger UI:** https://localhost:{PORT}
- **Health Check:** https://localhost:{PORT}/health

---

## اجرای تست‌ها

```bash
# همه تست‌ها
dotnet test

# فقط Domain Tests
dotnet test tests/TaskManager.Domain.Tests

# فقط Application Tests
dotnet test tests/TaskManager.Application.Tests

# با نمایش جزئیات
dotnet test --verbosity normal
```

خروجی مورد انتظار:
```
Test summary: total: 26, failed: 0, succeeded: 26, skipped: 0
```

---

## ساختار پروژه

```
TaskManager/
├── src/
│   ├── TaskManager.API/          ← Web API (Controllers, Middleware)
│   ├── TaskManager.Application/  ← Business Logic (CQRS, Validators)
│   ├── TaskManager.Domain/       ← Entities, Interfaces, Enums
│   └── TaskManager.Infrastructure/ ← EF Core, Repositories
├── tests/
│   ├── TaskManager.Domain.Tests/
│   └── TaskManager.Application.Tests/
├── docker-compose.yml
├── .env.example
└── TaskManager.sln
```

---

## API Endpoints

| Method | Endpoint | توضیح |
|--------|----------|-------|
| GET | /api/tasks | لیست همه وظایف |
| GET | /api/tasks/{id} | یک وظیفه |
| GET | /api/tasks/category/{id} | وظایف یک دسته‌بندی |
| POST | /api/tasks | ساخت وظیفه |
| PUT | /api/tasks/{id} | ویرایش وظیفه |
| DELETE | /api/tasks/{id} | حذف وظیفه |
| PATCH | /api/tasks/{id}/status | تغییر وضعیت |
| GET | /api/categories | لیست دسته‌بندی‌ها |
| POST | /api/categories | ساخت دسته‌بندی |
| GET | /health | وضعیت سرویس |

---

## متغیرهای محیطی

| متغیر | توضیح | مثال |
|-------|-------|------|
| `SA_PASSWORD` | رمز SQL Server | `TaskManager@123456` |
| `ASPNETCORE_ENVIRONMENT` | محیط اجرا | `Development` یا `Production` |
| `ConnectionStrings__DefaultConnection` | رشته اتصال به دیتابیس | - |

> **نکته:** هیچ‌وقت فایل `.env` را به git push نکنید.

---

## Tech Stack

- **Backend:** ASP.NET Core (.NET 10)
- **Architecture:** Clean Architecture + CQRS
- **ORM:** Entity Framework Core
- **Database:** SQL Server
- **Logging:** Serilog
- **Validation:** FluentValidation
- **Mediator:** MediatR
- **Testing:** xUnit + FluentAssertions + NSubstitute
- **Container:** Docker + Docker Compose