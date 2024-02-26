using AutoMapper;
using ClientApi.DBContext;
using ClientApi.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientApi.Services
{
    public class ProductGenCategoryService : IProductGenCategoryService
    {
        private readonly ClientDbContext _context;
        private readonly IMapper _mapper;

        public ProductGenCategoryService(ClientDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductGenCategoryDto> GetProductGenCategory(int categoryId)
        {
            var category = await _context.ProductGenCategories.FindAsync(categoryId);
            return _mapper.Map<ProductGenCategoryDto>(category);
        }

        public async Task<List<ProductGenCategoryDto>> GetProductGenCategories()
        {
            var categories = await _context.ProductGenCategories
                .Where(p => p.Deleted == false)
                .ToListAsync();
            return _mapper.Map<List<ProductGenCategoryDto>>(categories);
        }

        public async Task<bool> SaveProductGenCategory(ProductGenCategoryDto productGenCategoryDto)
        {
            var category = _mapper.Map<ProductGenCategory>(productGenCategoryDto);
            category.CreatedDate = DateTime.Now;
            _context.ProductGenCategories.Add(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateProductGenCategory(ProductGenCategoryDto productGenCategoryDto)
        {
            var category = await _context.ProductGenCategories.FindAsync(productGenCategoryDto.Id);
            if (category == null)
                return false;

            _mapper.Map(productGenCategoryDto, category);
            category.ModifiedDate = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProductGenCategory(int categoryId)
        {
            var category = await _context.ProductGenCategories.FindAsync(categoryId);
            if (category == null)
                return false;
            category.DeletedDate = DateTime.Now;
            category.Deleted = true;
            //_context.ProductGenCategories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
