namespace ClientApi.DTO
{   
    public class LoginUserDto
    {
        public string Email { get; set; }

        public string Password { get; set; } = null!;
        public string UserName { get; set; }
    }
}
