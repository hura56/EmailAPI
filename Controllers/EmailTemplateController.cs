using EmailAPI.Interfaces;
using EmailAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmailAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmailTemplateController : ControllerBase
{
    private readonly IEmailTemplateRepository _templateRepository;

    public EmailTemplateController(IEmailTemplateRepository templateRepository)
    {
        _templateRepository = templateRepository;
    }

    [HttpGet("GetTemplates")]
    public IActionResult GetTemplates()
    {
        var templates = _templateRepository.GetTemplates();
        return Ok(templates);
    }

    [HttpGet("GetById{id}")]
    public IActionResult GetTemplateById(int id)
    {
        var template = _templateRepository.GetTemplateById(id);
        if (template == null)
            return NotFound();
        
        return Ok(template);
    }

    [HttpPost("Create")]
    public IActionResult CreateTemplate([FromBody] EmailTemplate template)
    {
        _templateRepository.AddTemplate(template);
        return CreatedAtAction(nameof(GetTemplateById), new { id = template.Id }, template);
    }

    [HttpPut("Update{id}")]
    public IActionResult UpdateTemplate(int id, [FromBody] EmailTemplate template)
    {
        if (id != template.Id)
            return BadRequest("Id szablonu nie zgadza się z przekazanym id.");

        var existingTemplate = _templateRepository.GetTemplateById(id);
        if (existingTemplate == null)
            return NotFound();

        _templateRepository.UpdateTemplate(template);
        return NoContent();
    }

    [HttpDelete("Delete{id}")]
    public IActionResult DeleteTemplate(int id)
    {
        var existingTemplate = _templateRepository.GetTemplateById(id);
        if (existingTemplate == null)
            return NotFound();

        _templateRepository.DeleteTemplate(id);
        return NoContent();
    }
}
