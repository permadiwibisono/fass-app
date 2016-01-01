using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace FASSProject
{
    public class PesertaModel
    {
        static string cs = ConfigurationManager.ConnectionStrings["FassDBConnection"].ConnectionString;
        public static int InsertPeserta(Peserta ps)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("insert into Peserta (pesertaID ,namaPeserta ,usia,gender,desaID,kelompok,festivalID,deleted,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy) values (@pesertaID ,@namaPeserta ,@usia,@gender,@desaID,@kelompok,@festivalID,0,@CreatedDate,@CreatedBy,@UpdatedDate,@UpdatedBy)", con);
            if (con.State.Equals(ConnectionState.Closed))
                con.Open();
            cmd.Parameters.AddWithValue("@pesertaID", ps.pesertaID);
            cmd.Parameters.AddWithValue("@namaPeserta", ps.namaPeserta);
            cmd.Parameters.AddWithValue("@usia", ps.usia);
            cmd.Parameters.AddWithValue("@gender", ps.gender);
            cmd.Parameters.AddWithValue("@desaID", ps.desaID);
            cmd.Parameters.AddWithValue("@kelompok", ps.kelompok);
            cmd.Parameters.AddWithValue("@festivalID", ps.festivalID);
            cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@CreatedBy", ps.CreatedBy);
            cmd.Parameters.AddWithValue("@UpdatedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@UpdatedBy", ps.UpdatedBy);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}