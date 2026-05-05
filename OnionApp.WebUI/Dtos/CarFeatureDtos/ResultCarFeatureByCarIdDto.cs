namespace OnionApp.WebUI.Dtos.CarFeatureDtos
{
    public class ResultCarFeatureByCarIdDto
    {
        public int Id { get; set; }
        public int FeatureId { get; set; }
        public string FeatureName { get; set; }
        public bool Available { get; set; }
    }
}
