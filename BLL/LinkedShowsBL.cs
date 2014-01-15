using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.sssTableAdapters;
using System.ComponentModel;

namespace BLL
{
    [DataObject]
    class LinkedShowsBL
    {
        private lnkLinked_ShowsTableAdapter _lnkLinked_ShowsAdapter = null;
        protected lnkLinked_ShowsTableAdapter adapter
        {
            get
            {
                if (_lnkLinked_ShowsAdapter == null)
                    _lnkLinked_ShowsAdapter = new lnkLinked_ShowsTableAdapter();

                return _lnkLinked_ShowsAdapter;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public sss.lnkLinked_ShowsDataTable GetLinked_Shows()
        {
            return adapter.GetLinked_Shows();
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.lnkLinked_ShowsDataTable GetLinked_ShowByLinked_Show_ID(Guid linked_Show_ID)
        {
            return adapter.GetLinked_ShowByLinked_Show_ID(linked_Show_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.lnkLinked_ShowsDataTable GetLinked_ShowsByParent_Show_ID(Guid parent_Show_ID)
        {
            return adapter.GetLinked_ShowsByParent_Show_ID(parent_Show_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.lnkLinked_ShowsDataTable GetLinked_ShowByChild_Show_ID(Guid child_Show_ID)
        {
            return adapter.GetLinked_ShowByChild_Show_ID(child_Show_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public Guid? Insert_Linked_Shows(Guid parent_Show_ID, Guid child_Show_ID, Guid user_ID)
        {
            Guid? newID = (Guid?)adapter.Insert_Linked_Shows(parent_Show_ID, child_Show_ID, user_ID);

            return newID;
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public bool Update_Linked_Shows(Guid original_ID, Guid parent_Show_ID, Guid child_Show_ID, bool deleted, Guid user_ID)
        {
            try
            {
                adapter.Update_Linked_Shows(original_ID, parent_Show_ID, child_Show_ID, deleted, user_ID);

                return true;
            }
            catch
            {
                ApplicationException ae = new ApplicationException("Failed to update Linked_Shows");

                return false;
            }
        }
    }
}
