using System.Text.Json.Serialization;

namespace UseCase1.Models
{
    public class Name
    {
        public string? Common { get; set; }
        public string? Official { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Dictionary<string, Name>? NativeName { get; set; }
    }
}