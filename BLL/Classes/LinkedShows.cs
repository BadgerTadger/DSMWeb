using System;
using System.Collections.Generic;
using System.Web;
using DAL;
using DAL.sssTableAdapters;

namespace BLL
{
    public class LinkedShows
    {
        private sss.lnkLinked_ShowsDataTable lnkLinkedShows = null;

        private Guid _linked_Show_ID;
        public Guid Linked_Show_ID
        {
            get { return _linked_Show_ID; }
            set { _linked_Show_ID = value; }
        }

        private Guid _parent_Show_ID;
        public Guid Parent_Show_ID
        {
            get { return _parent_Show_ID; }
            set { _parent_Show_ID = value; }
        }

        private Guid _child_Show_ID;
        public Guid Child_Show_ID
        {
            get { return _child_Show_ID; }
            set { _child_Show_ID = value; }
        }

        private bool _deleteLinkedShow = false;
        public bool DeleteLinkedShow
        {
            get { return _deleteLinkedShow; }
            set { _deleteLinkedShow = value; }
        }

        private DateTime? _parent_Show_Opens = null;
        public DateTime? Parent_Show_Opens
        {
            get { return _parent_Show_Opens; }
            set { _parent_Show_Opens = value; }
        }

        private string _child_Show_Name = null;
        public string Child_Show_Name
        {
            get { return _child_Show_Name; }
            set { _child_Show_Name = value; }
        }

        private DateTime? _child_Show_Opens = null;
        public DateTime? Child_Show_Opens
        {
            get { return _child_Show_Opens; }
            set { _child_Show_Opens = value; }
        }

        private string _parent_Show_Name = null;
        public string Parent_Show_Name
        {
            get { return _parent_Show_Name; }
            set { _parent_Show_Name = value; }
        }

        public LinkedShows()
        {

        }

        public LinkedShows(Guid linked_Show_ID)
        {
            LinkedShowsBL linkedShows = new LinkedShowsBL();
            lnkLinkedShows = linkedShows.GetLinked_ShowByLinked_Show_ID(linked_Show_ID);

            Linked_Show_ID = linked_Show_ID;
            Parent_Show_ID = lnkLinkedShows[0].Parent_Show_ID;
            Child_Show_ID = lnkLinkedShows[0].Child_Show_ID;
        }

        public List<LinkedShows> GetLinked_Shows()
        {
            List<LinkedShows> linkedShowList = new List<LinkedShows>();
            LinkedShowsBL linkedShows = new LinkedShowsBL();
            lnkLinkedShows = linkedShows.GetLinked_Shows();

            if (lnkLinkedShows != null && lnkLinkedShows.Count > 0)
            {
                foreach (sss.lnkLinked_ShowsRow row in lnkLinkedShows)
                {
                    LinkedShows linkedShow = new LinkedShows(row.Linked_Show_ID);
                    linkedShowList.Add(linkedShow);
                }
            }

            return linkedShowList;
        }

        public List<LinkedShows> GetLinked_ShowsByParent_ID(Guid parent_ID)
        {
            List<LinkedShows> linkedShowList = new List<LinkedShows>();
            LinkedShowsBL linkedShows = new LinkedShowsBL();
            lnkLinkedShows = linkedShows.GetLinked_ShowsByParent_Show_ID(parent_ID);

            if (lnkLinkedShows != null && lnkLinkedShows.Count > 0)
            {
                foreach (sss.lnkLinked_ShowsRow row in lnkLinkedShows)
                {
                    LinkedShows linkedShow = new LinkedShows(row.Linked_Show_ID);
                    linkedShowList.Add(linkedShow);
                }
            }

            return linkedShowList;
        }

        public List<LinkedShows> GetLinked_ShowsByChild_ID(Guid child_ID)
        {
            List<LinkedShows> linkedShowList = new List<LinkedShows>();
            LinkedShowsBL linkedShows = new LinkedShowsBL();
            lnkLinkedShows = linkedShows.GetLinked_ShowByChild_Show_ID(child_ID);

            if (lnkLinkedShows != null && lnkLinkedShows.Count > 0)
            {
                foreach (sss.lnkLinked_ShowsRow row in lnkLinkedShows)
                {
                    LinkedShows linkedShow = new LinkedShows(row.Linked_Show_ID);
                    linkedShowList.Add(linkedShow);
                }
            }

            return linkedShowList;
        }

        public Guid? Insert_Linked_Shows(Guid user_ID)
        {
            LinkedShowsBL linkedShows = new LinkedShowsBL();
            Guid? newID = linkedShows.Insert_Linked_Shows(Parent_Show_ID, Child_Show_ID, user_ID);

            return newID;
        }

        public bool Update_Linked_Shows(Guid original_ID, Guid user_ID)
        {
            bool success = false;

            LinkedShowsBL linkedShows = new LinkedShowsBL();
            success = linkedShows.Update_Linked_Shows(original_ID, Parent_Show_ID, Child_Show_ID, DeleteLinkedShow, user_ID);

            return success;
        }
    }
}