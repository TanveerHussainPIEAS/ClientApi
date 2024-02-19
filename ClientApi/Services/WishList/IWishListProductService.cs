using System.Collections.Generic;
using System.Threading.Tasks;
using ClientApi.DTO;

namespace ClientApi.Services
{
    public interface IWishListProductService
    {
        Task<bool> DeleteWishListProduct(int wishListProductId);
        Task<List<WishListProductDto>> GetWishListProducts(int userId);
        Task<bool> SaveWishListProduct(List<WishListProductDto> wishListProductDtos);
    }
}
