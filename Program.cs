using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MinimalWebApiProject.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var sqlConnBuilder = new SqlConnectionStringBuilder();
sqlConnBuilder.ConnectionString = builder.Configuration.GetConnectionString("MSSQLDBConn");
sqlConnBuilder.UserID = builder.Configuration["UserId"];
sqlConnBuilder.Password = builder.Configuration["Password"];

builder.Services.AddDbContext<ProductDbContext>(opt => 
                                            opt.UseSqlServer(sqlConnBuilder.ConnectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.Run();
