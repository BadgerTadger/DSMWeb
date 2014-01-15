using System;
using System.Collections.Generic;
using System.Web;
using DAL;
using DAL.sssTableAdapters;

namespace BLL
{
    public class Venues
    {
        private sss.tblVenuesDataTable tblVenues = null;

        private Guid _venue_ID;
        public Guid Venue_ID
        {
            get { return _venue_ID; }
            set { _venue_ID = value; }
        }
        private string _venue_Name = null;
        public string Venue_Name
        {
            get { return _venue_Name; }
            set { _venue_Name = value; }
        }

        private Guid? _address_ID = null;
        public Guid? Address_ID
        {
            get { return _address_ID; }
            set { _address_ID = value; }
        }

        private Guid? _venue_Contact = null;
        public Guid? Venue_Contact
        {
            get { return _venue_Contact; }
            set { _venue_Contact = value; }
        }

        private bool _deleteVenue = false;
        public bool DeleteVenue
        {
            get { return _deleteVenue; }
            set { _deleteVenue = value; }
        }

        public Venues()
        {

        }

        public Venues(Guid venue_ID)
        {
            VenuesBL venues = new VenuesBL();
            tblVenues = venues.GetVenueByVenue_ID(venue_ID);

            Venue_ID = venue_ID;
            Venue_Name = tblVenues[0].Venue_Name;
            Address_ID = tblVenues[0].Address_ID;
            if (!tblVenues[0].IsVenue_ContactNull())
                Venue_Contact = tblVenues[0].Venue_Contact;
        }

        public List<Venues> GetVenues()
        {
            List<Venues> venueList = new List<Venues>();
            VenuesBL venues = new VenuesBL();
            tblVenues = venues.GetVenues();

            if (tblVenues != null && tblVenues.Count > 0)
            {
                foreach (sss.tblVenuesRow row in tblVenues)
                {
                    Venues venue = new Venues(row.Venue_ID);
                    venueList.Add(venue);
                }
            }

            return venueList;
        }

        public List<Venues> GetVenuesByAddress_ID(Guid address_ID)
        {
            List<Venues> venueList = new List<Venues>();
            VenuesBL venues = new VenuesBL();
            tblVenues = venues.GetVenueByAddress_ID(address_ID);

            if (tblVenues != null && tblVenues.Count > 0)
            {
                foreach (sss.tblVenuesRow row in tblVenues)
                {
                    Venues venue = new Venues(row.Venue_ID);
                    venueList.Add(venue);
                }
            }

            return venueList;
        }

        public List<Venues> GetVenuesLikeVenue_Name(string venue_Name)
        {
            List<Venues> venueList = new List<Venues>();
            VenuesBL venues = new VenuesBL();
            tblVenues = venues.GetVenuesLikeVenue_Name(venue_Name);

            if (tblVenues != null && tblVenues.Count > 0)
            {
                foreach (sss.tblVenuesRow row in tblVenues)
                {
                    Venues venue = new Venues(row.Venue_ID);
                    venueList.Add(venue);
                }
            }

            return venueList;
        }

        public Guid? Insert_Venue(Guid user_ID)
        {
            VenuesBL venues = new VenuesBL();
            Guid? newID = venues.Insert_Venues(Venue_Name, Address_ID, Venue_Contact, user_ID);

            return newID;
        }

        public bool Update_Venue(Guid venue_ID, Guid user_ID)
        {
            bool success = false;

            VenuesBL venues = new VenuesBL();
            success = venues.Update_Venues(venue_ID, Venue_Name, Address_ID, Venue_Contact, DeleteVenue, user_ID);

            return success;
        }
    }
}