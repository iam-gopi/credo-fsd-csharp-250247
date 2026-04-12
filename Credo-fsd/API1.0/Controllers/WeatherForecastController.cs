using System.ComponentModel.DataAnnotations;
using API1._0.Services;
using Microsoft.AspNetCore.Mvc;

namespace API1._0.Controllers;

public class Student{
    [Required(ErrorMessage = "Name is required")]
    [MinLength(10, ErrorMessage = "Name must be at least 10 characters")]
    [MaxLength(20, ErrorMessage = "Name must be at least 20 characters")]
    [RegularExpression("[A-Za-z]", ErrorMessage = "not matched")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Department is required")]
    public string Department { get; set; }
}

[ApiController]
[Route("[controller]")]
public class WeatherForecastController(IStudent student) : ControllerBase
{
    [HttpGet(Name = "GetWeatherForecast")]
    public IActionResult Get()
    {
        throw new Exception("something not working");
        return Ok(student.GetName());
    }
    
    //localhost:2342/api/student/4
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return Ok(student.GetName() + " " + id);
    }
    
    //localhost:2342/api/student/query?name=Gopi&dept=cse
    [HttpGet("query")]
    public IActionResult GetQuery([FromQuery]string name, [FromQuery]string dept)
    {
        return Ok(new {name, dept});
    }

    [HttpPost]
    public IActionResult Post([FromBody]Student model)
    {
        return Ok(model);
    }
}