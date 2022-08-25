using System.ComponentModel.DataAnnotations;

namespace MinimalWebApiProject.DTOs;
public class ProductReadDTO
{
    [Key]
    public int Id { get; set; }
    public string? ProductName { get; set; }
    public string? QtyPerUnit { get; set; }
    public decimal PricePerUnit { get; set; }   
    public bool Discontinued { get; set; } 
    public short? UnitsInStock { get; set; }  
    public short? UnitsOnOrder { get; set; }
    public string? ProductCategory { get; set; }
}