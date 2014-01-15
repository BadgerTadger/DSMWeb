using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.sssTableAdapters;
using System.ComponentModel;

namespace BLL
{
    [DataObject]
    class DogSiresBL
    {
        private lnkDog_SiresTableAdapter _lnkDog_SiresAdapter = null;
        protected lnkDog_SiresTableAdapter adapter
        {
            get
            {
                if (_lnkDog_SiresAdapter == null)
                    _lnkDog_SiresAdapter = new lnkDog_SiresTableAdapter();

                return _lnkDog_SiresAdapter;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public sss.lnkDog_SiresDataTable GetDog_Sires()
        {
            return adapter.GetDog_Sires();
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.lnkDog_SiresDataTable GetDog_SireByDog_Sire_ID(Guid dog_Sire_ID)
        {
            return adapter.GetDog_SireByDog_Sire_ID(dog_Sire_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.lnkDog_SiresDataTable GetDog_SireByDog_ID(Guid dog_ID)
        {
            return adapter.GetDog_SireByDog_ID(dog_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.lnkDog_SiresDataTable GetDog_SiresBySire_ID(Guid sire_ID)
        {
            return adapter.GetDog_SiresBySire_ID(sire_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public Guid? Insert_Dog_Sires(Guid dog_ID, Guid sire_ID, Guid user_ID)
        {
            Guid? newID = (Guid?)adapter.Insert_Dog_Sires(dog_ID, sire_ID, user_ID);

            return newID;
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public bool Update_Dog_Sires(Guid original_ID, Guid dog_ID, Guid sire_ID, bool deleted, Guid user_ID)
        {
            try
            {
                adapter.Update_Dog_Sires(original_ID, dog_ID, sire_ID, deleted, user_ID);

                return true;
            }
            catch
            {
                ApplicationException ae = new ApplicationException("Failed to update Dog_Sires");

                return false;
            }
        }
    }
}
