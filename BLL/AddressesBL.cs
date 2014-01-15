using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.sssTableAdapters;
using System.ComponentModel;

namespace BLL
{
    [DataObject]
    class AddressesBL
    {
        private tblAddressesTableAdapter _tblAddressesAdapter = null;
        protected tblAddressesTableAdapter adapter
        {
            get
            {
                if (_tblAddressesAdapter == null)
                    _tblAddressesAdapter = new tblAddressesTableAdapter();

                return _tblAddressesAdapter;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public sss.tblAddressesDataTable GetAddresses()
        {
            return adapter.GetAddresses();
        }


        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblAddressesDataTable GetAddressByAddress_ID(Guid address_ID)
        {
            return adapter.GetAddressByAddress_ID(address_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblAddressesDataTable GetAddressesLikeAddress_1(string address_1)
        {
            return adapter.GetAddressesLikeAddress_1(address_1);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblAddressesDataTable GetAddressesLikeAddress_2(string address_2)
        {
            return adapter.GetAddressesLikeAddress_2(address_2);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblAddressesDataTable GetAddressesLikeAddress_Town(string address_Town)
        {
            return adapter.GetAddressesLikeAddress_Town(address_Town);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblAddressesDataTable GetAddressesLikeAddress_City(string address_City)
        {
            return adapter.GetAddressesLikeAddress_City(address_City);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblAddressesDataTable GetAddressesLikeAddress_County(string address_County)
        {
            return adapter.GetAddressesLikeAddress_County(address_County);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblAddressesDataTable GetAddressesLikeAddress_Postcode(string address_Postcode)
        {
            return adapter.GetAddressesLikeAddress_Postcode(address_Postcode);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public Guid? Insert_Address(string address_1, string address_2, string address_Town,
            string address_City, string address_County, string address_Postcode, Guid user_ID)
        {
            Guid? newID = null;
            newID = (Guid?)adapter.Insert_Address(address_1, address_2, address_Town, address_City, address_County, address_Postcode, user_ID);

            return newID;
        }


        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public bool Update_Address(Guid original_ID, string address_1, string address_2, string address_Town,
            string address_City, string address_County, string address_Postcode, bool deleted, Guid user_ID)
        {
            try
            {
                adapter.Update_Address(original_ID, address_1, address_2, address_Town, address_City,
                    address_County, address_Postcode, deleted, user_ID);

                return true;
            }
            catch
            {
                ApplicationException ae = new ApplicationException("Failed to update Address");

                return false;
            }
        }
    }
}
