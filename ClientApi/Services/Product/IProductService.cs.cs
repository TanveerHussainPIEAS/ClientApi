using ClientApi.DTO;

namespace ClientApi.Services
{
    public interface IProductService
    {
        Task<ProductDto> GetProduct(int productId);
        Task<bool> DeteleProduct(int productId);
        Task<List<ProductDto>> GetProducts();
        Task<bool> SaveProduct(ProductDto userDto);
        Task<bool> UpdateProduct(ProductDto userDto);
    }
}
