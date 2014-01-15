using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.sssTableAdapters;
using System.ComponentModel;

namespace BLL
{
    [DataObject]
    class FinalClassNamesBL
    {
        private tblFinalClassNamesTableAdapter _tblFinalClassNames = null;
        protected tblFinalClassNamesTableAdapter adapter
        {
            get
            {
                if (_tblFinalClassNames == null)
                    _tblFinalClassNames = new tblFinalClassNamesTableAdapter();

                return _tblFinalClassNames;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public sss.tblFinalClassNamesDataTable GetFinalClassNames()
        {
            return adapter.GetFinalClassNames();
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblFinalClassNamesDataTable GetFinalClassNamesByOrderBy(short orderBy)
        {
            return adapter.GetFinalClassNamesByOrderBy(orderBy);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public bool InsertFinalClassNames(Guid show_Entry_Class_ID, string class_Name_Description, short class_No,
            string show_Final_Class_Description, short entries, short orderBy)
        {
            try
            {
                adapter.InsertFinalClassNames(show_Entry_Class_ID, class_Name_Description, class_No, show_Final_Class_Description, entries, orderBy);

                return true;
            }
            catch
            {
                ApplicationException ae = new ApplicationException("Failed to insert Final Class Names");

                return false;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public bool UpdateFinalClassNames(Guid show_Entry_Class_ID, string class_Name_Description, short class_No,
            string show_Final_Class_Description, short entries, short orderBy)
        {
            try
            {
                adapter.UpdateFinalClassNames(show_Entry_Class_ID, class_Name_Description, class_No, show_Final_Class_Description, entries, orderBy);

                return true;
            }
            catch
            {
                ApplicationException ae = new ApplicationException("Failed to update Final Class Names");

                return false;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool ClearFinalClassNames()
        {
            try
            {
                adapter.ClearFinalClassNames();

                return true;
            }
            catch
            {
                ApplicationException ae = new ApplicationException("Failed to clear Final Class Names");

                return false;
            }
        }
    }
}
