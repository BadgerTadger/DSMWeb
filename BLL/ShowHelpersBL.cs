using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.sssTableAdapters;
using System.ComponentModel;

namespace BLL
{
    [DataObject]
    class ShowHelpersBL
    {
        private tblShow_HelpersTableAdapter _tblShow_HelpersAdapter = null;
        protected tblShow_HelpersTableAdapter adapter
        {
            get
            {
                if (_tblShow_HelpersAdapter == null)
                    _tblShow_HelpersAdapter = new tblShow_HelpersTableAdapter();

                return _tblShow_HelpersAdapter;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public sss.tblShow_HelpersDataTable GetShow_Helpers()
        {
            return adapter.GetShow_Helpers();
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblShow_HelpersDataTable GetShow_HelpersByShow_Helper_ID(Guid show_Helper_ID)
        {
            return adapter.GetShow_HelperByShow_Helper_ID(show_Helper_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblShow_HelpersDataTable GetShow_HelpersByShow_ID(Guid show_ID)
        {
            return adapter.GetShow_HelpersByShow_ID(show_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public Guid? Insert_Show_Helpers(Guid? show_ID, Guid? person_ID, int? show_Role_ID, Guid user_ID)
        {
            Guid? newID = (Guid?)adapter.Insert_Show_Helpers(show_ID, person_ID, show_Role_ID, user_ID);

            return newID;
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public bool Update_Show_Helpers(Guid original_ID, Guid? show_ID, Guid? person_ID, int? show_Role_ID, bool? deleted, Guid user_ID)
        {
            try
            {
                adapter.Update_Show_Helpers(original_ID, show_ID, person_ID, show_Role_ID, deleted, user_ID);

                return true;
            }
            catch
            {
                ApplicationException ae = new ApplicationException("Failed to update Show Helper");

                return false;
            }
        }
    }
}
