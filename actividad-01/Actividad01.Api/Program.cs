using Actividad01.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<StudentDb>(opt =>
    // opt.UseSqlite(builder.Configuration.GetConnectionString("StudentsDb")));
    opt.UseMySQL(builder.Configuration.GetConnectionString("MySql")!));
builder.Services.AddScoped<StudentRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// for testing purposes. Never disable CORS policy
builder.Services.AddCors(options =>
{
    // options.AddDefaultPolicy(
    //     static builder => builder
    //         .AllowAnyOrigin()
    //         .AllowAnyMethod()
    //         .AllowAnyHeader());
    options.AddPolicy("allow-all",
        static builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<StudentDb>();
    db.Database.EnsureCreated();
}

app.UseCors("allow-all");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();