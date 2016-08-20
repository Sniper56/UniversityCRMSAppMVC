using System;
using System.Collections.Generic;
using System.Web.Mvc;
using UniversityCRMSAppWeb.BLL;
using UniversityCRMSAppWeb.Models;

namespace UniversityCRMSAppWeb.Controllers
{
    public class DepartmentController : Controller
    {
        //
        // GET: /Department/
        DepartmentManager departmentManager = new DepartmentManager();
        public ActionResult Save()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Save(DepartmentModel department)
        {
            if (department.DepartmentCode.Length < 2 || department.DepartmentCode.Length > 7)
            {
                Response.Write("Department code must be 2 to 7 charecter long.");
            }
            else
            {
                if (departmentManager.IsDepartmentTestExists(department))
                {
                    Response.Write("Department code alredy exist!");
                }
                else
                {
                    departmentManager.SaveDepartment(department);
                    Response.Write("Department save successfuly.!");
                }
            }
            return View();
        }

        public ActionResult GetAllDepartment()
        {
            List<DepartmentModel> departments = departmentManager.GetDepartment();
            return View(departments);
        }
    }
}