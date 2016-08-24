using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCRMSAppWeb.DAL;
using UniversityCRMSAppWeb.Models;

namespace UniversityCRMSAppWeb.BLL
{
    public class StudentManager
    {
        StudentGateway studentGateway = new StudentGateway();
        public IEnumerable<Student> GetAllStudents
        {
            get { return studentGateway.GetAllStudents(); }
        }
    }

   
}