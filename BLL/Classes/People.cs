using System;
using System.Collections.Generic;
using System.Web;
using DAL;
using DAL.sssTableAdapters;

namespace BLL
{
    public class People
    {
        private sss.tblPeopleDataTable tblPeople = null;

        private Guid _person_ID;
        public Guid Person_ID
        {
            get { return _person_ID; }
            set { _person_ID = value; }
        }

        private string _person_Title = null;
        public string Person_Title
        {
            get { return _person_Title; }
            set { _person_Title = value; }
        }

        private string _person_Surname = null;
        public string Person_Surname
        {
            get { return _person_Surname; }
            set { _person_Surname = value; }
        }

        private string _person_Forname = null;
        public string Person_Forename
        {
            get { return _person_Forname; }
            set { _person_Forname = value; }
        }

        private Guid? _address_ID = null;
        public Guid? Address_ID
        {
            get { return _address_ID; }
            set { _address_ID = value; }
        }

        private string _person_Mobile = null;
        public string Person_Mobile
        {
            get { return _person_Mobile; }
            set { _person_Mobile = value; }
        }

        private string _person_Landline = null;
        public string Person_Landline
        {
            get { return _person_Landline; }
            set { _person_Landline = value; }
        }

        private string _person_Email = null;
        public string Person_Email
        {
            get { return _person_Email; }
            set { _person_Email = value; }
        }
        private string _person_FullName;
        public string Person_FullName
        {
            get
            {
                string title = null;
                string forename = null;
                string surname = null;
                if (!string.IsNullOrEmpty(Person_Title))
                    title = Person_Title + " ";
                if (!string.IsNullOrEmpty(Person_Forename))
                    forename = Person_Forename + " ";
                if (!string.IsNullOrEmpty(Person_Surname))
                    surname = Person_Surname;
                return string.Format("{0}{1}{2}", title, forename, surname);
            }
        }

        private bool _deletePerson = false;
        public bool DeletePerson
        {
            get { return _deletePerson; }
            set { _deletePerson = value; }
        }

        public People()
        {

        }

        public People(Guid person_ID)
        {
            PeopleBL people = new PeopleBL();
            tblPeople = people.GetPersonByPerson_ID(person_ID);

            Person_ID = person_ID;
            if (!tblPeople[0].IsPerson_TitleNull())
                Person_Title = tblPeople[0].Person_Title;
            if (!tblPeople[0].IsPerson_SurnameNull())
                Person_Surname = tblPeople[0].Person_Surname;
            if (!tblPeople[0].IsPerson_ForenameNull())
                Person_Forename = tblPeople[0].Person_Forename;
            if (!tblPeople[0].IsAddress_IDNull())
                Address_ID = tblPeople[0].Address_ID;
            if (!tblPeople[0].IsPerson_MobileNull())
                Person_Mobile = tblPeople[0].Person_Mobile;
            if (!tblPeople[0].IsPerson_LandlineNull())
                Person_Landline = tblPeople[0].Person_Landline;
            if (!tblPeople[0].IsPerson_EmailNull())
                Person_Email = tblPeople[0].Person_Email;
        }

        public List<People> GetPeople()
        {
            List<People> peopleList = new List<People>();
            PeopleBL people = new PeopleBL();
            tblPeople = people.GetPeople();

            if (tblPeople != null && tblPeople.Count > 0)
            {
                foreach (sss.tblPeopleRow row in tblPeople)
                {
                    People person = new People(row.Person_ID);
                    peopleList.Add(person);
                }
            }

            return peopleList;
        }

        public List<People> GetPeopleByAddress_ID(Guid address_ID)
        {
            List<People> peopleList = new List<People>();
            PeopleBL people = new PeopleBL();
            tblPeople = people.GetPeopleByAddress_ID(address_ID);

            if (tblPeople != null && tblPeople.Count > 0)
            {
                foreach (sss.tblPeopleRow row in tblPeople)
                {
                    People person = new People(row.Person_ID);
                    peopleList.Add(person);
                }
            }

            return peopleList;
        }

        public List<People> GetPeopleByPerson_Forename(string person_Forename)
        {
            List<People> peopleList = new List<People>();
            PeopleBL people = new PeopleBL();
            tblPeople = people.GetPeopleByPerson_Forename(person_Forename);

            if (tblPeople != null && tblPeople.Count > 0)
            {
                foreach (sss.tblPeopleRow row in tblPeople)
                {
                    People person = new People(row.Person_ID);
                    peopleList.Add(person);
                }
            }

            return peopleList;
        }

        public List<People> GetPeopleByPerson_Surname(string person_Surname)
        {
            List<People> peopleList = new List<People>();
            PeopleBL people = new PeopleBL();
            tblPeople = people.GetPeopleByPerson_Surname(person_Surname);

            if (tblPeople != null && tblPeople.Count > 0)
            {
                foreach (sss.tblPeopleRow row in tblPeople)
                {
                    People person = new People(row.Person_ID);
                    peopleList.Add(person);
                }
            }

            return peopleList;
        }

        public Guid? Insert_Person(Guid user_ID)
        {
            PeopleBL people = new PeopleBL();
            Guid? newID = people.Insert_People(Person_Title, Person_Surname, Person_Forename, Address_ID, Person_Mobile,
                Person_Landline, Person_Email, user_ID);

            return newID;
        }

        public bool Update_Person(Guid person_ID, Guid user_ID)
        {
            bool success = false;

            PeopleBL people = new PeopleBL();
            success = people.Update_People(person_ID, Person_Title, Person_Surname, Person_Forename, Address_ID, Person_Mobile,
                Person_Landline, Person_Email, DeletePerson, user_ID);

            return success;
        }
    }
}