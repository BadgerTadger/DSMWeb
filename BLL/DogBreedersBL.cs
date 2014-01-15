using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.sssTableAdapters;
using System.ComponentModel;

namespace BLL
{
    [DataObject]
    class DogBreedersBL
    {
        private lnkDog_BreedersTableAdapter _lnkDog_BreedersAdapter = null;
        public lnkDog_BreedersTableAdapter adapter
        {
            get
            {
                if (_lnkDog_BreedersAdapter == null)
                    _lnkDog_BreedersAdapter = new lnkDog_BreedersTableAdapter();

                return _lnkDog_BreedersAdapter;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public sss.lnkDog_BreedersDataTable GetDog_Breeders()
        {
            return adapter.GetDog_Breeders();
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.lnkDog_BreedersDataTable GetDog_BreedersByDog_Breeder_ID(Guid dog_Breeder_ID)
        {
            return adapter.GetDog_BreedersByDog_Breeder_ID(dog_Breeder_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.lnkDog_BreedersDataTable GetDog_BreedersByDog_ID(Guid dog_ID)
        {
            return adapter.GetDog_BreedersByDog_ID(dog_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.lnkDog_BreedersDataTable GetDog_BreedersByBreeder_ID(Guid breeder_ID)
        {
            return adapter.GetDog_BreedersByBreeder_ID(breeder_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public Guid? Insert_Dog_Breeders(Guid dog_ID, Guid breeder_ID, Guid user_ID)
        {
            Guid? newID = (Guid?)adapter.Insert_Dog_Breeders(dog_ID, breeder_ID, user_ID);

            return newID;
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public bool Update_Dog_Breeders(Guid original_ID, Guid dog_ID, Guid breeder_ID, bool deleted, Guid user_ID)
        {
            try
            {
                adapter.Update_Dog_Breeders(original_ID, dog_ID, breeder_ID, deleted, user_ID);

                return true;
            }
            catch
            {
                ApplicationException ae = new ApplicationException("Failed to update Dog_Breeders");

                return false;
            }
        }
    }
}
