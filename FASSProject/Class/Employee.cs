using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FASSProject
{
    public class Employee
    {
        private string _employeeid;
        private string _katasandi;
        public Employee(string id, string pass)
        {
            employeeid = id;
            katasandi = pass;
        }
        public string employeeid
        {
            get { return _employeeid; }
            set { _employeeid = value; }
        }
        public string katasandi
        {
            get { return _katasandi; }
            set { _katasandi = value; }
        }
    }
}