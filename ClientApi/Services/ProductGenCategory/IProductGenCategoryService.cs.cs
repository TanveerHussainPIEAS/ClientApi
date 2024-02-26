using System.Collections.Generic;
using System.Threading.Tasks;
using ClientApi.DTO;

namespace ClientApi.Services
{
    public interface IProductGenCategoryService
    {
        Task<ProductGenCategoryDto> GetProductGenCategory(int categoryId);
        Task<List<ProductGenCategoryDto>> GetProductGenCategories();
        Task<bool> SaveProductGenCategory(ProductGenCategoryDto productGenCategoryDto);
        Task<bool> UpdateProductGenCategory(ProductGenCategoryDto productGenCategoryDto);
        Task<bool> DeleteProductGenCategory(int categoryId);
    }
}
