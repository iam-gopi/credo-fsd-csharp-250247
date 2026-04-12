using API.service;
using Microsoft.AspNetCore.Mvc;

namespace API.controllers;

[ApiController]
[Route("[controller]")]  
public class HomeController : ControllerBase
{
    private readonly IStudent stud;
    
    public HomeController(IStudent student)
    {
        stud = student;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        var name = stud.GetName();
        return Ok(name);
    }
    
    [HttpGet("/getastudent")]
    public IActionResult GetById()
    {
        return Ok("Welcome from API Home Controller");
    }
}

