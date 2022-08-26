using AutoMapper;
using MinimalWebApiProject.DTOs;
using MinimalWebApiProject.Models;

namespace MinimalWebApiProject.Profiles;

public class ProductProfile: Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductReadDTO>();
        CreateMap<ProductUpdateDTO, Product>();
        CreateMap<ProductCreateDTO, Product>();
    }
}