using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCRMSAppWeb.Models
{
    public class StudentRegisterModel
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string StudentRegId { get; set; }
        public DateTime RegisterDate { get; set; }
        public string  DepartmenName { get; set; }
        public int DepartmentId { get; set; }
    }
}