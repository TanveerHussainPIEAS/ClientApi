using ClientApi.DTO;

namespace ClientApi.Services
{
    public interface IProductService
    {
        Task<ProductDto> GetProduct(int productId);
        Task<bool> DeteleProduct(int productId);
        Task<List<ProductDto>> GetProducts(string size, string price,string internationalPrice, string brand, string color, string sellPrice, string rentPrice);
        Task<List<ProductDto>> GetProductsByCatogeryId(int catogeryId, string size, string price, string internationalSize, string brand, string color, string sellPrice, string rentPrice);

        Task<List<ProductDto>> GetProductsByGenCatogeryId(int catogeryId, string size, string price, string internationalSize, string brand, string color, string sellPrice, string rentPrice);
        Task<List<ProductDto>> GetProductsByDesignerId(int designerId, string size, string price, string internationalSize, string brand, string color, string sellPrice, string rentPrice);
        Task<List<ProductDto>> GetProductsByTypeId(int typeId, string size, string price, string internationalSize, string brand, string color, string sellPrice, string rentPrice);
        Task<List<ProductDto>> GetProductsByEditId(int editId, string size, string price, string internationalSize, string brand, string color, string sellPrice, string rentPrice);
        Task<bool> SaveProduct(ProductDto userDto);
        Task<bool> UpdateProduct(ProductDto userDto);
    }
}
