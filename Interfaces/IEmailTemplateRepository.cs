using EmailAPI.Models;

namespace EmailAPI.Interfaces;

public interface IEmailTemplateRepository
{
    List<EmailTemplate> GetTemplates();
    EmailTemplate? GetTemplateById(int id);
}
