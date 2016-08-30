using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCRMSAppWeb.Models;

namespace UniversityCRMSAppWeb.DAL
{
    public class StudentGateway
    {
        string connectinDB = WebConfigurationManager.ConnectionStrings["UniversityCRMS"].ConnectionString;
        public IEnumerable<Student> GetAllStudents()
        {
            SqlConnection connection = new SqlConnection(connectinDB);
            string Query = "SELECT * FROM StudentRegister";
            SqlCommand Command=new SqlCommand(Query,connection);
            List<Student> students = new List<Student>();
            connection.Open();
            SqlDataReader Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Student aStudent = new Student();

                aStudent.Id = Convert.ToInt32(Reader["StudentId"].ToString());
                aStudent.RegNo = Reader["StudentRegId"].ToString();
                aStudent.Name = Reader["StudentName"].ToString();
                aStudent.Email = Reader["Email"].ToString();
                aStudent.Address = Reader["Address"].ToString();
                aStudent.ContactNo = Reader["ContactNo"].ToString();
                aStudent.Date = Convert.ToDateTime(Reader["InsertDate"].ToString());
                aStudent.DepartmentId = Convert.ToInt32(Reader["DepartmentId"].ToString());

                students.Add(aStudent);
            }
            Reader.Close();
            connection.Close();
            return students;
        }

        public ViewStudentDetails GetAllStudentsByStudentId(int id)
        {
            SqlConnection connection = new SqlConnection(connectinDB);
            string Query = "SELECT * FROM ViewStudentDetail where ID='" + id + "'";
            SqlCommand Command = new SqlCommand(Query, connection);
            ViewStudentDetails aStudent=new ViewStudentDetails();
            connection.Open();
            SqlDataReader Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
            
                aStudent.StudentName= Reader["StudentName"].ToString();
                aStudent.Email = Reader["Email"].ToString();
                aStudent.DepartmentName = Reader["Name"].ToString();
               

            }
            Reader.Close();
            connection.Close();
            return aStudent;
        }



    }
}
