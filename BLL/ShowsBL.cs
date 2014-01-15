using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.sssTableAdapters;
using System.ComponentModel;

namespace BLL
{
    [DataObject]
    public class ShowsBL
    {
        private tblShowsTableAdapter _tblShowsAdapter = null;
        protected tblShowsTableAdapter adapter
        {
            get
            {
                if (_tblShowsAdapter == null)
                    _tblShowsAdapter = new tblShowsTableAdapter();

                return _tblShowsAdapter;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public sss.tblShowsDataTable GetShows()
        {
            return adapter.GetShows();
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblShowsDataTable GetShowByShow_ID(Guid show_ID)
        {
            return adapter.GetShowByShow_ID(show_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblShowsDataTable GetShowsByClub_ID(Guid club_ID)
        {
            return adapter.GetShowsByClub_ID(club_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblShowsDataTable GetShowsByClub_ID_And_Show_Year_ID(Guid club_ID, int show_Year_ID)
        {
            return adapter.GetShowsByClub_ID_And_Show_Year_ID(club_ID, show_Year_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblShowsDataTable GetShowsByShow_Type_ID(int show_Type_ID)
        {
            return adapter.GetShowsByShow_Type_ID(show_Type_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblShowsDataTable GetShowsByShow_Year(short show_Year_ID)
        {
            return adapter.GetShowsByShow_Year(show_Year_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblShowsDataTable GetShowsByVenue_ID(Guid venue_ID)
        {
            return adapter.GetShowsByVenue_ID(venue_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblShowsDataTable GetShowsLikeShow_Name(string show_Name)
        {
            return adapter.GetShowsLikeShow_Name(show_Name);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public Guid? Insert_Shows(Guid? club_ID, int? show_Year_ID, int? show_Type_ID, Guid? venue_ID, DateTime? show_Opens, DateTime? judging_Commences,
        string show_Name, DateTime? closing_Date, short? maxClassesPerDog, bool? linked_Show, Guid user_ID)
        {
            Guid? newID = (Guid?)adapter.Insert_Shows(club_ID, show_Year_ID, show_Type_ID, venue_ID, show_Opens,
                judging_Commences, show_Name, closing_Date, maxClassesPerDog, linked_Show, user_ID);

            return newID;
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public bool Update_Shows(Guid original_ID, Guid? club_ID, int? show_Year_ID, int? show_Type_ID, Guid? venue_ID, DateTime? show_Opens, DateTime? judging_Commences,
        string show_Name, DateTime? closing_Date, bool? entries_Complete, bool? judges_Allocated, bool? split_Classes, bool? running_Orders_Allocated,
        bool? ring_Numbers_Allocated, short? maxClassesPerDog, bool? linked_Show, bool? deleted, Guid user_ID)
        {
            try
            {
                adapter.Update_Shows(original_ID, club_ID, show_Year_ID, show_Type_ID, venue_ID, show_Opens, judging_Commences, show_Name,
                    closing_Date, entries_Complete, judges_Allocated, split_Classes, running_Orders_Allocated, ring_Numbers_Allocated,
                    maxClassesPerDog, linked_Show, deleted, user_ID);

                return true;
            }
            catch
            {
                ApplicationException ae = new ApplicationException("Failed to update the Show");

                return false;
            }
        }

    }
}
