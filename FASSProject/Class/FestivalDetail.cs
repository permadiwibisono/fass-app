using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FASSProject
{
    public class FestivalDetail
    {
        private string _festivalID;
        private int _poinID;
        private string _poinPenilaian;
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public FestivalDetail(string ID, int poinid, string poinpenilaian)
        {
            festivalID = ID;
            poinID =poinid;
            poinPenilaian = poinpenilaian;
        }
        public FestivalDetail(string id, int poinid)
        {
            festivalID = id;
            poinID = poinid;
        }
        public string festivalID
        {
            get { return _festivalID; }
            set { _festivalID = value; }
        }
        public int poinID
        {
            get { return _poinID; }
            set { _poinID = value; }
        }
        public string poinPenilaian
        {
            get { return _poinPenilaian; }
            set { _poinPenilaian = value; }
        }
    }
}