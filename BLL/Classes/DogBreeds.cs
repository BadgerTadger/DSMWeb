using System;
using System.Collections.Generic;
using System.Web;
using DAL;
using DAL.sssTableAdapters;

namespace BLL
{
    public class DogBreeds
    {
        public sss.lkpDog_BreedsDataTable lkpDogBreeds = null;

        private int _dog_Breed_ID;
        public int Dog_Breed_ID
        {
            get { return _dog_Breed_ID; }
            set { _dog_Breed_ID = value; }
        }

        private string _description = null;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public DogBreeds()
        {
            DogBreedsBL dogBreeds = new DogBreedsBL();
            lkpDogBreeds = dogBreeds.GetDog_Breeds();
        }

        public DogBreeds(int dog_Breed_ID)
        {
            DogBreedsBL dogBreeds = new DogBreedsBL();
            lkpDogBreeds = dogBreeds.GetDog_BreedsByDog_Breed_ID(dog_Breed_ID);

            Dog_Breed_ID = dog_Breed_ID;
            Description = lkpDogBreeds[0].Dog_Breed_Description;
        }

        public List<DogBreeds> GetDog_Breeds()
        {
            List<DogBreeds> dogBreedList = new List<DogBreeds>();
            DogBreedsBL dogBreeds = new DogBreedsBL();
            lkpDogBreeds = dogBreeds.GetDog_Breeds();

            if (lkpDogBreeds != null && lkpDogBreeds.Count > 0)
            {
                DogBreeds firstDogBreed = new DogBreeds();
                firstDogBreed.Dog_Breed_ID = 1;
                firstDogBreed.Description = "Please Select...";
                dogBreedList.Add(firstDogBreed);
                foreach (sss.lkpDog_BreedsRow row in lkpDogBreeds)
                {
                    DogBreeds dogBreed = new DogBreeds(row.Dog_Breed_ID);
                    dogBreedList.Add(dogBreed);
                }
            }

            return dogBreedList;
        }

        public List<DogBreeds> GetDog_BreedsByDog_Breed_Description(string description)
        {
            List<DogBreeds> dogBreedList = new List<DogBreeds>();
            DogBreedsBL dogBreeds = new DogBreedsBL();
            lkpDogBreeds = dogBreeds.GetDog_BreedsByDog_Breed_Description(description);

            if (lkpDogBreeds != null && lkpDogBreeds.Count > 0)
            {
                foreach (sss.lkpDog_BreedsRow row in lkpDogBreeds)
                {
                    DogBreeds dogBreed = new DogBreeds(row.Dog_Breed_ID);
                    dogBreedList.Add(dogBreed);
                }
            }

            return dogBreedList;
        }
        public int? Insert_Dog_Breed(string dog_Breed_Description)
        {
            DogBreedsBL dogBreeds = new DogBreedsBL();
            return dogBreeds.Insert_Dog_Breed(dog_Breed_Description);
        }
    }
}