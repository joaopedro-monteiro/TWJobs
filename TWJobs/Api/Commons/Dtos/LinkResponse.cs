namespace TWJobs.Api.Commons.Dtos
{
    public class LinkResponse(string? href, string? type, string? rel)
    {
        public string? Href { get; set; } = href;
        public string? Type { get; set; } = type;
        public string? Rel { get; set; } = rel;
    }
}
