using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace FASSProject
{
    public class EmployeeModel
    {
        static string cs = ConfigurationManager.ConnectionStrings["FassDBConnection"].ConnectionString;
        public static Employee getEmployee(Employee emp)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Select * from Employees", con);
            if (con.State.Equals(ConnectionState.Closed))
                con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                if (rd.GetString(0) == emp.employeeid && rd.GetString(1) == emp.katasandi)
                {
                    con.Close();
                    return emp;
                }
            }
            return null;
        }

    }
}