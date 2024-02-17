using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClientApi.DBContext;
using ClientApi.DTO;
using Microsoft.EntityFrameworkCore;

namespace ClientApi.Services
{
    public class ProductDesignerService : IProductDesignerService
    {
        private readonly ClientDbContext _context;
        private readonly IMapper _mapper;

        public ProductDesignerService(ClientDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductDesignerDto> GetProductDesigner(int productDesignerId)
        {
            var designer = await _context.ProductDesigners.FindAsync(productDesignerId);
            return _mapper.Map<ProductDesignerDto>(designer);
        }

        public async Task<bool> DeleteProductDesigner(int productDesignerId)
        {
            var designer = await _context.ProductDesigners.FindAsync(productDesignerId);
            if (designer == null)
                return false;

            designer.Deleted = true;
            designer.DeletedDate = DateTimeOffset.Now;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SaveProductDesigner(ProductDesignerDto productDto)
        {
            var designer = _mapper.Map<ProductDesigner>(productDto);
            designer.CreatedDate = DateTimeOffset.Now;
            designer.Deleted = false;
            designer.DeletedDate = null;

            await _context.ProductDesigners.AddAsync(designer);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateProductDesigner(ProductDesignerDto productDto)
        {
            var designer = await _context.ProductDesigners.FindAsync(productDto.Id);
            if (designer == null)
                return false;

            _mapper.Map(productDto, designer);
            designer.Deleted = false;
            designer.DeletedDate = null;
            designer.ModifiedDate = DateTimeOffset.Now;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<ProductDesignerDto>> GetAllProductDesigners()
        {
            var designers = await _context.ProductDesigners
                .Where(p => p.Deleted == false)
                .ToListAsync();
            return _mapper.Map<List<ProductDesignerDto>>(designers);
        }
    }
}
