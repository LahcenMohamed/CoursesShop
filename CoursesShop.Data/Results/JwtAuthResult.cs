namespace CoursesShop.Data.Results
{
    public sealed class JwtAuthResult
    {
        public string AccessToken { get; set; }
        public RefreshToken refreshToken { get; set; }
    }
}
