using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClientApi.DBContext;
using ClientApi.DTO;
using Microsoft.EntityFrameworkCore;

namespace ClientApi.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly ClientDbContext _context;
        private readonly IMapper _mapper;

        public ProductCategoryService(ClientDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductCategoryDto> GetProductCategory(int categoryId)
        {
            var category = await _context.ProductCategories.FindAsync(categoryId);
            return _mapper.Map<ProductCategoryDto>(category);
        }

        public async Task<List<ProductCategoryDto>> GetProductCategories()
        {
            var categories = await _context.ProductCategories
                .Where(p => p.Deleted == false)
                .ToListAsync();
            return _mapper.Map<List<ProductCategoryDto>>(categories);
        }

        public async Task<bool> SaveProductCategory(ProductCategoryDto productCategoryDto)
        {
            var category = _mapper.Map<ProductCategory>(productCategoryDto);
            category.CreatedDate = DateTime.Now;
            _context.ProductCategories.Add(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateProductCategory(ProductCategoryDto productCategoryDto)
        {
            var category = await _context.ProductCategories.FindAsync(productCategoryDto.Id);
            if (category == null)
                return false;

            _mapper.Map(productCategoryDto, category);
            category.ModifiedDate = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProductCategory(int categoryId)
        {
            var category = await _context.ProductCategories.FindAsync(categoryId);
            if (category == null)
                return false;

            _context.ProductCategories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
