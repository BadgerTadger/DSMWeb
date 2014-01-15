using System;
using System.Collections.Generic;
using System.Web;
using DAL;
using DAL.sssTableAdapters;

namespace BLL
{
    public class ShowTypes
    {
        public sss.lkpShow_TypesDataTable lkpShowTypes = null;

        private int _show_Type_ID;
        public int Show_Type_ID
        {
            get { return _show_Type_ID; }
            set { _show_Type_ID = value; }
        }
        private string _description = null;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public ShowTypes()
        {
            ShowTypesBL showTypes = new ShowTypesBL();
            lkpShowTypes = showTypes.GetShow_Types();
        }

        public ShowTypes(int show_Type_ID)
        {
            ShowTypesBL showTypes = new ShowTypesBL();
            lkpShowTypes = showTypes.GetShow_TypesByShow_Type_ID(show_Type_ID);

            Show_Type_ID = show_Type_ID;
            Description = lkpShowTypes[0].Show_Type_Description;
        }

        public List<ShowTypes> GetShow_Types()
        {
            List<ShowTypes> showTypeList = new List<ShowTypes>();
            ShowTypesBL showTypes = new ShowTypesBL();
            lkpShowTypes = showTypes.GetShow_Types();

            if (lkpShowTypes != null && lkpShowTypes.Count > 0)
            {
                foreach (sss.lkpShow_TypesRow row in lkpShowTypes)
                {
                    ShowTypes showType = new ShowTypes(row.Show_Type_ID);
                    showTypeList.Add(showType);
                }
            }

            return showTypeList;
        }
    }
}