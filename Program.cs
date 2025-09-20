using Amazon.Data;
using Amazon.Domain;
using System.Text.Json;

namespace MigrationApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LoadDefaultEmployeesData();
            
        
        }

        private static void LoadDefaultEmployeesData()
        {
            // read the Data.Json file  
            string contentsAsString = File.ReadAllText("Data.json");
            // change the String into a List<Employee> (Deserialize)
            var employees = JsonSerializer.Deserialize<List<Employee>>(contentsAsString);
            //call Context to Adding the new employees
            using (var context = new AmazonContext())
            { 
            //add bulk employee
            context.Employees.AddRange(employees);
            context.SaveChanges();
            
            }
        }


    }



}