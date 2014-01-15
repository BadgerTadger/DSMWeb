using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.sssTableAdapters;
using System.ComponentModel;

namespace BLL
{
    [DataObject]
    class DogClassesBL
    {
        private tblDog_ClassesTableAdapter _tblDog_ClassesAdapter = null;
        protected tblDog_ClassesTableAdapter adapter
        {
            get
            {
                if (_tblDog_ClassesAdapter == null)
                    _tblDog_ClassesAdapter = new tblDog_ClassesTableAdapter();

                return _tblDog_ClassesAdapter;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public sss.tblDog_ClassesDataTable GetDog_Classes()
        {
            return adapter.GetDog_Classes();
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblDog_ClassesDataTable GetDog_ClassByDog_Class_ID(Guid dog_Class_ID)
        {
            return adapter.GetDog_ClassByDog_Class_ID(dog_Class_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblDog_ClassesDataTable GetDog_ClassesByDog_ID(Guid dog_ID)
        {
            return adapter.GetDog_ClassesByDog_ID(dog_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblDog_ClassesDataTable GetDog_ClassesByEntrant_ID(Guid entrant_ID)
        {
            return adapter.GetDog_ClassesByEntrant_ID(entrant_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblDog_ClassesDataTable GetDog_ClassesByHandler_ID(Guid handler_ID)
        {
            return adapter.GetDog_ClassesByHandler_ID(handler_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblDog_ClassesDataTable GetDog_ClassesByShow_Entry_Class_ID(Guid show_Entry_Class_ID)
        {
            return adapter.GetDog_ClassesByShow_Entry_Class_ID(show_Entry_Class_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblDog_ClassesDataTable GetDog_ClassesByShow_Final_Class_ID(Guid show_Final_Class_ID)
        {
            return adapter.GetDog_ClassesByShow_Final_Class_ID(show_Final_Class_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblDog_ClassesDataTable GetDog_ClassesByDog_IDAndShow_Entry_Class_ID(Guid dog_ID, Guid show_Entry_Class_ID)
        {
            return adapter.GetDog_ClassesByDog_IDAndShow_Entry_Class_ID(dog_ID, show_Entry_Class_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public sss.tblDog_ClassesDataTable GetRunning_OrderForClass(Guid show_Final_Class_ID)
        {
            return adapter.GetRunning_OrderForClass(show_Final_Class_ID);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public short GetMaxRunningOrderForClass(Guid show_Final_Class_ID)
        {
            short maxRunningOrder = (short)adapter.GetMaxRunningOrderForClass(show_Final_Class_ID);
            return maxRunningOrder;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public int GetEntryCountByShow_Final_Class_ID(Guid show_Final_Class_ID)
        {
            int entryCount = (int)adapter.GetEntryCountByShow_Final_Class_ID(show_Final_Class_ID);
            return entryCount;
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public Guid? Insert_Dog_Classes(Guid? entrant_ID, Guid? dog_ID, Guid? show_Entry_Class_ID, Guid? handler_ID,
            string special_Request, Guid user_ID)
        {
            Guid? newID = (Guid?)adapter.Insert_Dog_Classes(entrant_ID, dog_ID, show_Entry_Class_ID, handler_ID, special_Request, user_ID);

            return newID;
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public bool Update_Dog_Classes(Guid original_ID, Guid? entrant_ID, Guid? dog_ID, Guid? show_Entry_Class_ID,
            Guid? show_Final_Class_ID, Guid? handler_ID, short? ring_No, short? running_Order, string special_Request,
            bool deleted, Guid user_ID)
        {
            try
            {
                adapter.Update_Dog_Classes(original_ID, entrant_ID, dog_ID, show_Entry_Class_ID, show_Final_Class_ID,
                    handler_ID, ring_No, running_Order, special_Request, deleted, user_ID);

                return true;
            }
            catch
            {
                ApplicationException ae = new ApplicationException("Failed to update Dog Classes");

                return false;
            }
        }
    }
}
