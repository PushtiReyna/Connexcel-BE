namespace WebAPI.ViewModel.ResViewModel
{
    public class CreateTokenResViewModel
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
