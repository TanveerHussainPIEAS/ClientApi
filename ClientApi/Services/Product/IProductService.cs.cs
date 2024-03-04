using ClientApi.DTO;

namespace ClientApi.Services
{
    public interface IProductService
    {
        Task<ProductDto> GetProduct(int productId);
        Task<bool> DeteleProduct(int productId);
        Task<List<ProductDto>> GetProducts();
        Task<List<ProductDto>> GetProductsByCatogeryId(int catogeryId);

        Task<List<ProductDto>> GetProductsByGenCatogeryId(int catogeryId);
        Task<List<ProductDto>> GetProductsByDesignerId(int designerId);
        Task<List<ProductDto>> GetProductsByTypeId(int typeId);
        Task<List<ProductDto>> GetProductsByEditId(int editId);
        Task<bool> SaveProduct(ProductDto userDto);
        Task<bool> UpdateProduct(ProductDto userDto);
    }
}
