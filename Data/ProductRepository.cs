using Microsoft.EntityFrameworkCore;
using MinimalWebApiProject.DTOs;
using MinimalWebApiProject.Models;

namespace MinimalWebApiProject.Data;

public class ProductRepository : IProductRepository
{
    private readonly ProductDbContext context;

    public ProductRepository(ProductDbContext context)
    {
        this.context = context;
    }
    public async Task CreateProduct(Product product)
    {
        if(product is null)
        {
            throw new ArgumentNullException(nameof(product));
        }
        await this.context.AddAsync(product);
    }

    public void DeleteProduct(Product product)
    {
        if(product is null)
        {
            throw new ArgumentNullException(nameof(product));
        }
        this.context.Remove(product);
    }

    public async Task<Product> GetProductById(int id)
    {
        return await this.context.Products.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
        return await this.context.Products!.ToListAsync();
    }

    public async Task SaveChanges()
    {
        await this.context.SaveChangesAsync();
    }
}