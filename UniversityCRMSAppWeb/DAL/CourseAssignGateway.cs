using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace UniversityCRMSAppWeb.DAL
{
    public class CourseAssignGateway
    {
        string connectinDB = WebConfigurationManager.ConnectionStrings["UniversityCRMS"].ConnectionString;
        public int Save(int d, int t, int c)
        {
            SqlConnection con = new SqlConnection(connectinDB);
            string query = "INSERT INTO CourseAssignToTeacher(DepartmentId,TeacherId,CourseId,CourseAssignStatus) VALUES('" + d + "','" + t + "'," + c + ",'True')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int rowAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowAffected;
        }

        public bool OverlapCourse(int tid, int cid)
        {
            SqlConnection Connection = new SqlConnection(connectinDB);
            string query = "SELECT * FROM CourseAssignToTeacher WHERE TeacherId=" + tid + " AND CourseId=" + cid + "";
            //Command.CommandText = Query;
            SqlCommand cmd = new SqlCommand(query, Connection);
            Connection.Open();
            SqlDataReader Reader = cmd.ExecuteReader();
            if (Reader.HasRows)
            {
                return true;
            }

            Reader.Close();
            Connection.Close();
            return false;
        }
        public bool AssignCourse(int cid)
        {
            SqlConnection Connection = new SqlConnection(connectinDB);
            string query = "SELECT * FROM CourseAssignToTeacher WHERE CourseId =" + cid + "";
            SqlCommand Command = new SqlCommand(query, Connection);
           Connection.Open();
            SqlDataReader Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                return true;
            }

            Reader.Close();
            Connection.Close();
            return false;
        }
    }
}
