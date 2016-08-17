using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCRMSAppWeb.DAL;
using UniversityCRMSAppWeb.Models;

namespace UniversityCRMSAppWeb.BLL
{
    public class AllocateClassroomManager
    {
        AllocateClassroomGateway allocateClassroomGateway=new AllocateClassroomGateway();
        TeacherGateway teacherGateway=new TeacherGateway();
        CourseGateway courseGateway=new CourseGateway();
        public int AllocateClassroom(AllocateClassroomModel allocateClassroom)
        {
            return allocateClassroomGateway.SaveAllocateClassroom(allocateClassroom);
        }

        public List<DepartmentModel> GetAllDepartment()//load department to department dropdown list
        {
            return teacherGateway.GetAllDepartment();
        }


        public List<RoomModel> GetallRoom()
        {
            return allocateClassroomGateway.GetallRoom();
        }

        public List<DayModel> GetAllDay()
        {
            return allocateClassroomGateway.GetAllDay();
        }

        public List<CourseModel> GetAllCourse(int depertmetnId)
        {
            return allocateClassroomGateway.GetAllCourse(depertmetnId);
        }
    }
}