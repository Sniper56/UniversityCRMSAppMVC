using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityCRMSAppWeb.Models
{
    public class DepartmentModel
    {
        [Required(ErrorMessage = "Please Select a valid Department")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Please Select a valid DepartmentCode")]
        public string DepartmentCode { get; set; }

        [Required(ErrorMessage = "Please Select a valid DepartmentName")]
        public String DepartmentName { get; set; }
    }
}