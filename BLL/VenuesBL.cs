using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.sssTableAdapters;
using System.ComponentModel;

namespace BLL
{
    [DataObject]
    class VenuesBL
    {
        private tblVenuesTableAdapter _tblVenuesAdapter = null;
        protected tblVenuesTableAdapter adapter
        {
            get
            {
                if (_tblVenuesAdapter == null)
                    _tblVenuesAdapter = new tblVenuesTableAdapter();

                return _tblVenuesAdapter;
            }
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public sss.tblVenuesDataTable GetVenues()
        {
            return adapter.GetVenues();
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public sss.tblVenuesDataTable GetVenueByVenue_ID(Guid venue_ID)
        {
            return adapter.GetVenueByVenue_ID(venue_ID);
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public sss.tblVenuesDataTable GetVenueByAddress_ID(Guid address_ID)
        {
            return adapter.GetVenueByAddress_ID(address_ID);
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public sss.tblVenuesDataTable GetVenuesLikeVenue_Name(string venue_Name)
        {
            return adapter.GetVenuesLikeVenue_Name(venue_Name);
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, false)]
        public Guid? Insert_Venues(string venue_Name, Guid? address_ID, Guid? venue_Contact, Guid user_ID)
        {
            Guid? newID = (Guid?)adapter.Insert_Venues(venue_Name, address_ID, venue_Contact, user_ID);

            return newID;
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, false)]
        public bool Update_Venues(Guid original_ID, string venue_Name, Guid? address_ID, Guid? venue_Contact, bool? deleted, Guid user_ID)
        {
            try
            {
                adapter.Update_Venues(original_ID, venue_Name, address_ID, venue_Contact, deleted, user_ID);

                return true;
            }
            catch
            {
                ApplicationException ae = new ApplicationException("Failed to update the Venue");

                return false;
            }
        }
    }
}
