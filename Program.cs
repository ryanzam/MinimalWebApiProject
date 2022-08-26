using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MinimalWebApiProject.Data;
using MinimalWebApiProject.DTOs;
using MinimalWebApiProject.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var sqlConnBuilder = new SqlConnectionStringBuilder();
sqlConnBuilder.ConnectionString = builder.Configuration.GetConnectionString("MSSQLDBConn");
sqlConnBuilder.UserID = builder.Configuration["UserId"];
sqlConnBuilder.Password = builder.Configuration["Password"];

builder.Services.AddDbContext<ProductDbContext>(opt => 
                                            opt.UseSqlServer(sqlConnBuilder.ConnectionString));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//API Endpoints 
//Get all products
app.MapGet("api/products", async (IProductRepository repo, IMapper mapper) => {
    var products = await repo.GetProducts();
    return Results.Ok(mapper.Map<IEnumerable<ProductReadDTO>>(products));
});

//Get product by id
app.MapGet("api/products/{id}", async (IProductRepository repo, IMapper mapper, int id) => {
    var product = await repo.GetProductById(id);
    if(product is not null)
    {
        return Results.Ok(mapper.Map<ProductReadDTO>(product));
    }
    return Results.NotFound();
});

//Create product
app.MapPost("api/products", async (IProductRepository repo, IMapper mapper, ProductCreateDTO productCreateDto) => {
    var productModel = mapper.Map<Product>(productCreateDto);
    await repo.CreateProduct(productModel);
    await repo.SaveChanges();

    var productReadDto = mapper.Map<ProductReadDTO>(productModel);
    return Results.Created($"api/products/{productReadDto.Id}", productReadDto);
});

//Update a product
app.MapPut("api/products/{id}", async (IProductRepository repo, IMapper mapper, ProductUpdateDTO productUpdateDTO, int id) => {
   var product = await repo.GetProductById(id);
    if(product is null)
    {
        return Results.NotFound();
    }
    mapper.Map(productUpdateDTO, product);
    await repo.SaveChanges();
    return Results.NoContent();
});

//Delete a product
app.MapDelete("api/products/{id}", async (IProductRepository repo, IMapper mapper, int id) => {
   var product = await repo.GetProductById(id);
    if(product is null)
    {
        return Results.NotFound();
    }
    repo.DeleteProduct(product);
    await repo.SaveChanges();
    return Results.NoContent();
});

app.Run();
