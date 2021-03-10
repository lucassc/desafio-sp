namespace InterestCalc.Api.Models
{
    public class RepositoryUrlResponse
    {
        public RepositoryUrlResponse(string url) => Url = url;

        public string Url { get; }
    }
}