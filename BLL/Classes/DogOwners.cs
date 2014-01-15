using System;
using System.Collections.Generic;
using System.Web;
using DAL;
using DAL.sssTableAdapters;

namespace BLL
{
    public class DogOwners
    {
        private sss.lnkDog_OwnersDataTable lnkDogOwners = null;

        private Guid _dog_Owner_ID;
        public Guid Dog_Owner_ID
        {
            get { return _dog_Owner_ID; }
            set { _dog_Owner_ID = value; }
        }
        private Guid _dog_ID;
        public Guid Dog_ID
        {
            get { return _dog_ID; }
            set { _dog_ID = value; }
        }
        private Guid _owner_ID;
        public Guid Owner_ID
        {
            get { return _owner_ID; }
            set { _owner_ID = value; }
        }

        private bool _deleteDogOwner = false;
        public bool DeleteDogOwner
        {
            get { return _deleteDogOwner; }
            set { _deleteDogOwner = value; }
        }

        public DogOwners()
        {

        }

        public DogOwners(Guid dog_Owner_ID)
        {
            DogOwnersBL dogOwners = new DogOwnersBL();
            lnkDogOwners = dogOwners.GetDog_OwnersByDog_Owner_ID(dog_Owner_ID);

            Dog_Owner_ID = dog_Owner_ID;
            Dog_ID = lnkDogOwners[0].Dog_ID;
            Owner_ID = lnkDogOwners[0].Owner_ID;
        }

        public List<DogOwners> GetDogOwnersByDog_ID(Guid dog_ID)
        {
            List<DogOwners> dogOwnerList = new List<DogOwners>();
            DogOwnersBL dogOwners = new DogOwnersBL();
            lnkDogOwners = dogOwners.GetDog_OwnersByDog_ID(dog_ID);

            if (lnkDogOwners != null && lnkDogOwners.Count > 0)
            {
                foreach (sss.lnkDog_OwnersRow row in lnkDogOwners)
                {
                    DogOwners dogOwner = new DogOwners(row.Dog_Owner_ID);
                    dogOwnerList.Add(dogOwner);
                }
            }

            return dogOwnerList;
        }

        public List<DogOwners> GetDogOwnersByOwner_ID(Guid owner_ID)
        {
            List<DogOwners> dogOwnerList = new List<DogOwners>();
            DogOwnersBL dogOwners = new DogOwnersBL();
            lnkDogOwners = dogOwners.GetDog_OwnersByOwner_ID(owner_ID);

            if (lnkDogOwners != null && lnkDogOwners.Count > 0)
            {
                foreach (sss.lnkDog_OwnersRow row in lnkDogOwners)
                {
                    DogOwners dogOwner = new DogOwners(row.Dog_Owner_ID);
                    dogOwnerList.Add(dogOwner);
                }
            }

            return dogOwnerList;
        }

        public List<DogOwners> GetDogOwnersByShow_ID(Guid show_ID)
        {
            List<DogOwners> dogOwnerList = new List<DogOwners>();
            DogOwnersBL dogOwners = new DogOwnersBL();
            lnkDogOwners = dogOwners.GetDog_OwnersByShow_ID(show_ID);

            if (lnkDogOwners != null && lnkDogOwners.Count > 0)
            {
                foreach (sss.lnkDog_OwnersRow row in lnkDogOwners)
                {
                    DogOwners dogOwner = new DogOwners(row.Dog_Owner_ID);
                    dogOwnerList.Add(dogOwner);
                }
            }

            return dogOwnerList;
        }

        public Guid? Insert_Dog_Owner(Guid user_ID)
        {
            DogOwnersBL dogOwners = new DogOwnersBL();
            Guid? newID = null;
            if (Dog_ID != null && Owner_ID != null)
                newID = dogOwners.Insert_Dog_Owners(Dog_ID, Owner_ID, user_ID);

            return newID;
        }

        public bool Update_Dog_Owner(Guid original_ID, Guid user_ID)
        {
            bool success = false;

            DogOwnersBL dogOwners = new DogOwnersBL();
            success = dogOwners.Update_Dog_Owners(original_ID, Dog_ID, Owner_ID, DeleteDogOwner, user_ID);

            return success;
        }
    }

    public class DogOwnerList
    {
        private List<People> _myDogOwnerList;
        public List<People> MyDogOwnerList
        {
            get { return _myDogOwnerList; }
            set { _myDogOwnerList = value; }
        }

        public DogOwnerList()
        {
            GetDogOwnerList();
        }
        public List<People> GetDogOwnerList()
        {
            return MyDogOwnerList;
        }
        public int AddOwner(People owner)
        {
            if (MyDogOwnerList == null)
                MyDogOwnerList = new List<People>();
            bool foundOwner = false;
            foreach (People o in MyDogOwnerList)
            {
                if (o.Person_ID == owner.Person_ID)
                    foundOwner = true;
            }
            if (!foundOwner)
                MyDogOwnerList.Add(owner);

            return MyDogOwnerList.Count;
        }
        public List<People> Sort()
        {
            MyDogOwnerList.Sort(
                delegate(People p1, People p2)
                {
                    return p1.Person_Surname.CompareTo(p2.Person_Surname);
                }
            );
            return MyDogOwnerList;
        }
        public int DeleteDogOwner(int owner)
        {
            if (MyDogOwnerList == null)
                MyDogOwnerList = new List<People>();
            MyDogOwnerList.RemoveAt(owner);
            return MyDogOwnerList.Count;
        }
        public int ClearDogList()
        {
            if (MyDogOwnerList == null)
                MyDogOwnerList = new List<People>();
            MyDogOwnerList.Clear();
            return MyDogOwnerList.Count;
        }
    }
}