
namespace ClientApi.DTO
{
    public class CartProductDto
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int? UserId { get; set; }

        public bool Deleted { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public virtual ProductDto Product { get; set; } = null!;
    }
}
