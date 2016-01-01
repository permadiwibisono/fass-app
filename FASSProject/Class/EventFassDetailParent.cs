using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FASSProject
{
    public class EventFassDetailParent
    {
         private Guid _eventID;
        private Guid _pesertaID;
        private string _namaPeserta;
        private string _usia;
        private string _desaID;
        private string _namaDesa;
        private string _festivalID;
        private double _totalskor;
        public EventFassDetailParent(Guid evID, Guid pesID, string nama, string Usia, string desaid, string NamaDesa, string festID, double score)
        {
            eventID = evID;
            pesertaID = pesID;
            namaPeserta = nama;
            umur = Usia;
            desaID = desaid;
            namaDesa = NamaDesa;
            festivalID = festID;
            totalscore = score;
        }
        public EventFassDetailParent(Guid evID,  string desaid, string NamaDesa, double score)
        {
            eventID = evID;
            desaID = desaid;
            namaDesa = NamaDesa;
            totalscore = score;
        }
        public EventFassDetailParent(Guid evID, Guid pesID, string festID)
        {
            eventID = evID;
            pesertaID = pesID;
            festivalID = festID;
        }
        public Guid eventID
        {
            get { return _eventID; }
            set { _eventID = value; }
        }
        public Guid pesertaID
        {
            get { return _pesertaID; }
            set { _pesertaID = value; }
        }
        public string namaPeserta
        {
            get { return _namaPeserta; }
            set { _namaPeserta = value; }
        }
        public string umur
        {
            get { return _usia; }
            set { _usia = value; }
        }
        public string desaID
        {
            get { return _desaID; }
            set { _desaID = value; }
        }
        public string namaDesa
        {
            get { return _namaDesa; }
            set { _namaDesa = value; }
        }
        public string festivalID
        {
            get { return _festivalID; }
            set { _festivalID = value; }
        }
        public double totalscore
        {
            get { return _totalskor; }
            set { _totalskor = value; }
        }
    }
}