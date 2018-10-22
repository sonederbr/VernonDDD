using System;
using ManageMainEvents.Domain.Model.MainEvents;

namespace Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new MainEvent("");             if (!obj.IsValid())             {                 foreach (var error in obj.ValidationResult.Errors)                     Console.WriteLine(error.ErrorMessage);             }             Console.ReadKey(); 
        }
    }
}
