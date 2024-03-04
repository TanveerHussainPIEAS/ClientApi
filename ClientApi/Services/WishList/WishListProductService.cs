using AutoMapper;
using ClientApi.DBContext;
using ClientApi.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientApi.Services
{
    public class WishListProductService : IWishListProductService
    {
        private readonly ClientDbContext _context;
        private readonly IMapper _mapper;

        public WishListProductService(ClientDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> DeleteWishListProduct(int wishListProductId)
        {
            var product = await _context.WishListProducts.FindAsync(wishListProductId);
            if (product == null)
                return false;

            product.Deleted = true;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<WishListProductDto>> GetWishListProducts(int userId)
        {
            var products = await _context.WishListProducts
                .Where(p=>p.UserId == userId && p.Deleted==false)
                .ToListAsync();
            return _mapper.Map<List<WishListProductDto>>(products);
        }

        public async Task<bool> SaveWishListProduct(WishListProductDto product)
        {            
            var item = new WishListProduct();
            
                var cartItem = new WishListProduct
                {
                    CreatedDate = DateTimeOffset.Now,
                    Deleted = false,
                    ProductId = product.ProductId,
                    UserId = product.UserId
                };
               

            await _context.WishListProducts.AddAsync(cartItem);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
