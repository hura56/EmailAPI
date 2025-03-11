using EmailAPI.Models;

namespace EmailAPI.Interfaces;

public interface IEmailTemplateRepository
{
    List<EmailTemplate> GetTemplates();
    EmailTemplate? GetTemplateById(int id);
    void AddTemplate(EmailTemplate template);
    void UpdateTemplate(EmailTemplate template);
    void DeleteTemplate(int id);
}
