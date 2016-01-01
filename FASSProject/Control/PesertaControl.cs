using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FASSProject
{
    public class PesertaControl
    {
        public static int InsertPeserta(Peserta ps)
        { 
            return PesertaModel.InsertPeserta(ps);
        }
    }
}