namespace ClientApi.DTO
{   
    public class ProductEditDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Detail { get; set; }

        public bool? Deleted { get; set; }

    }

}
