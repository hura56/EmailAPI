namespace EmailAPI.Models;

public class EmailTemplate
{
    public int Id { get; set; }
    public string Subject { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
}
