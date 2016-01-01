using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace FASSProject
{
    public class DesaModel
    {
        static string cs = ConfigurationManager.ConnectionStrings["FassDBConnection"].ConnectionString;
        public static IEnumerable<DesaClass> getDesaList()
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Select * from Desa where deleted=0 order by cast(replace(desaid,'DS','') as int)", con);
            if (con.State.Equals(ConnectionState.Closed))
                con.Open();
            List<DesaClass> newdesa = new List<DesaClass>();
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                DesaClass ds = new DesaClass(rd.GetString(0), rd.GetString(1), rd.GetString(2), rd.GetString(3));
                newdesa.Add(ds);
            }
            return newdesa;
        }

        public static int DeleteDesa(DesaClass ds)
        {
            SqlConnection con = new SqlConnection(cs);
            //SqlCommand cmd = new SqlCommand("delete from Desa where DesaID='" + ds.desaid + "'", con);
            SqlCommand cmd = new SqlCommand("update Desa set deleted=1,UpdatedDate=@UpdatedDate,UpdatedBy=@UpdatedBy where DesaID=@desaid", con);
            if (con.State.Equals(ConnectionState.Closed))
                con.Open();
            cmd.Parameters.AddWithValue("@desaid", ds.desaid);
            cmd.Parameters.AddWithValue("@UpdatedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@UpdatedBy", ds.UpdatedBy);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public static int InsertDesa(DesaClass ds)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("insert into Desa (DesaID,NamaDesa,MesjidDesa,Alamat,CreatedDate,CreatedBy,UpdatedDate, UpdatedBy) values(@desaid,@namadesa,@mesjiddesa ,@alamat,@CreatedDate,@CreatedBy,@UpdatedDate, @UpdatedBy)", con);

            if (con.State.Equals(ConnectionState.Closed))
                con.Open();
            cmd.Parameters.AddWithValue("@desaid", ds.desaid);
            cmd.Parameters.AddWithValue("@namadesa", ds.namadesa);
            cmd.Parameters.AddWithValue("@mesjiddesa", ds.mesjiddesa);
            cmd.Parameters.AddWithValue("@alamat", ds.alamat);
            cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@CreatedBy", ds.CreatedBy);
            cmd.Parameters.AddWithValue("@UpdatedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@UpdatedBy", ds.UpdatedBy);


            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public static int UpdateDesa(DesaClass ds)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("update Desa set NamaDesa=@namadesa,mesjidDesa=@mesjiddesa, alamat=@alamat,UpdatedDate=@UpdatedDate,UpdatedBy=@UpdatedBy  where DesaID=@desaid  and deleted=0", con);
            if (con.State.Equals(ConnectionState.Closed))
                con.Open();
            cmd.Parameters.AddWithValue("@desaid", ds.desaid);
            cmd.Parameters.AddWithValue("@namadesa", ds.namadesa);
            cmd.Parameters.AddWithValue("@mesjiddesa", ds.mesjiddesa);
            cmd.Parameters.AddWithValue("@alamat", ds.alamat);
            cmd.Parameters.AddWithValue("@UpdatedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@UpdatedBy", ds.UpdatedBy);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public static int GetMaksID()
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("select max(cast(replace(desaid,'DS','') as int)) from Desa ", con);
            if (con.State.Equals(ConnectionState.Closed))
                con.Open();
            string id = cmd.ExecuteScalar().ToString();
            con.Close();
            if (!string.IsNullOrEmpty(id))
            {
                string getid = id;
                return Int32.Parse(getid);
            }
            return 0;
        }
    }
}