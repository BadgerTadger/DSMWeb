using System;
using System.Collections.Generic;
using System.Web;
using DAL;
using DAL.sssTableAdapters;

namespace BLL
{
    public class Entrants
    {
        private sss.tblEntrantsDataTable tblEntrants = null;

        private Guid? _entrant_ID = null;
        public Guid? Entrant_ID
        {
            get { return _entrant_ID; }
            set { _entrant_ID = value; }
        }

        private Guid? _show_ID = null;
        public Guid? Show_ID
        {
            get { return _show_ID; }
            set { _show_ID = value; }
        }

        private bool? _catalogue = null;
        public bool? Catalogue
        {
            get { return _catalogue; }
            set { _catalogue = value; }
        }

        private bool? _overnight_Camping = null;
        public bool? Overnight_Camping
        {
            get { return _overnight_Camping; }
            set { _overnight_Camping = value; }
        }

        private decimal? _overpayment = null;
        public decimal? Overpayment
        {
            get { return _overpayment; }
            set { _overpayment = value; }
        }

        private decimal? _underpayment = null;
        public decimal? Underpayment
        {
            get { return _underpayment; }
            set { _underpayment = value; }
        }

        private bool? _offer_Of_Help = null;
        public bool? Offer_Of_Help
        {
            get { return _offer_Of_Help; }
            set { _offer_Of_Help = value; }
        }

        private string _help_Details = null;
        public string Help_Details
        {
            get { return _help_Details; }
            set { _help_Details = value; }
        }

        private bool? _withold_Address = null;
        public bool? Withold_Address
        {
            get { return _withold_Address; }
            set { _withold_Address = value; }
        }

        private bool? _send_Running_Order = null;
        public bool? Send_Running_Order
        {
            get { return _send_Running_Order; }
            set { _send_Running_Order = value; }
        }
        private DateTime? _entry_Date = null;
        public DateTime? Entry_Date
        {
            get { return _entry_Date; }
            set { _entry_Date = value; }
        }
        private bool? _deleteEntrant = null;
        public bool? DeleteEntrant
        {
            get { return _deleteEntrant; }
            set { _deleteEntrant = value; }
        }

        public Entrants()
        {

        }

        public Entrants(Guid entrant_ID)
        {
            EntrantsBL entrants = new EntrantsBL();
            tblEntrants = entrants.GetEntrantsByEntrant_ID(entrant_ID);

            Entrant_ID = entrant_ID;
            if (!tblEntrants[0].IsShow_IDNull())
                Show_ID = tblEntrants[0].Show_ID;
            if (!tblEntrants[0].IsCatalogueNull())
                Catalogue = tblEntrants[0].Catalogue;
            else
                Catalogue = false;
            if (!tblEntrants[0].IsOvernight_CampingNull())
                Overnight_Camping = tblEntrants[0].Overnight_Camping;
            else
                Overnight_Camping = false;
            if (!tblEntrants[0].IsOverpaymentNull())
                Overpayment = decimal.Parse(tblEntrants[0].Overpayment.ToString("#.00"));
            if (!tblEntrants[0].IsUnderpaymentNull())
                Underpayment = decimal.Parse(tblEntrants[0].Underpayment.ToString("#.00"));
            if (!tblEntrants[0].IsOffer_Of_HelpNull())
                Offer_Of_Help = tblEntrants[0].Offer_Of_Help;
            else
                Offer_Of_Help = false;
            if (!tblEntrants[0].IsHelp_DetailsNull())
                Help_Details = tblEntrants[0].Help_Details;
            if (!tblEntrants[0].IsWithold_AddressNull())
                Withold_Address = tblEntrants[0].Withold_Address;
            else
                Withold_Address = false;
            if (!tblEntrants[0].IsSend_Running_OrderNull())
                Send_Running_Order = tblEntrants[0].Send_Running_Order;
            else
                Send_Running_Order = false;
            if (!tblEntrants[0].IsEntry_DateNull())
                Entry_Date = tblEntrants[0].Entry_Date;
        }

        public List<Entrants> GetEntrantsByShow_ID(Guid show_ID, bool includeLinked)
        {
            List<Entrants> entrantList = new List<Entrants>();
            EntrantsBL entrants = new EntrantsBL();
            tblEntrants = entrants.GetEntrantsByShow_ID(show_ID, includeLinked);

            if (tblEntrants != null && tblEntrants.Count > 0)
            {
                foreach (sss.tblEntrantsRow row in tblEntrants)
                {
                    Entrants entrant = new Entrants(row.Entrant_ID);
                    entrantList.Add(entrant);
                }
            }

            return entrantList;
        }

        public List<Entrants> GetEntrantsByShow_IDAndDog_ID(Guid show_ID, Guid dog_ID, bool includeLinked)
        {
            List<Entrants> entrantList = new List<Entrants>();
            EntrantsBL entrants = new EntrantsBL();
            tblEntrants = entrants.GetEntrantsByShow_IDAndDog_ID(show_ID, dog_ID, includeLinked);

            if (tblEntrants != null && tblEntrants.Count > 0)
            {
                foreach (sss.tblEntrantsRow row in tblEntrants)
                {
                    Entrants entrant = new Entrants(row.Entrant_ID);
                    entrantList.Add(entrant);
                }
            }

            return entrantList;
        }

        public Guid? Insert_Entrant(Guid user_ID)
        {
            EntrantsBL entrants = new EntrantsBL();
            Guid? newID = (Guid?)entrants.Insert_Entrants(Show_ID, Catalogue, Overnight_Camping, Overpayment,
                Underpayment, Offer_Of_Help, Help_Details, Withold_Address, Send_Running_Order, Entry_Date, user_ID);

            return newID;
        }

        public bool Update_Entrant(Guid entrant_ID, Guid user_ID)
        {
            bool success = false;

            EntrantsBL entrants = new EntrantsBL();
            success = entrants.Update_Entrants(entrant_ID, Show_ID, Catalogue, Overnight_Camping, Overpayment,
                Underpayment, Offer_Of_Help, Help_Details, Withold_Address, Send_Running_Order, Entry_Date, DeleteEntrant, user_ID);

            return success;
        }
    }
}