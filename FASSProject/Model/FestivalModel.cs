using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace FASSProject
{
    public class FestivalModel
    {
        static string cs = ConfigurationManager.ConnectionStrings["FassDBConnection"].ConnectionString;
        public static IEnumerable<FestivalClass> getFestivalList()
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Select * from Festival where deleted=0", con);
            if (con.State.Equals(ConnectionState.Closed))
                con.Open();
            List<FestivalClass> newFestival = new List<FestivalClass>();
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                FestivalClass fe = new FestivalClass(rd.GetString(0), rd.GetString(1), rd.GetString(2), rd.GetString(3));
                newFestival.Add(fe);
            }
            return newFestival;
        }
        public static IEnumerable<FestivalClass> getFestivalList(string sistem)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Select * from Festival where SistemFestival=@sistem ", con);
            if (con.State.Equals(ConnectionState.Closed))
                con.Open();
            cmd.Parameters.AddWithValue("@sistem", sistem);
            List<FestivalClass> newFestival = new List<FestivalClass>();
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                FestivalClass fe = new FestivalClass(rd.GetString(0), rd.GetString(1), rd.GetString(2), rd.GetString(3));
                newFestival.Add(fe);
            }
            return newFestival;
        }

        public static int DeleteFestival(FestivalClass fe)
        {
            SqlConnection con = new SqlConnection(cs);
            //SqlCommand cmd = new SqlCommand("delete from Festival where FestivalID='" + fe.festivalID + "'", con);
            SqlCommand cmd = new SqlCommand("update Festival set deleted=1,UpdatedDate=@UpdatedDate,UpdatedBy=@UpdatedBy where FestivalID=@festivalID", con);
            if (con.State.Equals(ConnectionState.Closed))
                con.Open();
            cmd.Parameters.AddWithValue("@festivalID", fe.festivalID);
            cmd.Parameters.AddWithValue("@UpdatedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@UpdatedBy", fe.UpdatedBy);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public static int InsertFestival(FestivalClass fe)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("insert into Festival (FestivalID,NamaFestival,SistemFestival,[Description],CreatedDate,CreatedBy,UpdatedDate,UpdatedBy) "+
            " values(@festivalID ,@namaFestival,@sistemPermainan,@desc,@CreatedDate,@CreatedBy,@UpdatedDate,@UpdatedBy )", con);
            if (con.State.Equals(ConnectionState.Closed))
                con.Open();
            cmd.Parameters.AddWithValue("@festivalID", fe.festivalID);
            cmd.Parameters.AddWithValue("@namaFestival", fe.namaFestival);
            cmd.Parameters.AddWithValue("@sistemPermainan", fe.sistemPermainan);
            cmd.Parameters.AddWithValue("@desc", fe.desc);
            cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@CreatedBy", fe.UpdatedBy);
            cmd.Parameters.AddWithValue("@UpdatedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@UpdatedBy", fe.UpdatedBy);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public static int UpdateFestival(FestivalClass fe)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("update Festival set NamaFestival=@namaFestival,SistemFestival=@sistemPermainan, [Description]=@desc "+
                ",UpdatedDate=@UpdatedDate,UpdatedBy=@UpdatedBy " +
                " where FestivalID=@festivalID ", con);
            if (con.State.Equals(ConnectionState.Closed))
                con.Open();
            cmd.Parameters.AddWithValue("@festivalID", fe.festivalID);
            cmd.Parameters.AddWithValue("@namaFestival", fe.namaFestival);
            cmd.Parameters.AddWithValue("@sistemPermainan", fe.sistemPermainan);
            cmd.Parameters.AddWithValue("@desc", fe.desc);
            cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@CreatedBy", fe.UpdatedBy);
            cmd.Parameters.AddWithValue("@UpdatedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@UpdatedBy", fe.UpdatedBy);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public static int GetMaksID()
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Select max(FestivalID) from Festival", con);
            if (con.State.Equals(ConnectionState.Closed))
                con.Open();
            string id = cmd.ExecuteScalar().ToString();
            con.Close();
            if (!string.IsNullOrEmpty(id))
            {
                string getid = id.Substring(2);
                return Int32.Parse(getid);
            }
            return 0;
        }

        public static IEnumerable<FestivalDetail> getFestivalDetailList(string festid)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Select * from FestivalDetail where FestivalID=@festivalID and deleted=0", con);
            if (con.State.Equals(ConnectionState.Closed))
                con.Open();
            cmd.Parameters.AddWithValue("@festivalID", festid);
            List<FestivalDetail> newFestival = new List<FestivalDetail>();
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                FestivalDetail fes = new FestivalDetail(rd.GetString(0), rd.GetInt32(1), rd.GetString(2));
                newFestival.Add(fes);
            }
            return newFestival;
        }

        public static int DeleteFestivalDetail(FestivalDetail fe)
        {
            SqlConnection con = new SqlConnection(cs);
            //SqlCommand cmd = new SqlCommand("delete from FestivalDetail where FestivalID='" + fe.festivalID + "' and PoinID='" + fe.poinID + "'", con);
            SqlCommand cmd = new SqlCommand("update FestivalDetail set deleted=1, UpdatedDate=@UpdatedDate,UpdatedBy=@UpdatedBy where FestivalID=@festivalID  and PoinID=@poinID  and deleted=0", con);
            if (con.State.Equals(ConnectionState.Closed))
                con.Open();
            cmd.Parameters.AddWithValue("@festivalID", fe.festivalID);
            cmd.Parameters.AddWithValue("@poinID", fe.poinID);
            cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@CreatedBy", fe.UpdatedBy);
            cmd.Parameters.AddWithValue("@UpdatedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@UpdatedBy", fe.UpdatedBy);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public static int InsertFestivalDetail(FestivalDetail fe)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("insert into FestivalDetail (festivalID,poinID,poinPenilaian,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy) values (@festivalID,@poinID,@poinPenilaian,@CreatedDate,@CreatedBy,@UpdatedDate,@UpdatedBy)", con);
            if (con.State.Equals(ConnectionState.Closed))
                con.Open();
            cmd.Parameters.AddWithValue("@festivalID", fe.festivalID);
            cmd.Parameters.AddWithValue("@poinID", fe.poinID);
            cmd.Parameters.AddWithValue("@poinPenilaian", fe.poinPenilaian);
            cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@CreatedBy", fe.UpdatedBy);
            cmd.Parameters.AddWithValue("@UpdatedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@UpdatedBy", fe.UpdatedBy);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public static int UpdateFestivalDetail(FestivalDetail fe)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("update FestivalDetail set PoinPenilaian=@poinPenilaian,UpdatedDate=@UpdatedDate,UpdatedBy=@UpdatedBy  where FestivalID=@festivalID and PoinID=@poinID ", con);
            if (con.State.Equals(ConnectionState.Closed))
                con.Open();
            cmd.Parameters.AddWithValue("@festivalID", fe.festivalID);
            cmd.Parameters.AddWithValue("@poinID", fe.poinID);
            cmd.Parameters.AddWithValue("@poinPenilaian", fe.poinPenilaian);
            cmd.Parameters.AddWithValue("@UpdatedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@UpdatedBy", fe.UpdatedBy);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public static int GetMaksID(string festid)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Select max(PoinID) from FestivalDetail where FestivalID=@festivalID ", con);
            if (con.State.Equals(ConnectionState.Closed))
                con.Open();
            cmd.Parameters.AddWithValue("@festivalID", festid);
            string id = cmd.ExecuteScalar().ToString();
            con.Close();
            if(!String.IsNullOrEmpty(id))
                return Int32.Parse(id);
            return 0;
        }
    }
}