using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.sssTableAdapters;
using System.ComponentModel;

namespace BLL
{
    [DataObject]
    class DogBreedsBL
    {
        private lkpDog_BreedsTableAdapter _lkpDog_BreedsAdapter = null;
        protected lkpDog_BreedsTableAdapter adapter
        {
            get
            {
                if (_lkpDog_BreedsAdapter == null)
                    _lkpDog_BreedsAdapter = new lkpDog_BreedsTableAdapter();

                return _lkpDog_BreedsAdapter;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public sss.lkpDog_BreedsDataTable GetDog_Breeds()
        {
            return adapter.GetDog_Breeds();
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.lkpDog_BreedsDataTable GetDog_BreedsByDog_Breed_ID(int dog_Breed_ID)
        {
            return adapter.GetDog_BreedByDog_Breed_ID(dog_Breed_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.lkpDog_BreedsDataTable GetDog_BreedsByDog_Breed_Description(string dog_Breed_Description)
        {
            return adapter.GetDog_BreedsByDog_Breed_Description(dog_Breed_Description);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int? Insert_Dog_Breed(string dog_Breed_Description)
        {
            return adapter.Insert_Dog_Breed(dog_Breed_Description);
        }
    }
}
