name: CI — Build & Test

# ─── چه زمانی اجرا بشه ────────────────────────────────────
on:
push:
branches: [ main, develop ]
pull_request:
branches: [ main, develop ]

# ─── Jobs ────────────────────────────────────────────────
jobs:

# ─── Job 1: Test ───────────────────────────────────────
test:
name: 🧪 Run Tests
runs-on: ubuntu-latest

steps:
- name: Checkout code
uses: actions/checkout@v4

    - name: Setup .NET
uses: actions/setup-dotnet@v4
with:
dotnet-version: '10.0.x'

    - name: Restore packages
run: dotnet restore

    - name: Build
run: dotnet build --no-restore --configuration Release

    - name: Run tests
run: dotnet test --no-build --configuration Release --verbosity normal --logger "trx;LogFileName=test-results.trx"

    - name: Upload test results
uses: actions/upload-artifact@v4
if: always()
with:
name: test-results
path: '**/TestResults/*.trx'

# ─── Job 2: Docker Build ────────────────────────────────
docker-build:
name: 🐳 Docker Build
runs-on: ubuntu-latest
needs: test

steps:
- name: Checkout code
uses: actions/checkout@v4

    - name: Build Docker image
run: docker build -f src/TaskManager.API/Dockerfile -t taskmanager-api:${{ github.sha }} .

- name: Verify image exists
run: docker images taskmanager-api