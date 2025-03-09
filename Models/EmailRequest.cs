namespace EmailAPI.Models;

public class EmailRequest
{
    public string Recipient { get; set; } = string.Empty;
    public int TemplateId { get; set; }
    public Dictionary<string, string> Placeholders { get; set; } = new();
}
