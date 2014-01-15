using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.sssTableAdapters;
using System.ComponentModel;

namespace BLL
{
    [DataObject]
    class CatalogueListBL
    {
        private tblCatalogueListByRingNumberTableAdapter _tblCatalogueListByRingNumber = null;
        protected tblCatalogueListByRingNumberTableAdapter adapter
        {
            get
            {
                if (_tblCatalogueListByRingNumber == null)
                    _tblCatalogueListByRingNumber = new tblCatalogueListByRingNumberTableAdapter();

                return _tblCatalogueListByRingNumber;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public sss.tblCatalogueListByRingNumberDataTable GetCatalogueListByRingNumber()
        {
            return adapter.GetCatalogueListByRingNumber();
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public bool PopulateCatalogueListByRingNumber(Guid show_ID)
        {
            try
            {
                adapter.PopulateCatalogueListByRingNumber(show_ID);

                return true;
            }
            catch
            {
                ApplicationException ae = new ApplicationException("Failed to update Catalogue List");

                return false;
            }
        }
    }
}
