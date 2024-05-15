namespace CoursesShop.Data.Identity
{
    public sealed class UserRefreshToken
    {
        public string Id { get; set; }
        public string ApplicationUserId { get; set; }
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        public string? JwtId { get; set; }
        public bool IsUsed { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime AddedTime { get; set; }
        public DateTime ExpiryDate { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
