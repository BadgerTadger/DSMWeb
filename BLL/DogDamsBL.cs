using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.sssTableAdapters;
using System.ComponentModel;

namespace BLL
{
    [DataObject]
    class DogDamsBL
    {
        private lnkDog_DamsTableAdapter _lnkDog_DamsAdapter = null;
        protected lnkDog_DamsTableAdapter adapter
        {
            get
            {
                if (_lnkDog_DamsAdapter == null)
                    _lnkDog_DamsAdapter = new lnkDog_DamsTableAdapter();

                return _lnkDog_DamsAdapter;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public sss.lnkDog_DamsDataTable GetDog_Dams()
        {
            return adapter.GetDog_Dams();
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.lnkDog_DamsDataTable GetDog_DamByDog_Dam_ID(Guid dog_Dam_ID)
        {
            return adapter.GetDog_DamByDog_Dam_ID(dog_Dam_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.lnkDog_DamsDataTable GetDog_DamByDog_ID(Guid dog_ID)
        {
            return adapter.GetDog_DamByDog_ID(dog_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.lnkDog_DamsDataTable GetDog_DamsByDam_ID(Guid dam_ID)
        {
            return adapter.GetDog_DamsByDam_ID(dam_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public Guid? Insert_Dog_Dams(Guid dog_ID, Guid dam_ID, Guid user_ID)
        {
            Guid? newID = (Guid?)adapter.Insert_Dog_Dams(dog_ID, dam_ID, user_ID);

            return newID;
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public bool Update_Dog_Dams(Guid original_ID, Guid dog_ID, Guid dam_ID, bool deleted, Guid user_ID)
        {
            try
            {
                adapter.Update_Dog_Dams(original_ID, dog_ID, dam_ID, deleted, user_ID);

                return true;
            }
            catch
            {
                ApplicationException ae = new ApplicationException("Failed to update Dog_Dams");

                return false;
            }
        }
    }
}
