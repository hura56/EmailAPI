using EmailAPI.Interfaces;
using EmailAPI.Models;

namespace EmailAPI.Repositories;

public class EmailTemplateRepository : IEmailTemplateRepository
{
    private readonly List<EmailTemplate> _templates = new()
    {
        new EmailTemplate {Id = 0, Subject = "Witaj, {{name}}!",  Content = "Cześć {{name}}, witamy w serwisie {{serviceName}}"},
        new EmailTemplate {Id = 1, Subject = "Potwierdzenie zamówienia #{{order}}",  Content = "Witaj {{name}}, Twoje zamówienie #{{order}} zostało potwierdzone"}
    };

    public List<EmailTemplate> GetTemplates() => _templates;

    public EmailTemplate? GetTemplateById(int id)
    {
        return _templates.FirstOrDefault(t => t.Id == id);
    }

    public void AddTemplate(EmailTemplate template)
    {
        template.Id = _templates.Any() ? _templates.Max(t => t.Id) + 1 : 1;
        _templates.Add(template);
    }

    public void UpdateTemplate(EmailTemplate template)
    {
        var exisitng = _templates.FirstOrDefault(t => t.Id == template.Id);
        if (exisitng != null)
        {
            exisitng.Subject = template.Subject;
            exisitng.Content = template.Content;
        }
    }

    public void DeleteTemplate(int id)
    {
        var template = _templates.FirstOrDefault(t => t.Id == id);
        if (template != null)
        {
            _templates.Remove(template);
        }
    }
}
