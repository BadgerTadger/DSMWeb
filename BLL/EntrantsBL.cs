using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.sssTableAdapters;
using System.ComponentModel;

namespace BLL
{
    [DataObject]
    class EntrantsBL
    {
        private tblEntrantsTableAdapter _tblEntrantsAdapter = null;
        protected tblEntrantsTableAdapter adapter
        {
            get
            {
                if (_tblEntrantsAdapter == null)
                    _tblEntrantsAdapter = new tblEntrantsTableAdapter();

                return _tblEntrantsAdapter;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public sss.tblEntrantsDataTable GetEntrants()
        {
            return adapter.GetEntrants();
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblEntrantsDataTable GetEntrantsByEntrant_ID(Guid entrant_ID)
        {
            return adapter.GetEntrantByEntrant_ID(entrant_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblEntrantsDataTable GetEntrantsByShow_ID(Guid show_ID, bool includeLinked)
        {
            return adapter.GetEntrantsByShow_ID(show_ID, includeLinked);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblEntrantsDataTable GetEntrantsByShow_IDAndDog_ID(Guid show_ID, Guid dog_ID, bool includeLinked)
        {
            return adapter.GetEntrantsByShow_IDAndDog_ID(show_ID, dog_ID, includeLinked);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public Guid? Insert_Entrants(Guid? show_ID, bool? catalogue, bool? overnight_Camping, decimal? overpayment,
            decimal? underpayment, bool? offer_Of_Help, string help_Details, bool? withold_Address, bool? send_Running_Order, DateTime? entry_Date, Guid user_ID)
        {
            Guid? newID = (Guid?)adapter.Insert_Entrants(show_ID, catalogue, overnight_Camping, overpayment, underpayment,
                offer_Of_Help, help_Details, withold_Address, send_Running_Order, entry_Date, user_ID);

            return newID;
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public bool Update_Entrants(Guid original_ID, Guid? show_ID, bool? catalogue, bool? overnight_Camping, decimal? overpayment,
            decimal? underpayment, bool? offer_Of_Help, string help_Details, bool? withold_Address, bool? send_Running_Order, DateTime? entry_Date, bool? deleted, Guid user_ID)
        {
            try
            {
                adapter.Update_Entrants(original_ID, show_ID, catalogue, overnight_Camping, overpayment, underpayment,
                    offer_Of_Help, help_Details, withold_Address, send_Running_Order, entry_Date, deleted, user_ID);

                return true;
            }
            catch
            {
                ApplicationException ae = new ApplicationException("Failed to update Entrants");

                return false;
            }
        }
    }
}
