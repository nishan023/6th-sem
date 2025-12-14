using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    class Program
    {
        static void Main(string[] args)
        {
            Program pg = new Program();
            //pg.InsertRecord();
            // pg.UpdateRecord();
          //  pg.DeleteRecord();
           pg.SelectRecord();
            Console.ReadKey();
        }

        //Insert Method
        public void InsertRecord()
        {
            //1. connection 
            SqlConnection conn = new SqlConnection(@"Data Source=localhost;user=sa;password=Nishan@123;Initial Catalog=Employee_DB");
            //2.command
            SqlCommand cmd = new SqlCommand("INSERT INTO tblEmployee VALUES (1, 'Sujal', 20, '2003-12-12', 'Male', 'Jorpati') ", conn);

            //3. connection open
            conn.Open();

            //4. execute query

            int result = cmd.ExecuteNonQuery();

            Console.WriteLine(result > 0 ? "Record Inserted Successfully" : "Insert Failed");
            //5.close
            conn.Close();

        }



        // Update Method
        public void UpdateRecord()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=localhost;user=sa;password=Nishan@123;Initial Catalog=Employee_DB");
            SqlCommand cmd = new SqlCommand("UPDATE tblEmployee SET Name='Nishan Dhakal', Age=22 WHERE Id=1", conn);
            conn.Open();
            int result = cmd.ExecuteNonQuery();
            Console.WriteLine(result);
            Console.WriteLine(result > 0 ? "Record Updated Successfully" : "Update Failed");
            conn.Close();
        }

        // Delete Method
        public void DeleteRecord()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=localhost;user=sa;password=Nishan@123;Initial Catalog=Employee_DB");
            SqlCommand cmd = new SqlCommand("DELETE FROM tblEmployee WHERE Id=1", conn);

            conn.Open();
            int result = cmd.ExecuteNonQuery();
            Console.WriteLine(result > 0 ? "Record Deleted Successfully" : "Delete Failed");
            conn.Close();
        }


        // Select Method
        public void SelectRecord()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=localhost;user=sa;password=Nishan@123;Initial Catalog=Employee_DB");
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblEmployee", conn);
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("---- Customer Records ----");
            while (reader.Read())
            {
                Console.WriteLine($"Id: {reader["Id"]}, Name: {reader["Name"]}, Age: {reader["Age"]}, DOB: {reader["DOB"]}, Gender: {reader["Gender"]}, Address: {reader["Address"]}");
            }

            reader.Close();
            conn.Close();
        }
    }
}

