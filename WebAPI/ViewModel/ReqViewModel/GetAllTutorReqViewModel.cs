namespace WebAPI.ViewModel.ReqViewModel
{
    public class GetAllTutorReqViewModel
    {
        public int Page { get; set; }
        public int ItemsPerPage { get; set; }
        public bool OrderBy { get; set; }
        public string? Search { get; set; }
    }
}
