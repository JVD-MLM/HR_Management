namespace HR_Management.Application.Models.Identity.Login
{
    public class LoginResponseModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
    }
}
