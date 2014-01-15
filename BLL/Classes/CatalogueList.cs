using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.sssTableAdapters;

namespace BLL
{
    public class CatalogueList
    {
        private sss.tblCatalogueListByRingNumberDataTable tblCatalogueListByRingNumber = null;

        private short _ring_No;
        public short Ring_No
        {
            get { return _ring_No; }
            set { _ring_No = value; }
        }
        private string _owner = null;
        public string Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }
        private List<string> _owners = null;
        public List<string> Owners
        {
            get 
            {
                if (_owners == null)
                    _owners = new List<string>();

                return _owners; 
            }
            set { _owners = value; }
        }
        private string _address = null;
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        private List<string> _addresses = null;
        public List<string> Addresses
        {
            get 
            {
                if (_addresses == null)
                    _addresses = new List<string>();

                return _addresses; 
            }
            set { _addresses = value; }
        }
        private string _dog_KC_Name = null;
        public string Dog_KC_Name
        {
            get { return _dog_KC_Name; }
            set { _dog_KC_Name = value; }
        }
        private string _dog_Breed_Description = null;
        public string Dog_Breed_Description
        {
            get { return _dog_Breed_Description; }
            set { _dog_Breed_Description = value; }
        }
        private string _dog_Gender = null;
        public string Dog_Gender
        {
            get { return _dog_Gender; }
            set { _dog_Gender = value; }
        }
        private string _date_Of_Birth = null;
        public string Date_Of_Birth
        {
            get { return _date_Of_Birth; }
            set { _date_Of_Birth = value; }
        }
        private string _breeder = null;
        public string Breeder
        {
            get { return _breeder; }
            set { _breeder = value; }
        }
        private List<string> _breeders = null;
        public List<string> Breeders
        {
            get 
            {
                if (_breeders == null)
                    _breeders = new List<string>();

                return _breeders; 
            }
            set { _breeders = value; }
        }
        private string _sire = null;
        public string Sire
        {
            get { return _sire; }
            set { _sire = value; }
        }
        private string _dam = null;
        public string Dam
        {
            get { return _dam; }
            set { _dam = value; }
        }
        private string _class_Name = null;
        public string Class_Name
        {
            get { return _class_Name; }
            set { _class_Name = value; }
        }
        private bool _breederIsOwner = false;
        public bool BreederIsOwner
        {
            get { return _breederIsOwner; }
            set { _breederIsOwner = value; }
        }
        private bool _catalogue;
        public bool Catalogue
        {
            get { return _catalogue; }
            set { _catalogue = value; }
        }
        private List<string> _class_NameList = null;
        public List<string> Class_NameList
        {
            get 
            {
                if (_class_NameList == null)
                    _class_NameList = new List<string>();

                return _class_NameList; 
            }
            set { _class_NameList = value; }
        }

        public CatalogueList()
        {

        }

        public List<CatalogueList> GetCatalogueListByRingNumber()
        {
            List<CatalogueList> catalogueListByRingNumbersList = new List<CatalogueList>();
            CatalogueListBL catalogueListByRingNumbers = new CatalogueListBL();
            tblCatalogueListByRingNumber = catalogueListByRingNumbers.GetCatalogueListByRingNumber();

            if (tblCatalogueListByRingNumber != null && tblCatalogueListByRingNumber.Count > 0)
            {
                foreach (sss.tblCatalogueListByRingNumberRow row in tblCatalogueListByRingNumber)
                {
                    CatalogueList catalogueListByRingNumber = new CatalogueList();
                    catalogueListByRingNumber.Ring_No = row.Ring_No;
                    catalogueListByRingNumber.Owner = row.Owner;
                    catalogueListByRingNumber.Address = row.Address;
                    catalogueListByRingNumber.Dog_KC_Name = row.Dog_KC_Name;
                    catalogueListByRingNumber.Dog_Breed_Description = row.Dog_Breed_Description;
                    catalogueListByRingNumber.Dog_Gender = row.Dog_Gender;
                    catalogueListByRingNumber.Date_Of_Birth = row.Date_Of_Birth;
                    catalogueListByRingNumber.Breeder = row.Breeder;
                    catalogueListByRingNumber.Sire = row.Sire;
                    catalogueListByRingNumber.Dam = row.Dam;
                    catalogueListByRingNumber.Class_Name = row.Class_Name;
                    catalogueListByRingNumber.BreederIsOwner = row.BreederIsOwner;
                    if (!row.IsCatalogueNull())
                    {
                        catalogueListByRingNumber.Catalogue = row.Catalogue;
                    }
                    else
                    {
                        catalogueListByRingNumber.Catalogue = false;
                    }
                    catalogueListByRingNumbersList.Add(catalogueListByRingNumber);
                }
            }

            return catalogueListByRingNumbersList;
        }

        public bool PopulateCatalogueListByRingNumber(Guid show_ID)
        {
            bool success = false;

            CatalogueListBL catalogueListByRingNumbers = new CatalogueListBL();
            success = catalogueListByRingNumbers.PopulateCatalogueListByRingNumber(show_ID);

            return success;
        }
        public static List<CatalogueList> GetCatalogueListData(string Show_ID)
        {
            List<CatalogueList> catalogueList = new List<CatalogueList>();
            CatalogueList catalogue = new CatalogueList();
            Guid show_ID = new Guid(Show_ID);
            if (catalogue.PopulateCatalogueListByRingNumber(show_ID))
            {
                catalogueList = catalogue.GetCatalogueListByRingNumber();
            }
            return catalogueList;
        }
    }
}
