using System.Collections.Generic;
using System.Threading.Tasks;
using ClientApi.DTO;

namespace ClientApi.Services
{
    public interface IProductEditService
    {
        Task<ProductEditDto> GetProductEdit(int productEditId);
        Task<List<ProductEditDto>> GetProductEdits();
        Task<bool> DeleteProductEdit(int productEditId);
        Task<bool> SaveProductEdit(ProductEditDto productDto);
        Task<bool> UpdateProductEdit(ProductEditDto productDto);
    }
}
