using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.sssTableAdapters;
using System.Data;

namespace BLL
{
    public class EntryClassesCount
    {
        private sss.tblEntryClassCountDataTable tblEntryClassCount = null;

        private Guid _show_Entry_Class_ID;
        public Guid Show_Entry_Class_ID
        {
            get { return _show_Entry_Class_ID; }
            set { _show_Entry_Class_ID = value; }
        }
        private string _class_Name_Description = null;
        public string Class_Name_Description
        {
            get { return _class_Name_Description; }
            set { _class_Name_Description = value; }
        }
        private short _class_No;
        public short Class_No
        {
            get { return _class_No; }
            set { _class_No = value; }
        }
        private short _entries;
        public short Entries
        {
            get { return _entries; }
            set { _entries = value; }
        }

        public EntryClassesCount()
        {

        }

        public List<EntryClassesCount> GetEntryClassCount()
        {
            List<EntryClassesCount> entryClassList = new List<EntryClassesCount>();
            EntryClassCountBL entryClasses = new EntryClassCountBL();
            tblEntryClassCount = entryClasses.GetEntryClassCount();

            if (tblEntryClassCount != null && tblEntryClassCount.Count > 0)
            {
                foreach (sss.tblEntryClassCountRow row in tblEntryClassCount)
                {
                    EntryClassesCount entryClass = new EntryClassesCount();
                    entryClass.Show_Entry_Class_ID = row.Show_Entry_Class_ID;
                    entryClass.Class_Name_Description = row.Class_Name_Description;
                    entryClass.Class_No = row.Class_No;
                    entryClass.Entries = row.Entries;
                    entryClassList.Add(entryClass);
                }
            }
            return entryClassList;
        }

        public EntryClassesCount(Guid show_Entry_Class_ID)
        {
            EntryClassCountBL entryClasses = new EntryClassCountBL();
            tblEntryClassCount = entryClasses.GetEntryClassCountByShow_Entry_Class_ID(show_Entry_Class_ID);

            Show_Entry_Class_ID = tblEntryClassCount[0].Show_Entry_Class_ID;
            Class_Name_Description = tblEntryClassCount[0].Class_Name_Description;
            Class_No = tblEntryClassCount[0].Class_No;
            Entries = tblEntryClassCount[0].Entries;
        }

        public bool PopulateEntryClassCount(Guid show_ID)
        {
            bool success = false;

            EntryClassCountBL entryClasses = new EntryClassCountBL();
            success = entryClasses.PopulateEntryClassCount(show_ID);

            return success;
        }
    }
}
