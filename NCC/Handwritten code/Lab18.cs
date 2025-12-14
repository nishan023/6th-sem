-- Create Customers table
CREATE TABLE Customers (
    CustomerId INT PRIMARY KEY,
    CustomerName VARCHAR(100),
    Email VARCHAR(100),
    Phone VARCHAR(20),
    Address VARCHAR(100)
);

-- Insert Customer Records
INSERT INTO Customers (CustomerId, CustomerName, Email, Phone, Address)
VALUES 
(1, 'Ram Sharma', 'ram@example.com', '9876543210', 'Kathmandu'),
(2, 'Sita Thapa', 'sita@example.com', '9812345678', 'Pokhara');

-- Update Customer
UPDATE Customers 
SET CustomerName = 'Sita Devi Thapa', Address = 'Lalitpur' 
WHERE CustomerId = 2;

-- Delete Customer
DELETE FROM Customers 
WHERE CustomerId = 3;

// To generate the models using EF Core CLI, run the following command in the terminal:
Scaffold-DbContext "Server=localhost;Database=Employee_DB;User Id=sa;Password=Nishan@123;Trusted_Connection=False;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models


//program to perform CRUD operations
using CustomerEntity.Models;
using System;
using System.Linq;

namespace CustomerEntity
{
    class Program
    {
        CustomerDbContext _context = new CustomerDbContext();

        static void Main(string[] args)
        {
            Program pg = new Program();
            //pg.InsertRecord();
            //pg.UpdateRecord();
            //pg.DeleteRecord();
            pg.Select();
            Console.ReadKey();
        }

        // Insert Method
        public void InsertRecord()
        {
            var customer = new TblCustomer
            {
                CustomerName = "Hari KC",
                Email = "hari@example.com",
                Phone = "9801234567",
                Address = "Lalitpur"
            };

            _context.TblCustomers.Add(customer);
            _context.SaveChanges();
            Console.WriteLine("Successfully inserted customer.");
        }

        // Update Method
        public void UpdateRecord()
        {
            var customerUpdate = _context.TblCustomers.Where(x => x.CustomerId == 1).FirstOrDefault();
            if (customerUpdate != null)
            {
                customerUpdate.CustomerName = "Ram Bahadur Sharma";
                customerUpdate.Phone = "9845678901";
                _context.SaveChanges();
                Console.WriteLine("Customer updated successfully.");
            }
        }

        // Delete Method
        public void DeleteRecord()
        {
            var customerToDelete = _context.TblCustomers.Where(x => x.CustomerId == 2).FirstOrDefault();
            if (customerToDelete != null)
            {
                _context.TblCustomers.Remove(customerToDelete);
                _context.SaveChanges();
                Console.WriteLine("Customer deleted successfully.");
            }
        }

        // Select Method
        public void Select()
        {
            var customers = _context.TblCustomers.ToList();
            Console.WriteLine("---- Customer Records ----");
            foreach (var cust in customers)
            {
                Console.WriteLine($"Id:{cust.CustomerId}, Name:{cust.CustomerName}, Email:{cust.Email}, Phone:{cust.Phone}, Address:{cust.Address}");
            }
        }
    }
}
