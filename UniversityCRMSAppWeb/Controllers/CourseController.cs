using System.Web.Mvc;
using UniversityCRMSAppWeb.BLL;
using UniversityCRMSAppWeb.Models;

namespace UniversityCRMSAppWeb.Controllers
{
    public class CourseController : Controller
    {
        //
        // GET: /Course/
        CourseManager courseManager = new CourseManager();
        public ActionResult SaveCourse()
        {
            ViewBag.Department = courseManager.GetAllDepartment();
            ViewBag.Semister = courseManager.GetAllSemester();
            return View();
        }

        [HttpPost]
        public ActionResult SaveCourse(CourseModel course)
        {
            if (course.SemesterId == 0 || course.DepartmentId == 0)
            {
                Response.Write("Please select departmnet and semester!");
            }
            else
            {
                if (courseManager.IsCourseCodeAndNameExist(course.CourseCode, course.CourseName))
                {
                    Response.Write("Course code & name alredy exixt!");
                }
                else
                {
                    if (course.CourseName.Length < 5)
                    {
                        Response.Write("Course  name must be at least 5 charecter long!");
                    }
                    else
                    {
                        courseManager.SaveCourse(course);
                        Response.Write("Course save successfuly.");
                    }
                }
            }
            ViewBag.Department = courseManager.GetAllDepartment();
            ViewBag.Semister = courseManager.GetAllSemester();
            return View();
        }
    }
}