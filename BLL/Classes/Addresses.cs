using System;
using System.Collections.Generic;
using System.Web;
using DAL;
using DAL.sssTableAdapters;

namespace BLL
{
    public class Addresses
    {
        private sss.tblAddressesDataTable tblAddresses = null;

        private Guid _address_ID;
        public Guid Address_ID
        {
            get { return _address_ID; }
            set { _address_ID = value; }
        }
        private string _address_1 = null;
        public string Address_1
        {
            get { return _address_1; }
            set { _address_1 = value; }
        }

        private string _address_2 = null;
        public string Address_2
        {
            get { return _address_2; }
            set { _address_2 = value; }
        }

        private string _address_Town = null;
        public string Address_Town
        {
            get { return _address_Town; }
            set { _address_Town = value; }
        }

        private string _address_City = null;
        public string Address_City
        {
            get { return _address_City; }
            set { _address_City = value; }
        }

        private string _address_County = null;
        public string Address_County
        {
            get { return _address_County; }
            set { _address_County = value; }
        }

        private string _address_Postcode = null;
        public string Address_Postcode
        {
            get { return _address_Postcode; }
            set { _address_Postcode = value; }
        }

        private bool _deleteAddress = false;
        public bool DeleteAddress
        {
            get { return _deleteAddress; }
            set { _deleteAddress = value; }
        }

        public Addresses()
        {

        }

        public Addresses(Guid address_ID)
        {
            AddressesBL addresses = new AddressesBL();
            tblAddresses = addresses.GetAddressByAddress_ID(address_ID);

            Address_ID = address_ID;
            Address_1 = tblAddresses[0].Address_1;
            if (!tblAddresses[0].IsAddress_2Null())
                Address_2 = tblAddresses[0].Address_2;
            if (!tblAddresses[0].IsAddress_TownNull())
                Address_Town = tblAddresses[0].Address_Town;
            if (!tblAddresses[0].IsAddress_CityNull())
                Address_City = tblAddresses[0].Address_City;
            if (!tblAddresses[0].IsAddress_CountyNull())
                Address_County = tblAddresses[0].Address_County;
            if (!tblAddresses[0].IsAddress_PostcodeNull())
                Address_Postcode = tblAddresses[0].Address_Postcode;
        }

        public List<Addresses> GetAddresses()
        {
            List<Addresses> addressList = new List<Addresses>();
            AddressesBL addresses = new AddressesBL();
            tblAddresses = addresses.GetAddresses();

            if (tblAddresses != null && tblAddresses.Count > 0)
            {
                foreach (sss.tblAddressesRow row in tblAddresses)
                {
                    Addresses address = new Addresses(row.Address_ID);
                    addressList.Add(address);
                }
            }

            return addressList;
        }

        public List<Addresses> GetAddressesLikeAddress_1(string address_1)
        {
            List<Addresses> addressList = new List<Addresses>();
            AddressesBL addresses = new AddressesBL();
            tblAddresses = addresses.GetAddressesLikeAddress_1(address_1);

            if (tblAddresses != null && tblAddresses.Count > 0)
            {
                foreach (sss.tblAddressesRow row in tblAddresses)
                {
                    Addresses address = new Addresses(row.Address_ID);
                    addressList.Add(address);
                }
            }

            return addressList;
        }

        public List<Addresses> GetAddressesLikeAddress_2(string address_2)
        {
            List<Addresses> addressList = new List<Addresses>();
            AddressesBL addresses = new AddressesBL();
            tblAddresses = addresses.GetAddressesLikeAddress_2(address_2);

            if (tblAddresses != null && tblAddresses.Count > 0)
            {
                foreach (sss.tblAddressesRow row in tblAddresses)
                {
                    Addresses address = new Addresses(row.Address_ID);
                    addressList.Add(address);
                }
            }

            return addressList;
        }

        public List<Addresses> GetAddressesLikeAddress_Town(string address_Town)
        {
            List<Addresses> addressList = new List<Addresses>();
            AddressesBL addresses = new AddressesBL();
            tblAddresses = addresses.GetAddressesLikeAddress_Town(address_Town);

            if (tblAddresses != null && tblAddresses.Count > 0)
            {
                foreach (sss.tblAddressesRow row in tblAddresses)
                {
                    Addresses address = new Addresses(row.Address_ID);
                    addressList.Add(address);
                }
            }

            return addressList;
        }

        public List<Addresses> GetAddressesLikeAddress_City(string address_City)
        {
            List<Addresses> addressList = new List<Addresses>();
            AddressesBL addresses = new AddressesBL();
            tblAddresses = addresses.GetAddressesLikeAddress_City(address_City);

            if (tblAddresses != null && tblAddresses.Count > 0)
            {
                foreach (sss.tblAddressesRow row in tblAddresses)
                {
                    Addresses address = new Addresses(row.Address_ID);
                    addressList.Add(address);
                }
            }

            return addressList;
        }

        public List<Addresses> GetAddressesLikeAddress_County(string address_County)
        {
            List<Addresses> addressList = new List<Addresses>();
            AddressesBL addresses = new AddressesBL();
            tblAddresses = addresses.GetAddressesLikeAddress_County(address_County);

            if (tblAddresses != null && tblAddresses.Count > 0)
            {
                foreach (sss.tblAddressesRow row in tblAddresses)
                {
                    Addresses address = new Addresses(row.Address_ID);
                    addressList.Add(address);
                }
            }

            return addressList;
        }

        public List<Addresses> GetAddressesByAddress_Postcode(string address_Postcode)
        {
            List<Addresses> addressList = new List<Addresses>();
            AddressesBL addresses = new AddressesBL();
            tblAddresses = addresses.GetAddressesLikeAddress_Postcode(address_Postcode);

            if (tblAddresses != null && tblAddresses.Count > 0)
            {
                foreach (sss.tblAddressesRow row in tblAddresses)
                {
                    Addresses address = new Addresses(row.Address_ID);
                    addressList.Add(address);
                }
            }

            return addressList;
        }

        public Guid? Insert_Address(Guid user_ID)
        {
            AddressesBL addresses = new AddressesBL();
            Guid? newID = (Guid?)addresses.Insert_Address(Address_1, Address_2, Address_Town,
                Address_City, Address_County, Address_Postcode, user_ID);

            return newID;
        }

        public bool Update_Address(Guid address_ID, Guid user_ID)
        {
            bool success = false;

            AddressesBL addresses = new AddressesBL();
            success = addresses.Update_Address(address_ID, Address_1, Address_2, Address_Town, Address_City, Address_County,
                Address_Postcode, DeleteAddress, user_ID);

            return success;
        }

    }
}