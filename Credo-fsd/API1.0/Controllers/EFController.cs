using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API1._0.Controllers;

[ApiController]
[Route("[controller]")]
public class EFController(AppDbContext context) : ControllerBase
{

    /**
     * EF -> ORM
     * Tables -> class
     * Row -> obj
     * column -> properties
     *
     * public class Student
     * {
     *   public int Id { get; set; }
     *   public string name { get; set; }
     * }
     * in adonet -> select * from student;
     * in ef -> context.Student.tolist()
     *
     * DBContext
     * class FSDClassContext : DBContext{
     *      public DBSet<Student> Student {get;set;}
     * }
     * code first approach
     * DB first approach
     * application code -> DBContext -> DBSet -> provider -> Database
     */
    [HttpGet]
    public IActionResult Get()
    {
        var students = context.Student.AsNoTracking().Take(50).ToList();

        return Ok(new
        {
            message = "success",
            data = students
        });
    }
    
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var students = context.Student.Where(x => x.Id == id).FirstOrDefault();

        return Ok(new
        {
            message = "success",
            data = students
        });
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var students = await context.Student.FindAsync(id);
        
        // SP 
        // var students111 = context.Student.FromSqlRaw("call sp_name({0},{1})", 1,2); // Select
        var students111 = context.Student.ex("call sp_name({0},{1})", 1,2);
        
        if(students == null)
            return NotFound();
        
        context.Student.Remove(students);
        await context.SaveChangesAsync();

        return Ok(new
        {
            message = "success",
            data = students
        });
    }
    
    [HttpPost]
    public IActionResult Post([FromBody] Student student)
    {
        context.Student.Add(new Student()
        {
            Id = student.Id,
            Name = student.Name 
        });

        context.SaveChanges();

        return Ok(new
        {
            message = "success"
        });
    }
}

public class Student
{
    [Key]
    public int Id { get; set; }
    
    [Column("StudentName", TypeName = "nvarchar(100)")]
    [Required]
    [MaxLength(20)]
    public string? Name { get; set; }
    
    public int DepartmentId { get; set; }
    
    [ForeignKey("DepartmentId")]
    public Department Department { get; set; }
}

public class Department
{
    [Key]
    public int Id { get; set; }
    [Column("DepartmentName", TypeName = "nvarchar(100)")]
    [Required]
    [MaxLength(100)]
    public string? Name { get; set; }
}

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Student> Student { get; set; }
    public DbSet<Department> Department { get; set; }
}