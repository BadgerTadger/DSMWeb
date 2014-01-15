using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.sssTableAdapters;
using System.Data;

namespace BLL
{
    public class FinalClassNames
    {
        private sss.tblFinalClassNamesDataTable tblFinalClassNames = null;

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
        private string _show_Final_Class_Description = null;
        public string Show_Final_Class_Description
        {
            get { return _show_Final_Class_Description; }
            set { _show_Final_Class_Description = value; }
        }
        private short _entries;
        public short Entries
        {
            get { return _entries; }
            set { _entries = value; }
        }
        private short _orderBy;
        public short OrderBy
        {
            get { return _orderBy; }
            set { _orderBy = value; }
        }

        public FinalClassNames()
        {

        }

        public FinalClassNames(short orderBy)
        {
            FinalClassNamesBL finalClassNames = new FinalClassNamesBL();
            tblFinalClassNames = finalClassNames.GetFinalClassNamesByOrderBy(orderBy);

            if (tblFinalClassNames != null && tblFinalClassNames.Count > 0)
            {
                Show_Entry_Class_ID = tblFinalClassNames[0].Show_Entry_Class_ID;
                Class_Name_Description = tblFinalClassNames[0].Class_Name_Description;
                Class_No = tblFinalClassNames[0].Class_No;
                Show_Final_Class_Description = tblFinalClassNames[0].Show_Final_Class_Description;
                Entries = tblFinalClassNames[0].Entries;
                OrderBy = tblFinalClassNames[0].OrderBy;
            }
        }

        public List<FinalClassNames> GetFinalClassNames()
        {
            List<FinalClassNames> finalClassNameList = new List<FinalClassNames>();
            FinalClassNamesBL finalClassNames = new FinalClassNamesBL();
            tblFinalClassNames = finalClassNames.GetFinalClassNames();

            if (tblFinalClassNames != null && tblFinalClassNames.Count > 0)
            {
                foreach (sss.tblFinalClassNamesRow row in tblFinalClassNames)
                {
                    FinalClassNames finalClassName = new FinalClassNames();
                    finalClassName.Show_Entry_Class_ID = row.Show_Entry_Class_ID;
                    finalClassName.Class_Name_Description = row.Class_Name_Description;
                    finalClassName.Class_No = row.Class_No;
                    finalClassName.Show_Final_Class_Description = row.Show_Final_Class_Description;
                    finalClassName.Entries = row.Entries;
                    finalClassName.OrderBy = row.OrderBy;
                    finalClassNameList.Add(finalClassName);
                }
            }
            return finalClassNameList;
        }

        public bool ClearFinalClassNames()
        {
            FinalClassNamesBL finalClassNames = new FinalClassNamesBL();
            bool success = false;

            success = finalClassNames.ClearFinalClassNames();

            return success;
        }

        public bool InsertFinalClassNames()
        {
            FinalClassNamesBL finalClassNames = new FinalClassNamesBL();
            bool success = false;

            success = finalClassNames.InsertFinalClassNames(Show_Entry_Class_ID, Class_Name_Description, Class_No,
                Show_Final_Class_Description, Entries, OrderBy);

            return success;
        }

        public bool UpdateFinalClassNames()
        {
            FinalClassNamesBL finalClassNames = new FinalClassNamesBL();
            bool success = false;

            success = finalClassNames.UpdateFinalClassNames(Show_Entry_Class_ID, Class_Name_Description, Class_No,
                Show_Final_Class_Description, Entries, OrderBy);

            return success;
        }
    }
}
