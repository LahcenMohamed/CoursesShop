namespace CoursesShop.Data.Results
{
    public sealed class RefreshToken
    {
        public string UserName { get; set; }
        public string UserType { get; set; }
        public string TokenString { get; set; }
        public DateTime ExpireAt { get; set; }
    }
}
