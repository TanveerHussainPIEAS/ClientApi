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
            var user = await _context.Products.Include(p => p.ProductImages).Where(u => u.Id == userId).FirstOrDefaultAsync();
            var userDto = mapper.Map<ProductDto>(user);
            return userDto;
        }

        public async Task<bool> DeteleProduct(int proId)
        {
            var isDeleted = false;
            var product = await _context.Products.Where(u => u.Id == proId).FirstOrDefaultAsync();

            product.Deleted = true;
            product.DeletedDate = DateTime.Now;
            _context.SaveChanges();
            isDeleted = true;
            return isDeleted;
        }

        public async Task<List<ProductDto>> GetProducts()
        {
            var products = await _context.Products
                .Include(p => p.ProductImages)
                .Where(p => p.Deleted == false)
                .ToListAsync();

            var productsDto = mapper.Map<List<ProductDto>>(products);
            return productsDto;
        }

        public async Task<List<ProductDto>> GetProductsByCatogeryId(int catogeryId)
        {
            var products = await _context.Products
                .Include(p => p.ProductImages)
                .Where(p => p.CategoryId == catogeryId && p.Deleted == false)
                .ToListAsync();

            var productsDto = mapper.Map<List<ProductDto>>(products);
            return productsDto;
        }

        public async Task<List<ProductDto>> GetProductsByDesignerId(int designerId)
        {
            var products = await _context.Products
                .Include(p => p.ProductImages)
                .Where(p => p.DesignerId == designerId && p.Deleted == false)
                .ToListAsync();

            var productsDto = mapper.Map<List<ProductDto>>(products);
            return productsDto;
        }

        public async Task<List<ProductDto>> GetProductsByTypeId(int typeId)
        {
            var products = await _context.Products
                 .Include(p => p.ProductImages)
                 .Where(p => p.TypeId == typeId && p.Deleted == false)
                 .ToListAsync();

            var productsDto = mapper.Map<List<ProductDto>>(products);
            return productsDto;
        }

        public async Task<List<ProductDto>> GetProductsByEditId(int editId)
        {
            var products = await _context.Products
                 .Include(p => p.ProductImages)
                 .Where(p => p.EditId == editId && p.Deleted == false)
                 .ToListAsync();

            var productsDto = mapper.Map<List<ProductDto>>(products);
            return productsDto;
        }

        public async Task<bool> SaveProduct(ProductDto productDto)
        {
            var product = mapper.Map<Product>(productDto);
            var isSaved = false;
            product.CreatedDate = DateTime.Now;
            product.Deleted = false;
            product.DeletedDate = null;
            foreach (var p in product.ProductImages)
            {
                p.Deleted = false;
                p.DeletedDate = null;
            }
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
                product.IsAvailable = productDto.IsAvailable;
                product.Color = productDto.Color;
                product.Color = productDto.Color;
                product.InternationalSize = productDto.InternationalSize;
                product.SellPrice = productDto.SellPrice;
                product.Price = productDto.Price;
                product.CategoryId = productDto.CategoryId;
                product.ProductGenCategoryId = productDto.ProductGenCategoryId;
                product.DesignerId = productDto.DesignerId;
                product.EditId = productDto.EditId;
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


                await _context.SaveChangesAsync();
                isUpdated = true;
            }

            return isUpdated;
        }

    }
}
