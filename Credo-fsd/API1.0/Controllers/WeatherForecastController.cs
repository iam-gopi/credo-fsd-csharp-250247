// using System.ComponentModel.DataAnnotations;
// using System.Data;
// using System.IdentityModel.Tokens.Jwt;
// using System.Security.Claims;
// using System.Text;
// using API1._0.Services;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.IdentityModel.Tokens;
// using MySql.Data.MySqlClient;
//
// namespace API1._0.Controllers;
//
// public class Student
// {
//     [Required(ErrorMessage = "Name is required")]
//     [MinLength(10, ErrorMessage = "Name must be at least 10 characters")]
//     [MaxLength(20, ErrorMessage = "Name must be at least 20 characters")]
//     [RegularExpression("[A-Za-z]", ErrorMessage = "not matched")]
//     public string Name { get; set; }
//
//     [Required(ErrorMessage = "Department is required")]
//     public string Department { get; set; }
// }
//
// public class ApiStudent
// {
//     public int Id { get; set; }
//     public string Name { get; set; }
// }
//
// public class Login
// {
//     public string Username { get; set; }
//     public string Password { get; set; }
// }
//
// [ApiController]
// [Route("[controller]")]
// public class WeatherForecastController(IStudent student, IConfiguration configuration) : ControllerBase
// {
//     [HttpGet(Name = "GetWeatherForecast")]
//     public IActionResult Get()
//     {
//         //throw new Exception("something not working");
//
//         // connection, command, datereader, data adapter, datatable
//         var connectionString = "server=localhost;user id=root;password=;database=fsdclass";
//         var responseDetails = new List<ApiStudent>();
//         using (MySqlConnection connection = new MySqlConnection(connectionString))
//         {
//             connection.Open();
//             MySqlCommand command = new MySqlCommand("SELECT id,name FROM student", connection);
//             //command.CommandType = CommandType.StoredProcedure;
//             var result = command.ExecuteReader();
//             while (result.Read())
//             {
//                 int id = Convert.ToInt32(result["id"]);
//                 string name = Convert.ToString(result["name"]);
//                 responseDetails.Add(new ApiStudent
//                     {
//                         Id = id,
//                         Name = name
//                     }
//                 );
//             }
//         }
//
//         return Ok(responseDetails);
//     }
//
//     //localhost:2342/api/student/4
//     [HttpGet("{id}")]
//     public IActionResult Get(int id)
//     {
//         return Ok(student.GetName() + " " + id);
//     }
//
//     //localhost:2342/api/student/query?name=Gopi&dept=cse
//     [HttpGet("query")]
//     public IActionResult GetQuery([FromQuery] string name, [FromQuery] string dept)
//     {
//         return Ok(new { name, dept });
//     }
//
//     [HttpPost]
//     public async Task<IActionResult> Post([FromBody] ApiStudent model)
//     {
//         var connectionString = "server=localhost;user id=root;password=;database=fsdclass";
//
//         await using (MySqlConnection connection = new MySqlConnection(connectionString))
//         {
//             connection.Open();
//             MySqlCommand command = new MySqlCommand("insert into student (name) values(@name)", connection);
//             command.Parameters.AddWithValue("@name", model.Name);
//             int noOfAffectedRows = await command.ExecuteNonQueryAsync();
//             return Ok(noOfAffectedRows);
//         }
//
//         return NotFound();
//     }
//
//     [HttpGet("adapter")]
//     public IActionResult GetWithAdapter()
//     {
//         var responseDetails = new List<ApiStudent>();
//         var connectionString = "server=localhost;user id=root;password=;database=fsdclass";
//         using (MySqlConnection connection = new MySqlConnection(connectionString))
//         {
//             connection.Open();
//             var myAdapter = new MySqlDataAdapter("SELECT id,name FROM student", connection);
//             DataTable dataTable = new DataTable();
//             myAdapter.Fill(dataTable);
//
//             foreach (DataRow row in dataTable.Rows)
//             {
//                 responseDetails.Add(new ApiStudent()
//                 {
//                     Id = Convert.ToInt32(row["id"]),
//                     Name = Convert.ToString(row["name"])
//                 });
//             }
//         }
//
//         return Ok(responseDetails);
//     }
//
//     [HttpPost("login")]
//     public IActionResult Login([FromBody] Login model)
//     {
//         if (model is { Username: "test@gmail.com", Password: "123456" })
//         {
//             var claims = new[]
//             {
//                 new Claim(ClaimTypes.Name, model.Username),
//                 new Claim(ClaimTypes.Email, "test@gmail.com"),
//                 new Claim(ClaimTypes.Role, "Admin"),
//             };
//             var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
//
//             var token = new JwtSecurityToken(
//                 issuer: configuration["Jwt:Issuer"],
//                 audience: configuration["Jwt:Audience"],
//                 expires: DateTime.Now.AddMinutes(Convert.ToDouble(configuration["Jwt:ExpireMinutes"])),
//                 claims: claims,
//                 signingCredentials:  new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
//             );
//             
//             return Ok(new JwtSecurityTokenHandler().WriteToken(token));
//         }
//
//         return Unauthorized();
//     }
// }