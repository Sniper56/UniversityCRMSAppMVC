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
            if (teacherManager.IsTeacherEmailExist(teacher.Email) == true)
            {
                Response.Write("Teacher email already exist!");
            }
            else
            {
                teacherManager.SaveTeacher(teacher);
                Response.Write("Teacher save successful.");
            }

            ViewBag.Department = teacherManager.GetAllDepartment();
            ViewBag.Designation = teacherManager.GetTeacherDesignation();
            return View();
        }
	}
}