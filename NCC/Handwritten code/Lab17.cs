-- Create Customer table--
CREATE TABLE Customers (
    CustomerId INT PRIMARY KEY,
    CustomerName VARCHAR(100),
    Email VARCHAR(100),
    Phone VARCHAR(20),
    Address VARCHAR(100)
);

-- Insert sample data--
INSERT INTO Customers (CustomerId, CustomerName, Email, Phone, Address)
VALUES
(1, 'Ram Sharma', 'ram@example.com', '9876543210', 'Kathmandu'),
(2, 'Sita Thapa', 'sita@example.com', '9812345678', 'Pokhara');

--update---
update Employee set Name='Nishan', Address='Jorpati' where id=3;

--delete--
Delete from Employee where id=3;

//program to perform CRUD operations
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Program pg = new Program();
            //pg.InsertRecord();
            //pg.UpdateRecord();
            //pg.DeleteRecord();
            pg.SelectRecord();
            Console.ReadKey();
        }

        // Insert Method
        public void InsertRecord()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=localhost;user=sa;password=Nishan@123;Initial Catalog=Customer_DB");
            SqlCommand cmd = new SqlCommand("INSERT INTO Customers VALUES (3, 'Hari KC', 'hari@example.com', '9801234567', 'Lalitpur')", conn);

            conn.Open();
            int result = cmd.ExecuteNonQuery();
            Console.WriteLine(result > 0 ? "Record Inserted Successfully" : "Insert Failed");
            conn.Close();
        }

        // Update Method
        public void UpdateRecord()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=localhost;user=sa;password=Nishan@123;Initial Catalog=Customer_DB");
            SqlCommand cmd = new SqlCommand("UPDATE Customers SET CustomerName='Hari Bahadur KC', Phone='9841234567' WHERE CustomerId=3", conn);

            conn.Open();
            int result = cmd.ExecuteNonQuery();
            Console.WriteLine(result > 0 ? "Record Updated Successfully" : "Update Failed");
            conn.Close();
        }

        // Delete Method
        public void DeleteRecord()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=localhost;user=sa;password=Nishan@123;Initial Catalog=Customer_DB");
            SqlCommand cmd = new SqlCommand("DELETE FROM Customers WHERE CustomerId=3", conn);

            conn.Open();
            int result = cmd.ExecuteNonQuery();
            Console.WriteLine(result > 0 ? "Record Deleted Successfully" : "Delete Failed");
            conn.Close();
        }

        // Select Method
        public void SelectRecord()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=localhost;user=sa;password=Nishan@123;Initial Catalog=Customer_DB");
            SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", conn);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("---- Customer Records ----");
            while (reader.Read())
            {
                Console.WriteLine($"Id: {reader["CustomerId"]}, Name: {reader["CustomerName"]}, Email: {reader["Email"]}, Phone: {reader["Phone"]}, Address: {reader["Address"]}");
            }

            reader.Close();
            conn.Close();
        }
    }
}