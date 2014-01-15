using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.sssTableAdapters;
using System.ComponentModel;

namespace BLL
{
    [DataObject]
    class ShowYearsBL
    {
        private lkpShow_YearsTableAdapter _lkpShow_YearsAdapter = null;
        protected lkpShow_YearsTableAdapter adapter
        {
            get
            {
                if (_lkpShow_YearsAdapter == null)
                    _lkpShow_YearsAdapter = new lkpShow_YearsTableAdapter();

                return _lkpShow_YearsAdapter;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public sss.lkpShow_YearsDataTable GetShow_Years()
        {
            return adapter.GetShow_Years();
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.lkpShow_YearsDataTable GetShow_YearByShow_Year_ID(int show_Year_ID)
        {
            return adapter.GetShow_YearsByShow_Year_ID(show_Year_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.lkpShow_YearsDataTable GetShow_YearByShow_Year(short show_Year)
        {
            return adapter.GetShow_YearByShow_Year(show_Year);
        }
    }
}
