using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.sssTableAdapters;
using System.ComponentModel;

namespace BLL
{
    [DataObject]
    class ShowTypesBL
    {
        private lkpShow_TypesTableAdapter _lkpShow_TypesAdapter = null;
        protected lkpShow_TypesTableAdapter adapter
        {
            get
            {
                if (_lkpShow_TypesAdapter == null)
                    _lkpShow_TypesAdapter = new lkpShow_TypesTableAdapter();

                return _lkpShow_TypesAdapter;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public sss.lkpShow_TypesDataTable GetShow_Types()
        {
            return adapter.GetShow_Types();
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.lkpShow_TypesDataTable GetShow_TypesByShow_Type_ID(int show_Type_ID)
        {
            return adapter.GetShow_TypesByShow_Type_ID(show_Type_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.lkpShow_TypesDataTable GetShow_TypesLikeShow_Type_Description(string show_Type_Description)
        {
            return adapter.GetShow_TypesLikeShow_Type_Description(show_Type_Description);
        }
    }
}
