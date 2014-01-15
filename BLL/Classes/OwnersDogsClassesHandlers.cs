using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.sssTableAdapters;

namespace BLL
{
    public class OwnersDogsClassesHandlers
    {
        private sss.tblOwnersDogsClassesHandlersDataTable tblOwnersDogsClassesHandlers = null;

        private Guid _dog_Class_ID;
        public Guid Dog_Class_ID
        {
            get {return _dog_Class_ID;}
            set {_dog_Class_ID=value;}
        }
        private Guid _owner_ID;
        public Guid Owner_ID
        {
            get {return _owner_ID;}
            set {_owner_ID=value;}
        }
        private Guid _handler_ID;
        public Guid Handler_ID
        {
            get {return _handler_ID;}
            set {_handler_ID=value;}
        }
        private string _owner = null;
        public string Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }
        private string _dog_KC_Name = null;
        public string Dog_KC_Name
        {
            get { return _dog_KC_Name; }
            set { _dog_KC_Name = value; }
        }
        private string _class = null;
        public string Class
        {
            get { return _class; }
            set { _class = value; }
        }
        private string _handler = null;
        public string Handler
        {
            get { return _handler; }
            set { _handler = value; }
        }

        public List<OwnersDogsClassesHandlers> GetOwnersDogsClassesHandlers(Guid owner_ID)
        {
            List<OwnersDogsClassesHandlers> ownersDogsClassesHandlersList = new List<OwnersDogsClassesHandlers>();
            OwnersDogsClassesHandlersBL ownersDogsClassesHandlers = new OwnersDogsClassesHandlersBL();
            tblOwnersDogsClassesHandlers = ownersDogsClassesHandlers.GetOwnersDogsClassesHandlers(owner_ID);

            if (tblOwnersDogsClassesHandlers != null && tblOwnersDogsClassesHandlers.Count > 0)
            {
                foreach (sss.tblOwnersDogsClassesHandlersRow row in tblOwnersDogsClassesHandlers)
                {
                    OwnersDogsClassesHandlers oDCH = new OwnersDogsClassesHandlers();
                    oDCH.Dog_Class_ID = row.Dog_Class_ID;
                    oDCH.Owner_ID = row.Owner_ID;
                    oDCH.Handler_ID = row.Handler_ID;
                    oDCH.Owner = row.Owner;
                    oDCH.Dog_KC_Name = row.Dog_KC_Name;
                    oDCH.Class = row.Class;
                    oDCH.Handler = row.Handler;
                    ownersDogsClassesHandlersList.Add(oDCH);
                }
            }
            return ownersDogsClassesHandlersList;
        }
        public bool PopulateOwnersDogsClassesHandlers(Guid owner_ID)
        {
            bool success = false;

            OwnersDogsClassesHandlersBL ownersDogsClassesHandlers = new OwnersDogsClassesHandlersBL();
            success = ownersDogsClassesHandlers.PopulateOwnersDogsClassesHandlers(owner_ID);

            return success;
        }
    }
}
