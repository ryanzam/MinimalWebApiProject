using MinimalWebApiProject.DTOs;
using MinimalWebApiProject.Models;

namespace MinimalWebApiProject.Data;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProducts();
    Task<Product> GetProductById(int id);
    Task CreateProduct(ProductCreateDTO product);
    void DeleteProduct(Product product); 
    Task SaveChanges();
}