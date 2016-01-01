using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FASSProject
{
    public class EventFassControl
    {
        public static IEnumerable<EventFass> getEventList()
        {

            return EventFassModel.getEventList();
        }
        public static int InsertEvent(List<EventFassDetail> evdetail)
        {
            return EventFassModel.InsertEvent(evdetail); ;
        }
        public static int InsertEvent(EventFass evdetail)
        {
            return EventFassModel.InsertEvent(evdetail); ;
        }
        public static IEnumerable<EventFassDetailParent> getPesertaListByFestival(FestivalClass fe, Guid eventid)
        {
            return EventFassModel.getPesertaListByFestival(fe, eventid);
        }
        public static IEnumerable<EventFassDetail> getPoinPenilaianByPeserta(EventFassDetailParent ev)
        {
            return EventFassModel.getPoinPenilaianByPeserta(ev);
        }
        public static int UpdateScore(EventFassDetail ev)
        {
            return EventFassModel.UpdateScore(ev);
        }
    }
}