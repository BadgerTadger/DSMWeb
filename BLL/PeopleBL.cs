using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.sssTableAdapters;
using System.ComponentModel;

namespace BLL
{
    [DataObject]
    class PeopleBL
    {
        private tblPeopleTableAdapter _tblPeopleAdapter = null;
        protected tblPeopleTableAdapter adapter
        {
            get
            {
                if (_tblPeopleAdapter == null)
                    _tblPeopleAdapter = new tblPeopleTableAdapter();

                return _tblPeopleAdapter;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public sss.tblPeopleDataTable GetPeople()
        {
            return adapter.GetPeople();
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblPeopleDataTable GetPersonByPerson_ID(Guid person_ID)
        {
            return adapter.GetPersonByPerson_ID(person_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblPeopleDataTable GetPeopleByAddress_ID(Guid address_ID)
        {
            return adapter.GetPeopleByAddress_ID(address_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblPeopleDataTable GetPeopleByPerson_Forename(string person_Forename)
        {
            return adapter.GetPeopleLikePerson_Forename(person_Forename);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblPeopleDataTable GetPeopleByPerson_Surname(string person_Surname)
        {
            return adapter.GetPeopleLikePerson_Surname(person_Surname);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public Guid? Insert_People(string person_Title, string person_Surname, string person_Forename, Guid? address_ID, string person_Mobile,
            string person_Landline, string person_Email, Guid user_ID)
        {
            Guid? newID = (Guid?)adapter.Insert_People(person_Title, person_Surname, person_Forename, address_ID, person_Mobile,
                person_Landline, person_Email, user_ID);

            return newID;
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public bool Update_People(Guid original_ID, string person_Title, string person_Surname, string person_Forename, Guid? address_ID, string person_Mobile,
            string person_Landline, string person_Email, bool? deleted, Guid user_ID)
        {
            try
            {
                adapter.Update_People(original_ID, person_Title, person_Surname, person_Forename, address_ID, person_Mobile, person_Landline,
                    person_Email, deleted, user_ID);

                return true;
            }
            catch
            {
                ApplicationException ae = new ApplicationException("Failed to update Person");

                return false;
            }
        }
    }
}
