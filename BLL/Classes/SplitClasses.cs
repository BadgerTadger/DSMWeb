using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.sssTableAdapters;
using System.Data;

namespace BLL
{
    public static class SplitClasses
    {
        private static List<EntryClassesCount> _entryClassList;
        private static List<EntryClassesCount> EntryClassList
        {
            get { return _entryClassList; }
            set { _entryClassList = value; }
        }
        private static List<ShowEntryClasses> _showEntryClassList;
        private static List<ShowEntryClasses> ShowEntryClassList
        {
            get { return _showEntryClassList; }
            set { _showEntryClassList = value; }
        }
        private static int _partCount = 0;
        public static int PartCount
        {
            get { return _partCount; }
            set { _partCount = value; }
        }

        public static bool PopulateFinalClassNames()
        {
            short order_By = 0;
            bool success = false;
            EntryClassesCount entryClasses = new EntryClassesCount();
            EntryClassList = entryClasses.GetEntryClassCount();
            if (EntryClassList != null && EntryClassList.Count > 0)
            {
                FinalClassNames clearFinalClassNames = new FinalClassNames();
                bool clearSuccess = clearFinalClassNames.ClearFinalClassNames();
                if (clearSuccess)
                {
                    foreach (EntryClassesCount row in EntryClassList)
                    {
                        if (row.Entries > Constants.MAX_CLASS_SIZE)
                        {
                            int classQty = ClassQty(row.Entries);
                            int partMod = row.Entries % classQty;
                            for (int i = 0; i < classQty; i++)
                            {
                                int partCount = row.Entries / classQty;
                                if (partMod > 0)
                                    partCount += 1;

                                order_By += 1;
                                AddFinalClass(row, i, partCount, order_By);
                                partMod -= 1;
                            }
                        }
                        else
                        {
                            order_By += 1;
                            FinalClassNames finalClassName = new FinalClassNames();
                            finalClassName.Show_Entry_Class_ID = row.Show_Entry_Class_ID;
                            finalClassName.Class_Name_Description = row.Class_Name_Description;
                            finalClassName.Class_No = row.Class_No;
                            finalClassName.Show_Final_Class_Description = row.Class_Name_Description;
                            finalClassName.Entries = row.Entries;
                            finalClassName.OrderBy = order_By;
                            finalClassName.InsertFinalClassNames();
                        }
                    }
                    success = true;
                }
                else
                {
                    success = false;
                }
            }
            return success;
        }

        private static void AddFinalClass(EntryClassesCount row, int part, int partCount, short order_By)
        {
            int newPart = part += 1;
            string newClassDescription = string.Format("{0} Part {1}", row.Class_Name_Description, newPart);
            FinalClassNames finalClassName = new FinalClassNames();
            finalClassName.Show_Entry_Class_ID = row.Show_Entry_Class_ID;
            finalClassName.Class_Name_Description = row.Class_Name_Description;
            finalClassName.Class_No = row.Class_No;
            finalClassName.Show_Final_Class_Description = newClassDescription;
            finalClassName.Entries = (short)partCount;
            finalClassName.OrderBy = order_By;
            finalClassName.InsertFinalClassNames();
        }

        private static int ClassQty(short entries)
        {
            int classCount = entries / Constants.MAX_CLASS_SIZE;

            if (entries % Constants.MAX_CLASS_SIZE > 0)
                classCount += 1;

            return classCount;
        }

        public static List<FinalClassNames> DisplayFinalClassNames()
        {
            FinalClassNames finalClassNames = new FinalClassNames();

            return finalClassNames.GetFinalClassNames();
        }

        public static bool UpdateFinalClassName(short orderBy, string newClassName)
        {
            bool success = false;

            FinalClassNames finalClassName = new FinalClassNames(orderBy);
            finalClassName.Show_Final_Class_Description = newClassName;
            success = finalClassName.UpdateFinalClassNames();

            return success;
        }

        public static bool AllocateDogsToFinalClasses(Guid show_ID, Guid user_ID)
        {
            bool success = false;
            List<ShowEntryClasses> showEntryClassList = new List<ShowEntryClasses>();
            ShowEntryClasses showEntryClasses = new ShowEntryClasses();
            showEntryClassList = showEntryClasses.GetShow_Entry_ClassesByShow_ID(show_ID);
            foreach (ShowEntryClasses showEntryClass in showEntryClassList)
            {
                List<ShowFinalClasses> showFinalClassList = new List<ShowFinalClasses>();
                ShowFinalClasses showFinalClasses = new ShowFinalClasses();
                showFinalClassList = showFinalClasses.GetShow_Final_ClassesByShow_Entry_Class_ID(showEntryClass.Show_Entry_Class_ID);
                if (showFinalClassList != null && showFinalClassList.Count > 0)
                {
                    List<DogClasses> dogClassList = new List<DogClasses>();
                    DogClasses dogClasses = new DogClasses();
                    dogClassList = dogClasses.GetDog_ClassesByShow_Entry_Class_ID(showEntryClass.Show_Entry_Class_ID);
                    if (showFinalClassList.Count == 1)
                    {
                        foreach (DogClasses dogClass in dogClassList)
                        {
                            dogClass.Show_Final_Class_ID = showFinalClassList[0].Show_Final_Class_ID;
                            Guid dog_Class_ID = new Guid(dogClass.Dog_Class_ID.ToString());
                            success = dogClass.Update_Dog_Class(dog_Class_ID, user_ID);
                        }
                    }
                    else
                    {
                        List<ClassParts> classParts = new List<ClassParts>();
                        foreach (ShowFinalClasses showFinalClass in showFinalClassList)
                        {
                            ClassParts classPart = new ClassParts();
                            FinalClassNames finalClassNames = new FinalClassNames(showFinalClass.Show_Final_Class_No);
                            classPart.Show_Final_Class_ID = showFinalClass.Show_Final_Class_ID;
                            classPart.Show_Final_Class_Description = showFinalClass.Show_Final_Class_Description;
                            classPart.MaxDogsInPart = finalClassNames.Entries;
                            classParts.Add(classPart);
                        }
                        List<DogsInClass> allDogsInClass = new List<DogsInClass>();
                        allDogsInClass = AllocateDogsToClassParts(dogClassList, classParts);
                        List<DogClasses> failedUpdateList = new List<DogClasses>();
                        foreach (DogsInClass dog in allDogsInClass)
                        {
                            DogClasses dogClass = new DogClasses(dog.Dog_Class_ID);
                            dogClass.Show_Final_Class_ID = dog.Show_Final_Class_ID;
                            success = dogClass.Update_Dog_Class(dog.Dog_Class_ID, user_ID);
                            if (!success)
                                failedUpdateList.Add(dogClass);
                        }
                    }
                }
                    
            }
            return success;
        }

        public static bool UnAllocateDogsFromFinalClasses(Guid user_ID)
        {
            bool success = false;
            List<EntryClassesCount> entryClassesList = new List<EntryClassesCount>();
            EntryClassesCount entryClasses = new EntryClassesCount();
            entryClassesList = entryClasses.GetEntryClassCount();
            foreach (EntryClassesCount entryClass in entryClassesList)
            {
                List<DogClasses> dogClassList = new List<DogClasses>();
                DogClasses dogClasses = new DogClasses();
                dogClassList = dogClasses.GetDog_ClassesByShow_Entry_Class_ID(entryClass.Show_Entry_Class_ID);
                foreach (DogClasses row in dogClassList)
                {
                    row.Show_Final_Class_ID = null;
                    Guid dog_Class_ID = new Guid(row.Dog_Class_ID.ToString());
                    success = row.Update_Dog_Class(dog_Class_ID, user_ID);
                }
            }
            return success;
        }

        private static List<DogsInClass> AllocateDogsToClassParts(List<DogClasses> dogClassList, List<ClassParts> classParts)
        {
            PartCount = 0;
            List<DogsInClass> allDogsInClass = new List<DogsInClass>();
            foreach (DogClasses dogClass in dogClassList)
            {
                Guid show_Entry_Class_ID = new Guid(dogClass.Show_Entry_Class_ID.ToString());
                List<DogOwners> dogOwnersList = new List<DogOwners>();
                DogOwners dogOwners = new DogOwners();
                Guid dog_ID = new Guid(dogClass.Dog_ID.ToString());
                dogOwnersList = dogOwners.GetDogOwnersByDog_ID(dog_ID);
                foreach (DogOwners owner in dogOwnersList)
                {
                    List<DogOwners> dogOwnerDogList = new List<DogOwners>();
                    DogOwners dogOwnerDogs = new DogOwners();
                    dogOwnerDogList = dogOwnerDogs.GetDogOwnersByOwner_ID(owner.Owner_ID);
                    List<Dogs> ownerDogsInClassList = new List<Dogs>();
                    ownerDogsInClassList = OwnerDogsInCurrentClass(dogOwnerDogList, show_Entry_Class_ID);
                    if (ownerDogsInClassList.Count == 1)
                    {
                        if (!FoundInList(allDogsInClass, ownerDogsInClassList[0].Dog_ID))
                        {
                            Dogs dog = new Dogs(ownerDogsInClassList[0].Dog_ID);
                            DogsInClass dogInClass = new DogsInClass();
                            dogInClass.Dog = dog;
                            dogInClass.Dog_Class_ID = GetDogClassID(dog.Dog_ID, show_Entry_Class_ID);
                            dogInClass.Show_Final_Class_ID = NextPart(classParts);
                            dogInClass.AddToPart = PartCount;
                            allDogsInClass.Add(dogInClass);
                        }
                    }
                    else if (ownerDogsInClassList.Count == 2)
                    {
                        if (!FoundInList(allDogsInClass, ownerDogsInClassList[0].Dog_ID))
                        {
                            Dogs dog1 = new Dogs(ownerDogsInClassList[0].Dog_ID);
                            DogsInClass dogInClass1 = new DogsInClass();
                            dogInClass1.Dog = dog1;
                            dogInClass1.Dog_Class_ID = GetDogClassID(dog1.Dog_ID, show_Entry_Class_ID);
                            dogInClass1.Show_Final_Class_ID = NextPart(classParts);
                            dogInClass1.AddToPart = PartCount;
                            allDogsInClass.Add(dogInClass1);
                        }
                        if (!FoundInList(allDogsInClass, ownerDogsInClassList[1].Dog_ID))
                        {
                            Dogs dog2 = new Dogs(ownerDogsInClassList[1].Dog_ID);
                            DogsInClass dogInClass2 = new DogsInClass();
                            dogInClass2.Dog = dog2;
                            dogInClass2.Dog_Class_ID = GetDogClassID(dog2.Dog_ID, show_Entry_Class_ID);
                            dogInClass2.Show_Final_Class_ID = NextPart(classParts);
                            dogInClass2.AddToPart = PartCount;
                            allDogsInClass.Add(dogInClass2);
                        }
                    }
                    else
                    {
                        foreach (Dogs ownerDog in ownerDogsInClassList)
                        {
                            if (!FoundInList(allDogsInClass, ownerDog.Dog_ID))
                            {
                                Dogs dog = new Dogs(ownerDog.Dog_ID);
                                DogsInClass dogInClass = new DogsInClass();
                                dogInClass.Dog = dog;
                                dogInClass.Dog_Class_ID = GetDogClassID(dog.Dog_ID, show_Entry_Class_ID);
                                dogInClass.Show_Final_Class_ID = NextPart(classParts);
                                dogInClass.AddToPart = PartCount;
                                allDogsInClass.Add(dogInClass);
                            }
                        }
                    }
                }
            }
            return allDogsInClass;
        }

        private static Guid GetDogClassID(Guid dog_ID, Guid show_Entry_Class_ID)
        {
            Guid dog_Class_ID = new Guid();
            DogClasses dogClass = new DogClasses();
            List<DogClasses> dogClassList = dogClass.GetDog_ClassesByDog_IDAndShow_Entry_Class_ID(dog_ID, show_Entry_Class_ID);
            if (dogClassList != null && dogClassList.Count > 0)
            {
                Guid newDog_Class_ID = new Guid(dogClassList[0].Dog_Class_ID.ToString());
                dog_Class_ID = newDog_Class_ID;
            }
            return dog_Class_ID;
        }

        private static Guid NextPart(List<ClassParts> classParts)
        {
            if (PartCount >= classParts.Count)
            {
                PartCount = 0;
            }
            PartCount += 1;

            return classParts[PartCount -1].Show_Final_Class_ID;
        }

        private static bool FoundInList(List<DogsInClass> allDogsInClass, Guid dog_ID)
        {
            bool found = false;

            found = allDogsInClass.Exists(delegate(DogsInClass i) { return i.Dog.Dog_ID == dog_ID; });

            return found;
        }

        private static List<Dogs> OwnerDogsInCurrentClass(List<DogOwners> ownerDogList, Guid show_Entry_Class_ID)
        {
            List<Dogs> ownerDogsInCurrentClass = new List<Dogs>();
            List<Dogs> existsInCurrentClass = new List<Dogs>();
            List<Dogs> ownerDogsNotInCurrentClass = new List<Dogs>();
            foreach (DogOwners dog in ownerDogList)
            {
                DogClasses dc = new DogClasses();
                List<DogClasses> dcList = dc.GetDog_ClassesByDog_ID(dog.Dog_ID);
                if(dcList != null && dcList.Count > 0)
                {
                    foreach (DogClasses dogClassRow in dcList)
                    {
                        Guid dog_ID = new Guid(dogClassRow.Dog_ID.ToString());
                        if (dogClassRow.Show_Entry_Class_ID == show_Entry_Class_ID)
                        {
                            if (!ownerDogsInCurrentClass.Exists(delegate(Dogs i) { return i.Dog_ID == dog_ID; }))
                            {
                                Dogs d = new Dogs(dog_ID);
                                ownerDogsInCurrentClass.Add(d);
                            }
                            else
                            {
                                Dogs d = new Dogs(dog_ID);
                                existsInCurrentClass.Add(d);
                            }
                        }
                        else
                        {
                            Dogs d = new Dogs(dog_ID);
                            ownerDogsNotInCurrentClass.Add(d);
                        }
                    }
                }
            }
            return ownerDogsInCurrentClass;
        }
    }


    public class ClassParts
    {
        public ClassParts()
        {
        }
        private short _partNo = 0;
        public short PartNo
        {
            get { return _partNo;}
            set { _partNo = value;}
        }
        private short _maxDogsInPart = 0;
        public short MaxDogsInPart
        {
            get { return _maxDogsInPart; }
            set { _maxDogsInPart = value; }
        }
        private Guid _show_Final_Class_ID;
        public Guid Show_Final_Class_ID
        {
            get { return _show_Final_Class_ID; }
            set { _show_Final_Class_ID = value; }
        }
        private string _show_Final_Class_Description = null;
        public string Show_Final_Class_Description
        {
            get { return _show_Final_Class_Description; }
            set { _show_Final_Class_Description = value; }
        }
        private short _dogsAddedToPart = 0;
        public short DogsAddedToPart
        {
            get { return _dogsAddedToPart; }
            set { _dogsAddedToPart = value; }
        }
    }
    public class DogsInClass
    {
        public DogsInClass()
        {
        }
        private Guid _dog_Class_ID;
        public Guid Dog_Class_ID
        {
            get { return _dog_Class_ID; }
            set { _dog_Class_ID = value; }
        }
        private Dogs _dog;
        public Dogs Dog
        {
            get { return _dog; }
            set { _dog = value; }
        }
        private Guid _show_Final_Class_ID;
        public Guid Show_Final_Class_ID
        {
            get { return _show_Final_Class_ID; }
            set { _show_Final_Class_ID = value; }
        }
        private string _show_Final_Class_Description = null;
        public string Show_Final_Class_Description
        {
            get { return _show_Final_Class_Description; }
            set { _show_Final_Class_Description = value; }
        }
        private int _addToPart = 0;
        public int AddToPart
        {
            get { return _addToPart; }
            set { _addToPart = value; }
        }
        private int _addedToPart = 0;
        public int AddedToPart
        {
            get { return _addedToPart; }
            set { _addedToPart = value; }
        }
    }
}
