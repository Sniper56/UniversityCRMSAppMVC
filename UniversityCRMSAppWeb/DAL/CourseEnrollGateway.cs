﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCRMSAppWeb.Models;

namespace UniversityCRMSAppWeb.DAL
{
    public class CourseEnrollGateway
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["UniversityCRMS"].ConnectionString;
        SqlConnection connection = new SqlConnection();
        public List<ViewStudentDetails> GetAllStudentDetails(int studentId)
        {
            List<ViewStudentDetails> viewStudentDetailses = new List<ViewStudentDetails>();
            string Query = "SELECT * FROM ViewStudentDetails where StudentId='" + studentId + "'";
            SqlCommand cmd = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader Reader = cmd.ExecuteReader();
            while (Reader.Read())
            {
                ViewStudentDetails aViewStudentDetails = new ViewStudentDetails();
                aViewStudentDetails.Id = Convert.ToInt32(Reader["StudentId"]);
                aViewStudentDetails.Name = Reader["StudentName"].ToString();
                aViewStudentDetails.Email = Reader["StudentEmail"].ToString();
                aViewStudentDetails.RegNo = Reader["StudentRegNo"].ToString();
                viewStudentDetailses.Add(aViewStudentDetails);
            }

            Reader.Close();
            connection.Close();
            return viewStudentDetailses;
        }


        public List<ViewCourseFromStudentDepartmentName> GetAllCourseFromStudentDepartmentNames(int studentId)
        {
            List<ViewCourseFromStudentDepartmentName> viewCourseFromStudentDepartment = new List<ViewCourseFromStudentDepartmentName>();
            string Query = "SELECT * FROM ViewCourseFromStudentDepartmentMenu where StudentId='" + studentId + "'";
            SqlCommand Command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                ViewCourseFromStudentDepartmentName aViewStudentDepartmentName = new ViewCourseFromStudentDepartmentName();
                aViewStudentDepartmentName.CourseId = Convert.ToInt32(Reader["CourseId"]);
                aViewStudentDepartmentName.CourseName = Reader["CourseName"].ToString();
                aViewStudentDepartmentName.DepartmentId = Convert.ToInt32(Reader["DepartmentId"]);
                aViewStudentDepartmentName.StudentId = Convert.ToInt32(Reader["StudentId"]);
                viewCourseFromStudentDepartment.Add(aViewStudentDepartmentName);
            }

            Reader.Close();
            connection.Close();
            return viewCourseFromStudentDepartment;
        }


        public int EnrollCourse(CourseEnroll courseEnroll)
        {
            string Query = "INSERT INTO EnrollCourse VALUES('" + courseEnroll.StudentId + "','" + courseEnroll.CourseId + "','" + courseEnroll.EnrollDate + "')";
            SqlCommand Command=new SqlCommand(Query,connection);
            connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }


        public string FindSameCourseForAStudent(CourseEnroll courseEnroll)
        {
            string Query = "SELECT * FROM EnrollCourse WHERE StudentId='" + courseEnroll.StudentId + "' AND CourseId='" + courseEnroll.CourseId + "'";
            SqlCommand Command=new SqlCommand(Query,connection);
            string message = null;
            connection.Open();
            SqlDataReader Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                message = "This Course Already Enroll by This Student";
            }
            Reader.Close();
            connection.Close();
            return message;
        }
    }
}