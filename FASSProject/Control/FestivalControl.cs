using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FASSProject
{
    public class FestivalControl
    {
        public static IEnumerable<FestivalClass> getFestivalList()
        {
            return FestivalModel.getFestivalList();
        }
        public static IEnumerable<FestivalClass> getFestivalList( string sistem)
        {
            return FestivalModel.getFestivalList(sistem);
        }
        public static int DeleteFestival(FestivalClass fe)
        {
            return FestivalModel.DeleteFestival(fe);
        }
        public static int InsertFestival(FestivalClass fe)
        {
            return FestivalModel.InsertFestival(fe);
        }
        public static int UpdateFestival(FestivalClass fe)
        {
            return FestivalModel.UpdateFestival(fe);
        }
        public static IEnumerable<FestivalDetail> getFestivalDetailList(string id)
        {
            return FestivalModel.getFestivalDetailList(id);
        }
        public static int DeleteFestivalDetail(FestivalDetail fe)
        {
            return FestivalModel.DeleteFestivalDetail(fe);
        }
        public static int InsertFestivalDetail(FestivalDetail fe)
        {
            return FestivalModel.InsertFestivalDetail(fe);
        }
        public static int UpdateFestivalDetail(FestivalDetail fe)
        {
            return FestivalModel.UpdateFestivalDetail(fe);
        }
    }
}