// using System.Text.Json;
//
// namespace Credo_fsd;
//
// class Student
// {
//     public string Name { get; set; }
// }
//
// public class FileIOOperation
// {
//     public static void Main(String[] args)
//     {
//         // var result = File.ReadAllLines("data.txt");
//         // foreach (var se in result)
//         // {
//         //     Console.WriteLine(se);
//         // }
//
//         // using StreamReader reader = new StreamReader("data.txt");
//         // while (!reader.EndOfStream)
//         //     Console.WriteLine(reader.ReadLine());
//
//         // File.AppendAllLines("data1.txt", ["this is the new content"]);
//         // Console.WriteLine("completed");
//         //
//         // using StreamWriter reader = new StreamWriter("data1.txt", append: true);
//         // reader.WriteLine("this is the new content");
//           
//         // using BinaryWriter writer = new BinaryWriter(File.Open("data.txt", FileMode.Append));
//         // writer.Write("Started building project: Credo-fsd \n");
//         // writer.Write(2569);
//
//         // var students = new { name = "Sakthi" };
//         // string json = JsonSerializer.Serialize(students);
//         // File.WriteAllText("students.json", json);   
//         //
//         // var strContent = File.ReadAllText("students.json");
//         // var obj = JsonSerializer.Deserialize<Student>(strContent, 
//         //     new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
//         // Console.WriteLine(obj.Name);
//     }
// }