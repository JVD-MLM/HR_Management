namespace HR_Management.Application.Models.Identity.Login
{
    public class JwtSetting
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Duration { get; set; }
    }
}
