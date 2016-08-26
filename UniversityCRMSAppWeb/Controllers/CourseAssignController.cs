﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCRMSAppWeb.BLL;

namespace UniversityCRMSAppWeb.Controllers
{
    public class CourseAssignController : Controller
    {
        TeacherManager teacherManager = new TeacherManager();
        CourseAssingManager courseAssignManager = new CourseAssingManager();
        //
        // GET: /CourseAssign/
        public ActionResult CourseAssignToTeacher()
        {
            ViewBag.listOfDepartments = teacherManager.GetAllDepartment();
            return View();
        }
        [HttpPost]
        public ActionResult CourseAssignToTeacher(int departmentId, int teacherId, int CourseId)
        {
            ViewBag.message = courseAssignManager.Save(departmentId, teacherId, CourseId);
            ViewBag.listOfDepartments = teacherManager.GetAllDepartment();
            return View();
        }


        public JsonResult GetTeacherByDepartmentId(int departmentId)
        {
            var teacher = teacherManager.GetAllDepartment();
            var studentList = teacher.Where(x => x.DepartmentId == departmentId).ToList();
            return Json(studentList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCourseCodeByDepartmentId(int departmentId)
        {
            var courses = teacherManager.GetAllCourses();
            var studentList = courses.Where(x => x.DepartmentId == departmentId).ToList();
            return Json(studentList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCourseNameAndCreditByCourseId(int courseId)
        {
            var teacher = teacherManager.GetAllCourses();
            var studentList = teacher.Where(x => x.CourseId == courseId).ToList();
            return Json(studentList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetTeacherCreditByTeacherId(int teacherId)
        {
            var teacher = teacherManager.GetAllTeachers();
            var studentList = teacher.Where(x => x.TeacherId == teacherId).ToList();
            return Json(studentList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetTeacherTakenCreditByDepartmentIdAndTeacherId(int deptId, int teacherId)
        {
            var remainingCredit = teacherManager.GetTakenCredit(deptId, teacherId);
            return Json(remainingCredit, JsonRequestBehavior.AllowGet);
        }
	
    }

}