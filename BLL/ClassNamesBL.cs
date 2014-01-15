using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.sssTableAdapters;
using System.ComponentModel;

namespace BLL
{
    [DataObject]
    class ClassNamesBL
    {
        private lkpClass_NamesTableAdapter _lkpClass_NamesAdapter = null;
        protected lkpClass_NamesTableAdapter adapter
        {
            get
            {
                if (_lkpClass_NamesAdapter == null)
                    _lkpClass_NamesAdapter = new lkpClass_NamesTableAdapter();

                return _lkpClass_NamesAdapter;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public sss.lkpClass_NamesDataTable GetClass_Names()
        {
            return adapter.GetClass_Names();
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.lkpClass_NamesDataTable GetClass_NameByClass_Name_ID(int class_Name_ID)
        {
            return adapter.GetClass_NameByClass_Name_ID(class_Name_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.lkpClass_NamesDataTable GetClass_NameLikeClass_Name_Description(string class_Name_Description)
        {
            return adapter.GetClass_NamesLikeClass_Name_Description(class_Name_Description);
        }
    }
}
