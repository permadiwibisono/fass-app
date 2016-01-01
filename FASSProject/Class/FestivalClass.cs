using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FASSProject
{
    public class FestivalClass
    {
        private string _festivalID;
        private string _namaFestival;
        private string _sistemPermainan;
        private string _desc;
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public FestivalClass(string ID, string Nama, string Sistem, string Desc)
        {
            festivalID = ID;
            namaFestival = Nama;
            sistemPermainan = Sistem;
            desc = Desc;
        }
        public FestivalClass(string id)
        {
            festivalID = id;
        }
        public string festivalID
        {
            get { return _festivalID; }
            set { _festivalID = value; }
        }
        public string namaFestival
        {
            get { return _namaFestival; }
            set { _namaFestival = value; }
        }
        public string sistemPermainan
        {
            get { return _sistemPermainan; }
            set { _sistemPermainan = value; }
        }
        public string desc
        {
            get { return _desc; }
            set { _desc = value; }
        }
    }
}