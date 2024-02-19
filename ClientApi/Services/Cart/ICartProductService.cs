using System.Collections.Generic;
using System.Threading.Tasks;
using ClientApi.DTO;

namespace ClientApi.Services
{
    public interface ICartProductService
    {
        Task<bool> DeleteCartProduct(int cartProductId);
        Task<List<CartProductDto>> GetCartProducts(int userId);
        Task<bool> SaveCartProduct(List<CartProductDto> cartProductDtos);
    }
}
