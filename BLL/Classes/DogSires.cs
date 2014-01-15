using System;
using System.Collections.Generic;
using System.Web;
using DAL;
using DAL.sssTableAdapters;

namespace BLL
{
    public class DogSires
    {
        private sss.lnkDog_SiresDataTable lnkDogSires = null;

        private Guid _dog_Sire_ID;
        public Guid Dog_Sire_ID
        {
            get { return _dog_Sire_ID; }
            set { _dog_Sire_ID = value; }
        }
        private Guid _dog_ID;
        public Guid Dog_ID
        {
            get { return _dog_ID; }
            set { _dog_ID = value; }
        }
        private Guid _sire_ID;
        public Guid Sire_ID
        {
            get { return _sire_ID; }
            set { _sire_ID = value; }
        }

        private bool _deleteDogSire = false;
        public bool DeleteDogSire
        {
            get { return _deleteDogSire; }
            set { _deleteDogSire = value; }
        }

        public DogSires()
        {

        }

        public DogSires(Guid dog_Sire_ID)
        {
            DogSiresBL dogSires = new DogSiresBL();
            lnkDogSires = dogSires.GetDog_SireByDog_Sire_ID(dog_Sire_ID);

            Dog_Sire_ID = dog_Sire_ID;
            Dog_ID = lnkDogSires[0].Dog_ID;
            Sire_ID = lnkDogSires[0].Sire_ID;
        }

        public List<DogSires> GetDogSiresByDog_ID(Guid dog_ID)
        {
            List<DogSires> dogSireList = new List<DogSires>();
            DogSiresBL dogSires = new DogSiresBL();
            lnkDogSires = dogSires.GetDog_SireByDog_ID(dog_ID);

            if (lnkDogSires != null && lnkDogSires.Count > 0)
            {
                foreach (sss.lnkDog_SiresRow row in lnkDogSires)
                {
                    DogSires dogSire = new DogSires(row.Dog_Sire_ID);
                    dogSireList.Add(dogSire);
                }
            }

            return dogSireList;
        }

        public List<DogSires> GetDogSiresBySire_ID(Guid sire_ID)
        {
            List<DogSires> dogSireList = new List<DogSires>();
            DogSiresBL dogSires = new DogSiresBL();
            lnkDogSires = dogSires.GetDog_SiresBySire_ID(sire_ID);

            if (lnkDogSires != null && lnkDogSires.Count > 0)
            {
                foreach (sss.lnkDog_SiresRow row in lnkDogSires)
                {
                    DogSires dogSire = new DogSires(row.Dog_Sire_ID);
                    dogSireList.Add(dogSire);
                }
            }

            return dogSireList;
        }

        public Guid? Insert_Dog_Sire(Guid user_ID)
        {
            DogSiresBL dogSires = new DogSiresBL();
            Guid? newID = null;
            if (Dog_ID != null && Sire_ID != null)
                newID = dogSires.Insert_Dog_Sires(Dog_ID, Sire_ID, user_ID);

            return newID;
        }

        public bool Update_Dog_Sire(Guid original_ID, Guid user_ID)
        {
            bool success = false;

            DogSiresBL dogSires = new DogSiresBL();
            success = dogSires.Update_Dog_Sires(original_ID, Dog_ID, Sire_ID, DeleteDogSire, user_ID);

            return success;
        }
    }
}