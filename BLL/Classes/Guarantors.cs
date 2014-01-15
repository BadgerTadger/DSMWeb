using System;
using System.Collections.Generic;
using System.Web;
using DAL;
using DAL.sssTableAdapters;

namespace BLL
{
    public class Guarantors
    {
        private sss.tblGuarantorsDataTable tblGuarantors = null;

        private Guid _guarantor_ID;
        public Guid Guarantor_ID
        {
            get { return _guarantor_ID; }
            set { _guarantor_ID = value; }
        }
        private bool _isShow_IDNull;
        public bool IsShow_IDNull
        {
            get { return _isShow_IDNull; }
            set { _isShow_IDNull = value; }
        }
        private Guid? _show_ID = null;
        public Guid? Show_ID
        {
            get { return _show_ID; }
            set { _show_ID = value; }
        }
        private bool _isChairman_Person_IDNull;
        public bool IsChairman_Person_IDNull
        {
            get { return _isChairman_Person_IDNull; }
            set { _isChairman_Person_IDNull = value; }
        }
        private Guid? _chairman_Person_ID = null;
        public Guid? Chairman_Person_ID
        {
            get { return _chairman_Person_ID; }
            set { _chairman_Person_ID = value; }
        }
        private bool _isSecretary_Person_IDNull;
        public bool IsSecretary_Person_IDNull
        {
            get { return _isSecretary_Person_IDNull; }
            set { _isSecretary_Person_IDNull = value; }
        }
        private Guid? _secretary_Person_ID = null;
        public Guid? Secretary_Person_ID
        {
            get { return _secretary_Person_ID; }
            set { _secretary_Person_ID = value; }
        }
        private bool _isTreasurer_Person_IDNull;
        public bool IsTreasurer_Person_IDNull
        {
            get { return _isTreasurer_Person_IDNull; }
            set { _isTreasurer_Person_IDNull = value; }
        }
        private Guid? _treasurer_Person_ID = null;
        public Guid? Treasurer_Person_ID
        {
            get { return _treasurer_Person_ID; }
            set { _treasurer_Person_ID = value; }
        }
        private bool _isCommittee1_Person_IDNull;
        public bool IsCommittee1_Person_IDNull
        {
            get { return _isCommittee1_Person_IDNull; }
            set { _isCommittee1_Person_IDNull = value; }
        }
        private Guid? _committee1_Person_ID = null;
        public Guid? Committee1_Person_ID
        {
            get { return _committee1_Person_ID; }
            set { _committee1_Person_ID = value; }
        }
        private bool _isCommittee2_Person_IDNull;
        public bool IsCommittee2_Person_IDNull
        {
            get { return _isCommittee2_Person_IDNull; }
            set { _isCommittee2_Person_IDNull = value; }
        }
        private Guid? _committee2_Person_ID = null;
        public Guid? Committee2_Person_ID
        {
            get { return _committee2_Person_ID; }
            set { _committee2_Person_ID = value; }
        }
        private bool _isCommittee3_Person_IDNull;
        public bool IsCommittee3_Person_IDNull
        {
            get { return _isCommittee3_Person_IDNull; }
            set { _isCommittee3_Person_IDNull = value; }
        }
        private Guid? _committee3_Person_ID = null;
        public Guid? Committee3_Person_ID
        {
            get { return _committee3_Person_ID; }
            set { _committee3_Person_ID = value; }
        }

        private bool? _deleteGuarantor = null;
        public bool? DeleteGuarantor
        {
            get { return _deleteGuarantor; }
            set { _deleteGuarantor = value; }
        }

        public Guarantors()
        {

        }

        public Guarantors(Guid guarantor_ID)
        {
            GuarantorsBL guarantors = new GuarantorsBL();
            tblGuarantors = guarantors.GetGuarantorByGuarantor_ID(guarantor_ID);

            Guarantor_ID = guarantor_ID;
            IsShow_IDNull = tblGuarantors[0].IsShow_IDNull();
            if (!IsShow_IDNull)
                Show_ID = tblGuarantors[0].Show_ID;
            IsChairman_Person_IDNull = tblGuarantors[0].IsChairman_Person_IDNull();
            if (!IsChairman_Person_IDNull)
                Chairman_Person_ID = tblGuarantors[0].Chairman_Person_ID;
            IsSecretary_Person_IDNull = tblGuarantors[0].IsSecretary_Person_IDNull();
            if (!IsSecretary_Person_IDNull)
                Secretary_Person_ID = tblGuarantors[0].Secretary_Person_ID;
            IsTreasurer_Person_IDNull = tblGuarantors[0].IsTreasurer_Person_IDNull();
            if (!IsTreasurer_Person_IDNull)
                Treasurer_Person_ID = tblGuarantors[0].Treasurer_Person_ID;
            IsCommittee1_Person_IDNull = tblGuarantors[0].IsCommittee1_Person_IDNull();
            if (!IsCommittee1_Person_IDNull)
                Committee1_Person_ID = tblGuarantors[0].Committee1_Person_ID;
            IsCommittee2_Person_IDNull = tblGuarantors[0].IsCommittee2_Person_IDNull();
            if (!IsCommittee2_Person_IDNull)
                Committee2_Person_ID = tblGuarantors[0].Committee2_Person_ID;
            IsCommittee3_Person_IDNull = tblGuarantors[0].IsCommittee3_Person_IDNull();
            if (!IsCommittee3_Person_IDNull)
                Committee3_Person_ID = tblGuarantors[0].Committee3_Person_ID;
        }

        public List<Guarantors> GetGuarantorsByGuarantor_ID(Guid guarantor_ID)
        {
            List<Guarantors> guarantorList = new List<Guarantors>();
            GuarantorsBL guarantors = new GuarantorsBL();
            tblGuarantors = guarantors.GetGuarantorByGuarantor_ID(guarantor_ID);

            if (tblGuarantors != null && tblGuarantors.Count > 0)
            {
                foreach (sss.tblGuarantorsRow row in tblGuarantors)
                {
                    Guarantors guarantor = new Guarantors(row.Guarantor_ID);
                    guarantorList.Add(guarantor);
                }
            }

            return guarantorList;
        }

        public List<Guarantors> GetGuarantorsByShow_ID(Guid show_ID)
        {
            List<Guarantors> guarantorList = new List<Guarantors>();
            GuarantorsBL guarantors = new GuarantorsBL();
            tblGuarantors = guarantors.GetGuarantorsByShow_ID(show_ID);

            if (tblGuarantors != null && tblGuarantors.Count > 0)
            {
                foreach (sss.tblGuarantorsRow row in tblGuarantors)
                {
                    Guarantors guarantor = new Guarantors(row.Guarantor_ID);
                    guarantorList.Add(guarantor);
                }
            }

            return guarantorList;
        }

        public Guid? Insert_Guarantor(Guid user_ID)
        {
            GuarantorsBL guarantors = new GuarantorsBL();
            Guid? newID = (Guid?)guarantors.Insert_Guarantors(Show_ID, Chairman_Person_ID, Secretary_Person_ID, Treasurer_Person_ID,
                Committee1_Person_ID, Committee2_Person_ID, Committee3_Person_ID, user_ID);

            return newID;
        }

        public bool Update_Guarantor(Guid guarantor_ID, Guid user_ID)
        {
            bool success = false;

            GuarantorsBL guarantors = new GuarantorsBL();
            success = guarantors.Update_Guarantors(guarantor_ID, Show_ID, Chairman_Person_ID, Secretary_Person_ID, Treasurer_Person_ID,
                Committee1_Person_ID, Committee2_Person_ID, Committee3_Person_ID, DeleteGuarantor, user_ID);

            return success;
        }
    }
}