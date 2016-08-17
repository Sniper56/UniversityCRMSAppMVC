using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCRMSAppWeb.BLL;
using UniversityCRMSAppWeb.DAL;
using UniversityCRMSAppWeb.Models;

namespace UniversityCRMSAppWeb.Controllers
{
    public class AllocateClassroomsController : Controller
    {
        //
        // GET: /AllocateClassrooms/
        AllocateClassroomManager allocateClassroomManager=new AllocateClassroomManager();
        public ActionResult AllocateClassRoom()
        {
            ViewBag.Department = allocateClassroomManager.GetAllDepartment();
            ViewBag.RoomNo = allocateClassroomManager.GetallRoom();
            ViewBag.Day = allocateClassroomManager.GetAllDay();
            return View();
        }
        [HttpPost]
        public ActionResult AllocateClassRoom(AllocateClassroomModel allocate)
        {

            ViewBag.Department = allocateClassroomManager.GetAllDepartment();
            ViewBag.RoomNo = allocateClassroomManager.GetallRoom();
            ViewBag.Day = allocateClassroomManager.GetAllDay();
            return View();
        }
	}
}