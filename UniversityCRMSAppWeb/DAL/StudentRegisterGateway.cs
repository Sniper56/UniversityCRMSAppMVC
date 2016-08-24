using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCRMSAppWeb.Models;

namespace UniversityCRMSAppWeb.DAL
{
    public class StudentRegisterGateway
    {
        string connectionDB = WebConfigurationManager.ConnectionStrings["UniversityCRMS"].ConnectionString;
        public int SaveStudent(StudentRegisterModel student, string registrationNo)
        {
            int rowAffected = 0;
            SqlConnection connection = new SqlConnection(connectionDB);
            string query = @"INSERT INTO [Student.Register] (StudentRegId,StudentName,Email,ContactNo,RegisterDate,Address,DepartmentId,InsertDate)
                          VALUES ('" + registrationNo + "','" + student.StudentName + "','" + student.Email + "','" + student.ContactNo + "','" + student.RegisterDate + "','" + student.Address + "','" + student.DepartmentId + "',GETDATE())";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public List<StudentRegisterViewModel> GetAllRegisterStudent()
        {
            SqlConnection connection = new SqlConnection(connectionDB);
            string query = @"SELECT  [Student.Register].StudentRegId, [Student.Register].StudentName, Depatment.Name, [Student.Register].Email, [Student.Register].ContactNo, [Student.Register].RegisterDate, [Student.Register].Address
                            FROM Depatment INNER JOIN  [Student.Register] ON Depatment.DepartmentId = [Student.Register].DepartmentId
                            where StudentRegId=(SELECT MAX(StudentRegId) FROM [Student.Register])";
            SqlCommand command = new SqlCommand(query, connection);
            List<StudentRegisterViewModel> studentRegisterList = new List<StudentRegisterViewModel>();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            // if (reader.HasRows)
            //{
            while (reader.Read())
            {
                StudentRegisterViewModel studentRegister = new StudentRegisterViewModel();
                studentRegister.StudentRegisterId = reader["StudentRegId"].ToString();
                studentRegister.StudentName = reader["StudentName"].ToString();
                studentRegister.ContactNo =Convert.ToInt32( reader["ContactNo"].ToString());
                studentRegister.Address = reader["Address"].ToString();
                studentRegister.Email = reader["Email"].ToString();
                studentRegister.DepartmentName = reader["Name"].ToString();
                studentRegister.RegisterDate =Convert.ToDateTime( reader["RegisterDate"].ToString());

                studentRegisterList.Add(studentRegister);
            }
            reader.Close();
            connection.Close();
            return studentRegisterList;
        }

        public string GetDepartmentCode(int departmentId)
        {
            SqlConnection connection = new SqlConnection(connectionDB);
            string departmentCode = "";
            string query = "select DepartmentCode from Depatment where DepartmentId='" + departmentId + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string getCode = reader["DepartmentCode"].ToString();
                departmentCode = getCode;
            }
            reader.Close();
            connection.Close();
            return departmentCode;
        }

        //public int GetNo( StudentRegisterModel student)
        //{
        //    int studentId=0;
        //    SqlConnection connection = new SqlConnection(connectionDB);
        //    string query = "select MAX (StudentRegId) from [Student.Register] where DepartmentId='" + student.DepartmentId + "'";
        //    SqlCommand command = new SqlCommand(query, connection);
        //    connection.Open();
        //    SqlDataReader reader = command.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        string getCode = reader["StudentRegId"].ToString();
        //        studentId =Convert.ToInt32( getCode.Substring(9, 3));
        //    }
        //    reader.Close();
        //    connection.Close();
        //    return studentId;
        //}
        public int GetNo()
        {
            int studentId = 0;
            SqlConnection connection = new SqlConnection(connectionDB);
            string query = "select StudentRegId from [Student.Register] where StudentRegId=(SELECT MAX(StudentRegId) FROM [Student.Register])";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string getCode = reader["StudentRegId"].ToString();
                studentId = Convert.ToInt32(getCode.Substring(9, 3));
            }
            reader.Close();
            connection.Close();
            return studentId;
        }
    }
}