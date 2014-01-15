using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.sssTableAdapters;
using System.ComponentModel;

namespace BLL
{
    [DataObject]
    class UserPersonBL
    {
        private lnkUser_PersonTableAdapter _lnkUser_PersonAdapter = null;
        public lnkUser_PersonTableAdapter adapter
        {
            get
            {
                if (_lnkUser_PersonAdapter == null)
                    _lnkUser_PersonAdapter = new lnkUser_PersonTableAdapter();

                return _lnkUser_PersonAdapter;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public sss.lnkUser_PersonDataTable GetUser_Person()
        {
            return adapter.GetUser_Person();
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.lnkUser_PersonDataTable GetUser_PersonByUser_Person_ID(Guid user_Person_ID)
        {
            return adapter.GetUser_PersonByUser_Person_ID(user_Person_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.lnkUser_PersonDataTable GetUser_PersonByUser_ID(Guid user_ID)
        {
            return adapter.GetUser_PersonByUser_ID(user_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.lnkUser_PersonDataTable GetUser_PersonByPerson_ID(Guid person_ID)
        {
            return adapter.GetUser_PersonByPerson_ID(person_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public Guid? Insert_User_Person(Guid user_ID, Guid person_ID, Guid userID)
        {
            Guid? newID = (Guid?)adapter.Insert_User_Person(user_ID, person_ID, userID);

            return newID;
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public bool Update_User_Person(Guid original_ID, Guid user_ID, Guid person_ID, bool deleted, Guid userID)
        {
            try
            {
                adapter.Update_User_Person(original_ID, user_ID, person_ID, deleted, userID);

                return true;
            }
            catch
            {
                ApplicationException ae = new ApplicationException("Failed to update User_Person");

                return false;
            }
        }
    }
}
