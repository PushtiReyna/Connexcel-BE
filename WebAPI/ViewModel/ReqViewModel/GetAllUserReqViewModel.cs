namespace WebAPI.ViewModel.ReqViewModel
{
    public class GetAllUserReqViewModel
    {
        public int Page { get; set; }
        public int ItemsPerPage { get; set; }
        public bool OrderBy { get; set; }
        public string? Search { get; set; }
        public bool? IsTutor { get; set; }
    }
}
