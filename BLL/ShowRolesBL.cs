using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.sssTableAdapters;
using System.ComponentModel;

namespace BLL
{
    [DataObject]
    class ShowRolesBL
    {
        private lkpShow_RolesTableAdapter _lkpShow_RolesAdapter = null;
        protected lkpShow_RolesTableAdapter adapter
        {
            get
            {
                if (_lkpShow_RolesAdapter == null)
                    _lkpShow_RolesAdapter = new lkpShow_RolesTableAdapter();

                return _lkpShow_RolesAdapter;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public sss.lkpShow_RolesDataTable GetShow_Roles()
        {
            return adapter.GetShow_Roles();
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.lkpShow_RolesDataTable GetShow_RolesByShow_Role_ID(int show_Role_ID)
        {
            return adapter.GetShow_RoleByShow_Role_ID(show_Role_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.lkpShow_RolesDataTable GetShow_RolesByShow_Role_Description(string show_Role_Description)
        {
            return adapter.GetShow_RolesByShow_Role_Description(show_Role_Description);
        }
    }
}
