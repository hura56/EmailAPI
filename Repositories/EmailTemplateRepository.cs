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
}
