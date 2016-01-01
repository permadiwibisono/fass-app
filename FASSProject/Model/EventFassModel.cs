using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace FASSProject
{
    public class EventFassModel
    {
        static string cs = ConfigurationManager.ConnectionStrings["FassDBConnection"].ConnectionString;
        public static IEnumerable<EventFass> getEventList()
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Select * from Events where closed=0", con);
            if (con.State.Equals(ConnectionState.Closed))
                con.Open();
            List<EventFass> newEvent = new List<EventFass>();
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                EventFass ev = new EventFass(rd.GetGuid(0), rd.GetDateTime(1), rd.GetBoolean(2),rd.GetString(3));
                newEvent.Add(ev);
            }
            return newEvent;
        }
        public static int InsertEvent(EventFass ev)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("insert into Events values(@eventID,@eventDate ,@closed ,@namaEvent)", con);
            if (con.State.Equals(ConnectionState.Closed))
                con.Open();
            cmd.Parameters.AddWithValue("@eventID", ev.eventID);
            cmd.Parameters.AddWithValue("@eventDate", ev.eventDate);
            cmd.Parameters.AddWithValue("@closed", ev.closed);
            cmd.Parameters.AddWithValue("@namaEvent", ev.namaEvent);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public static int InsertEvent(List<EventFassDetail> ev)
        {
            SqlConnection con = new SqlConnection(cs);
            string queryInsert="insert into EventDetail (EventID, PesertaID, FestivalID, PoinID) values";
            for (int j=0; j<ev.Count;j++)
            {
                if(j!=ev.Count-1)
                    queryInsert += "('" + ev[j].eventID + "','" + ev[j].pesertaID + "','" + ev[j].festivalID + "','" + ev[j].poinID + "'), ";
                else
                    queryInsert += "('" + ev[j].eventID + "','" + ev[j].pesertaID + "','" + ev[j].festivalID + "','" + ev[j].poinID + "') ";
            }
            SqlCommand cmd = new SqlCommand(queryInsert, con);
            if (con.State.Equals(ConnectionState.Closed))
                con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public static IEnumerable<EventFassDetailParent> getPesertaListByFestival( FestivalClass fe, Guid eventid)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Select distinct EventID,a.PesertaID,NamaPeserta,  Usia,b.DesaID,NamaDesa,a.FestivalID, Sum(Skor) TotalScore  from EventDetail a "+
            "join Peserta b on a.PesertaID=b.PesertaID join Desa c on c.desaid=b.desaid  where EventID='"+eventid+"' and a.FestivalID='"+fe.festivalID+"' "+
            "group by EventID,a.PesertaID,NamaPeserta, Usia,b.DesaID,NamaDesa,a.FestivalID order by TotalScore desc, NamaPeserta asc", con);
            if (con.State.Equals(ConnectionState.Closed))
                con.Open();
            List<EventFassDetailParent> newEvent = new List<EventFassDetailParent>();
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                EventFassDetailParent ev = new EventFassDetailParent(rd.GetGuid(0), rd.GetGuid(1), rd.GetString(2), rd.GetString(3), rd.GetString(4), rd.GetString(5), rd.GetString(6), rd.GetDouble(7));
                newEvent.Add(ev);
            }
            return newEvent;
        }
        public static IEnumerable<EventFassDetailParent> getPesertaListDesaScore(Guid eventid)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Select distinct EventID,b.DesaID,NamaDesa,Sum(Skor) TotalScore  from EventDetail a " +
            "join Peserta b on a.PesertaID=b.PesertaID join Desa c on c.desaid=b.desaid  where EventID='" + eventid + "' " +
            "group by EventID,b.DesaID,NamaDesa order by TotalScore desc", con);
            if (con.State.Equals(ConnectionState.Closed))
                con.Open();
            List<EventFassDetailParent> newEvent = new List<EventFassDetailParent>();
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                EventFassDetailParent ev = new EventFassDetailParent(rd.GetGuid(0),rd.GetString(1), rd.GetString(2), rd.GetDouble(3));
                newEvent.Add(ev);
            }
            rd.Close();
            cmd = new SqlCommand("Select DesaID, NamaDesa from Desa  where DesaID not in (Select distinct b.DesaID from EventDetail a " +
            "join Peserta b on a.PesertaID=b.PesertaID   where EventID='" + eventid + "') and deleted=0", con);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                EventFassDetailParent ev = new EventFassDetailParent(eventid, rd.GetString(0), rd.GetString(1), 0);
                newEvent.Add(ev); 
                
            }
            return newEvent;
        }
        public static IEnumerable<EventFassDetail> getPoinPenilaianByPeserta(EventFassDetailParent ev)
        {

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Select EventID,a.PesertaID,a.FestivalID,a.PoinID, PoinPenilaian, Skor  from EventDetail a " +
            "join FestivalDetail b on a.FestivalID=b.FestivalID and a.PoinID=b.PoinID where EventID='" + ev.eventID + "' and a.FestivalID='" + ev.festivalID + "' and a.PesertaID='"+ev.pesertaID+"' ", con);
            if (con.State.Equals(ConnectionState.Closed))
                con.Open();
            List<EventFassDetail> newEvent = new List<EventFassDetail>();
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                EventFassDetail newev = new EventFassDetail(rd.GetGuid(0), rd.GetGuid(1), rd.GetString(2), rd.GetInt32(3), rd.GetString(4), rd.GetDouble(5));
                newEvent.Add(newev);
            }
            return newEvent;
        }
        public static int UpdateScore(EventFassDetail ev)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Update EventDetail set Skor="+ev.skor+" where EventID='"+ev.eventID+"' "+
                "and FestivalID='"+ev.festivalID+"' and PesertaID='"+ev.pesertaID+"' and PoinID="+ev.poinID, con);
            if (con.State.Equals(ConnectionState.Closed))
                con.Open();
            return cmd.ExecuteNonQuery();
        }
    }
}