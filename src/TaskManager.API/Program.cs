using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using Serilog;
using Scalar.AspNetCore;
using TaskManager.API.Middleware;
using TaskManager.Infrastructure.Data;
using TaskManager.Infrastructure.Repositories;
using TaskManager.Domain.Interfaces;
using TaskManager.Application.Validators;

// ─── Serilog Setup ────────────────────────────────────────
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    // ─── Serilog ──────────────────────────────────────────
    builder.Host.UseSerilog((context, services, configuration) =>
        configuration.ReadFrom.Configuration(context.Configuration)
                     .WriteTo.Console()
                     .WriteTo.File("logs/taskmanager-.txt", rollingInterval: RollingInterval.Day));

    // ─── Database ─────────────────────────────────────────
    builder.Services.AddDbContext<TaskManagerDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    // ─── Repositories ─────────────────────────────────────
    builder.Services.AddScoped<ITaskRepository, TaskRepository>();
    builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

    // ─── MediatR ──────────────────────────────────────────
    builder.Services.AddMediatR(cfg =>
        cfg.RegisterServicesFromAssembly(
            typeof(TaskManager.Application.Commands.Tasks.CreateTaskCommand).Assembly));

    // ─── FluentValidation ─────────────────────────────────
    builder.Services.AddValidatorsFromAssembly(
        typeof(CreateTaskCommandValidator).Assembly);

    // ─── CORS ─────────────────────────────────────────────
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowFrontend", policy =>
        {
            policy.WithOrigins(
                    builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>()
                    ?? ["http://localhost:5173"])
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
    });

    // ─── Controllers + OpenAPI ────────────────────────────
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "TaskManager API",
            Version = "v1",
            Description = "API مدیریت وظایف"
        });
    });

    // ─── Health Check ─────────────────────────────────────
    builder.Services.AddHealthChecks()
        .AddDbContextCheck<TaskManagerDbContext>();

    var app = builder.Build();

    // ─── Database Migration + Seed ────────────────────────
    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<TaskManagerDbContext>();
        await db.Database.MigrateAsync();
        await DataSeeder.SeedAsync(db);
    }

    // ─── Middleware Error Pipeline ───────────────────────────────
    app.UseMiddleware<ExceptionHandlingMiddleware>();
    
    
    // ─── Middleware Pipeline ───────────────────────────────
    app.UseSerilogRequestLogging();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskManager API v1");
            c.RoutePrefix = "swagger";
        });
        app.MapScalarApiReference();
    }

    app.UseHttpsRedirection();
    app.UseCors("AllowFrontend");
    app.UseAuthorization();
    app.MapControllers();
    app.MapHealthChecks("/health");

    Log.Information("TaskManager API started successfully");
    await app.RunAsync();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    await Log.CloseAndFlushAsync();
}