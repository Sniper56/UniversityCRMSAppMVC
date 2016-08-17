using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCRMSAppWeb.Models;

namespace UniversityCRMSAppWeb.Controllers
{
    public class AllocateClassroomsController : Controller
    {
        //
        // GET: /AllocateClassrooms/
        public ActionResult Allocate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Allocate(AllocateClassroomModel allocate )
        {

            return View();
        }
	}
}