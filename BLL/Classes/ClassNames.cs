using System;
using System.Collections.Generic;
using System.Web;
using DAL;
using DAL.sssTableAdapters;

namespace BLL
{
    public class ClassNames
    {
        private sss.lkpClass_NamesDataTable lkpClassNames;

        private int _class_Name_ID;
        public int Class_Name_ID
        {
            get { return _class_Name_ID; }
            set { _class_Name_ID = value; }
        }
        private string _description = null;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        private string _class_Name_Description = null;
        public string Class_Name_Description
        {
            get { return _class_Name_Description; }
            set { _class_Name_Description = value; }
        }

        public ClassNames()
        {
            ClassNamesBL classNames = new ClassNamesBL();
            lkpClassNames = classNames.GetClass_Names();
        }

        public ClassNames(int class_Name_ID)
        {
            ClassNamesBL classNames = new ClassNamesBL();
            lkpClassNames = classNames.GetClass_NameByClass_Name_ID(class_Name_ID);

            Class_Name_ID = class_Name_ID;
            Description = lkpClassNames[0].Class_Name_Description;
            Class_Name_Description = Description;
        }

        public List<ClassNames> GetClass_Names()
        {
            List<ClassNames> classNameList = new List<ClassNames>();
            ClassNamesBL classNames = new ClassNamesBL();
            lkpClassNames = classNames.GetClass_Names();

            if (lkpClassNames != null && lkpClassNames.Count > 0)
            {
                foreach (sss.lkpClass_NamesRow row in lkpClassNames)
                {
                    ClassNames className = new ClassNames(row.Class_Name_ID);
                    classNameList.Add(className);
                }
            }

            return classNameList;
        }
    }
}