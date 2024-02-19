using AutoMapper;
using ClientApi.DBContext;
using ClientApi.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientApi.Services
{
    public class CartProductService : ICartProductService
    {
        private readonly ClientDbContext _context;
        private readonly IMapper _mapper;

        public CartProductService(ClientDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> DeleteCartProduct(int cartProductId)
        {
            var product = await _context.CartProducts.FindAsync(cartProductId);
            if (product == null)
                return false;

            product.Deleted = true;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<CartProductDto>> GetCartProducts(int userId)
        {
            var products = await _context.CartProducts
                .Where(p=>p.UserId==userId && p.Deleted==false)
                .Include(p => p.Product)
                .ToListAsync();
            return _mapper.Map<List<CartProductDto>>(products);
        }

        public async Task<bool> SaveCartProduct(List<CartProductDto> cartProductDtos)
        {
            var cartItems= new List<CartProduct>();
            foreach (var product in cartProductDtos)
            {
                var cartItem = new CartProduct
                {
                    CreatedDate = DateTimeOffset.Now,
                    Deleted = false,
                    ProductId = product.ProductId,
                    UserId = product.UserId
                };
                cartItems.Add(cartItem);
            }
            await _context.CartProducts.AddRangeAsync(cartItems);
            await _context.SaveChangesAsync();

            return true;
        }
               
    }
}
