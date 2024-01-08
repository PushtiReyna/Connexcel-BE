namespace WebAPI.ViewModel.ResViewModel
{
    public class LoginResViewModel
    {
        public string EmailOrPhoneNo { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime TokenExpiryTime { get; set; }
    }
}
