using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.sssTableAdapters;
using System.ComponentModel;

namespace BLL
{
    [DataObject]
    class ClubsBL
    {
        private tblClubsTableAdapter _tblClubsAdapter = null;
        protected tblClubsTableAdapter adapter
        {
            get
            {
                if (_tblClubsAdapter == null)
                    _tblClubsAdapter = new tblClubsTableAdapter();

                return _tblClubsAdapter;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public sss.tblClubsDataTable GetClubs()
        {
            return adapter.GetClubs();
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblClubsDataTable GetClubByClub_ID(Guid club_ID)
        {
            return adapter.GetClubByClub_ID(club_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblClubsDataTable GetClubsByClub_Contact(Guid club_Contact)
        {
            return adapter.GetClubsByClub_Contact(club_Contact);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblClubsDataTable GetClubsLikeClub_Short_Name(string club_Short_Name)
        {
            return adapter.GetClubsLikeClub_Short_Name(club_Short_Name);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblClubsDataTable GetClubsLikeClub_Long_Name(string club_Long_Name)
        {
            return adapter.GetClubsLikeClub_Long_Name(club_Long_Name);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public Guid? Insert_Clubs(string club_Long_Name, string club_Short_Name, Guid? club_Contact, Guid user_ID)
        {
            Guid? newID = (Guid?)adapter.Insert_Clubs(club_Long_Name, club_Short_Name, club_Contact, user_ID);

            return newID;
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public bool Update_Clubs(Guid original_ID, string club_Long_Name, string club_Short_Name, Guid? club_Contact, bool deleted, Guid user_ID)
        {
            try
            {
                adapter.Update_Clubs(original_ID, club_Long_Name, club_Short_Name, club_Contact, deleted, user_ID);

                return true;
            }
            catch
            {
                ApplicationException ae = new ApplicationException("Failed to update Club");

                return false;
            }
        }
    }
}
