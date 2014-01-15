using System;
using System.Collections.Generic;
using System.Web;
using DAL;
using DAL.sssTableAdapters;

namespace BLL
{
    public class UserPerson
    {
        private sss.lnkUser_PersonDataTable lnkUserPerson = null;

        private Guid _user_Person_ID;
        public Guid User_Person_ID
        {
            get { return _user_Person_ID; }
            set { _user_Person_ID = value; }
        }
        private Guid _user_ID;
        public Guid User_ID
        {
            get { return _user_ID; }
            set { _user_ID = value; }
        }

        private Guid _person_ID;
        public Guid Person_ID
        {
            get { return _person_ID; }
            set { _person_ID = value; }
        }

        private bool _deleteUserPerson = false;
        public bool DeleteUserPerson
        {
            get { return _deleteUserPerson; }
            set { _deleteUserPerson = value; }
        }

        public UserPerson()
        {

        }

        public UserPerson(Guid user_Person_ID)
        {
            UserPersonBL userPerson = new UserPersonBL();
            lnkUserPerson = userPerson.GetUser_PersonByUser_Person_ID(user_Person_ID);

            User_Person_ID = user_Person_ID;
            User_ID = lnkUserPerson[0].User_ID;
            Person_ID = lnkUserPerson[0].Person_ID;
        }

        public List<UserPerson> GetUser_PersonByUser_ID(Guid user_ID)
        {
            List<UserPerson> userPersonList = new List<UserPerson>();
            UserPersonBL person = new UserPersonBL();
            lnkUserPerson = person.GetUser_PersonByUser_ID(user_ID);

            if (lnkUserPerson != null && lnkUserPerson.Count > 0)
            {
                foreach (sss.lnkUser_PersonRow row in lnkUserPerson)
                {
                    UserPerson userPerson = new UserPerson(row.User_Person_ID);
                    userPersonList.Add(userPerson);
                }
            }

            return userPersonList;
        }

        public List<UserPerson> GetUser_PersonByPerson_ID(Guid person_ID)
        {
            List<UserPerson> userPersonList = new List<UserPerson>();
            UserPersonBL person = new UserPersonBL();
            lnkUserPerson = person.GetUser_PersonByUser_Person_ID(person_ID);

            if (lnkUserPerson != null && lnkUserPerson.Count > 0)
            {
                foreach (sss.lnkUser_PersonRow row in lnkUserPerson)
                {
                    UserPerson userPerson = new UserPerson(row.User_Person_ID);
                    userPersonList.Add(userPerson);
                }
            }

            return userPersonList;
        }

        public Guid? Insert_User_Person(Guid userID)
        {
            UserPersonBL userPerson = new UserPersonBL();
            Guid? newID = (Guid?)userPerson.Insert_User_Person(User_ID, Person_ID, userID);

            return newID;
        }

        public bool Update_User_Person(Guid original_ID, Guid userID)
        {
            bool success = false;

            UserPersonBL userPerson = new UserPersonBL();
            success = userPerson.Update_User_Person(original_ID, User_ID, Person_ID, DeleteUserPerson, userID);

            return success;
        }
    }
}