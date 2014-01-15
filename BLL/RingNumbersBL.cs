using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.sssTableAdapters;
using System.ComponentModel;

namespace BLL
{
    [DataObject]
    class RingNumbersBL
    {
        private tblRing_NumbersTableAdapter _tblRing_NumbersAdapter = null;
        protected tblRing_NumbersTableAdapter adapter
        {
            get
            {
                if (_tblRing_NumbersAdapter == null)
                    _tblRing_NumbersAdapter = new tblRing_NumbersTableAdapter();

                return _tblRing_NumbersAdapter;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public sss.tblRing_NumbersDataTable GetRing_Numbers()
        {
            return adapter.GetRing_Numbers();
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public bool PopulateRing_Numbers(Guid show_ID)
        {
            try
            {
                adapter.PopulateRing_Numbers(show_ID);

                return true;
            }
            catch
            {
                ApplicationException ae = new ApplicationException("Failed to update Ring Numbers");

                return false;
            }
        }
    }
}
