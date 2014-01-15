using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.sssTableAdapters;
using System.Data;

namespace BLL
{
    public static class RunningOrders
    {
        private static List<ClassesAndDrawQty> _classesAndDrawQtyList;
        private static List<ClassesAndDrawQty> ClassesAndDrawQtyList
        {
            get { return _classesAndDrawQtyList; }
            set { _classesAndDrawQtyList = value; }
        }
        private static List<OwnersDogsClassesDrawn> _allEntriesInClass;
        public static List<OwnersDogsClassesDrawn> AllEntriesInClass
        {
            get { return _allEntriesInClass; }
            set { _allEntriesInClass = value; }
        }
        private static List<Guid> _ownersDrawn;
        public static List<Guid> OwnersDrawn
        {
            get
            {
                if (_ownersDrawn == null)
                    _ownersDrawn = new List<Guid>();

                return _ownersDrawn;
            }
            set { _ownersDrawn = value; }
        }
        private static List<Guid> _ownersDrawnOnDay1;
        public static List<Guid> OwnersDrawnOnDay1
        {
            get
            {
                if (_ownersDrawnOnDay1 == null)
                    _ownersDrawnOnDay1 = new List<Guid>();

                return _ownersDrawnOnDay1;
            }
            set { _ownersDrawnOnDay1 = value; }
        }
        private static List<Guid> _ownersDrawnOnDay2;
        public static List<Guid> OwnersDrawnOnDay2
        {
            get
            {
                if (_ownersDrawnOnDay2 == null)
                    _ownersDrawnOnDay2 = new List<Guid>();

                return _ownersDrawnOnDay2;
            }
            set { _ownersDrawnOnDay2 = value; }
        }
        private static List<Guid> _dogsDrawn;
        public static List<Guid> DogsDrawn
        {
            get
            {
                if (_dogsDrawn == null)
                    _dogsDrawn = new List<Guid>();

                return _dogsDrawn;
            }
            set { _dogsDrawn = value; }
        }
        private static int _ownerDogCount;
        public static int OwnerDogCount
        {
            get { return _ownerDogCount; }
            set { _ownerDogCount = value; }
        }
        private static int _ownerDogsInClassCount;
        public static int OwnerDogsInClassCount
        {
            get { return _ownerDogsInClassCount; }
            set { _ownerDogsInClassCount = value; }
        }
        private static int _classesPerOwnerEnteredCount;
        public static int ClassesPerOwnerEnteredCount
        {
            get { return _classesPerOwnerEnteredCount; }
            set { _classesPerOwnerEnteredCount = value; }
        }
        private static int _classesPerDogEnteredCount;
        public static int ClassesPerDogEnteredCount
        {
            get { return _classesPerDogEnteredCount; }
            set { _classesPerDogEnteredCount = value; }
        }
        private static Guid _day1_Show_ID;
        public static Guid Day1_Show_ID
        {
            get { return _day1_Show_ID; }
            set { _day1_Show_ID = value; }
        }
        public static void AllocateRunningOrders(string show_ID, Guid user_ID)
        {
            Guid newShow_ID = new Guid(show_ID);
            List<Guid> showList = new List<Guid>();
            showList.Add(newShow_ID);
            LinkedShows ls = new LinkedShows();
            List<LinkedShows> lsList = ls.GetLinked_ShowsByParent_ID(newShow_ID);
            if (lsList != null && lsList.Count > 0)
            {
                foreach (LinkedShows linkedShow in lsList)
                {
                    showList.Add(linkedShow.Child_Show_ID);
                }
            }
            SetDay1Show_ID(showList);
            if (OwnersDogsClassesDrawn.DeleteOwnersDogsClassesDrawnList())
            {
                foreach (Guid s_ID in showList)
                {
                    OwnersDrawn = null;
                    DogsDrawn = null;
                    Shows show = new Shows(s_ID);
                    if (!(bool)show.Running_Orders_Allocated)
                    {
                        AllEntriesInClass = OwnersDogsClassesDrawn.GetOwnersDogsClassesDrawnListData(s_ID, null, false);
                        AllocateRunningOrdersStage1(s_ID, user_ID);
                        AllocateRunningOrdersStage2(s_ID, user_ID);
                        AllocateRunningOrdersStage3(s_ID, user_ID);
                        show.Running_Orders_Allocated = true;
                        show.Update_Show(s_ID, user_ID);
                    }
                }
            }
        }
        public static void SetDay1Show_ID(List<Guid> showList)
        {
            Guid firstShow_ID = showList[0];
            Shows show = new Shows(showList[0]);
            DateTime firstShowDate = (DateTime)show.Show_Opens;
            foreach (Guid show_ID in showList)
            {
                Shows show2 = new Shows(show_ID);
                if (DateTime.Compare((DateTime)show2.Show_Opens, firstShowDate) < 0)
                {
                    firstShow_ID = show_ID;
                    firstShowDate = (DateTime)show2.Show_Opens;
                }
            }
            RunningOrders.Day1_Show_ID = firstShow_ID;
        }
        public static void ClearRunningOrders(string show_ID, Guid user_ID)
        {
            Guid newShow_ID = new Guid(show_ID);
            List<Guid> showList = new List<Guid>();
            showList.Add(newShow_ID);
            LinkedShows ls = new LinkedShows();
            List<LinkedShows> lsList = ls.GetLinked_ShowsByParent_ID(newShow_ID);
            if (lsList != null && lsList.Count > 0)
            {
                foreach (LinkedShows linkedShow in lsList)
                {
                    showList.Add(linkedShow.Child_Show_ID);
                }
            }
            List<OwnersDogsClassesDrawn> oDCDList = new List<OwnersDogsClassesDrawn>();
            oDCDList = OwnersDogsClassesDrawn.GetOwnersDogsClassesDrawnListData(newShow_ID, null, true);
            if (oDCDList != null && oDCDList.Count > 0)
            {
                SetClassesAndDrawQty(newShow_ID);
                foreach (ClassesAndDrawQty classRow in ClassesAndDrawQtyList)
                {
                    foreach (OwnersDogsClassesDrawn row in oDCDList)
                    {
                        if (row.Show_Final_Class_ID == classRow.Show_Final_Class_ID)
                        {
                            SetRunningOrderNull(row, user_ID);
                        }
                    }
                }
            }
            foreach (Guid s_ID in showList)
            {
                Shows show = new Shows(s_ID);
                show.Running_Orders_Allocated = false;
                show.Update_Show(s_ID, user_ID);
            }
        }
        public static void AllocateRunningOrdersStage1(Guid show_ID, Guid user_ID)
        {
            if (AllEntriesInClass != null && AllEntriesInClass.Count > 0)
            {
                SetClassesAndDrawQty(show_ID);
                if (ClassesAndDrawQtyList != null && ClassesAndDrawQtyList.Count > 0)
                {
                    //All Classes - Highest to Lowest
                    //All Dogs in more than one class - draw highest class
                    for (int i = (ClassesAndDrawQtyList.Count-1); i > -1; i--)
                    {
                        Guid thisClass_ID = ClassesAndDrawQtyList[i].Show_Final_Class_ID;
                        DogClasses dogClass = new DogClasses();
                        short thisClassRunningOrder = dogClass.GetMaxRunningOrderForClass(thisClass_ID);
                        foreach (OwnersDogsClassesDrawn thisClassRow in AllEntriesInClass)
                        {
                            if (OwnersDrawn.IndexOf(thisClassRow.Owner_ID) == -1 && DogsDrawn.IndexOf(thisClassRow.Dog_ID) == -1)
                            //if (DogsDrawn.IndexOf(thisClassRow.Dog_ID) == -1)
                            {
                                if (thisClassRow.Show_Final_Class_ID == thisClass_ID)
                                {
                                    if (!thisClassRow.Helper && !(thisClassRow.OwnerDogCount == 1 && thisClassRow.ClassesPerOwnerEnteredCount == 1))
                                    {
                                        if (thisClassRow.ClassesPerDogEnteredCount > 1 && thisClassRow.HighestClass)
                                        {
                                            thisClassRunningOrder += 1;
                                            if (thisClassRunningOrder <= ClassesAndDrawQtyList[i].DrawQty)
                                            {
                                                UpdateRunningOrder(thisClassRow, thisClassRunningOrder, user_ID);
                                                if (OwnersDrawn.IndexOf(thisClassRow.Owner_ID) == -1)
                                                    OwnersDrawn.Add(thisClassRow.Owner_ID);
                                                ShowFinalClasses sfc = new ShowFinalClasses(thisClassRow.Show_Final_Class_ID);
                                                if (sfc.Show_ID == Day1_Show_ID)
                                                {
                                                    if (OwnersDrawnOnDay1.IndexOf(thisClassRow.Owner_ID) == -1)
                                                        OwnersDrawnOnDay1.Add(thisClassRow.Owner_ID);
                                                }
                                                else
                                                {
                                                    if (OwnersDrawnOnDay2.IndexOf(thisClassRow.Owner_ID) == -1)
                                                        OwnersDrawnOnDay2.Add(thisClassRow.Owner_ID);
                                                }
                                                if (DogsDrawn.IndexOf(thisClassRow.Dog_ID) == -1)
                                                    DogsDrawn.Add(thisClassRow.Dog_ID);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public static void AllocateRunningOrdersStage2(Guid show_ID, Guid user_ID)
        {
            if (AllEntriesInClass != null && AllEntriesInClass.Count > 0)
            {
                SetClassesAndDrawQty(show_ID);
                if (ClassesAndDrawQtyList != null && ClassesAndDrawQtyList.Count > 0)
                {
                    //All Classes -  Lowest to Highest
                    //Owner has more than one dog in this class
                    for (int i = 0; i < ClassesAndDrawQtyList.Count; i++)
                    {
                        Guid thisClass_ID = ClassesAndDrawQtyList[i].Show_Final_Class_ID;
                        DogClasses dogClass = new DogClasses();
                        short thisClassRunningOrder = dogClass.GetMaxRunningOrderForClass(thisClass_ID);
                        foreach (OwnersDogsClassesDrawn thisClassRow in AllEntriesInClass)
                        {
                            if (OwnersDrawn.IndexOf(thisClassRow.Owner_ID) == -1 && DogsDrawn.IndexOf(thisClassRow.Dog_ID) == -1)
                            //if (DogsDrawn.IndexOf(thisClassRow.Dog_ID) == -1)
                            {
                                if (thisClassRow.Show_Final_Class_ID == thisClass_ID)
                                {
                                    if (!thisClassRow.Helper && !(thisClassRow.OwnerDogCount == 1 && thisClassRow.ClassesPerOwnerEnteredCount == 1))
                                    {
                                        if (thisClassRow.OwnerDogsInClassCount > 1)
                                        {
                                            thisClassRunningOrder += 1;
                                            if (thisClassRunningOrder <= ClassesAndDrawQtyList[i].DrawQty)
                                            {
                                                UpdateRunningOrder(thisClassRow, thisClassRunningOrder, user_ID);
                                                if (OwnersDrawn.IndexOf(thisClassRow.Owner_ID) == -1)
                                                    OwnersDrawn.Add(thisClassRow.Owner_ID);
                                                ShowFinalClasses sfc = new ShowFinalClasses(thisClassRow.Show_Final_Class_ID);
                                                if (sfc.Show_ID == Day1_Show_ID)
                                                {
                                                    if (OwnersDrawnOnDay1.IndexOf(thisClassRow.Owner_ID) == -1)
                                                        OwnersDrawnOnDay1.Add(thisClassRow.Owner_ID);
                                                }
                                                else
                                                {
                                                    if (OwnersDrawnOnDay2.IndexOf(thisClassRow.Owner_ID) == -1)
                                                        OwnersDrawnOnDay2.Add(thisClassRow.Owner_ID);
                                                }
                                                if (DogsDrawn.IndexOf(thisClassRow.Dog_ID) == -1)
                                                    DogsDrawn.Add(thisClassRow.Dog_ID);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public static void AllocateRunningOrdersStage3(Guid show_ID, Guid user_ID)
        {
            if (AllEntriesInClass != null && AllEntriesInClass.Count > 0)
            {
                SetClassesAndDrawQty(show_ID);
                if (ClassesAndDrawQtyList != null && ClassesAndDrawQtyList.Count > 0)
                {
                    //All Classes - Lowest to Highest 
                    //Owner has more than one class entered
                    for (int i = (ClassesAndDrawQtyList.Count-1); i > -1; i--)
                    {
                        Guid thisClass_ID = ClassesAndDrawQtyList[i].Show_Final_Class_ID;
                        DogClasses dogClass = new DogClasses();
                        short thisClassRunningOrder = dogClass.GetMaxRunningOrderForClass(thisClass_ID);
                        foreach (OwnersDogsClassesDrawn thisClassRow in AllEntriesInClass)
                        {
                            if (OwnersDrawn.IndexOf(thisClassRow.Owner_ID) == -1 && DogsDrawn.IndexOf(thisClassRow.Dog_ID) == -1)
                            //if (!thisClassRow.OwnerDrawnOnDay)
                            {
                                if (thisClassRow.Show_Final_Class_ID == thisClass_ID)
                                {
                                    if (!thisClassRow.Helper && !(thisClassRow.OwnerDogCount == 1 && thisClassRow.ClassesPerOwnerEnteredCount == 1))
                                    {
                                        if (thisClassRow.ClassesPerOwnerEnteredCount > 1)
                                        {
                                            thisClassRunningOrder += 1;
                                            if (thisClassRunningOrder <= ClassesAndDrawQtyList[i].DrawQty)
                                            {
                                                UpdateRunningOrder(thisClassRow, thisClassRunningOrder, user_ID);
                                                if (OwnersDrawn.IndexOf(thisClassRow.Owner_ID) == -1)
                                                    OwnersDrawn.Add(thisClassRow.Owner_ID);
                                                ShowFinalClasses sfc = new ShowFinalClasses(thisClassRow.Show_Final_Class_ID);
                                                if (sfc.Show_ID == Day1_Show_ID)
                                                {
                                                    if (OwnersDrawnOnDay1.IndexOf(thisClassRow.Owner_ID) == -1)
                                                        OwnersDrawnOnDay1.Add(thisClassRow.Owner_ID);
                                                }
                                                else
                                                {
                                                    if (OwnersDrawnOnDay2.IndexOf(thisClassRow.Owner_ID) == -1)
                                                        OwnersDrawnOnDay2.Add(thisClassRow.Owner_ID);
                                                }
                                                if (DogsDrawn.IndexOf(thisClassRow.Dog_ID) == -1)
                                                    DogsDrawn.Add(thisClassRow.Dog_ID);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private static void UpdateRunningOrder(OwnersDogsClassesDrawn row, int runningOrder, Guid user_ID)
        {
            DogClasses dc = new DogClasses(row.Dog_Class_ID);
            dc.Running_Order = short.Parse(runningOrder.ToString());
            dc.Update_Dog_Class(row.Dog_Class_ID, user_ID);
        }
        private static void SetRunningOrderNull(OwnersDogsClassesDrawn row, Guid user_ID)
        {
            DogClasses dc = new DogClasses(row.Dog_Class_ID);
            dc.Running_Order = null;
            dc.Update_Dog_Class(row.Dog_Class_ID, user_ID);
        }
        public static void SetClassesAndDrawQty(Guid show_ID)
        {
            bool lowestClassSet = false;
            List<ClassesAndDrawQty> classesAndDrawQtyList = new List<ClassesAndDrawQty>();
            ShowFinalClasses showFinalClasses = new ShowFinalClasses();
            List<ShowFinalClasses> showFinalClassList = showFinalClasses.GetShow_Final_ClassesByShow_ID(show_ID);
            foreach (ShowFinalClasses row in showFinalClassList)
            {
                if (row.Show_Final_Class_Description != "NFC"
                    && !row.Show_Final_Class_Description.Contains("YKC")
                    && !row.Show_Final_Class_Description.Contains("Champ"))
                {
                    int drawQty = 10;
                    DogClasses dogClass = new DogClasses();
                    int entryCount = dogClass.GetEntryCountByShow_Final_Class_ID(row.Show_Final_Class_ID);
                    if (entryCount <= Constants.DRAW_QTY_LESS_THAN)
                    {
                        drawQty = 6;
                    }
                    ClassesAndDrawQty classAndDrawQty = new ClassesAndDrawQty();
                    classAndDrawQty.Show_Final_Class_ID = row.Show_Final_Class_ID;
                    classAndDrawQty.DrawQty = drawQty;
                    if (!lowestClassSet)
                    {
                        classAndDrawQty.LowestClass = true;
                        lowestClassSet = true;
                    }
                    classesAndDrawQtyList.Add(classAndDrawQty);
                }
            }
            ClassesAndDrawQtyList = classesAndDrawQtyList;
        }
    }

    public class ClassesAndDrawQty
    {
        public ClassesAndDrawQty()
        {

        }
        private Guid _show_Final_Class_ID;
        public Guid Show_Final_Class_ID
        {
            get { return _show_Final_Class_ID; }
            set { _show_Final_Class_ID = value; }
        }
        private int _drawQty = 0;
        public int DrawQty
        {
            get { return _drawQty; }
            set { _drawQty = value; }
        }
        private bool _runningOrdersAllocated = false;
        public bool RunningOrdersAllocated
        {
            get { return _runningOrdersAllocated; }
            set { _runningOrdersAllocated = value; }
        }
        private bool _lowestClass = false;
        public bool LowestClass
        {
            get { return _lowestClass; }
            set { _lowestClass = value; }
        }
    }

    public class OwnersDogsClassesDrawn
    {
        private sss.tblOwnersDogsClassesDrawnListDataTable tblOwnersDogsClassesDrawnList = null;

        public OwnersDogsClassesDrawn()
        {

        }
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
        //private List<People> _owners;
        //public List<People> Owners
        //{
        //    get { return _owners; }
        //    set { _owners = value; }
        //}
        private Dogs _dog;
        public Dogs Dog
        {
            get { return _dog; }
            set { _dog = value; }
        }
        private Guid _entrant_ID;
        public Guid Entrant_ID
        {
            get { return _entrant_ID; }
            set { _entrant_ID = value; }
        }
        private DateTime _entry_Date;
        public DateTime Entry_Date
        {
            get { return _entry_Date; }
            set { _entry_Date = value; }
        }
        private Guid _owner_ID;
        public Guid Owner_ID
        {
            get { return _owner_ID; }
            set { _owner_ID = value; }
        }
        private Guid _dog_ID;
        public Guid Dog_ID
        {
            get { return _dog_ID; }
            set { _dog_ID = value; }
        }
        private Guid _dog_Class_ID;
        public Guid Dog_Class_ID
        {
            get { return _dog_Class_ID; }
            set { _dog_Class_ID = value; }
        }
        private Guid _show_Final_Class_ID;
        public Guid Show_Final_Class_ID
        {
            get { return _show_Final_Class_ID; }
            set { _show_Final_Class_ID = value; }
        }
        private string _dog_KC_Name;
        public string Dog_KC_Name
        {
            get { return _dog_KC_Name; }
            set { _dog_KC_Name = value; }
        }
        private short _running_Order;
        public short Running_Order
        {
            get { return _running_Order; }
            set { _running_Order = value; }
        }
        private bool _offer_Of_Help;
        public bool Offer_Of_Help
        {
            get { return _offer_Of_Help; }
            set { _offer_Of_Help = value; }
        }
        private string _show_Final_Class_Description;
        public string Show_Final_Class_Description
        {
            get { return _show_Final_Class_Description; }
            set { _show_Final_Class_Description = value; }
        }
        private DogClasses _dogClass;
        public DogClasses DogClass
        {
            get { return _dogClass; }
            set { _dogClass = value; }
        }
        private bool _ownerDrawn;
        public bool OwnerDrawn
        {
            get { return _ownerDrawn; }
            set { _ownerDrawn = value; }
        }
        private bool _ownerDrawnOnDay;
        public bool OwnerDrawnOnDay
        {
            get { return _ownerDrawnOnDay; }
            set { _ownerDrawnOnDay = value; }
        }
        private bool _dogDrawn;
        public bool DogDrawn
        {
            get { return _dogDrawn; }
            set { _dogDrawn = value; }
        }
        private bool _dogDrawnInClass;
        public bool DogDrawnInClass
        {
            get { return _dogDrawnInClass; }
            set { _dogDrawnInClass = value; }
        }
        private bool _highestClass;
        public bool HighestClass
        {
            get { return _highestClass; }
            set { _highestClass = value; }
        }
        private bool _oldestDog;
        public bool OldestDog
        {
            get { return _oldestDog; }
            set { _oldestDog = value; }
        }
        private bool _helper;
        public bool Helper
        {
            get { return _helper; }
            set { _helper = value; }
        }
        private bool _hasTicketDraw;
        public bool HasTicketDraw
        {
            get { return _hasTicketDraw; }
            set { _hasTicketDraw = value; }
        }
        private int _ownerDogCount;
        public int OwnerDogCount
        {
            get { return _ownerDogCount; }
            set { _ownerDogCount = value; }
        }
        private int _ownerDogsInClassCount;
        public int OwnerDogsInClassCount
        {
            get { return _ownerDogsInClassCount; }
            set { _ownerDogsInClassCount = value; }
        }
        private int _classesPerDogEnteredCount;
        public int ClassesPerDogEnteredCount
        {
            get { return _classesPerDogEnteredCount; }
            set { _classesPerDogEnteredCount = value; }
        }
        private int _classesPerOwnerEnteredCount;
        public int ClassesPerOwnerEnteredCount
        {
            get { return _classesPerOwnerEnteredCount; }
            set { _classesPerOwnerEnteredCount = value; }
        }
        public List<OwnersDogsClassesDrawn> GetOwnerDogsClassesDrawnList(Guid show_ID, Guid? show_Final_Class_ID, bool display)
        {
            RunningOrdersBL rOBL = new RunningOrdersBL();
            tblOwnersDogsClassesDrawnList = rOBL.GetOwnersDogsClassesDrawn(display);

            List<OwnersDogsClassesDrawn> displayList = new List<OwnersDogsClassesDrawn>();
            OwnersDogsClassesDrawn displayItem = new OwnersDogsClassesDrawn();
            if (tblOwnersDogsClassesDrawnList != null && tblOwnersDogsClassesDrawnList.Count > 0)
            {
                short ring_No = 0;
                Shows show = new Shows(show_ID);

                string show_Final_Class_Description = string.Empty;

                ClearDrawnFlags();
                int rowCount = 0;
                int rowCountRO = 0;
                int rowCountInScope = 0;
                foreach (sss.tblOwnersDogsClassesDrawnListRow oDCDLRow in tblOwnersDogsClassesDrawnList)
                {
                    rowCount += 1;
                    if (!oDCDLRow.IsRunning_OrderNull())
                    {
                        rowCountRO += 1;
                        displayItem.Running_Order = oDCDLRow.Running_Order;
                        if (oDCDLRow.Running_Order > 0 && oDCDLRow.Running_Order < 21)
                        {
                            rowCountInScope += 1;
                            //if (display)
                                SetDrawnFlags(oDCDLRow, show_ID);
                            displayItem.DogDrawnInClass = true;
                        }
                    }
                }
                foreach (sss.tblOwnersDogsClassesDrawnListRow row in tblOwnersDogsClassesDrawnList)
                {
                    ShowFinalClasses sfc = new ShowFinalClasses(row.Show_Final_Class_ID);
                    if ((ring_No != row.Ring_No && ring_No != 0) || (ring_No == row.Ring_No && show_Final_Class_Description != row.Show_Final_Class_Description))
                    {
                        //new ring number
                        OwnersDogsClassesDrawn completeRow = BuildCompleteRow(displayItem);
                        displayList.Add(completeRow);
                        displayItem = new OwnersDogsClassesDrawn();
                    }
                    if (!row.IsRunning_OrderNull())
                    {
                        displayItem.Running_Order = row.Running_Order;
                        if (row.Running_Order > 0 && row.Running_Order < 21)
                        {
                            //if (display)
                                SetDrawnFlags(row, show_ID);
                            displayItem.DogDrawnInClass = true;
                        }
                    }
                    displayItem.Ring_No = row.Ring_No;
                    displayItem.Owners.Add(row.Owner);
                    if (RunningOrders.OwnersDrawn.IndexOf(row.Owner_ID) != -1)
                        displayItem.OwnerDrawn = true;
                    if ((Guid)sfc.Show_ID == RunningOrders.Day1_Show_ID)
                    {
                        if (RunningOrders.OwnersDrawnOnDay1.IndexOf(row.Owner_ID) != -1)
                            displayItem.OwnerDrawnOnDay = true;
                    }
                    else
                    {
                        if (RunningOrders.OwnersDrawnOnDay2.IndexOf(row.Owner_ID) != -1)
                            displayItem.OwnerDrawnOnDay = true;
                    }
                    displayItem.Dog_KC_Name = row.Dog_KC_Name;
                    if (!row.IsOffer_Of_HelpNull())
                    {
                        displayItem.Offer_Of_Help = row.Offer_Of_Help;
                        displayItem.Helper = row.Offer_Of_Help;
                    }
                    else
                        displayItem.Helper = false;
                    displayItem.HighestClass = IsHighestClass(row);
                    displayItem.OldestDog = IsOldestDog(row);
                    displayItem.Entrant_ID = row.Entrant_ID;
                    if (!row.IsEntry_DateNull())
                        displayItem.Entry_Date = row.Entry_Date;
                    displayItem.Owner_ID = row.Owner_ID;
                    displayItem.Dog_ID = row.Dog_ID;
                    if (RunningOrders.DogsDrawn.IndexOf(row.Dog_ID) != -1)
                        displayItem.DogDrawn = true;
                    displayItem.Dog_Class_ID = row.Dog_Class_ID;
                    displayItem.Show_Final_Class_ID = row.Show_Final_Class_ID;
                    SetOwnerDogCounts(row, show_ID);
                    displayItem.OwnerDogCount = RunningOrders.OwnerDogCount;
                    displayItem.OwnerDogsInClassCount = RunningOrders.OwnerDogsInClassCount;
                    displayItem.ClassesPerOwnerEnteredCount = RunningOrders.ClassesPerOwnerEnteredCount;
                    displayItem.ClassesPerDogEnteredCount = RunningOrders.ClassesPerDogEnteredCount;
                    displayItem.Show_Final_Class_Description = row.Show_Final_Class_Description;
                    show_Final_Class_Description = row.Show_Final_Class_Description;
                    //displayList.Add(displayItem);
                    ring_No = row.Ring_No;
                }
                OwnersDogsClassesDrawn completeRowFinal = BuildCompleteRow(displayItem);
                displayList.Add(completeRowFinal);
            }

            return displayList;
        }
        private OwnersDogsClassesDrawn BuildCompleteRow(OwnersDogsClassesDrawn displayItem)
        {
            OwnersDogsClassesDrawn completeRow = new OwnersDogsClassesDrawn();
            completeRow.Ring_No = displayItem.Ring_No;
            string ownerList = string.Empty;
            displayItem.Owners.Sort();
            foreach (string owner in displayItem.Owners)
            {
                if (ownerList.IndexOf(owner) == -1)
                {
                    ownerList = string.Format("{0}{1}", ownerList, " & " + owner);
                }
            }
            completeRow.Owner = ownerList.Substring(3);
            completeRow.Owner_ID = displayItem.Owner_ID;
            completeRow.Entrant_ID = displayItem.Entrant_ID;
            completeRow.OwnerDrawn = displayItem.OwnerDrawn;
            completeRow.OwnerDrawnOnDay = displayItem.OwnerDrawnOnDay;
            completeRow.Dog_KC_Name = displayItem.Dog_KC_Name;
            completeRow.Running_Order = displayItem.Running_Order;
            completeRow.DogDrawnInClass = displayItem.DogDrawnInClass;
            completeRow.Offer_Of_Help = displayItem.Offer_Of_Help;
            completeRow.Helper = displayItem.Helper;
            completeRow.HighestClass = displayItem.HighestClass;
            completeRow.OldestDog = displayItem.OldestDog;
            completeRow.Show_Final_Class_Description = displayItem.Show_Final_Class_Description;
            completeRow.Dog_ID = displayItem.Dog_ID;
            completeRow.DogDrawn = displayItem.DogDrawn;
            completeRow.Dog_Class_ID = displayItem.Dog_Class_ID;
            completeRow.Show_Final_Class_ID = displayItem.Show_Final_Class_ID;
            completeRow.OwnerDogCount = displayItem.OwnerDogCount;
            completeRow.OwnerDogsInClassCount = displayItem.OwnerDogsInClassCount;
            completeRow.ClassesPerOwnerEnteredCount = displayItem.ClassesPerOwnerEnteredCount;
            completeRow.ClassesPerDogEnteredCount = displayItem.ClassesPerDogEnteredCount;

            return completeRow;
        }
        private bool IsHighestClass(sss.tblOwnersDogsClassesDrawnListRow row)
        {
            bool isHighestClass = true;
            ShowFinalClasses sfcCurrent = new ShowFinalClasses(row.Show_Final_Class_ID);
            short currentClassNo = sfcCurrent.Show_Final_Class_No;
            DogClasses dc = new DogClasses();
            List<DogClasses> dogClassesList = dc.GetDog_ClassesByDog_ID(row.Dog_ID);
            foreach (DogClasses dcRow in dogClassesList)
            {
                if (dcRow.Show_Final_Class_ID != null)
                {
                    Guid show_Final_Class_ID = (Guid)dcRow.Show_Final_Class_ID;
                    ShowFinalClasses sfc = new ShowFinalClasses(show_Final_Class_ID);
                    if (sfc.Show_Final_Class_No > currentClassNo)
                        isHighestClass = false;
                }
            }
            return isHighestClass;
        }
        private void SetOwnerDogCounts(sss.tblOwnersDogsClassesDrawnListRow row, Guid show_ID)
        {
            RunningOrders.OwnerDogCount = 0;
            RunningOrders.OwnerDogsInClassCount = 0;
            RunningOrders.ClassesPerOwnerEnteredCount = 0;
            RunningOrders.ClassesPerDogEnteredCount = 0;

            List<Guid> ownerDogsList = new List<Guid>();
            List<Guid> ownerDogsInClassList = new List<Guid>();
            List<Guid> classesPerOwnerEnteredList = new List<Guid>();
            List<Guid> classesPerDogEnteredList = new List<Guid>();
            DogClasses dogClass = new DogClasses();
            List<DogClasses> dogClasses1 = dogClass.GetDog_ClassesByDog_ID((Guid)row.Dog_ID);
            foreach (DogClasses dogClass1 in dogClasses1)
            {
                ShowFinalClasses sfc = new ShowFinalClasses((Guid)dogClass1.Show_Final_Class_ID);
                if ((Guid)sfc.Show_ID == show_ID)
                {
                    if (classesPerDogEnteredList.IndexOf((Guid)dogClass1.Show_Entry_Class_ID) == -1)
                        classesPerDogEnteredList.Add((Guid)dogClass1.Show_Entry_Class_ID);
                }
            }
            DogOwners dogOwner = new DogOwners();
            List<DogOwners> dogOwnerList = dogOwner.GetDogOwnersByOwner_ID(row.Owner_ID);
            foreach (DogOwners dogOwnerRow in dogOwnerList)
            {
                List<DogClasses> dogClasses = dogClass.GetDog_ClassesByEntrant_ID(row.Entrant_ID);
                foreach (DogClasses dcRow in dogClasses)
                {
                    ShowFinalClasses sfc = new ShowFinalClasses((Guid)dcRow.Show_Final_Class_ID);
                    if ((Guid)sfc.Show_ID == show_ID)
                    {
                        Guid dog_ID = (Guid)dcRow.Dog_ID;
                        Guid dog_Class_ID = (Guid)dcRow.Dog_Class_ID;
                        Guid show_Entry_Class_ID = (Guid)dcRow.Show_Entry_Class_ID;
                        ShowEntryClasses sec = new ShowEntryClasses(show_Entry_Class_ID);
                        ClassNames cn = new ClassNames(int.Parse(sec.Class_Name_ID.ToString()));
                        if (cn.Class_Name_Description != "NFC")
                        {
                            if (ownerDogsList.IndexOf(dog_ID) == -1)
                                ownerDogsList.Add(dog_ID);
                            if (classesPerOwnerEnteredList.IndexOf(show_Entry_Class_ID) == -1)
                                classesPerOwnerEnteredList.Add(show_Entry_Class_ID);
                            if (dcRow.Show_Entry_Class_ID == sfc.Show_Entry_Class_ID)
                            {
                                if (ownerDogsInClassList.IndexOf(dog_ID) == -1)
                                    ownerDogsInClassList.Add(dog_ID);
                            }
                        }
                    }
                }
            }
            RunningOrders.OwnerDogCount = ownerDogsList.Count;
            RunningOrders.OwnerDogsInClassCount = ownerDogsInClassList.Count;
            RunningOrders.ClassesPerOwnerEnteredCount = classesPerOwnerEnteredList.Count;
            RunningOrders.ClassesPerDogEnteredCount = classesPerDogEnteredList.Count;
        }
        private bool IsOldestDog(sss.tblOwnersDogsClassesDrawnListRow row)
        {
            bool oldestDog = true;
            Dogs currentDog = new Dogs(row.Dog_ID);
            int? currentYOB = currentDog.Year_Of_Birth;
            if(currentYOB == null)
            {
                DateTime? currentDOB = currentDog.Date_Of_Birth;
                if(currentDOB != null)
                {
                    DateTime dteCurrentDOB = (DateTime)currentDOB;
                    currentYOB = dteCurrentDOB.Year;
                }
                else
                {
                    return true;
                }
            }
            DogOwners dogOwner = new DogOwners();
            List<DogOwners> dogOwnerList = dogOwner.GetDogOwnersByOwner_ID(row.Owner_ID);
            foreach (DogOwners dogOwnerRow in dogOwnerList)
            {                
                if (dogOwnerRow.Dog_ID != row.Dog_ID)
                {
                    Dogs thisDog = new Dogs(dogOwnerRow.Dog_ID);
                    int? thisYOB = thisDog.Year_Of_Birth;
                    if (thisYOB == null)
                    {
                        DateTime? thisDOB = thisDog.Date_Of_Birth;
                        if (thisDOB != null)
                        {
                            DateTime dteThisDOB = (DateTime)thisDOB;
                            thisYOB = dteThisDOB.Year;
                        }
                        else
                        {
                            thisYOB=0;
                        }
                    }
                    if (thisYOB < currentYOB)
                        return false;                        
                }
            }
            return oldestDog;
        }
        private void ClearDrawnFlags()
        {
            RunningOrders.OwnersDrawn = null;
            RunningOrders.OwnersDrawnOnDay1 = null;
            RunningOrders.OwnersDrawnOnDay2 = null;
            RunningOrders.DogsDrawn = null;
        }
        private void SetDrawnFlags(sss.tblOwnersDogsClassesDrawnListRow row, Guid show_ID)
        {
            bool setFlags = true;
            //if((row.Show_Final_Class_Description.Contains("Champ") || row.Show_Final_Class_Description.Contains("YKC")) && row.Running_Order <= 20)
            //{
            //    setFlags=false;
            //}
            if (setFlags)
            {
                //Dog Level Flag
                if (RunningOrders.DogsDrawn.IndexOf(row.Dog_ID) == -1)
                {
                    RunningOrders.DogsDrawn.Add(row.Dog_ID);
                }
                //Owner Level Flag
                if (RunningOrders.OwnersDrawn.IndexOf(row.Owner_ID) == -1)
                {
                    RunningOrders.OwnersDrawn.Add(row.Owner_ID);
                }
                ShowFinalClasses sfc = new ShowFinalClasses(row.Show_Final_Class_ID);
                if ((Guid)sfc.Show_ID == RunningOrders.Day1_Show_ID)
                {
                    if (RunningOrders.OwnersDrawnOnDay1.IndexOf(row.Owner_ID) == -1)
                        RunningOrders.OwnersDrawnOnDay1.Add(row.Owner_ID);
                }
                else
                {
                    if (RunningOrders.OwnersDrawnOnDay2.IndexOf(row.Owner_ID) == -1)
                        RunningOrders.OwnersDrawnOnDay2.Add(row.Owner_ID);
                }
            }
        }
        public static bool DeleteOwnersDogsClassesDrawnList()
        {
            bool success = false;

            RunningOrdersBL runningOrders = new RunningOrdersBL();
            success = runningOrders.DeleteOwnersDogsClassesList();

            return success;
        }
        public bool PopulateOwnersDogsClassesDrawnList(Guid show_ID, Guid? show_Final_Class_ID, bool display)
        {
            bool success = false;

            if (show_Final_Class_ID == new Guid())
                show_Final_Class_ID = null;

            RunningOrdersBL runningOrders = new RunningOrdersBL();
            if (display)
                success = runningOrders.PopulateOwnersDogsClassesList(show_ID, show_Final_Class_ID);
            else
                success = runningOrders.PopulateOwnersDogsClassesListOrderByEntry_Date(show_ID, null);

            return success;
        }
        public static List<OwnersDogsClassesDrawn> GetOwnersDogsClassesDrawnListData(Guid show_ID, Guid? show_Final_Class_ID, bool display)
        {
            List<OwnersDogsClassesDrawn> ownersDogsClassesDrawnList = new List<OwnersDogsClassesDrawn>();
            OwnersDogsClassesDrawn ownersDogsClassesDrawn = new OwnersDogsClassesDrawn();
            if (ownersDogsClassesDrawn.PopulateOwnersDogsClassesDrawnList(show_ID, show_Final_Class_ID, display))
            {
                ownersDogsClassesDrawnList = ownersDogsClassesDrawn.GetOwnerDogsClassesDrawnList(show_ID, show_Final_Class_ID, display);
            }
            return ownersDogsClassesDrawnList;
        }
    }
}
