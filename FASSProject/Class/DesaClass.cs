using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FASSProject
{
    public class DesaClass
    {
        private string _desaID;
        private string _namaDesa;
        private string _mesjidDesa;
        private string _alamat;
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DesaClass(string id, string nama, string mesjidDesa, string Alamat)
        {
            desaid = id;
            namadesa = nama;
            this.mesjiddesa = mesjidDesa;
            alamat = Alamat;
        }
        public DesaClass(string id)
        {
            desaid = id;
        }
        public string desaid
        {
            get { return _desaID; }
            set { _desaID = value; }
        }
        public string namadesa
        {
            get { return _namaDesa; }
            set { _namaDesa = value; }
        }
        public string mesjiddesa
        {
            get { return _mesjidDesa; }
            set { _mesjidDesa = value; }
        }
        public string alamat
        {
            get { return _alamat; }
            set { _alamat = value; }
        }
    }
}