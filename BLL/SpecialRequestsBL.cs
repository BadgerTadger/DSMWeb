using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.sssTableAdapters;
using System.ComponentModel;

namespace BLL
{
    [DataObject]
    class SpecialRequestsBL
    {
        private tblSpecialRequestListTableAdapter _tblSpecialRequests = null;
        protected tblSpecialRequestListTableAdapter adapter
        {
            get
            {
                if (_tblSpecialRequests == null)
                    _tblSpecialRequests = new tblSpecialRequestListTableAdapter();

                return _tblSpecialRequests;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public sss.tblSpecialRequestListDataTable GetSpecialRequests()
        {
            return adapter.GetSpecialRequestList();
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public bool PopulateSpecialRequestList(Guid show_ID, Guid? show_Entry_Class_ID, bool specialRequestsOnly)
        {
            try
            {
                adapter.PopulateSpecialRequestList(show_ID, show_Entry_Class_ID, specialRequestsOnly);

                return true;
            }
            catch
            {
                ApplicationException ae = new ApplicationException("Failed to update Special Requests List");

                return false;
            }
        }
    }
}
