using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.sssTableAdapters;
using System.ComponentModel;

namespace BLL
{
    [DataObject]
    class ShowFinalClassesBL
    {
        private tblShow_Final_ClassesTableAdapter _tblShow_Final_ClassesAdapter = null;
        protected tblShow_Final_ClassesTableAdapter adapter
        {
            get
            {
                if (_tblShow_Final_ClassesAdapter == null)
                    _tblShow_Final_ClassesAdapter = new tblShow_Final_ClassesTableAdapter();

                return _tblShow_Final_ClassesAdapter;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public sss.tblShow_Final_ClassesDataTable GetShow_Final_Classes()
        {
            return adapter.GetShow_Final_Classes();
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblShow_Final_ClassesDataTable GetShow_Final_ClassByShow_Final_Class_ID(Guid show_Final_Class_ID)
        {
            return adapter.GetShow_Final_ClassByShow_Final_Class_ID(show_Final_Class_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblShow_Final_ClassesDataTable GetShow_Final_ClassByShow_Entry_Class_ID(Guid show_Entry_Class_ID)
        {
            return adapter.GetShow_Final_ClassesByShow_Entry_Class_ID(show_Entry_Class_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblShow_Final_ClassesDataTable GetShow_Final_ClassesByShow_ID(Guid show_ID)
        {
            return adapter.GetShow_Final_ClassesByShow_ID(show_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public Guid? Insert_Show_Final_Classes(Guid? show_ID, Guid? show_Entry_Class_ID, string show_Final_Class_Description,
            short show_Final_Class_No, Guid? judge_ID, DateTime? stay_Time, DateTime? lunch_Time, Guid user_ID)
        {
            Guid? newID = (Guid?)adapter.Insert_Show_Final_Classes(show_ID, show_Entry_Class_ID, show_Final_Class_Description,
                show_Final_Class_No, judge_ID, stay_Time, lunch_Time, user_ID);

            return newID;
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public bool Update_Show_Final_Classes(Guid original_ID, Guid? show_ID, Guid? show_Entry_Class_ID, string show_Final_Class_Description,
            short show_Final_Class_No, Guid? judge_ID, DateTime? stay_Time, DateTime? lunch_Time, bool? deleted, Guid user_ID)
        {
            try
            {
                adapter.Update_Show_Final_Classes(original_ID, show_ID, show_Entry_Class_ID, show_Final_Class_Description,
                    show_Final_Class_No, judge_ID, stay_Time, lunch_Time, deleted, user_ID);

                return true;
            }
            catch
            {
                ApplicationException ae = new ApplicationException("Failed to update Show Final Class");

                return false;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public int DeleteShowFinalClassesByShowEntryClass(Guid show_Entry_Class_ID)
        {
            int? rowsAffected = 0;
            adapter.DeleteShowFinalClassesByShowEntryClass(show_Entry_Class_ID, ref rowsAffected);

            return (int)rowsAffected;
        }
    }
}
