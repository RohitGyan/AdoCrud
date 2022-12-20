using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CustomerDashBoardApp.Models
{
    public class CRUD
    {
        private string _connectionString = @"Data Source=IN-5H5Q303\SQLEXPRESS;Initial Catalog=Testdb;User Id=sa;Password=sa";
        public DataTable GetAllEmployee()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("Select * from tblStudent", sqlConnection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }
            return dataTable;
        }
        public DataTable GetEmployeeById(int id)
        {
            DataTable dataTable = new DataTable();
            string _connectionString = @"Data Source=IN-B2WMGK3\SQLEXPRESS;Initial Catalog=Testdb;User Id=sa; Password=sa";
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("Select * from tblStudent where Id=" + id, sqlConnection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dataTable);
            }
            return dataTable;
        }

        public int UpdateEmployee(int students_id, string student_name, int student_age, string student_gender)
        {
            string strConString = @"Data Source=IN-B2WMGK3\SQLEXPRESS;Initial Catalog=Testdb;User Id=sa;Password=sa";



            using (SqlConnection sqlConnection = new SqlConnection(strConString))
            {
                sqlConnection.Open();
                string query = "Update tblStudent SET student_name=@student_name, student_age=@student_age , student_gender=@student_gender,  where students_id=@students_id";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.AddWithValue("@students_id", students_id);
                cmd.Parameters.AddWithValue("@student_name", student_name);
                cmd.Parameters.AddWithValue("@student_age", student_age);
                cmd.Parameters.AddWithValue("@student_gender", student_gender);
                return cmd.ExecuteNonQuery();
            }
        }

        internal int UpdateEmployee(string student_name, int student_age, string student_gender)
        {
            throw new NotImplementedException();
        }

        
public int Delete(int students_id)
        {
            string strConString = @"Data Source=IN-B2WMGK3\SQLEXPRESS;Initial Catalog=paginationDb;User Id=sa; Password=sa";

            using (SqlConnection sqlConnection = new SqlConnection(strConString))
            {
                sqlConnection.Open();
                string query = "Delete from Customers where Id=@id";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.AddWithValue("@students_id", students_id);
                return cmd.ExecuteNonQuery();
            }
        }


    }
}
