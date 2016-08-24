﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCRMSAppWeb.DAL;
using UniversityCRMSAppWeb.Models;

namespace UniversityCRMSAppWeb.BLL
{
    public class TeacherManager
    {
        TeacherGateway teacherGateway = new TeacherGateway();
        CourseGateway courseGateway=new CourseGateway();
        AssingCourseViewManager assingCourseViewManager = new AssingCourseViewManager();

        public int SaveTeacher(TeacherModel teacher)
        {
            return teacherGateway.SaveTeacher(teacher);
        }

        public List<DepartmentModel> GetAllDepartment()//load department to department dropdown list
        {
            return teacherGateway.GetAllDepartment();
        }

        public List<DesignationModel> GetTeacherDesignation()//load teacher designation to designatin dropdown list
        {
            return teacherGateway.GetTeacherDesignation();
        }
        public List<CourseModel> GetAllCourses()
        {
            return courseGateway.GetAllCourses();
        }
        public List<TeacherModel> GetAllTeachers()
        {
            return teacherGateway.GetAllTeacher();
        }

        public decimal GetTakenCredit(int dId, int tId)
        {
            return assingCourseViewManager.GetTakenCredit(dId, tId);
        }
         public bool IsTeacherEmailExist( string email)
        {
            TeacherModel isteacherEmailExist = teacherGateway.IsTecherEamilExist(email);
            if (isteacherEmailExist != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
