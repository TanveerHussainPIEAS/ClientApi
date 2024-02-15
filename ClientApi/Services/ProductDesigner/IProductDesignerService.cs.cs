using System.Collections.Generic;
using System.Threading.Tasks;
using ClientApi.DTO;

namespace ClientApi.Services
{
    public interface IProductDesignerService
    {
        Task<ProductDesignerDto> GetProductDesigner(int productDesignerId);
        Task<bool> DeleteProductDesigner(int productDesignerId);
        Task<bool> SaveProductDesigner(ProductDesignerDto productDto);
        Task<bool> UpdateProductDesigner(ProductDesignerDto productDto);
        Task<List<ProductDesignerDto>> GetAllProductDesigners();
    }
}
