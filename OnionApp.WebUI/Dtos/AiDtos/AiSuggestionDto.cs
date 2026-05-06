namespace OnionApp.WebUI.Dtos.AiDtos
{
    public sealed class AiSuggestionDto
    {
        public string Title { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
        public List<string> Suggestions { get; set; } = [];
        public string Source { get; set; } = string.Empty;
        public DateTime GeneratedAtUtc { get; set; }
        public string Disclaimer { get; set; } = string.Empty;
    }
}
