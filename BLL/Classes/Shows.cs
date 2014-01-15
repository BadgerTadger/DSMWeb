using System;
using System.Collections.Generic;
using System.Web;
using DAL;
using DAL.sssTableAdapters;

namespace BLL
{
    public class Shows
    {
        private sss.tblShowsDataTable tblShows = null;

        private Guid? _show_ID = null;
        public Guid? Show_ID
        {
            get { return _show_ID; }
            set { _show_ID = value; }
        }

        private Guid? _club_ID = null;
        public Guid? Club_ID
        {
            get { return _club_ID; }
            set { _club_ID = value; }
        }

        private int? _show_Year_ID = null;
        public int? Show_Year_ID
        {
            get { return _show_Year_ID; }
            set { _show_Year_ID = value; }
        }

        private int? _show_Type_ID = null;
        public int? Show_Type_ID
        {
            get { return _show_Type_ID; }
            set { _show_Type_ID = value; }
        }

        private Guid? _venue_ID = null;
        public Guid? Venue_ID
        {
            get { return _venue_ID; }
            set { _venue_ID = value; }
        }

        private DateTime? _show_Opens = null;
        public DateTime? Show_Opens
        {
            get { return _show_Opens; }
            set { _show_Opens = value; }
        }

        private DateTime? _judging_Commences = null;
        public DateTime? Judging_Commences
        {
            get { return _judging_Commences; }
            set { _judging_Commences = value; }
        }

        private string _show_Name = null;
        public string Show_Name
        {
            get { return _show_Name; }
            set { _show_Name = value; }
        }

        private DateTime? _closing_Date = null;
        public DateTime? Closing_Date
        {
            get { return _closing_Date; }
            set { _closing_Date = value; }
        }

        private bool? _entries_Complete = null;
        public bool? Entries_Complete
        {
            get { return _entries_Complete; }
            set { _entries_Complete = value; }
        }

        private bool? _judges_Allocated = null;
        public bool? Judges_Allocated
        {
            get { return _judges_Allocated; }
            set { _judges_Allocated = value; }
        }

        private bool? _split_Classes = null;
        public bool? Split_Classes
        {
            get { return _split_Classes; }
            set { _split_Classes = value; }
        }

        private bool? _running_Orders_Allocated = null;
        public bool? Running_Orders_Allocated
        {
            get { return _running_Orders_Allocated; }
            set { _running_Orders_Allocated = value; }
        }

        private bool? _ring_Numbers_Allocated = null;
        public bool? Ring_Numbers_Allocated
        {
            get { return _ring_Numbers_Allocated; }
            set { _ring_Numbers_Allocated = value; }
        }

        private bool? _linked_Show = false;
        public bool? Linked_Show
        {
            get { return _linked_Show; }
            set { _linked_Show = value; }
        }

        private short? _maxClassesPerDog = null;
        public short? MaxClassesPerDog
        {
            get { return _maxClassesPerDog; }
            set { _maxClassesPerDog = value; }
        }

        private bool _deleteShow = false;
        public bool DeleteShow
        {
            get { return _deleteShow; }
            set { _deleteShow = value; }
        }

        public Shows()
        {

        }

        public Shows(Guid show_ID)
        {
            ShowsBL shows = new ShowsBL();
            tblShows = shows.GetShowByShow_ID(show_ID);

            Show_ID = tblShows[0].Show_ID;
            Club_ID = tblShows[0].Club_ID;
            Show_Year_ID = tblShows[0].Show_Year_ID;
            if (!tblShows[0].IsShow_Type_IDNull())
                Show_Type_ID = tblShows[0].Show_Type_ID;
            if (!tblShows[0].IsVenue_IDNull())
                Venue_ID = tblShows[0].Venue_ID;
            if (!tblShows[0].IsShow_OpensNull())
                Show_Opens = tblShows[0].Show_Opens;
            if (!tblShows[0].IsJudging_CommencesNull())
                Judging_Commences = tblShows[0].Judging_Commences;
            if (!tblShows[0].IsShow_NameNull())
                Show_Name = tblShows[0].Show_Name;
            if (!tblShows[0].IsClosing_DateNull())
                Closing_Date = tblShows[0].Closing_Date;
            if (!tblShows[0].IsEntries_CompleteNull())
                Entries_Complete = tblShows[0].Entries_Complete;
            if (!tblShows[0].IsJudges_AllocatedNull())
                Judges_Allocated = tblShows[0].Judges_Allocated;
            if (!tblShows[0].IsSplit_ClassesNull())
                Split_Classes = tblShows[0].Split_Classes;
            if (!tblShows[0].IsRunning_Orders_AllocatedNull())
                Running_Orders_Allocated = tblShows[0].Running_Orders_Allocated;
            if (!tblShows[0].IsRing_Numbers_AllocatedNull())
                Ring_Numbers_Allocated = tblShows[0].Ring_Numbers_Allocated;
            if (!tblShows[0].IsLinked_ShowNull())
                Linked_Show = (tblShows[0].IsLinked_ShowNull()) ? false : tblShows[0].Linked_Show;
            if (!tblShows[0].IsMaxClassesPerDogNull())
                MaxClassesPerDog = tblShows[0].MaxClassesPerDog;
        }

        public List<Shows> GetShowsByClub_ID(Guid club_ID)
        {
            List<Shows> showList = new List<Shows>();
            ShowsBL shows = new ShowsBL();
            tblShows = shows.GetShowsByClub_ID(club_ID);

            if (tblShows != null && tblShows.Count > 0)
            {
                foreach (sss.tblShowsRow row in tblShows)
                {
                    Shows show = new Shows(row.Show_ID);
                    showList.Add(show);
                }
            }

            return showList;
        }

        public List<Shows> GetShowsByClub_ID_And_Show_Year_ID(Guid club_ID, int show_Year_ID)
        {
            List<Shows> showList = new List<Shows>();
            ShowsBL shows = new ShowsBL();
            tblShows = shows.GetShowsByClub_ID_And_Show_Year_ID(club_ID, show_Year_ID);

            if (tblShows != null && tblShows.Count > 0)
            {
                foreach (sss.tblShowsRow row in tblShows)
                {
                    Shows show = new Shows(row.Show_ID);
                    showList.Add(show);
                }
            }

            return showList;
        }

        public List<Shows> GetShowsByShow_Type_ID(int show_Type_ID)
        {
            List<Shows> showList = new List<Shows>();
            ShowsBL shows = new ShowsBL();
            tblShows = shows.GetShowsByShow_Type_ID(show_Type_ID);

            if (tblShows != null && tblShows.Count > 0)
            {
                foreach (sss.tblShowsRow row in tblShows)
                {
                    Shows show = new Shows(row.Show_ID);
                    showList.Add(show);
                }
            }

            return showList;
        }

        public List<Shows> GetShowsByShow_Year(short show_Year)
        {
            List<Shows> showList = new List<Shows>();
            ShowsBL shows = new ShowsBL();
            tblShows = shows.GetShowsByShow_Year(show_Year);

            if (tblShows != null && tblShows.Count > 0)
            {
                foreach (sss.tblShowsRow row in tblShows)
                {
                    Shows show = new Shows(row.Show_ID);
                    showList.Add(show);
                }
            }

            return showList;
        }

        public List<Shows> GetShowsByVenue_ID(Guid venue_ID)
        {
            List<Shows> showList = new List<Shows>();
            ShowsBL shows = new ShowsBL();
            tblShows = shows.GetShowsByVenue_ID(venue_ID);

            if (tblShows != null && tblShows.Count > 0)
            {
                foreach (sss.tblShowsRow row in tblShows)
                {
                    Shows show = new Shows(row.Show_ID);
                    showList.Add(show);
                }
            }

            return showList;
        }

        public List<Shows> GetShowsLikeShow_Name(string show_Name)
        {
            List<Shows> showList = new List<Shows>();
            ShowsBL shows = new ShowsBL();
            tblShows = shows.GetShowsLikeShow_Name(show_Name);

            if (tblShows != null && tblShows.Count > 0)
            {
                foreach (sss.tblShowsRow row in tblShows)
                {
                    Shows show = new Shows(row.Show_ID);
                    showList.Add(show);
                }
            }

            return showList;
        }

        public Guid? Insert_Show(Guid user_ID)
        {
            ShowsBL shows = new ShowsBL();
            Guid? newID = (Guid?)shows.Insert_Shows(Club_ID, Show_Year_ID, Show_Type_ID, Venue_ID, Show_Opens,
                Judging_Commences, Show_Name, Closing_Date, MaxClassesPerDog, Linked_Show, user_ID);

            return newID;
        }

        public bool Update_Show(Guid show_ID, Guid user_ID)
        {
            bool success = false;

            ShowsBL shows = new ShowsBL();
            success = shows.Update_Shows(show_ID, Club_ID, Show_Year_ID, Show_Type_ID, Venue_ID, Show_Opens,
                Judging_Commences, Show_Name, Closing_Date, Entries_Complete, Judges_Allocated, Split_Classes,
                Running_Orders_Allocated, Ring_Numbers_Allocated, MaxClassesPerDog, Linked_Show, DeleteShow, user_ID);

            return success;
        }
    }
}