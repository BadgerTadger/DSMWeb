using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.sssTableAdapters;
using System.ComponentModel;

namespace BLL
{
    [DataObject]
    class EntryClassCountBL
    {
        private tblEntryClassCountTableAdapter _tblEntryClassesCount = null;
        protected tblEntryClassCountTableAdapter adapter
        {
            get
            {
                if (_tblEntryClassesCount == null)
                    _tblEntryClassesCount = new tblEntryClassCountTableAdapter();

                return _tblEntryClassesCount;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public sss.tblEntryClassCountDataTable GetEntryClassCount()
        {
            return adapter.GetEntryClassCount();
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblEntryClassCountDataTable GetEntryClassCountByShow_Entry_Class_ID(Guid show_Entry_Class_ID)
        {
            return adapter.GetEntryClassCountByShow_Entry_Class_ID(show_Entry_Class_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public bool PopulateEntryClassCount(Guid show_ID)
        {
            try
            {
                adapter.PopulateEntryClassCount(show_ID);

                return true;
            }
            catch
            {
                ApplicationException ae = new ApplicationException("Failed to update Class Count");

                return false;
            }
        }
    }
}
