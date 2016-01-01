using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FASSProject
{
    public class Peserta
    {
        private Guid _pesertaID;
        private string _namaPeserta;
        private string _usia;
        private string _gender;
        private string _desaID;
        private string _kelompok;
        private string _festivalID;
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Peserta(Guid id, string nama, string Usia, string Gender, string desaid, string Kelompok, string festivalid)
        {
            pesertaID = id;
            namaPeserta = nama;
            usia = Usia;
            gender = Gender;
            desaID = desaid;
            kelompok = Kelompok;
            festivalID = festivalid;
        }
        public Peserta(Guid id)
        {
            pesertaID = id;
        }
        public string festivalID
        {
            get { return _festivalID; }
            set { _festivalID = value; }
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
        public string usia
        {
            get { return _usia; }
            set { _usia = value; }
        }
        public string gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        public string desaID
        {
            get { return _desaID; }
            set { _desaID = value; }
        }
        public string kelompok
        {
            get { return _kelompok; }
            set { _kelompok = value; }
        }

    }
}