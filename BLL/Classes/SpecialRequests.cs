using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.sssTableAdapters;

namespace BLL
{
    public class SpecialRequests
    {
        private sss.tblSpecialRequestListDataTable tblSpecialRequestList = null;

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
        private string _dog_KC_Name = null;
        public string Dog_KC_Name
        {
            get { return _dog_KC_Name; }
            set { _dog_KC_Name = value; }
        }
        private string _special_Request = null;
        public string Special_Request
        {
            get { return _special_Request; }
            set { _special_Request = value; }
        }
        private string _class_Name = null;
        public string Class_Name
        {
            get { return _class_Name; }
            set { _class_Name = value; }
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
        private Guid _dog_Class_ID;
        public Guid Dog_Class_ID
        {
            get { return _dog_Class_ID; }
            set { _dog_Class_ID=value;}
        }
        private Guid _show_Entry_Class_ID;
        public Guid Show_Entry_Class_ID
        {
            get { return _show_Entry_Class_ID; }
            set { _show_Entry_Class_ID=value;}
        }
        private Guid _show_Final_Class_ID;
        public Guid Show_Final_Class_ID
        {
            get { return _show_Final_Class_ID; }
            set { _show_Final_Class_ID=value;}
        }
        private int _rowCount;
        public int RowCount
        {
            get { return _rowCount; }
            set { _rowCount = value; }
        }
        public SpecialRequests()
        {

        }

        public List<SpecialRequests> GetSpecialRequestList()
        {
            List<SpecialRequests> specialRequestList = new List<SpecialRequests>();
            SpecialRequestsBL specialRequests = new SpecialRequestsBL();
            tblSpecialRequestList = specialRequests.GetSpecialRequests();

            if (tblSpecialRequestList != null && tblSpecialRequestList.Count > 0)
            {
                foreach (sss.tblSpecialRequestListRow row in tblSpecialRequestList)
                {
                    SpecialRequests specialRequest = new SpecialRequests();
                    specialRequest.Ring_No = row.Ring_No;
                    specialRequest.Owner = row.Owner;
                    specialRequest.Dog_KC_Name = row.Dog_KC_Name;
                    if(!row.IsSpecial_RequestNull())
                        specialRequest.Special_Request = row.Special_Request;
                    specialRequest.Class_Name = row.Class_Name;
                    specialRequest.Dog_Class_ID = row.Dog_Class_ID;
                    specialRequest.Show_Entry_Class_ID = row.Show_Entry_Class_ID;
                    specialRequest.Show_Final_Class_ID = row.Show_Final_Class_ID;
                    specialRequestList.Add(specialRequest);
                }
            }

            return specialRequestList;
        }

        public bool PopulateSpecialRequestList(Guid show_ID, Guid? show_Entry_Class_ID, bool specialRequestsOnly)
        {
            bool success = false;

            if (show_Entry_Class_ID == new Guid())
                show_Entry_Class_ID = null;

            SpecialRequestsBL specialRequests = new SpecialRequestsBL();
            success = specialRequests.PopulateSpecialRequestList(show_ID, show_Entry_Class_ID, specialRequestsOnly);

            return success;
        }
        public static List<SpecialRequests> GetSpecialRequestListData(string Show_ID, Guid? show_Entry_Class_ID, bool specialRequestsOnly)
        {
            List<SpecialRequests> specialRequestList = new List<SpecialRequests>();
            SpecialRequests specialRequest = new SpecialRequests();
            Guid show_ID = new Guid(Show_ID);
            if (specialRequest.PopulateSpecialRequestList(show_ID, show_Entry_Class_ID, specialRequestsOnly))
            {
                specialRequestList = specialRequest.GetSpecialRequestList();
            }
            return specialRequestList;
        }
    }    
}
