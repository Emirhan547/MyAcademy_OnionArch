namespace OnionApp.WebUI.Dtos.AiDtos
{
    public sealed class AdminContentAiRequestDto
    {
        public string ContentType { get; set; } = "Blog Taslağı";
        public string TargetAudience { get; set; } = string.Empty;
        public string Keywords { get; set; } = string.Empty;
        public string ToneOfVoice { get; set; } = "Profesyonel";
    }
}
