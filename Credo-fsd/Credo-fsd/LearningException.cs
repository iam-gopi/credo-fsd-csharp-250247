// using System;
//
// namespace Credo_fsd;
//
// public class LearningException
// {
//     public static void Main(string[] args)
//     {
//         try
//         {
//             // int a = 10 / 0;
//             print();
//         }
//         catch (DivideByZeroException ex)
//         {
//             Console.WriteLine(ex.ToString());
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine(ex.ToString());
//         }
//         finally
//         {
//            // always execute 
//         }
//     }
//     
//     private static void print()
//     {
//         try
//         {
//             // logic
//             print1();
//         }
//         catch (ArithmeticException ex)
//         {
//             throw;
//         }
//     }
//
//     private static void print1()
//     {
//         try
//         {
//             // logic
//             throw new ArithmeticException();
//         }
//         catch (ArithmeticException ex)
//         {
//             throw;
//         }
//     }
// }