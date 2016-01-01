using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FASSProject
{
    public class EventFass
    {
        private Guid _eventID;
        private string _namaEvent;
        private bool _closed;
        private DateTime _eventDate;
        public EventFass(Guid evID, DateTime evDate,bool tutup,string namaEv )
        {
            eventID = evID;
            namaEvent = namaEv;
            eventDate = evDate;
            closed = tutup;
        }
        public EventFass(Guid evID)
        {
            eventID = evID;

        }
        public Guid eventID
        {
            get { return _eventID; }
            set { _eventID = value; }
        }
        public string namaEvent
        {
            get { return _namaEvent; }
            set { _namaEvent = value; }
        }
        public bool closed
        {
            get { return _closed; }
            set { _closed = value; }
        }
        public DateTime eventDate
        {
            get { return _eventDate; }
            set { _eventDate = value; }
        }

    }
}