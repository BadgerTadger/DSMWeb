using System;
using System.Collections.Generic;
using System.Web;
using DAL;
using DAL.sssTableAdapters;

namespace BLL
{
    public class ShowFinalClasses
    {
        private sss.tblShow_Final_ClassesDataTable tblShowFinalClasses = null;

        private Guid _show_Final_Class_ID;
        public Guid Show_Final_Class_ID
        {
            get { return _show_Final_Class_ID; }
            set { _show_Final_Class_ID = value; }
        }
        private Guid? _show_ID = null;
        public Guid? Show_ID
        {
            get { return _show_ID; }
            set { _show_ID = value; }
        }

        private Guid? _show_Entry_Class_ID = null;
        public Guid? Show_Entry_Class_ID
        {
            get { return _show_Entry_Class_ID; }
            set { _show_Entry_Class_ID = value; }
        }

        private string _show_Final_Class_Description = null;
        public string Show_Final_Class_Description
        {
            get { return _show_Final_Class_Description; }
            set { _show_Final_Class_Description = value; }
        }

        private short _show_Final_Class_No;
        public short Show_Final_Class_No
        {
            get { return _show_Final_Class_No; }
            set { _show_Final_Class_No = value; }
        }

        private Guid? _judge_ID = null;
        public Guid? Judge_ID
        {
            get { return _judge_ID; }
            set { _judge_ID = value; }
        }

        private DateTime? _stay_Time = null;
        public DateTime? Stay_Time
        {
            get { return _stay_Time; }
            set { _stay_Time = value; }
        }

        private DateTime? _lunch_Time = null;
        public DateTime? Lunch_Time
        {
            get { return _lunch_Time; }
            set { _lunch_Time = value; }
        }

        private bool _deleteShowFinalClass = false;
        public bool DeleteShowFinalClass
        {
            get { return _deleteShowFinalClass; }
            set { _deleteShowFinalClass = value; }
        }

        public ShowFinalClasses()
        {

        }

        public ShowFinalClasses(Guid show_Final_Class_ID)
        {
            ShowFinalClassesBL showfinalclasses = new ShowFinalClassesBL();
            tblShowFinalClasses = showfinalclasses.GetShow_Final_ClassByShow_Final_Class_ID(show_Final_Class_ID);

            Show_Final_Class_ID = show_Final_Class_ID;
            Show_ID = tblShowFinalClasses[0].Show_ID;
            if (!tblShowFinalClasses[0].IsShow_Entry_Class_IDNull())
                Show_Entry_Class_ID = tblShowFinalClasses[0].Show_Entry_Class_ID;
            Show_Final_Class_Description = tblShowFinalClasses[0].Show_Final_Class_Description;
            Show_Final_Class_No = tblShowFinalClasses[0].Show_Final_Class_No;
            if (!tblShowFinalClasses[0].IsJudge_IDNull())
                Judge_ID = tblShowFinalClasses[0].Judge_ID;
            if (!tblShowFinalClasses[0].IsStay_TimeNull())
                Stay_Time = tblShowFinalClasses[0].Stay_Time;
            if (!tblShowFinalClasses[0].IsLunch_TimeNull())
                Lunch_Time = tblShowFinalClasses[0].Lunch_Time;
        }

        public List<ShowFinalClasses> GetShow_Final_Classes()
        {
            List<ShowFinalClasses> showFinalClassList = new List<ShowFinalClasses>();
            ShowFinalClassesBL showfinalclasses = new ShowFinalClassesBL();
            tblShowFinalClasses = showfinalclasses.GetShow_Final_Classes();

            if (tblShowFinalClasses != null && tblShowFinalClasses.Count > 0)
            {
                foreach (sss.tblShow_Final_ClassesRow row in tblShowFinalClasses)
                {
                    ShowFinalClasses showFinalClass = new ShowFinalClasses(row.Show_Final_Class_ID);
                    showFinalClassList.Add(showFinalClass);
                }
            }

            return showFinalClassList;
        }

        public List<ShowFinalClasses> GetShow_Final_ClassesByShow_ID(Guid show_ID)
        {
            List<ShowFinalClasses> showFinalClassList = new List<ShowFinalClasses>();
            ShowFinalClassesBL showfinalclasses = new ShowFinalClassesBL();
            tblShowFinalClasses = showfinalclasses.GetShow_Final_ClassesByShow_ID(show_ID);

            if (tblShowFinalClasses != null && tblShowFinalClasses.Count > 0)
            {
                foreach (sss.tblShow_Final_ClassesRow row in tblShowFinalClasses)
                {
                    ShowFinalClasses showFinalClass = new ShowFinalClasses(row.Show_Final_Class_ID);
                    showFinalClassList.Add(showFinalClass);
                }
            }

            return showFinalClassList;
        }

        public List<ShowFinalClasses> GetShow_Final_ClassesByShow_Entry_Class_ID(Guid show_Entry_Class_ID)
        {
            List<ShowFinalClasses> showFinalClassList = new List<ShowFinalClasses>();
            ShowFinalClassesBL showfinalclasses = new ShowFinalClassesBL();
            tblShowFinalClasses = showfinalclasses.GetShow_Final_ClassByShow_Entry_Class_ID(show_Entry_Class_ID);

            if (tblShowFinalClasses != null && tblShowFinalClasses.Count > 0)
            {
                foreach (sss.tblShow_Final_ClassesRow row in tblShowFinalClasses)
                {
                    ShowFinalClasses showFinalClass = new ShowFinalClasses(row.Show_Final_Class_ID);
                    showFinalClassList.Add(showFinalClass);
                }
            }

            return showFinalClassList;
        }

        public Guid? Insert_Show_Final_Class(Guid user_ID)
        {
            ShowFinalClassesBL showfinalclasses = new ShowFinalClassesBL();
            Guid? newID = (Guid?)showfinalclasses.Insert_Show_Final_Classes(Show_ID, Show_Entry_Class_ID,
                Show_Final_Class_Description, Show_Final_Class_No, Judge_ID, Stay_Time, Lunch_Time, user_ID);

            return newID;
        }

        public bool Update_Show_Final_Class(Guid show_Final_Class_ID, Guid user_ID)
        {
            bool success = false;

            ShowFinalClassesBL showfinalclasses = new ShowFinalClassesBL();
            success = showfinalclasses.Update_Show_Final_Classes(show_Final_Class_ID, Show_ID, Show_Entry_Class_ID,
                Show_Final_Class_Description, Show_Final_Class_No, Judge_ID, Stay_Time, Lunch_Time, DeleteShowFinalClass, user_ID);

            return success;
        }

        public int DeleteShowFinalClassesByShowEntryClass(Guid show_Entry_Class_ID)
        {
            ShowFinalClassesBL showFinalClasses = new ShowFinalClassesBL();

            return showFinalClasses.DeleteShowFinalClassesByShowEntryClass(show_Entry_Class_ID);
        }
    }
}