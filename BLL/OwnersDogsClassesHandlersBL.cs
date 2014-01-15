using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.sssTableAdapters;
using System.ComponentModel;

namespace BLL
{
    [DataObject]
    class OwnersDogsClassesHandlersBL
    {
        private tblOwnersDogsClassesHandlersTableAdapter _tblOwnersDogsClassesHandlersAdapter = null;
        protected tblOwnersDogsClassesHandlersTableAdapter adapter
        {
            get
            {
                if (_tblOwnersDogsClassesHandlersAdapter == null)
                    _tblOwnersDogsClassesHandlersAdapter = new tblOwnersDogsClassesHandlersTableAdapter();

                return _tblOwnersDogsClassesHandlersAdapter;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public sss.tblOwnersDogsClassesHandlersDataTable GetOwnersDogsClassesHandlers(Guid owner_ID)
        {
            if (PopulateOwnersDogsClassesHandlers(owner_ID))
            {
                return adapter.GetOwnersDogsClassesHandlers();
            }
            else
            {
                return null;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public bool PopulateOwnersDogsClassesHandlers(Guid owner_ID)
        {
            try
            {
                adapter.PopulateOwnersDogsClassesHandlers(owner_ID);

                return true;
            }
            catch
            {
                ApplicationException ae = new ApplicationException("Failed to update Owners, Dogs, Classes & Handlers Table!");

                return false;
            }
        }

    }
}
