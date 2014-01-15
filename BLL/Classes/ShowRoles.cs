using System;
using System.Collections.Generic;
using System.Web;
using DAL;
using DAL.sssTableAdapters;

namespace BLL
{
    public class ShowRoles
    {
        public sss.lkpShow_RolesDataTable lkpShowRoles = null;

        private int _show_Role_ID;
        public int Show_Role_ID
        {
            get { return _show_Role_ID; }
            set { _show_Role_ID = value; }
        }
        private string _description = null;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public ShowRoles()
        {
            ShowRolesBL showRoles = new ShowRolesBL();
            lkpShowRoles = showRoles.GetShow_Roles();
        }

        public ShowRoles(int show_Role_ID)
        {
            ShowRolesBL showRoles = new ShowRolesBL();
            lkpShowRoles = showRoles.GetShow_RolesByShow_Role_ID(show_Role_ID);

            Show_Role_ID = show_Role_ID;
            Description = lkpShowRoles[0].Show_Role_Description;
        }
    }
}