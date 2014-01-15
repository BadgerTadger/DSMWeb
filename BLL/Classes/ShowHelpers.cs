using System;
using System.Collections.Generic;
using System.Web;
using DAL;
using DAL.sssTableAdapters;

namespace BLL
{
    public class ShowHelpers
    {
        private sss.tblShow_HelpersDataTable tblShowHelpers = null;

        private Guid _show_Helper_ID;
        public Guid Show_Helper_ID
        {
            get { return _show_Helper_ID; }
            set { _show_Helper_ID = value; }
        }
        private Guid? _show_ID = null;
        public Guid? Show_ID
        {
            get { return _show_ID; }
            set { _show_ID = value; }
        }

        private Guid? _person_ID = null;
        public Guid? Person_ID
        {
            get { return _person_ID; }
            set { _person_ID = value; }
        }

        private int? _show_Role_ID = null;
        public int? Show_Role_ID
        {
            get { return _show_Role_ID; }
            set { _show_Role_ID = value; }
        }

        private bool? _deleteShowHelper = false;
        public bool? DeleteShowHelper
        {
            get { return _deleteShowHelper; }
            set { _deleteShowHelper = value; }
        }

        public ShowHelpers()
        {

        }

        public ShowHelpers(Guid show_Helper_ID)
        {
            ShowHelpersBL showhelpers = new ShowHelpersBL();
            tblShowHelpers = showhelpers.GetShow_HelpersByShow_Helper_ID(show_Helper_ID);

            Show_Helper_ID = show_Helper_ID;
            Show_ID = tblShowHelpers[0].Show_ID;
            Person_ID = tblShowHelpers[0].Person_ID;
            Show_Role_ID = tblShowHelpers[0].Show_Role_ID;
        }

        public List<ShowHelpers> GetShow_HelpersByShow_ID(Guid show_ID)
        {
            List<ShowHelpers> showHelperList = new List<ShowHelpers>();
            ShowHelpersBL showhelpers = new ShowHelpersBL();
            tblShowHelpers = showhelpers.GetShow_HelpersByShow_ID(show_ID);

            if (tblShowHelpers != null && tblShowHelpers.Count > 0)
            {
                foreach (sss.tblShow_HelpersRow row in tblShowHelpers)
                {
                    ShowHelpers showHelper = new ShowHelpers(row.Show_Helper_ID);
                    showHelperList.Add(showHelper);
                }
            }

            return showHelperList;
        }

        public Guid? Insert_Show_Helper(Guid user_ID)
        {
            ShowHelpersBL showhelpers = new ShowHelpersBL();
            Guid? newID = (Guid?)showhelpers.Insert_Show_Helpers(Show_ID, Person_ID, Show_Role_ID, user_ID);

            return newID;
        }

        public bool Update_Show_Helper(Guid show_Helper_ID, Guid user_ID)
        {
            bool success = false;

            ShowHelpersBL showhelpers = new ShowHelpersBL();
            success = showhelpers.Update_Show_Helpers(show_Helper_ID, Show_ID, Person_ID, Show_Role_ID, DeleteShowHelper, user_ID);

            return success;
        }
    }
}