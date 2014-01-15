using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.sssTableAdapters;
using System.ComponentModel;

namespace BLL
{
    [DataObject]
    class RunningOrdersBL
    {
        private tblOwnersDogsClassesDrawnListTableAdapter _tblOwnersDogsClassesDrawn = null;
        protected tblOwnersDogsClassesDrawnListTableAdapter adapter
        {
            get
            {
                if (_tblOwnersDogsClassesDrawn == null)
                    _tblOwnersDogsClassesDrawn = new tblOwnersDogsClassesDrawnListTableAdapter();

                return _tblOwnersDogsClassesDrawn;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public sss.tblOwnersDogsClassesDrawnListDataTable GetOwnersDogsClassesDrawn(bool display)
        {
            if (display)
                return adapter.GetOwnersDogsClassesDrawnList();
            else
                return adapter.GetOwnersDogsClassesDrawnListOrderByEntry_Date();
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public bool PopulateOwnersDogsClassesList(Guid show_ID, Guid? show_Final_Class_ID)
        {
            try
            {
                adapter.PopulateOwnersDogsClassesList(show_ID, show_Final_Class_ID);

                return true;
            }
            catch
            {
                ApplicationException ae = new ApplicationException("Failed to update Oweners, Dogs, Classes List");

                return false;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert, false)]
        public bool PopulateOwnersDogsClassesListOrderByEntry_Date(Guid show_ID, Guid? show_Final_Class_ID)
        {
            try
            {
                adapter.PopulateOwnersDogsClassesListOrderByEntry_Date(show_ID, show_Final_Class_ID);

                return true;
            }
            catch
            {
                ApplicationException ae = new ApplicationException("Failed to update Oweners, Dogs, Classes List");

                return false;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool DeleteOwnersDogsClassesList()
        {
            try
            {
                adapter.DeleteOwnersDogsClassesList();

                return true;
            }
            catch
            {
                ApplicationException ae = new ApplicationException("Failed to Delete Owners, Dogs, Classes List!");

                return false;
            }
        }
    }
}
