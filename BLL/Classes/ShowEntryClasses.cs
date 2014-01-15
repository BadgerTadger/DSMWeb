using System;
using System.Collections.Generic;
using System.Web;
using DAL;
using DAL.sssTableAdapters;

namespace BLL
{
    public class ShowEntryClasses
    {
        private sss.tblShow_Entry_ClassesDataTable tblShowEntryClasses = null;

        private Guid _show_Entry_Class_ID;
        public Guid Show_Entry_Class_ID
        {
            get { return _show_Entry_Class_ID; }
            set { _show_Entry_Class_ID = value; }
        }
        private Guid? _show_ID = null;
        public Guid? Show_ID
        {
            get { return _show_ID; }
            set { _show_ID = value; }
        }

        private int? _class_Name_ID = null;
        public int? Class_Name_ID
        {
            get { return _class_Name_ID; }
            set { _class_Name_ID = value; }
        }
        private string _class_Name_Description;
        public string Class_Name_Description
        {
            get { return _class_Name_Description; }
            set { _class_Name_Description = value; }
        }
        private short? _class_No = null;
        public short? Class_No
        {
            get { return _class_No; }
            set { _class_No = value; }
        }
        private short? _class_Gender = null;
        public short? Class_Gender
        {
            get { return _class_Gender; }
            set { _class_Gender = value; }
        }
        private bool _deleteShowEntryClass = false;
        public bool DeleteShowEntryClass
        {
            get { return _deleteShowEntryClass; }
            set { _deleteShowEntryClass = value; }
        }
        private bool _isNFC = false;
        public bool IsNFC
        {
            get { return _isNFC; }
            set { _isNFC = value; }
        }

        public ShowEntryClasses()
        {

        }

        public ShowEntryClasses(Guid show_Entry_Class_ID)
        {
            ShowEntryClassesBL showEntryClasses = new ShowEntryClassesBL();
            tblShowEntryClasses = showEntryClasses.GetShow_Entry_ClassByShow_Entry_Class_ID(show_Entry_Class_ID);

            Show_Entry_Class_ID = show_Entry_Class_ID;
            Show_ID = tblShowEntryClasses[0].Show_ID;
            Class_Name_ID = tblShowEntryClasses[0].Class_Name_ID;
            if (tblShowEntryClasses[0].Class_Name_Description == "NFC")
                IsNFC = true;
            if (!tblShowEntryClasses[0].IsClass_NoNull())
                Class_No = tblShowEntryClasses[0].Class_No;
            if (!tblShowEntryClasses[0].IsGenderNull())
                Class_Gender = tblShowEntryClasses[0].Gender;

            Class_Name_Description = string.Format("{0} : {1}", Class_No, tblShowEntryClasses[0].Class_Name_Description);
        }

        public List<ShowEntryClasses> GetShow_Entry_ClassesByShow_ID(Guid show_ID)
        {
            List<ShowEntryClasses> showEntryClassList = new List<ShowEntryClasses>();
            ShowEntryClassesBL showEntryClasses = new ShowEntryClassesBL();
            tblShowEntryClasses = showEntryClasses.GetShow_Entry_ClassesByShow_ID(show_ID);

            if (tblShowEntryClasses != null && tblShowEntryClasses.Count > 0)
            {
                foreach (sss.tblShow_Entry_ClassesRow row in tblShowEntryClasses)
                {
                    ShowEntryClasses showEntryClass = new ShowEntryClasses(row.Show_Entry_Class_ID);
                    showEntryClassList.Add(showEntryClass);
                }
            }

            return showEntryClassList;
        }

        public List<ShowEntryClasses> GetShow_Entry_Classes()
        {
            List<ShowEntryClasses> showEntryClassList = new List<ShowEntryClasses>();
            ShowEntryClassesBL showEntryClasses = new ShowEntryClassesBL();
            tblShowEntryClasses = showEntryClasses.GetShow_Entry_Classes();

            if (tblShowEntryClasses != null && tblShowEntryClasses.Count > 0)
            {
                foreach (sss.tblShow_Entry_ClassesRow row in tblShowEntryClasses)
                {
                    ShowEntryClasses showEntryClass = new ShowEntryClasses(row.Show_Entry_Class_ID);
                    showEntryClassList.Add(showEntryClass);
                }
            }

            return showEntryClassList;
        }

        public Guid? Insert_Show_Entry_Class(Guid user_ID)
        {
            ShowEntryClassesBL showEntryClasses = new ShowEntryClassesBL();
            Guid? newID = (Guid?)showEntryClasses.Insert_Show_Entry_Classes(Show_ID, Class_Name_ID, Class_No, Class_Gender, user_ID);

            return newID;
        }

        public bool Update_Show_Entry_Class(Guid show_Entry_Class_ID, Guid user_ID)
        {
            bool success = false;

            ShowEntryClassesBL showEntryClasses = new ShowEntryClassesBL();
            success = showEntryClasses.Update_Show_Entry_Classes(show_Entry_Class_ID, Show_ID, Class_Name_ID, Class_No,
                Class_Gender, DeleteShowEntryClass, user_ID);

            return success;
        }
    }
}