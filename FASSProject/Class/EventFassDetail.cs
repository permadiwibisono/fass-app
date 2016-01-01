using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FASSProject
{
    public class EventFassDetail : EventFassDetailParent 
    {
        private double _skor;
        private int _poinID;
        private string _judulPoin;
        public EventFassDetail(Guid evID, Guid pesID, string festID, int PoinID, double Skor)
            : base(evID, pesID, festID)
        {
            poinID = PoinID;
            skor = Skor;

        }
        public EventFassDetail(Guid evID, Guid pesID, string festID, int PoinID, string JudulPoin, double Skor)
            : base(evID, pesID, festID)
        {
            poinID = PoinID;
            skor = Skor;
            PoinPenilaian = JudulPoin;

        }

        public double skor
        {
            get { return _skor; }
            set { _skor = value; }
        }
        public int poinID
        {
            get { return _poinID; }
            set { _poinID = value; }
        }
        public string PoinPenilaian
        {
            get { return _judulPoin; }
            set { _judulPoin = value; }
        }
    }
}