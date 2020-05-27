using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MVCCRUDBAL
{
    public class StudentBal
    {
        public string StrConString = @"Data Source=(LocalDB)\MSSQLLocalDB; User Id=LAPTOP-1LQHV2MQ\koolm;Initial Catalog=mvc_demo; Integrated Security=True;";
        public int SaveRegistration(string firstName, string middleName, string lastName, string gender, DateTime dateOfBirth, bool isActive)
        {
            using (SqlConnection con = new SqlConnection(StrConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SaveStudentRegistrationForm", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@MiddleName", middleName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                cmd.Parameters.AddWithValue("@IsActive", isActive);
                return cmd.ExecuteNonQuery();
            }
        }

        public DataSet GetRecord()
        {
            string result = "";
            DataSet ds = null;
            try
            {
                using (SqlConnection con = new SqlConnection(StrConString))
                {
                    SqlCommand cmd = new SqlCommand("Proc_GetRecord", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = cmd;
                    ds = new DataSet();
                    sda.Fill(ds);
                }
                return ds;
            }
            catch
            {
                return ds;
            }
        }

        public DataSet GetStudentByID(int id)
        {
            DataSet ds = null;
            try
            {
                using (SqlConnection con = new SqlConnection(StrConString))
                {
                    SqlCommand cmd = new SqlCommand("Proc_Edit", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = cmd;
                    ds = new DataSet();
                    sda.Fill(ds);
                }
                return ds;
            }
            catch
            {
                return ds;
            }
        }

        public int UpdateRegistrationFoam(int StudentId, string firstName, string middleName, string lastName, string gender, DateTime dateOfBirth, bool isActive)
        {
            using (SqlConnection con = new SqlConnection(StrConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Firstname", firstName);
                cmd.Parameters.AddWithValue("@MiddleNAme", middleName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@IsActive", isActive);
                cmd.Parameters.AddWithValue("@id", StudentId);
                return cmd.ExecuteNonQuery();
            }

        }

        public int DeleteStudentRecord(int id)
        {
            using (SqlConnection con = new SqlConnection(StrConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_DeleteRecord", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery();
            }
        }

        public int LoginInfo(string Email, string Password)
        {
            using (SqlConnection con = new SqlConnection(StrConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("pro_loginn", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Password", Password);
                return cmd.ExecuteNonQuery();
            }
        }


        public int NewREgister(string firstName, string lastName, string Email, string Password, string CPassword)
        {
            using (SqlConnection con = new SqlConnection(StrConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_SaveSignUp", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.Parameters.AddWithValue("@CPassword", CPassword);
                return cmd.ExecuteNonQuery();
            }
        }


    }

}