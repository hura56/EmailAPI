using Microsoft.AspNetCore.Mvc;
using EmailAPI.Models;
using EmailAPI.Services;
using EmailAPI.Repositories;
using EmailAPI.Interfaces;

namespace EmailAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmailController : ControllerBase
{
    private readonly IEmailService _emailService;
    private readonly IEmailTemplateRepository _templateRepository;

    public EmailController(IEmailService emailService, IEmailTemplateRepository templateRepository)
    {
        _emailService = emailService;
        _templateRepository = templateRepository;
    }

    [HttpPost("send")]
    public async Task<IActionResult> SendEmail([FromBody] EmailRequest request)
    {
        var template = _templateRepository.GetTemplateById(request.TemplateId);
        if (template == null)
        {
            return BadRequest("Niepoprawne Id szablonu");
        }

        string personalizedContent = PersonalizeText(template.Content, request.Placeholders);
        string personalizedSubject = PersonalizeText(template.Subject, request.Placeholders);

        try
        {
            await _emailService.SendEmailAsync(request.Recipient, personalizedSubject, personalizedContent);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Błąd podczas wysyłania e-maila: {ex.Message}");
        }

        return Ok("Email wysłany poprawnie");

    }

    public static string PersonalizeText(string text, Dictionary<string, string> placeholders)
    {
        foreach (var placeholder in placeholders)
        {
            text = text.Replace($"{{{{{placeholder.Key}}}}}", placeholder.Value);
        }
        return text;
    }
}
