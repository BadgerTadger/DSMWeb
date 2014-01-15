using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.sssTableAdapters;
using System.ComponentModel;

namespace BLL
{
    [DataObject]
    class DogsBL
    {
        private tblDogsTableAdapter _tblDogsAdapter = null;
        protected tblDogsTableAdapter adapter
        {
            get
            {
                if (_tblDogsAdapter == null)
                    _tblDogsAdapter = new tblDogsTableAdapter();

                return _tblDogsAdapter;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public sss.tblDogsDataTable GetDogs()
        {
            return adapter.GetDogs();
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblDogsDataTable GetDogsByDog_ID(Guid dog_ID)
        {
            return adapter.GetDogByDog_ID(dog_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblDogsDataTable GetDogsWhereBreed_IDInList(string breed_IDs)
        {
            return adapter.GetDogsWhereDog_Breed_IDInList(breed_IDs);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblDogsDataTable GetDogsLikeDog_KC_Name(string dog_KC_Name)
        {
            return adapter.GetDogsLikeDog_KC_Name(dog_KC_Name);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblDogsDataTable GetDogsLikeDog_Pet_Name(string dog_Pet_Name)
        {
            return adapter.GetDogsLikeDog_Pet_Name(dog_Pet_Name);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public Guid? Insert_Dogs(string dog_KC_Name, string dog_Pet_Name, int? dog_Breed_ID, int? dog_Gender_ID,
            string reg_No, DateTime? date_Of_Birth, short? year_Of_Birth,
            short? merit_Points, bool? nLWU, Guid user_ID)
        {
            Guid? newID = (Guid?)adapter.Insert_Dogs(dog_KC_Name, dog_Pet_Name, dog_Breed_ID, dog_Gender_ID,
                reg_No, date_Of_Birth, year_Of_Birth, merit_Points, nLWU, user_ID);

            return newID;
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public bool Update_Dogs(Guid original_ID, string dog_KC_Name, string dog_Pet_Name, int? dog_Breed_ID, int? dog_Gender_ID,
            string reg_No, DateTime? date_Of_Birth, short? year_Of_Birth,
            short? merit_Points, bool? nLWU, bool? deleted, Guid user_ID)
        {
            try
            {
                adapter.Update_Dogs(original_ID, dog_KC_Name, dog_Pet_Name, dog_Breed_ID, dog_Gender_ID,
                    reg_No, date_Of_Birth, year_Of_Birth, merit_Points, nLWU, deleted, user_ID);

                return true;
            }
            catch
            {
                ApplicationException ae = new ApplicationException("Failed to update Dog");

                return false;
            }
        }
    }
}
