using System;
using System.Collections.Generic;
using System.Web;
using DAL;
using DAL.sssTableAdapters;

namespace BLL
{
    public class DogDams
    {
        private sss.lnkDog_DamsDataTable lnkDogDams = null;

        private Guid _dog_Dam_ID;
        public Guid Dog_Dam_ID
        {
            get { return _dog_Dam_ID; }
            set { _dog_Dam_ID = value; }
        }
        private Guid _dog_ID;
        public Guid Dog_ID
        {
            get { return _dog_ID; }
            set { _dog_ID = value; }
        }
        private Guid _dam_ID;
        public Guid Dam_ID
        {
            get { return _dam_ID; }
            set { _dam_ID = value; }
        }

        private bool _deleteDogDam = false;
        public bool DeleteDogDam
        {
            get { return _deleteDogDam; }
            set { _deleteDogDam = value; }
        }

        public DogDams()
        {

        }

        public DogDams(Guid dog_Dam_ID)
        {
            DogDamsBL dogDams = new DogDamsBL();
            lnkDogDams = dogDams.GetDog_DamByDog_Dam_ID(dog_Dam_ID);

            Dog_Dam_ID = dog_Dam_ID;
            Dog_ID = lnkDogDams[0].Dog_ID;
            Dam_ID = lnkDogDams[0].Dam_ID;
        }

        public List<DogDams> GetDogDamsByDog_ID(Guid dog_ID)
        {
            List<DogDams> dogDamList = new List<DogDams>();
            DogDamsBL dogDams = new DogDamsBL();
            lnkDogDams = dogDams.GetDog_DamByDog_ID(dog_ID);

            if (lnkDogDams != null && lnkDogDams.Count > 0)
            {
                foreach (sss.lnkDog_DamsRow row in lnkDogDams)
                {
                    DogDams dogDam = new DogDams(row.Dog_Dam_ID);
                    dogDamList.Add(dogDam);
                }
            }
            return dogDamList;
        }

        public List<DogDams> GetDogDamsByDam_ID(Guid dam_ID)
        {
            List<DogDams> dogDamList = new List<DogDams>();
            DogDamsBL dogDams = new DogDamsBL();
            lnkDogDams = dogDams.GetDog_DamsByDam_ID(dam_ID);

            if (lnkDogDams != null && lnkDogDams.Count > 0)
            {
                foreach (sss.lnkDog_DamsRow row in lnkDogDams)
                {
                    DogDams dogDam = new DogDams(row.Dog_Dam_ID);
                    dogDamList.Add(dogDam);
                }
            }
            return dogDamList;
        }

        public Guid? Insert_Dog_Dams(Guid user_ID)
        {
            DogDamsBL dogDams = new DogDamsBL();
            Guid? newID = dogDams.Insert_Dog_Dams(Dog_ID, Dam_ID, user_ID);

            return newID;
        }

        public bool Update_Dog_Dams(Guid original_ID, Guid user_ID)
        {
            bool success = false;

            DogDamsBL dogDams = new DogDamsBL();
            success = dogDams.Update_Dog_Dams(original_ID, Dog_ID, Dam_ID, DeleteDogDam, user_ID);

            return success;
        }
    }
}