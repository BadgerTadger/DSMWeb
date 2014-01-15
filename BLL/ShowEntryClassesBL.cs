using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.sssTableAdapters;
using System.ComponentModel;

namespace BLL
{
    [DataObject]
    class ShowEntryClassesBL
    {
        private tblShow_Entry_ClassesTableAdapter _tblShow_Entry_ClassesAdapter = null;
        protected tblShow_Entry_ClassesTableAdapter adapter
        {
            get
            {
                if (_tblShow_Entry_ClassesAdapter == null)
                    _tblShow_Entry_ClassesAdapter = new tblShow_Entry_ClassesTableAdapter();

                return _tblShow_Entry_ClassesAdapter;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public sss.tblShow_Entry_ClassesDataTable GetShow_Entry_Classes()
        {
            return adapter.GetShow_Entry_Classes();
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblShow_Entry_ClassesDataTable GetShow_Entry_ClassByShow_Entry_Class_ID(Guid show_Entry_Class_ID)
        {
            return adapter.GetShow_Entry_ClassesByShow_Entry_Class_ID(show_Entry_Class_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblShow_Entry_ClassesDataTable GetShow_Entry_ClassesByShow_ID(Guid show_ID)
        {
            return adapter.GetShow_Entry_ClassesByShow_ID(show_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public Guid? Insert_Show_Entry_Classes(Guid? show_ID, int? class_Name_ID, short? class_No, short? gender, Guid user_ID)
        {
            Guid? newID = (Guid?)adapter.Insert_Show_Entry_Classes(show_ID, class_Name_ID, class_No, gender, user_ID);

            return newID;
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public bool Update_Show_Entry_Classes(Guid original_ID, Guid? show_ID, int? class_Name_ID, short? class_No, short? gender, bool? deleted, Guid user_ID)
        {
            try
            {
                adapter.Update_Show_Entry_Classes(original_ID, show_ID, class_Name_ID, class_No, gender, deleted, user_ID);

                return true;
            }
            catch
            {
                ApplicationException ae = new ApplicationException("Failed to update Show Entry Class");

                return false;
            }
        }
    }
}
