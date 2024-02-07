using System.Collections.Generic;
using System.Threading.Tasks;
using ClientApi.DTO;

namespace ClientApi.Services
{
    public interface IProductCategoryService
    {
        Task<ProductCategoryDto> GetProductCategory(int categoryId);
        Task<List<ProductCategoryDto>> GetProductCategories();
        Task<bool> SaveProductCategory(ProductCategoryDto productCategoryDto);
        Task<bool> UpdateProductCategory(ProductCategoryDto productCategoryDto);
        Task<bool> DeleteProductCategory(int categoryId);
    }
}
