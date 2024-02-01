using ClientApi.DBContext;

namespace ClientApi.DTO
{
    public class UserDto
    {
        public int Id { get; set; }

        public int TypeId { get; set; }

        public int PermissionId { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string City { get; set; } = null!;

        public string ZipCode { get; set; } = null!;

        public string State { get; set; } = null!;

        public string Country { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string? PhoneNumber { get; set; }

        public string MobileNumber { get; set; } = null!;

        public bool Deleted { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset ModifiedDate { get; set; }

        public DateTimeOffset? DeletedDate { get; set; }

        public int? DeletedBy { get; set; }

        public int? ModifiedBy { get; set; }
    }
}
