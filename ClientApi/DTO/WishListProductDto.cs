
namespace ClientApi.DTO
{   
    public class WishListProductDto
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int? UserId { get; set; }

        public bool Deleted { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public ProductDto Product { get; set; } = null!;
    }
}
