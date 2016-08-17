using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCRMSAppWeb.BLL;
using UniversityCRMSAppWeb.Models;

namespace UniversityCRMSAppWeb.Controllers
{
    public class TeacherController : Controller
    {
        //
        // GET: /Teacher/
        TeacherManager teacherManager=new TeacherManager();
        public ActionResult SaveTeacher()
        {
            ViewBag.Department = teacherManager.GetAllDepartment();
            ViewBag.Designation = teacherManager.GetTeacherDesignation();
            return View();
        }
        [HttpPost]
        public ActionResult SaveTeacher(TeacherModel teacher)
        {

            ViewBag.Department = teacherManager.GetAllDepartment();
            ViewBag.Designation = teacherManager.GetTeacherDesignation();
            return View();
        }
	}
}