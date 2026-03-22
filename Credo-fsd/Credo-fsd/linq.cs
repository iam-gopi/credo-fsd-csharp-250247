using System.Linq;

namespace Credo_fsd;

// public class Student
// {
//     public int Id { get; set; }
//     public string Name { get; set; }
//     public int[] Marks
//     {
//         get;
//         set;
//     }
// }
//
// public class CollegeStudent
// {
//     public int Id { get; set; }
// }

class Employee
{
    public string Name { get; set; }
    public int DepartmentId { get; set; }
    public decimal Salary { get; set; }
}

class Department
{
    public string Name { get; set; }
    public int Id { get; set; }
}

public class LinqExample
{
    public static void Main(string[] args)
    {
         var employees = new List<Employee>()
        {
            new Employee() { Name = "Ärun", DepartmentId = 1, Salary = 120000 },
            new Employee() { Name = "Merlin", DepartmentId = 2, Salary = 120500 },
            new Employee() { Name = "Karthick", DepartmentId = 1, Salary = 170000 },
            new Employee() { Name = "Athithya", DepartmentId = 2, Salary = 190780 },
            new Employee() { Name = "Gopi", DepartmentId = 3, Salary = 137900 }
        };
        var department = new List<Department>()
        {
            new Department(){ Name = "IT", Id=1},
            new Department(){ Name = "HR", Id=2},
            new Department(){ Name = "BPO", Id=3},
        };


        var r = from e in employees
            join d in department
                on e.DepartmentId equals d.Id
            select new
            {
                EmployeeName = e.Name,
                DepartmentName = d.Name
            };
        
        foreach (var i in r)
        {
            Console.WriteLine(i.EmployeeName + " " + i.DepartmentName);
        }

        // var a = new List<int>() { 1,2,3,4,5,6,4,5,6};
        // var r = a.Distinct();

        // var a = new List<int>() { 1,2,3,4,5 };
        // var b = new List<int>() { 4,5,6,7,8 };
        //
        // // var r = a.Union(b);
        // // var r = a.Intersect(b);
        // var r = a.Except(b);
        // foreach (var i in r)
        // {
        //     Console.WriteLine(i);
        // }

        // public class ProductDBContext: DBContext
        // {
        //     
        // }
        //
        // IQueryable products = ProductDBContext.Orders;
        //
        // products.where()

        //  var e = new List<Employee>()
        // {
        //     new Employee() { Name = "Ärun", Department = "ÏT", Salary = 120000 },
        //     new Employee() { Name = "Merlin", Department = "HR", Salary = 120500 },
        //     new Employee() { Name = "Karthick", Department = "ÏT", Salary = 170000 },
        //     new Employee() { Name = "Athithya", Department = "HR", Salary = 190780 },
        //     new Employee() { Name = "Gopi", Department = "BPO", Salary = 137900 }
        // };
        //
        // var p = e.Skip(200).Take(100).ToList();
        //
        // var eg= e.GroupBy(x => x.Department);
        // foreach (var item in eg)
        // {
        //     Console.WriteLine(item);
        //     foreach (var i in item)
        //     {
        //         Console.WriteLine(i.Name);
        //     }
        // }


        // var students = new List<Student>()
        // {
        //     new Student() { Id = 1, Name = "Gopi", Marks = [11,22,33,44,55]},
        //     new Student() { Id = 2, Name = "Kannan", Marks = [1,2,3,4,5]},
        //     new Student() { Id = 2, Name = "Kannan", Marks = [13,12,23,43,54]}
        // };
        //
        // if (students != null && students.Any() == true) // if(null == true) {}
        // {
        //     
        // }

        // var b = students.Select(x =>
        // {
        //     // var total = 0;
        //     // foreach (var a in x.Marks)
        //     // {
        //     //     total += a;
        //     // }
        //     //
        //     // return total;
        //     // x.Marks.Sum()
        //     var aa = x.Marks.Min();
        //     Console.WriteLine(aa);
        //     return aa;
        // });
        //
        // foreach (var i in b)
        // {
        //     Console.WriteLine(i);    
        // }


        // students = students.OrderBy(x => x.Id).ToList(); asc order by student id
        // var a = students.Select(s=>new { s.Name });
        //var a = students.Select(x => new CollegeStudent() { Id = x.Id });


        // var marks = new List<int>() { 24, 46, 56, 28, 8, 78, 22, 46 };
        // // if (marks.Count > 0)
        //
        // if (marks.Any(x => x > 40))
        // {
        //     var a = marks.Where(x => x % 2 == 0).OrderByDescending(x => x).ToList();
        //     foreach (var i in a)
        //     {
        //         Console.WriteLine(i);
        //     }
        // }
        //
        // var b = from n in marks 
        //     where n % 2 == 0
        //         select n;
        //
        // if (marks.All(x => x % 2 == 0))
        // {
        //     Console.WriteLine("all elements ate even");
        // }


        // List<Guid?> cols = new List<Guid?>()
        // {
        //     Guid.NewGuid(), null, Guid.NewGuid(), Guid.NewGuid()
        // };
        //
        // var aa =cols.OfType<Guid>().ToList(); 
        // foreach (var a in aa)
        // {
        //     Console.WriteLine(a);
        // }
    }
}