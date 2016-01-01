using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FASSProject
{
    public class DesaControl
    {
        public static IEnumerable<DesaClass> getDesaList()
        {
            return DesaModel.getDesaList();
        }
        public static int DeleteDesa(DesaClass ds)
        {
            return DesaModel.DeleteDesa(ds);
        }
        public static int InsertDesa(DesaClass ds)
        {
            return DesaModel.InsertDesa(ds);
        }
        public static int UpdateDesa(DesaClass ds)
        {
            return DesaModel.UpdateDesa(ds);
        }
    }
}