using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.sssTableAdapters;
using System.ComponentModel;

namespace BLL
{
    [DataObject]
    class GuarantorsBL
    {
        private tblGuarantorsTableAdapter _tblGuarantorsAdapter = null;
        protected tblGuarantorsTableAdapter adapter
        {
            get
            {
                if (_tblGuarantorsAdapter == null)
                    _tblGuarantorsAdapter = new tblGuarantorsTableAdapter();

                return _tblGuarantorsAdapter;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public sss.tblGuarantorsDataTable GetGuarantors()
        {
            return adapter.GetGuarantors();
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblGuarantorsDataTable GetGuarantorByGuarantor_ID(Guid guarantor_ID)
        {
            return adapter.GetGuarantorByGuarantor_ID(guarantor_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblGuarantorsDataTable GetGuarantorsByShow_ID(Guid show_ID)
        {
            return adapter.GetGuarantorsByShow_ID(show_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public Guid? Insert_Guarantors(Guid? show_ID, Guid? chairman_Person_ID, Guid? secretary_Person_ID, Guid? treasurer_Person_ID,
            Guid? committee1_Person_ID, Guid? committee2_Person_ID, Guid? committee3_Person_ID, Guid user_ID)
        {
            Guid? newID = (Guid?)adapter.Insert_Guarantors(show_ID, chairman_Person_ID, secretary_Person_ID, treasurer_Person_ID,
                committee1_Person_ID, committee2_Person_ID, committee3_Person_ID, user_ID);

            return newID;
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public bool Update_Guarantors(Guid original_ID, Guid? show_ID, Guid? chairman_Person_ID, Guid? secretary_Person_ID, Guid? treasurer_Person_ID,
            Guid? committee1_Person_ID, Guid? committee2_Person_ID, Guid? committee3_Person_ID, bool? deleted, Guid? user_ID)
        {
            try
            {
                adapter.Update_Guarantors(original_ID, show_ID, chairman_Person_ID, secretary_Person_ID, treasurer_Person_ID, committee1_Person_ID,
                    committee2_Person_ID, committee3_Person_ID, deleted, user_ID);

                return true;
            }
            catch
            {
                ApplicationException ae = new ApplicationException("Failed to update Guarantors");

                return false;
            }
        }
    }
}
