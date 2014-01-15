using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.sssTableAdapters;
using System.ComponentModel;

namespace BLL
{
    [DataObject]
    class DogOwnersBL
    {
        private lnkDog_OwnersTableAdapter _lnkDog_OwnersAdapter = null;
        public lnkDog_OwnersTableAdapter adapter
        {
            get
            {
                if (_lnkDog_OwnersAdapter == null)
                    _lnkDog_OwnersAdapter = new lnkDog_OwnersTableAdapter();

                return _lnkDog_OwnersAdapter;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public sss.lnkDog_OwnersDataTable GetDog_Owners()
        {
            return adapter.GetDog_Owners();
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.lnkDog_OwnersDataTable GetDog_OwnersByDog_Owner_ID(Guid dog_Owner_ID)
        {
            return adapter.GetDog_OwnersByDog_Owner_ID(dog_Owner_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.lnkDog_OwnersDataTable GetDog_OwnersByDog_ID(Guid dog_ID)
        {
            return adapter.GetDog_OwnersByDog_ID(dog_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.lnkDog_OwnersDataTable GetDog_OwnersByOwner_ID(Guid owner_ID)
        {
            return adapter.GetDog_OwnersByOwner_ID(owner_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.lnkDog_OwnersDataTable GetDog_OwnersByShow_ID(Guid show_ID)
        {
            return adapter.GetDog_OwnersByShow_ID(show_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public Guid? Insert_Dog_Owners(Guid dog_ID, Guid owner_ID, Guid user_ID)
        {
            Guid? newID = (Guid?)adapter.Insert_Dog_Owners(dog_ID, owner_ID, user_ID);

            return newID;
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public bool Update_Dog_Owners(Guid original_ID, Guid dog_ID, Guid owner_ID, bool deleted, Guid user_ID)
        {
            try
            {
                adapter.Update_Dog_Owners(original_ID, dog_ID, owner_ID, deleted, user_ID);

                return true;
            }
            catch
            {
                ApplicationException ae = new ApplicationException("Failed to update Dog_Owners");

                return false;
            }
        }
    }
}
