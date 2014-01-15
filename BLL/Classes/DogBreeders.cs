using System;
using System.Collections.Generic;
using System.Web;
using DAL;
using DAL.sssTableAdapters;

namespace BLL
{
    public class DogBreeders
    {
        private sss.lnkDog_BreedersDataTable lnkDogBreeders = null;

        private Guid _dog_Breeder_ID;
        public Guid Dog_Breeder_ID
        {
            get { return _dog_Breeder_ID; }
            set { _dog_Breeder_ID = value; }
        }
        private Guid _dog_ID;
        public Guid Dog_ID
        {
            get { return _dog_ID; }
            set { _dog_ID = value; }
        }
        private Guid _breeder_ID;
        public Guid Breeder_ID
        {
            get { return _breeder_ID; }
            set { _breeder_ID = value; }
        }

        private bool _deleteDogBreeder = false;
        public bool DeleteDogBreeder
        {
            get { return _deleteDogBreeder; }
            set { _deleteDogBreeder = value; }
        }

        public DogBreeders()
        {

        }

        public DogBreeders(Guid dog_Breeder_ID)
        {
            DogBreedersBL dogBreeders = new DogBreedersBL();
            lnkDogBreeders = dogBreeders.GetDog_BreedersByDog_Breeder_ID(dog_Breeder_ID);

            Dog_Breeder_ID = dog_Breeder_ID;
            Dog_ID = lnkDogBreeders[0].Dog_ID;
            Breeder_ID = lnkDogBreeders[0].Breeder_ID;
        }

        public List<DogBreeders> GetDogBreedersByDog_ID(Guid dog_ID)
        {
            List<DogBreeders> dogBreederList = new List<DogBreeders>();
            DogBreedersBL dogBreeders = new DogBreedersBL();
            lnkDogBreeders = dogBreeders.GetDog_BreedersByDog_ID(dog_ID);

            if (lnkDogBreeders != null && lnkDogBreeders.Count > 0)
            {
                foreach (sss.lnkDog_BreedersRow row in lnkDogBreeders)
                {
                    DogBreeders dogBreeder = new DogBreeders(row.Dog_Breeder_ID);
                    dogBreederList.Add(dogBreeder);
                }
            }

            return dogBreederList;
        }

        public List<DogBreeders> GetDogBreedersByBreeder_ID(Guid breeder_ID)
        {
            List<DogBreeders> dogBreederList = new List<DogBreeders>();
            DogBreedersBL dogBreeders = new DogBreedersBL();
            lnkDogBreeders = dogBreeders.GetDog_BreedersByBreeder_ID(breeder_ID);

            if (lnkDogBreeders != null && lnkDogBreeders.Count > 0)
            {
                foreach (sss.lnkDog_BreedersRow row in lnkDogBreeders)
                {
                    DogBreeders dogBreeder = new DogBreeders(row.Dog_Breeder_ID);
                    dogBreederList.Add(dogBreeder);
                }
            }

            return dogBreederList;
        }

        public Guid? Insert_Dog_Breeder(Guid user_ID)
        {
            DogBreedersBL dogBreeders = new DogBreedersBL();
            Guid? newID = null;
            if (Dog_ID != null && Breeder_ID != null)
                newID = dogBreeders.Insert_Dog_Breeders(Dog_ID, Breeder_ID, user_ID);

            return newID;
        }

        public bool Update_Dog_Breeder(Guid original_ID, Guid user_ID)
        {
            bool success = false;

            DogBreedersBL dogBreeders = new DogBreedersBL();
            success = dogBreeders.Update_Dog_Breeders(original_ID, Dog_ID, Breeder_ID, DeleteDogBreeder, user_ID);

            return success;
        }
    }

    public class DogBreederList
    {
        private List<People> _myDogBreederList;
        public List<People> MyDogBreederList
        {
            get { return _myDogBreederList; }
            set { _myDogBreederList = value; }
        }

        public DogBreederList()
        {
            GetDogBreederList();
        }
        public List<People> GetDogBreederList()
        {
            return MyDogBreederList;
        }
        public int AddBreeder(People breeder)
        {
            if (MyDogBreederList == null)
                MyDogBreederList = new List<People>();
            MyDogBreederList.Add(breeder);
            return MyDogBreederList.Count;
        }
        public int DeleteDogBreeder(int breeder)
        {
            if (MyDogBreederList == null)
                MyDogBreederList = new List<People>();
            MyDogBreederList.RemoveAt(breeder);
            return MyDogBreederList.Count;
        }
        public int ClearDogList()
        {
            if (MyDogBreederList == null)
                MyDogBreederList = new List<People>();
            MyDogBreederList.Clear();
            return MyDogBreederList.Count;
        }
    }
}