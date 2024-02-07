using AutoMapper;
using ClientApi.DBContext;
using ClientApi.DTO;

namespace ClientApi.Infrastructure.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<ProductImageDto, ProductImage>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<ProductTypeDto, ProductType>().ReverseMap();
            CreateMap<ProductCategoryDto, ProductCategory>().ReverseMap();
            //CreateMap<ProductTypeDto, ProductType>().ReverseMap();

            //CreateMap<ProductImageDto, ProductImage>().ReverseMap();

            //CreateMap<AuthenticatedUserDto, User>().ReverseMap();
            //CreateMap<UserDto, User>().ReverseMap();
            //CreateMap<UserTypeDto, UserType>().ReverseMap();
            //CreateMap<UserPermissionDto, UserPermission>().ReverseMap();


            //CreateMap<DealDocument, DealDocumentDto>().ForMember(d => d.DocumentType, opt => opt.MapFrom(src => src.DocumentType));
            //CreateMap<DealDocumentDto, DealDocument>().ForMember(d => d.DocumentType, opt => opt.MapFrom(src => src.DocumentType));



            //CreateMap<Deal, DealDto>()
            //    .ForMember(d => d.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
            //    .ForMember(d => d.ModifiedDate, opt => opt.MapFrom(src => src.ModifiedDate))
            //    .ForMember(d => d.Type, opt => opt.MapFrom(src => src.Type))
            //    .ForMember(d => d.Priority, opt => opt.MapFrom(src => src.Priority))
            //    .ForMember(d => d.Status, opt => opt.MapFrom(src => src.Status));

        }
    }
}
