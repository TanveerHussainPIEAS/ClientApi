using AutoMapper;
using ClientApi.DBContext;
using ClientApi.DTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using BCrypt.Net;

namespace ClientApi.Services
{
    public class ProductService : IProductService
    {
        private readonly ClientDbContext _context;
        private readonly IMapper mapper;

        public ProductService(ClientDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }
        public async Task<ProductDto> GetProduct(int userId)
        {
            var user = await _context.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();
            var userDto = mapper.Map<ProductDto>(user);
            return userDto;
        }

        public async Task<List<ProductDto>> GetProducts()
        {
            var user = await _context.Products
                .Include(p => p.ProductImages)
                .ToListAsync();

            var usersDto = mapper.Map<List<ProductDto>>(user);
            return usersDto;
        }

        public async Task<bool> SaveProduct(ProductDto productDto)
        {
            var product = mapper.Map<Product>(productDto);
            var isSaved = false;
            product.CreatedDate = DateTime.Now;
            product.Deleted = false;
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            isSaved = true;
            return isSaved;
        }

        public async Task<bool> UpdateProduct(ProductDto productDto)
        {
            var isUpdated = false;
            var product = await _context.Products
                .Include(p => p.ProductImages)
                .FirstOrDefaultAsync(p => p.Id == productDto.Id);

            if (product != null)
            {
                product.TypeId = productDto.TypeId;
                product.Name = productDto.Name;
                product.Size = productDto.Size;
                product.Brand = productDto.Brand;
                product.Color = productDto.Color;
                product.Condition = productDto.Condition;
                product.SellPrice = productDto.SellPrice;
                product.RentPrice4Days = productDto.RentPrice4Days;
                product.RentPrice8Days = productDto.RentPrice8Days;
                product.RentPrice16Days = productDto.RentPrice16Days;
                product.RentPrice30Days = productDto.RentPrice30Days;
                product.Rrp = productDto.Rrp;
                product.Code = productDto.Code;
                product.Details = productDto.Details;
                product.IsEbayStore = productDto.IsEbayStore;
                product.ModifiedDate = DateTime.Now;
                product.Deleted = false;

                // Update ProductImages
                // Assuming ProductImages is a list of ProductImage entities in the Product entity
                // You may need to adjust this part based on your actual data model
                // Also, make sure to handle adding, updating, and deleting ProductImages accordingly
                // product.ProductImages = mapper.Map<List<ProductImage>>(productDto.ProductImages);

                await _context.SaveChangesAsync();
                isUpdated = true;
            }

            return isUpdated;
        }

    }
}
