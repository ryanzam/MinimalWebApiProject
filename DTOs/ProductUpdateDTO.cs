using System.ComponentModel.DataAnnotations;

namespace MinimalWebApiProject.DTOs;
public class ProductUpdateDTO
{
    [MaxLength(50)]
    public string? ProductName { get; set; }
    public string? QtyPerUnit { get; set; }
    public decimal PricePerUnit { get; set; }   
    public bool Discontinued { get; set; } 
    public short? UnitsInStock { get; set; }  
    public short? UnitsOnOrder { get; set; }
    [MaxLength(50)]
    public string? ProductCategory { get; set; }
}