using System;
using System.Collections.Generic;
using System.Web;
using DAL;
using DAL.sssTableAdapters;

namespace BLL
{
    public class Dogs
    {
        private sss.tblDogsDataTable tblDogs = null;

        private Guid _dog_ID;
        public Guid Dog_ID
        {
            get { return _dog_ID; }
            set { _dog_ID = value; }
        }
        private bool _isDog_KC_NameNull;
        public bool IsDog_KC_NameNull
        {
            get { return _isDog_KC_NameNull; }
            set { _isDog_KC_NameNull = value; }
        }
        private string _dog_KC_Name = null;
        public string Dog_KC_Name
        {
            get { return _dog_KC_Name; }
            set { _dog_KC_Name = value; }
        }
        private bool _isDog_Pet_NameNull;
        public bool IsDog_Pet_NameNull
        {
            get { return _isDog_Pet_NameNull; }
            set { _isDog_Pet_NameNull = value; }
        }
        private string _dog_Pet_Name = null;
        public string Dog_Pet_Name
        {
            get { return _dog_Pet_Name; }
            set { _dog_Pet_Name = value; }
        }
        private bool _isDog_Breed_IDNull;
        public bool IsDog_Breed_IDNull
        {
            get { return _isDog_Breed_IDNull; }
            set { _isDog_Breed_IDNull = value; }
        }
        private int? _dog_Breed_ID = null;
        public int? Dog_Breed_ID
        {
            get { return _dog_Breed_ID; }
            set { _dog_Breed_ID = value; }
        }
        private string _dog_Breed_Description;
        public string Dog_Breed_Description
        {
            get { return _dog_Breed_Description; }
            set { _dog_Breed_Description = value; }
        }
        private bool _isDog_Gender_IDNull;
        public bool IsDog_Gender_IDNull
        {
            get { return _isDog_Gender_IDNull; }
            set { _isDog_Gender_IDNull = value; }
        }
        private int? _dog_Gender_ID = null;
        public int? Dog_Gender_ID
        {
            get { return _dog_Gender_ID; }
            set { _dog_Gender_ID = value; }
        }
        private string _dog_Gender;
        public string Dog_Gender
        {
            get { return _dog_Gender; }
            set { _dog_Gender = value; }
        }
        private bool _isReg_NoNull;
        public bool IsReg_NoNull
        {
            get { return _isReg_NoNull; }
            set { _isReg_NoNull = value; }
        }
        private string _reg_No = null;
        public string Reg_No
        {
            get { return _reg_No; }
            set { _reg_No = value; }
        }
        private bool _isDate_Of_BirthNull;
        public bool IsDate_Of_BirthNull
        {
            get { return _isDate_Of_BirthNull; }
            set { _isDate_Of_BirthNull = value; }
        }
        private DateTime? _date_Of_Birth = null;
        public DateTime? Date_Of_Birth
        {
            get { return _date_Of_Birth; }
            set { _date_Of_Birth = value; }
        }
        private bool _isYear_Of_BirthNull;
        public bool IsYear_Of_BirthNull
        {
            get { return _isYear_Of_BirthNull; }
            set { _isYear_Of_BirthNull = value; }
        }
        private short? _year_Of_Birth = null;
        public short? Year_Of_Birth
        {
            get { return _year_Of_Birth; }
            set { _year_Of_Birth = value; }
        }
        private bool _isMerit_PointsNull;
        public bool IsMerit_PointsNull
        {
            get { return _isMerit_PointsNull; }
            set { _isMerit_PointsNull = value; }
        }
        private short? _merit_Points = null;
        public short? Merit_Points
        {
            get { return _merit_Points; }
            set { _merit_Points = value; }
        }
        private bool _isNLWUNull;
        public bool IsNLWUNull
        {
            get { return _isNLWUNull; }
            set { _isNLWUNull = value; }
        }
        private bool? _nLWU = null;
        public bool? NLWU
        {
            get { return _nLWU; }
            set { _nLWU = value; }
        }
        private bool? _deleteDog = null;
        public bool? DeleteDog
        {
            get { return _deleteDog; }
            set { _deleteDog = value; }
        }

        public Dogs()
        {

        }

        public Dogs(Guid dog_ID)
        {
            DogsBL dogs = new DogsBL();
            tblDogs = dogs.GetDogsByDog_ID(dog_ID);

            Dog_ID = dog_ID;
            IsDog_KC_NameNull=tblDogs[0].IsDog_KC_NameNull();
            if (!IsDog_KC_NameNull)
                Dog_KC_Name = tblDogs[0].Dog_KC_Name;
            IsDog_Pet_NameNull=tblDogs[0].IsDog_Pet_NameNull();
            if (!IsDog_Pet_NameNull)
                Dog_Pet_Name = tblDogs[0].Dog_Pet_Name;
            IsDog_Breed_IDNull = tblDogs[0].IsDog_Breed_IDNull();
            if (!IsDog_Breed_IDNull)
                Dog_Breed_ID = tblDogs[0].Dog_Breed_ID;
            IsDog_Gender_IDNull = tblDogs[0].IsDog_Gender_IDNull();
            if (!IsDog_Gender_IDNull)
                Dog_Gender_ID = tblDogs[0].Dog_Gender_ID;
            IsReg_NoNull = tblDogs[0].IsReg_NoNull();
            if (!IsReg_NoNull)
                Reg_No = tblDogs[0].Reg_No;
            IsDate_Of_BirthNull = tblDogs[0].IsDate_Of_BirthNull();
            if (!IsDate_Of_BirthNull)
                Date_Of_Birth = tblDogs[0].Date_Of_Birth;
            IsYear_Of_BirthNull = tblDogs[0].IsYear_Of_BirthNull();
            if (!IsYear_Of_BirthNull)
                Year_Of_Birth = tblDogs[0].Year_Of_Birth;
            IsMerit_PointsNull = tblDogs[0].IsMerit_PointsNull();
            if (!IsMerit_PointsNull)
                Merit_Points = tblDogs[0].Merit_Points;
            IsNLWUNull = tblDogs[0].IsNLWUNull();
            if (!IsNLWUNull)
                NLWU = tblDogs[0].NLWU;
        }

        public List<Dogs> GetDogs()
        {
            List<Dogs> dogList = new List<Dogs>();
            DogsBL dogs = new DogsBL();
            tblDogs = dogs.GetDogs();

            if (tblDogs != null && tblDogs.Count > 0)
            {
                foreach (sss.tblDogsRow row in tblDogs)
                {
                    Dogs dog = new Dogs(row.Dog_ID);
                    dogList.Add(dog);
                }
            }
            return dogList;
        }

        public List<Dogs> GetDogsLikeDog_KC_Name(string dog_KC_Name)
        {
            List<Dogs> dogList = new List<Dogs>();
            DogsBL dogs = new DogsBL();
            tblDogs = dogs.GetDogsLikeDog_KC_Name(dog_KC_Name);

            if (tblDogs != null && tblDogs.Count > 0)
            {
                foreach (sss.tblDogsRow row in tblDogs)
                {
                    Dogs dog = new Dogs(row.Dog_ID);
                    dogList.Add(dog);
                }
            }
            return dogList;
        }

        public List<Dogs> GetDogsLikeDog_Pet_Name(string dog_Pet_Name)
        {
            List<Dogs> dogList = new List<Dogs>();
            DogsBL dogs = new DogsBL();
            tblDogs = dogs.GetDogsLikeDog_Pet_Name(dog_Pet_Name);

            if (tblDogs != null && tblDogs.Count > 0)
            {
                foreach (sss.tblDogsRow row in tblDogs)
                {
                    Dogs dog = new Dogs(row.Dog_ID);
                    dogList.Add(dog);
                }
            }
            return dogList;
        }

        public List<Dogs> GetDogsByDog_Breed_ID(List<DogBreeds> lkpDogBreeds)
        {
            string dog_Breed_IDs = null;
            foreach (DogBreeds dog_Breed in lkpDogBreeds)
            {
                dog_Breed_IDs += dog_Breed.Dog_Breed_ID + ", ";
            }
            string Breed_IDs = dog_Breed_IDs.Substring(0, dog_Breed_IDs.Length - 2);

            List<Dogs> dogList = new List<Dogs>();
            DogsBL dogs = new DogsBL();
            tblDogs = dogs.GetDogsWhereBreed_IDInList(Breed_IDs);

            if (tblDogs != null && tblDogs.Count > 0)
            {
                foreach (sss.tblDogsRow row in tblDogs)
                {
                    Dogs dog = new Dogs(row.Dog_ID);
                    dogList.Add(dog);
                }
            }
            return dogList;
        }

        public Guid? Insert_Dog(Guid user_ID)
        {
            DogsBL dogs = new DogsBL();
            Guid? newID = (Guid?)dogs.Insert_Dogs(Dog_KC_Name, Dog_Pet_Name, Dog_Breed_ID, Dog_Gender_ID,
                Reg_No, Date_Of_Birth, Year_Of_Birth, Merit_Points, NLWU, user_ID);

            return newID;
        }

        public bool Update_Dog(Guid dog_ID, Guid user_ID)
        {
            bool success = false;

            DogsBL dogs = new DogsBL();
            success = dogs.Update_Dogs(dog_ID, Dog_KC_Name, Dog_Pet_Name, Dog_Breed_ID, Dog_Gender_ID,
                Reg_No, Date_Of_Birth, Year_Of_Birth, Merit_Points, NLWU, DeleteDog, user_ID);

            return success;
        }
    }

    public class DogList
    {
        private List<Dogs> _myDogList;
        public List<Dogs> MyDogList
        {
            get { return _myDogList; }
            set { _myDogList = value; }
        }

        public DogList()
        {
            GetDogList();
        }
        public List<Dogs> GetDogList()
        {
            return MyDogList;
        }
        public int AddDog(Dogs dog)
        {
            if (MyDogList == null)
                MyDogList = new List<Dogs>();
            bool foundDog = false;
            foreach (Dogs d in MyDogList)
            {
                if (d.Dog_ID == dog.Dog_ID)
                    foundDog = true;
            }
            if (!foundDog)
                MyDogList.Add(dog);

            return MyDogList.Count;
        }
        public int DeleteDog(int dog)
        {
            if (MyDogList == null)
                MyDogList = new List<Dogs>();
            MyDogList.RemoveAt(dog);
            return MyDogList.Count;
        }
        public int ClearDogList()
        {
            if (MyDogList == null)
                MyDogList = new List<Dogs>();
            MyDogList.Clear();
            return MyDogList.Count;
        }
        public void SortDogList()
        {
            if (MyDogList != null)
                MyDogList.Sort(delegate(Dogs d1, Dogs d2) { return d1.Dog_KC_Name.CompareTo(d2.Dog_KC_Name); });
        }
    }
}