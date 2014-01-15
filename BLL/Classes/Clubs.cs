using System;
using System.Collections.Generic;
using System.Web;
using DAL;
using DAL.sssTableAdapters;

namespace BLL
{
    public class Clubs
    {
        private sss.tblClubsDataTable tblClubs = null;

        private Guid _club_ID;
        public Guid Club_ID
        {
            get { return _club_ID; }
            set { _club_ID = value; }
        }
        private string _club_Long_Name = null;
        public string Club_Long_Name
        {
            get { return _club_Long_Name; }
            set { _club_Long_Name = value; }
        }

        private string _club_Short_Name = null;
        public string Club_Short_Name
        {
            get { return _club_Short_Name; }
            set { _club_Short_Name = value; }
        }

        private Guid? _club_Contact = null;
        public Guid? Club_Contact
        {
            get { return _club_Contact; }
            set { _club_Contact = value; }
        }

        private bool _deleteClub = false;
        public bool DeleteClub
        {
            get { return _deleteClub; }
            set { _deleteClub = value; }
        }

        public Clubs()
        {

        }

        public Clubs(Guid club_ID)
        {
            ClubsBL clubs = new ClubsBL();
            tblClubs = clubs.GetClubByClub_ID(club_ID);

            Club_ID = club_ID;
            if (!tblClubs[0].IsClub_Long_NameNull())
                Club_Long_Name = tblClubs[0].Club_Long_Name;
            if (!tblClubs[0].IsClub_Short_NameNull())
                Club_Short_Name = tblClubs[0].Club_Short_Name;
            if (!tblClubs[0].IsClub_ContactNull())
                Club_Contact = tblClubs[0].Club_Contact;
        }

        public List<Clubs> GetClubs()
        {
            List<Clubs> clubList = new List<Clubs>();
            ClubsBL clubs = new ClubsBL();
            tblClubs = clubs.GetClubs();

            if (tblClubs != null && tblClubs.Count > 0)
            {
                foreach (sss.tblClubsRow row in tblClubs)
                {
                    Clubs club = new Clubs(row.Club_ID);
                    clubList.Add(club);
                }
            }

            return clubList;
        }

        public List<Clubs> GetClubsLikeClub_Long_Name(string club_Long_Name)
        {
            List<Clubs> clubList = new List<Clubs>();
            ClubsBL clubs = new ClubsBL();
            tblClubs = clubs.GetClubsLikeClub_Long_Name(club_Long_Name);

            if (tblClubs != null && tblClubs.Count > 0)
            {
                foreach (sss.tblClubsRow row in tblClubs)
                {
                    Clubs club = new Clubs(row.Club_ID);
                    clubList.Add(club);
                }
            }

            return clubList;
        }

        public List<Clubs> GetClubsLikeClub_Short_Name(string club_Short_Name)
        {
            List<Clubs> clubList = new List<Clubs>();
            ClubsBL clubs = new ClubsBL();
            tblClubs = clubs.GetClubsLikeClub_Short_Name(club_Short_Name);

            if (tblClubs != null && tblClubs.Count > 0)
            {
                foreach (sss.tblClubsRow row in tblClubs)
                {
                    Clubs club = new Clubs(row.Club_ID);
                    clubList.Add(club);
                }
            }

            return clubList;
        }

        public Guid? Insert_Club(Guid user_ID)
        {
            ClubsBL clubs = new ClubsBL();
            Guid? newID = (Guid?)clubs.Insert_Clubs(Club_Long_Name, Club_Short_Name, Club_Contact, user_ID);

            return newID;
        }

        public bool Update_Club(Guid club_ID, Guid user_ID)
        {
            bool success = false;

            ClubsBL clubs = new ClubsBL();
            success = clubs.Update_Clubs(club_ID, Club_Long_Name, Club_Short_Name, Club_Contact, DeleteClub, user_ID);

            return success;
        }
    }
}