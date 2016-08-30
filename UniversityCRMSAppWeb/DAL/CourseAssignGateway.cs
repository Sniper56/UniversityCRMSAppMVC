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
            string query = "INSERT INTO CourseAssign(DepartmentId,TeacherId,CourseId,Status) VALUES('" + d + "','" + t + "'," + c + ",'True')";
            SqlCommand cmd = new SqlCommand(query, con);
            //Command.CommandText = Query;
            con.Open();
            int rowAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowAffected;
        }

        public bool OverlapCourse(int tid, int cid)
        {
            SqlConnection Connection = new SqlConnection(connectinDB);
            string query = "SELECT * FROM CourseAssign WHERE TeacherId=" + tid + " AND CourseId=" + cid + "";
            //Command.CommandText = Query;
            SqlCommand cmd = new SqlCommand(query, Connection);
            SqlDataReader Reader =cmd.ExecuteReader();
            Connection.Open();
            Reader = cmd.ExecuteReader();
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
            string query = "SELECT * FROM CourseAssign WHERE CourseId =" + cid + "";
            SqlCommand Command = new SqlCommand(query, Connection);
            //Command.CommandText = Query;
            SqlDataReader Reader = Command.ExecuteReader();

            Connection.Open();
            Reader = Command.ExecuteReader();
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
