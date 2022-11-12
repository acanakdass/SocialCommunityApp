using AutoMapper;
using Core.Domain.Models;
using Core.Paging.Abstract;
using Domain.DTOs.Product;
using Domain.Entities;

namespace Business.Mappers
{
    public class ProductMappers : Profile
    {
        public ProductMappers()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<IPaginate<Product>, PageableListModel<Product>>().ReverseMap();
            CreateMap<IPaginate<Comment>, PageableListModel<Comment>>().ReverseMap();
            CreateMap<IPaginate<Post>, PageableListModel<Post>>().ReverseMap();
            CreateMap<ProductCreateRequestDto, Product>().ReverseMap();
            CreateMap<ProductCreateResponseDto, Product>().ReverseMap();
            CreateMap<ProductUpdateRequestDto, Product>().ReverseMap();
            CreateMap<ProductUpdateResponseDto, Product>().ReverseMap();
        }
    }
}