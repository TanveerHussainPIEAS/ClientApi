using ClientApi.DTO;

namespace ClientApi.Services
{
    public interface IProductTpeService
    {
        Task<ProductTypeDto> GetProductType(int productId);
        Task<bool> DeteleProductType(int productId);
        Task<List<ProductTypeDto>> GetProductTypes();
        Task<bool> SaveProductType(ProductTypeDto userDto);
        Task<bool> UpdateProductType(ProductTypeDto userDto);
    }
}
