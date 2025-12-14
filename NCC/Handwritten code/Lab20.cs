-- Create Employee table--
CREATE TABLE Employees (
    Id INT PRIMARY KEY,
    Name VARCHAR(100),
    Age INT,
    DOB DATE,
    Gender VARCHAR(10),
    Address VARCHAR(100)
);

-- Insert Employee Records--
INSERT INTO Employees (Id, Name, Age, DOB, Gender, Address)
VALUES 
(1, 'Sujal', 20, '2003-12-12', 'Male', 'Jorpati'),
(2, 'Nishan Dhakal', 22, '2001-06-05', 'Male', 'KTM');

--update--
update Employee set Name='Nishan', Address='Jorpati' where id=3;

--delete--
Delete from Employee where id=3;



// To generate the models using EF Core CLI, run the following command in the terminal:
Scaffold-DbContext "Server=localhost;Database=Employee_DB;User Id=sa;Password=Nishan@123;Trusted_Connection=False;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models


//program to perform CRUD operations using Entity Framework Core
using EmployeeEntiry.Models;
using EmployeeEntiry.Models;
using System;
using System.Linq;

namespace EmployeeEntity
{
    class Program
    {
        EmployeeDbContext _context = new EmployeeDbContext();
        static void Main(string[] args)
        {
            Program pg = new Program();
            // pg.InsertRecord();
            //pg.UpdateRecord();
            //pg.UpdateRecord();
            pg.Select();
            Console.ReadKey();
        }


        public void InsertRecord()
        {
            var employee = new TblEmployee
            {
                Name = "NISHAN",
                Age = 30,
                Dob = new DateTime(1995, 5, 1).ToString("yyyy-MM-dd"),
                Gender = "Male",
                Address = "123 Main Street"
            };
            _context.TblEmployees.Add(employee);
            _context.SaveChanges();
            Console.WriteLine("Successfully data Inserted");
        }
        public void UpdateRecord()
        {
            var employeeUpdate = _context.TblEmployees.Where(x => x.Id == 1).FirstOrDefault();
            if (employeeUpdate != null)
            {
                employeeUpdate.Name = "Raut";
                _context.SaveChanges();
                Console.WriteLine("Employee Updated");
            }
        }


        public void DeleteRecord()
        {
            var employeeToDelete = _context.TblEmployees.Where(x => x.Id == 1).FirstOrDefault();
            if (employeeToDelete != null)
            {
                _context.TblEmployees.Remove(employeeToDelete);
                _context.SaveChanges();
                Console.WriteLine("Employee Deleted");
            }
        }

        public void Select()
        {
            //read
            var employees = _context.TblEmployees.Where(x => x.Id == 1).ToList();
            Console.WriteLine("Employees");
            foreach (var emp in employees)
            {
                Console.WriteLine($"Id:{emp.Id},Name:{emp.Name},Age:{emp.Age},DOB:{emp.Dob},Gender:{emp.Gender},Address:{emp.Address}");
            }
        }

    }
}
