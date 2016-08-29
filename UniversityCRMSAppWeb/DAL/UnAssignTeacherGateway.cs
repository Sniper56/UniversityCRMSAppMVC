using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace UniversityCRMSAppWeb.DAL
{
    public class UnAssignTeacherGateway
    {
        string connectinDB = WebConfigurationManager.ConnectionStrings["UniversityCRMS"].ConnectionString;

        public void UnassignTeacher()
        {
            SqlConnection con = new SqlConnection(connectinDB);
            string query = "UPDATE CourseAssignToTeacher SET CourseAssignStatus='False' WHERE CourseAssignStatus='True'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}