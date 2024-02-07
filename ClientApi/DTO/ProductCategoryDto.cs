namespace ClientApi.DTO
{
    public class ProductCategoryDto
    {
        public int Id { get; set; }

        public string Type { get; set; } = null!;

        public bool Deleted { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset ModifiedDate { get; set; }

        public DateTimeOffset? DeletedDate { get; set; }

        public int? DeletedBy { get; set; }

        public int? ModifiedBy { get; set; }

        public int? CreatedBy { get; set; }
    }
}
