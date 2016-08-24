using System;
using System.Collections.Generic;
using System.Web.Mvc;
using UniversityCRMSAppWeb.BLL;
using UniversityCRMSAppWeb.Models;

namespace UniversityCRMSAppWeb.Controllers
{
    public class StudentRegisterController : Controller
    {
        private StudentRegisterManager studentRegisterManager = new StudentRegisterManager();
        private DepartmentManager departmentManager = new DepartmentManager();

        public ActionResult StudentRegister()
        {
            ViewBag.Departments = departmentManager.GetDepartment();
            ViewBag.PostBack = false;
            return View();
        }

        [HttpPost]
        public ActionResult StudentRegister(StudentRegisterModel student)
        {
           string deppartmentCode= studentRegisterManager.GetDepartmentCode(student.DepartmentId);
            //generate registration number
            var code = deppartmentCode.Substring(0, 3);
            var year = DateTime.Now.Year;
            int no = studentRegisterManager.GetNo();
            //int no = studentRegisterManager.GetNo(student);
            no = no + 1;
            string registrationNo = (code +"-"+ year+"-")+(no.ToString().PadLeft(3,'0'));

            //-----------------------
            studentRegisterManager.SaveStudent(student, registrationNo); 
            ViewBag.Departments = departmentManager.GetDepartment();
            List<StudentRegisterViewModel> allRegisterStudent = studentRegisterManager.GetAllStudentRegister();
            ViewBag.AllRegisterStudent = allRegisterStudent;
            ViewBag.PostBack = true;
            return View();
        }
    }
}