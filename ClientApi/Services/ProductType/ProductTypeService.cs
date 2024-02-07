using AutoMapper;
using ClientApi.DBContext;
using ClientApi.DTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using BCrypt.Net;

namespace ClientApi.Services
{
    public class ProductTpeService : IProductTpeService
    {
        private readonly ClientDbContext _context;
        private readonly IMapper mapper;

        public ProductTpeService(ClientDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }
        public async Task<ProductTypeDto> GetProductType(int typeId)
        {
            var type = await _context.ProductTypes.Where(u => u.Id == typeId).FirstOrDefaultAsync();
            var typeDto = mapper.Map<ProductTypeDto>(type);
            return typeDto;
        }
        
        public async Task<bool> DeteleProductType(int typeId)
        {
            var isDeleted = false;
            var productType = await _context.ProductTypes.Where(u => u.Id == typeId).FirstOrDefaultAsync();
            
            productType.Deleted=true;
            productType.DeletedDate = DateTime.Now;
            _context.SaveChanges();
            isDeleted = true;
            return isDeleted;
        }

        public async Task<List<ProductTypeDto>> GetProductTypes()
        {
            var type = await _context.ProductTypes
                .ToListAsync();

            var typeDto = mapper.Map<List<ProductTypeDto>>(type);
            return typeDto;
        }

        public async Task<bool> SaveProductType(ProductTypeDto productDto)
        {
            var productType = mapper.Map<ProductType>(productDto);
            var isSaved = false;
            productType.CreatedDate = DateTime.Now;
            productType.Deleted = false;
            await _context.ProductTypes.AddAsync(productType);
            await _context.SaveChangesAsync();
            isSaved = true;
            return isSaved;
        }

        public async Task<bool> UpdateProductType(ProductTypeDto productTypeDto)
        {
            var isUpdated = false;
            var productType = await _context.ProductTypes
                .FirstOrDefaultAsync(p => p.Id == productTypeDto.Id);

            if (productType != null)
            {
                productType.Type = productTypeDto.Type;
                productType.ModifiedDate = DateTime.Now;
                await _context.SaveChangesAsync();
                isUpdated = true;
            }

            return isUpdated;
        }

    }
}
