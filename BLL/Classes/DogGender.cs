using System;
using System.Collections.Generic;
using System.Web;
using DAL;
using DAL.sssTableAdapters;

namespace BLL
{
    public class DogGender
    {
        public sss.lkpDog_GenderDataTable lkpDogGender = null;

        private int _dog_Gender_ID;
        public int Dog_Gender_ID
        {
            get { return _dog_Gender_ID; }
            set { _dog_Gender_ID = value; }
        }

        private string _description = null;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public DogGender()
        {
            DogGenderBL dogGender = new DogGenderBL();
            lkpDogGender = dogGender.GetDog_Gender();
        }

        public DogGender(int dog_Gender_ID)
        {
            DogGenderBL dogGender = new DogGenderBL();
            lkpDogGender = dogGender.GetDog_GenderByDog_Gender_ID(dog_Gender_ID);

            Dog_Gender_ID = dog_Gender_ID;
            Description = lkpDogGender[0].Dog_Gender;
        }

        public List<DogGender> GetDog_Gender()
        {
            List<DogGender> dogGenderList = new List<DogGender>();
            DogGenderBL dogGender = new DogGenderBL();
            lkpDogGender = dogGender.GetDog_Gender();

            if (lkpDogGender != null && lkpDogGender.Count > 0)
            {
                foreach (sss.lkpDog_GenderRow row in lkpDogGender)
                {
                    DogGender gender = new DogGender(row.Dog_Gender_ID);
                    dogGenderList.Add(gender);
                }
            }
            return dogGenderList;
        }
    }
}