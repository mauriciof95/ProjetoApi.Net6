namespace Models.ViewModel
{
    public class TokenVM
    {
        public bool authenticated { get; set; }
        public string created { get; set; }
        public string expiration { get; set; }
        public string token { get; set; }
        public string refresh_token { get; set; }
    }
}
