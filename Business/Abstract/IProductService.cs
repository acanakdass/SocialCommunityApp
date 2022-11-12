using Core.Business.Abstract;
using Domain.DTOs.Product;
using Domain.Entities;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService : IBaseService<Product>
    {
        Task<ProductCreateResponseDto> CreateAsync(ProductCreateRequestDto productCreateRequestDto);
        Task<ProductUpdateResponseDto> UpdateAsync(ProductUpdateRequestDto productUpdateRequestDto);
    }
}