using System;
using System.Collections.Generic;
using System.Web;
using DAL;
using DAL.sssTableAdapters;

namespace BLL
{
    public class ShowYears
    {
        public sss.lkpShow_YearsDataTable lkpShowYears = null;

        private int _show_Year_ID;
        public int Show_Year_ID
        {
            get { return _show_Year_ID; }
            set { _show_Year_ID = value; }
        }
        private short _showYear;
        public short ShowYear
        {
            get { return _showYear; }
            set { _showYear = value; }
        }
        private string _show_Year;
        public string Show_Year
        {
            get { return _show_Year; }
            set { _show_Year = value; }
        }

        public ShowYears()
        {
            ShowYearsBL showYears = new ShowYearsBL();
            lkpShowYears = showYears.GetShow_Years();
        }

        public ShowYears(int show_Year_ID)
        {
            ShowYearsBL showYears = new ShowYearsBL();
            lkpShowYears = showYears.GetShow_YearByShow_Year_ID(show_Year_ID);

            Show_Year_ID = show_Year_ID;
            ShowYear = lkpShowYears[0].Show_Year;
            Show_Year = ShowYear.ToString();
        }

        public List<ShowYears> GetShow_Years()
        {
            List<ShowYears> showYearList = new List<ShowYears>();
            ShowYearsBL showYears = new ShowYearsBL();
            lkpShowYears = showYears.GetShow_Years();

            if (lkpShowYears != null && lkpShowYears.Count > 0)
            {
                foreach (sss.lkpShow_YearsRow row in lkpShowYears)
                {
                    ShowYears showYear = new ShowYears(row.Show_Year_ID);
                    showYearList.Add(showYear);
                }
            }

            return showYearList;
        }

        public List<ShowYears> GetShow_YearByShow_Year(short show_Year)
        {
            List<ShowYears> showYearList = new List<ShowYears>();
            ShowYearsBL showYears = new ShowYearsBL();
            lkpShowYears = showYears.GetShow_YearByShow_Year(show_Year);

            if (lkpShowYears != null && lkpShowYears.Count > 0)
            {
                foreach (sss.lkpShow_YearsRow row in lkpShowYears)
                {
                    ShowYears showYear = new ShowYears(row.Show_Year_ID);
                    showYearList.Add(showYear);
                }
            }

            return showYearList;
        }
    }
}