using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCRMSAppWeb.DAL;
using UniversityCRMSAppWeb.Models;

namespace UniversityCRMSAppWeb.BLL
{
    public class StudentRegisterManager
    {
      StudentRegisterGateway studentRegisterGateway=new StudentRegisterGateway();

        public int SaveStudent(StudentRegisterModel student,string registrationNo)
        {
            return studentRegisterGateway.SaveStudent(student, registrationNo);
        }

        public List<StudentRegisterViewModel> GetAllStudentRegister()
        {
            return studentRegisterGateway.GetAllRegisterStudent();
        }

        public string GetDepartmentCode(int departmentId)
        {
          return  studentRegisterGateway.GetDepartmentCode(departmentId);
        }

        //public int GetNo(StudentRegisterModel student)
        //{
        //    return studentRegisterGateway.GetNo(student);
        //}

        public int GetNo()
        {
            return studentRegisterGateway.GetNo();
        }
    }
}