using System.Linq;

namespace Credo_fsd;

public class LinqExample
{
    public static void Main(string[] args)
    {
        var marks = new List<int>() { 23, 45, 56, 23, 7, 78, 23, 45 };
        // if (marks.Count > 0)
        
        if (marks.Any(x => x > 40))
        {
            var a = marks.Where(x => x % 2 == 0).OrderByDescending(x => x).ToList();
            foreach (var i in a)
            {
                Console.WriteLine(i);
            }
        }

        if (marks.All(x => x % 2 == 0))
        {
            
        }

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