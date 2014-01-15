using System;
using System.Collections.Generic;
using System.Web;
using DAL;
using DAL.sssTableAdapters;

namespace BLL
{
    public class DogClasses
    {
        private sss.tblDog_ClassesDataTable tblDogClasses = null;

        private Guid? _dog_Class_ID = null;
        public Guid? Dog_Class_ID
        {
            get { return _dog_Class_ID; }
            set { _dog_Class_ID = value; }
        }
        private bool _isEntrant_IDNull;
        public bool IsEntrant_IDNull
        {
            get { return _isEntrant_IDNull; }
            set { _isEntrant_IDNull = value; }
        }
        private Guid? _entrant_ID = null;
        public Guid? Entrant_ID
        {
            get { return _entrant_ID; }
            set { _entrant_ID = value; }
        }
        private bool _isDog_IDNull;
        public bool IsDog_IDNull
        {
            get { return _isDog_IDNull; }
            set { _isDog_IDNull = value; }
        }
        private Guid? _dog_ID = null;
        public Guid? Dog_ID
        {
            get { return _dog_ID; }
            set { _dog_ID = value; }
        }
        private string _dog_KC_Name = null;
        public string Dog_KC_Name
        {
            get { return _dog_KC_Name; }
            set { _dog_KC_Name = value; }
        }
        private bool _isShow_Entry_Class_IDNull;
        public bool IsShow_Entry_Class_IDNull
        {
            get { return _isShow_Entry_Class_IDNull; }
            set { _isShow_Entry_Class_IDNull = value; }
        }
        private Guid? _show_Entry_Class_ID = null;
        public Guid? Show_Entry_Class_ID
        {
            get { return _show_Entry_Class_ID; }
            set { _show_Entry_Class_ID = value; }
        }
        private string _class_Name_Description = null;
        public string Class_Name_Description
        {
            get { return _class_Name_Description; }
            set { _class_Name_Description = value; }
        }
        private bool _isShow_Final_Class_IDNull;
        public bool IsShow_Final_Class_IDNull
        {
            get { return _isShow_Final_Class_IDNull; }
            set { _isShow_Final_Class_IDNull = value; }
        }
        private Guid? _show_Final_Class_ID = null;
        public Guid? Show_Final_Class_ID
        {
            get { return _show_Final_Class_ID; }
            set { _show_Final_Class_ID = value; }
        }
        private bool _isHandler_IDNull;
        public bool IsHandler_IDNull
        {
            get { return _isHandler_IDNull; }
            set { _isHandler_IDNull = value; }
        }
        private Guid? _handler_ID = null;
        public Guid? Handler_ID
        {
            get { return _handler_ID; }
            set { _handler_ID = value; }
        }
        private string _handler_Name;
        public string Handler_Name
        {
            get { return _handler_Name; }
            set { _handler_Name = value; }
        }
        private bool _isRing_NoNull;
        public bool IsRing_NoNull
        {
            get { return _isRing_NoNull; }
            set { _isRing_NoNull = value; }
        }
        private short? _ring_No = null;
        public short? Ring_No
        {
            get { return _ring_No; }
            set { _ring_No = value; }
        }
        private bool _isRunning_OrderNull;
        public bool IsRunning_OrderNull
        {
            get { return _isRunning_OrderNull; }
            set { _isRunning_OrderNull = value; }
        }
        private short? _running_Order = null;
        public short? Running_Order
        {
            get { return _running_Order; }
            set { _running_Order = value; }
        }
        private bool _isSpecial_RequestNull;
        public bool IsSpecial_RequestNull
        {
            get { return _isSpecial_RequestNull; }
            set { _isSpecial_RequestNull = value; }
        }
        private string _special_Request = null;
        public string Special_Request
        {
            get { return _special_Request; }
            set { _special_Request = value; }
        }

        private bool _deleteDogClass = false;
        public bool DeleteDogClass
        {
            get { return _deleteDogClass; }
            set { _deleteDogClass = value; }
        }
        private bool _isNFC = false;
        public bool IsNFC
        {
            get { return _isNFC; }
            set { _isNFC = value; }
        }
        

        public DogClasses()
        {

        }

        public DogClasses(Guid dog_Class_ID)
        {
            DogClassesBL dogClasses = new DogClassesBL();
            tblDogClasses = dogClasses.GetDog_ClassByDog_Class_ID(dog_Class_ID);

            Dog_Class_ID = dog_Class_ID;
            IsEntrant_IDNull = tblDogClasses[0].IsEntrant_IDNull();
            if (!IsEntrant_IDNull)
                Entrant_ID = tblDogClasses[0].Entrant_ID;
            IsDog_IDNull = tblDogClasses[0].IsDog_IDNull();
            if (!IsDog_IDNull)
                Dog_ID = tblDogClasses[0].Dog_ID;
            IsShow_Entry_Class_IDNull = tblDogClasses[0].IsShow_Entry_Class_IDNull();
            if (!IsShow_Entry_Class_IDNull)
                Show_Entry_Class_ID = tblDogClasses[0].Show_Entry_Class_ID;
            IsShow_Final_Class_IDNull = tblDogClasses[0].IsShow_Final_Class_IDNull();
            if (!IsShow_Final_Class_IDNull)
                Show_Final_Class_ID = tblDogClasses[0].Show_Final_Class_ID;
            IsHandler_IDNull = tblDogClasses[0].IsHandler_IDNull();
            if (!IsHandler_IDNull)
                Handler_ID = tblDogClasses[0].Handler_ID;
            IsRing_NoNull = tblDogClasses[0].IsRing_NoNull();
            if (!IsRing_NoNull)
                Ring_No = tblDogClasses[0].Ring_No;
            IsRunning_OrderNull = tblDogClasses[0].IsRunning_OrderNull();
            if (!IsRunning_OrderNull)
                Running_Order = tblDogClasses[0].Running_Order;
            IsSpecial_RequestNull = tblDogClasses[0].IsSpecial_RequestNull();
            if (!IsSpecial_RequestNull)
                Special_Request = tblDogClasses[0].Special_Request;
            if (Show_Entry_Class_ID != null)
            {
                Guid sec_id = new Guid(Show_Entry_Class_ID.ToString());
                ShowEntryClasses sec = new ShowEntryClasses(sec_id);
                if (sec.IsNFC)
                    IsNFC = true;
            }
        }

        public List<DogClasses> GetDog_Classes()
        {
            List<DogClasses> dogClassesList = new List<DogClasses>();
            DogClassesBL dogClasses = new DogClassesBL();
            tblDogClasses = dogClasses.GetDog_Classes();

            if (tblDogClasses != null && tblDogClasses.Count > 0)
            {
                foreach (sss.tblDog_ClassesRow row in tblDogClasses)
                {
                    DogClasses dogClass = new DogClasses(row.Dog_Class_ID);
                    dogClassesList.Add(dogClass);
                }
            }

            return dogClassesList;
        }


        public List<DogClasses> GetDog_ClassesByDog_ID(Guid dog_ID)
        {
            List<DogClasses> dogClassesList = new List<DogClasses>();
            DogClassesBL dogClasses = new DogClassesBL();
            tblDogClasses = dogClasses.GetDog_ClassesByDog_ID(dog_ID);

            if (tblDogClasses != null && tblDogClasses.Count > 0)
            {
                foreach (sss.tblDog_ClassesRow row in tblDogClasses)
                {
                    DogClasses dogClass = new DogClasses(row.Dog_Class_ID);
                    dogClassesList.Add(dogClass);
                }
            }

            return dogClassesList;
        }

        public List<DogClasses> GetDog_ClassesByEntrant_ID(Guid entrant_ID)
        {
            List<DogClasses> dogClassesList = new List<DogClasses>();
            DogClassesBL dogClasses = new DogClassesBL();
            tblDogClasses = dogClasses.GetDog_ClassesByEntrant_ID(entrant_ID);

            if (tblDogClasses != null && tblDogClasses.Count > 0)
            {
                foreach (sss.tblDog_ClassesRow row in tblDogClasses)
                {                    
                    DogClasses dogClass = new DogClasses(row.Dog_Class_ID);
                    dogClassesList.Add(dogClass);
                }
            }

            return dogClassesList;
        }

        public List<DogClasses> GetDog_ClassesByEntrant_ID(Guid entrant_ID, bool excl_NFC)
        {
            List<DogClasses> dogClassesList = new List<DogClasses>();
            DogClassesBL dogClasses = new DogClassesBL();
            tblDogClasses = dogClasses.GetDog_ClassesByEntrant_ID(entrant_ID);

            if (tblDogClasses != null && tblDogClasses.Count > 0)
            {
                foreach (sss.tblDog_ClassesRow row in tblDogClasses)
                {
                    DogClasses dogClass = new DogClasses(row.Dog_Class_ID);
                    if ((excl_NFC && !dogClass.IsNFC) || !excl_NFC)
                        dogClassesList.Add(dogClass);
                }
            }

            return dogClassesList;
        }

        public List<DogClasses> GetDog_ClassesByHandler_ID(Guid handler_ID)
        {
            List<DogClasses> dogClassesList = new List<DogClasses>();
            DogClassesBL dogClasses = new DogClassesBL();
            tblDogClasses = dogClasses.GetDog_ClassesByHandler_ID(handler_ID);

            if (tblDogClasses != null && tblDogClasses.Count > 0)
            {
                foreach (sss.tblDog_ClassesRow row in tblDogClasses)
                {
                    DogClasses dogClass = new DogClasses(row.Dog_Class_ID);
                    dogClassesList.Add(dogClass);
                }
            }

            return dogClassesList;
        }

        public List<DogClasses> GetDog_ClassesByShow_Entry_Class_ID(Guid show_Entry_Class_ID)
        {
            List<DogClasses> dogClassesList = new List<DogClasses>();
            DogClassesBL dogClasses = new DogClassesBL();
            tblDogClasses = dogClasses.GetDog_ClassesByShow_Entry_Class_ID(show_Entry_Class_ID);

            if (tblDogClasses != null && tblDogClasses.Count > 0)
            {
                foreach (sss.tblDog_ClassesRow row in tblDogClasses)
                {
                    DogClasses dogClass = new DogClasses(row.Dog_Class_ID);
                    dogClassesList.Add(dogClass);
                }
            }

            return dogClassesList;
        }

        public List<DogClasses> GetDog_ClassesByShow_Final_Class_ID(Guid show_Final_Class_ID)
        {
            List<DogClasses> dogClassesList = new List<DogClasses>();
            DogClassesBL dogClasses = new DogClassesBL();
            tblDogClasses = dogClasses.GetDog_ClassesByShow_Final_Class_ID(show_Final_Class_ID);

            if (tblDogClasses != null && tblDogClasses.Count > 0)
            {
                foreach (sss.tblDog_ClassesRow row in tblDogClasses)
                {
                    DogClasses dogClass = new DogClasses(row.Dog_Class_ID);
                    dogClassesList.Add(dogClass);
                }
            }

            return dogClassesList;
        }

        public List<DogClasses> GetDog_ClassesByDog_IDAndShow_Entry_Class_ID(Guid dog_ID, Guid show_Entry_Class_ID)
        {
            List<DogClasses> dogClassesList = new List<DogClasses>();
            DogClassesBL dogClasses = new DogClassesBL();
            tblDogClasses = dogClasses.GetDog_ClassesByDog_IDAndShow_Entry_Class_ID(dog_ID, show_Entry_Class_ID);

            if (tblDogClasses != null && tblDogClasses.Count > 0)
            {
                foreach (sss.tblDog_ClassesRow row in tblDogClasses)
                {
                    DogClasses dogClass = new DogClasses(row.Dog_Class_ID);
                    dogClassesList.Add(dogClass);
                }
            }

            return dogClassesList;
        }

        public short GetMaxRunningOrderForClass(Guid show_Final_Class_ID)
        {
            short maxRunningOrder = 0;

            DogClassesBL dogClasses = new DogClassesBL();
            maxRunningOrder = dogClasses.GetMaxRunningOrderForClass(show_Final_Class_ID);

            return maxRunningOrder;
        }
        public int GetEntryCountByShow_Final_Class_ID(Guid show_Final_Class_ID)
        {
            int entryCount = 0;
            DogClassesBL dogClasses = new DogClassesBL();
            entryCount = dogClasses.GetEntryCountByShow_Final_Class_ID(show_Final_Class_ID);

            return entryCount;
        }

        public Guid? Insert_Dog_Class(Guid user_ID)
        {
            DogClassesBL dogClasses = new DogClassesBL();
            Guid? newID = (Guid?)dogClasses.Insert_Dog_Classes(Entrant_ID, Dog_ID, Show_Entry_Class_ID,
                Handler_ID, Special_Request, user_ID);

            return newID;
        }

        public bool Update_Dog_Class(Guid dog_Class_ID, Guid user_ID)
        {
            bool success = false;

            DogClassesBL dogClasses = new DogClassesBL();
            success = dogClasses.Update_Dog_Classes(dog_Class_ID, Entrant_ID, Dog_ID, Show_Entry_Class_ID,
                Show_Final_Class_ID, Handler_ID, Ring_No, Running_Order, Special_Request, DeleteDogClass, user_ID);

            return success;
        }
    }
}