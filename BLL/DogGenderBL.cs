using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.sssTableAdapters;
using System.ComponentModel;

namespace BLL
{
    [DataObject]
    class DogGenderBL
    {
        private lkpDog_GenderTableAdapter _lkpDog_Gender_Adapter = null;
        protected lkpDog_GenderTableAdapter adapter
        {
            get
            {
                if (_lkpDog_Gender_Adapter == null)
                    _lkpDog_Gender_Adapter = new lkpDog_GenderTableAdapter();

                return _lkpDog_Gender_Adapter;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public sss.lkpDog_GenderDataTable GetDog_Gender()
        {
            return adapter.GetDog_Gender();
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.lkpDog_GenderDataTable GetDog_GenderByDog_Gender_ID(int dog_Gender_ID)
        {
            return adapter.GetDog_GenderByDog_Gender_ID(dog_Gender_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.lkpDog_GenderDataTable GetDog_GenderLikeDog_Gender(string dog_Gender)
        {
            return adapter.GetDog_GenderLikeDog_Gender(dog_Gender);
        }
    }
}
