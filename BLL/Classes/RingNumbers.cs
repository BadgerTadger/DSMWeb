using System;
using System.Collections.Generic;
using System.Web;
using DAL;
using DAL.sssTableAdapters;

namespace BLL
{
    public class RingNumbers
    {
        private sss.tblRing_NumbersDataTable tblRing_Numbers = null;

        private short _ring_No;
        public short Ring_No
        {
            get { return _ring_No; }
            set { _ring_No = value; }
        }
        private Guid _dog_ID;
        public Guid Dog_ID
        {
            get { return _dog_ID; }
            set { _dog_ID = value; }
        }
        private string _dog_KC_Name = null;
        public string Dog_KC_Name
        {
            get { return _dog_KC_Name; }
            set { _dog_KC_Name = value; }
        }
        private string _person_Forname = null;
        public string Person_Forename
        {
            get { return _person_Forname; }
            set { _person_Forname = value; }
        }
        private string _person_Surname = null;
        public string Person_Surname
        {
            get { return _person_Surname; }
            set { _person_Surname = value; }
        }

        public RingNumbers()
        {

        }

        public List<RingNumbers> GetRing_Numbers()
        {
            List<RingNumbers> ringNumberList = new List<RingNumbers>();
            RingNumbersBL ringNumbers = new RingNumbersBL();
            tblRing_Numbers = ringNumbers.GetRing_Numbers();

            if (tblRing_Numbers != null && tblRing_Numbers.Count > 0)
            {
                foreach (sss.tblRing_NumbersRow row in tblRing_Numbers)
                {
                    RingNumbers ringNumber = new RingNumbers();
                    ringNumber.Ring_No = row.Ring_No;
                    ringNumber.Dog_ID = row.Dog_ID;
                    ringNumber.Dog_KC_Name = row.Dog_KC_Name;
                    ringNumber.Person_Forename = row.Person_Forename;
                    ringNumber.Person_Surname = row.Person_Surname;
                    ringNumberList.Add(ringNumber);
                }
            }

            return ringNumberList;
        }

        public bool PopulateRing_Numbers(Guid show_ID)
        {
            bool success = false;

            RingNumbersBL ringNumbers = new RingNumbersBL();
            success = ringNumbers.PopulateRing_Numbers(show_ID);

            return success;
        }
    }
}
