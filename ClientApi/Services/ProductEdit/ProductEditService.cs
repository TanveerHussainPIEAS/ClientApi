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
    public class ProductEditService : IProductEditService
    {
        private readonly ClientDbContext _context;
        private readonly IMapper _mapper;

        public ProductEditService(ClientDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductEditDto> GetProductEdit(int productEditId)
        {
            var productEdit = await _context.ProductEdits.FindAsync(productEditId);
            return _mapper.Map<ProductEditDto>(productEdit);
        }

        public async Task<List<ProductEditDto>> GetProductEdits()
        {
            var productEdits = await _context.ProductEdits.ToListAsync();
            return _mapper.Map<List<ProductEditDto>>(productEdits);
        }

        public async Task<bool> DeleteProductEdit(int productEditId)
        {
            var productEdit = await _context.ProductEdits.FindAsync(productEditId);
            if (productEdit == null)
                return false;

            _context.ProductEdits.Remove(productEdit);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> SaveProductEdit(ProductEditDto productDto)
        {
            var productEdit = _mapper.Map<ProductEdit>(productDto);
            productEdit.CreatedDate = DateTimeOffset.Now;
            productEdit.Deleted = false;

            await _context.ProductEdits.AddAsync(productEdit);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateProductEdit(ProductEditDto productDto)
        {
            var productEdit = await _context.ProductEdits.FindAsync(productDto.Id);
            if (productEdit == null)
                return false;

            _mapper.Map(productDto, productEdit);
            productEdit.ModifiedDate = DateTimeOffset.Now;
            productEdit.Deleted = false;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
