using Microsoft.AspNetCore.Mvc;

namespace billy_trees.Controllers;

[ApiController]
[Route("[controller]")]

public class FormController: ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<FormController> _logger;

    public FormController(ILogger<FormController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Form> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new Form
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, -20),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpPut("Form")]
    public bool Test([FromBody] string email)
    {
       return email?.Equals("TestInput") == true;
    }
}
