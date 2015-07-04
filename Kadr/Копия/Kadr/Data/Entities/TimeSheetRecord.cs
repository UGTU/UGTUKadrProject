using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;

namespace Kadr.Data
{
    public class TimeSheetRecord: TimeSheetFSWorkingDay
    {
        public TimeSheetRecord(FactStaff FactStaff, TimeSheet TimeSheet, decimal StaffCount, int daysCount)
        {
            factStaff = FactStaff;
            timeSheet = TimeSheet;
            staffCount = StaffCount;
            timeSheetFSRecord = NullTimeSheetFSWorkingDay.Instance;
            workingDaysCount = daysCount;
        }


        public TimeSheetRecord(TimeSheetFSWorkingDay tShRecord)
        {
            factStaff = tShRecord.FactStaff;
            timeSheetFSRecord = tShRecord;
        }
        


        private TimeSheetFSWorkingDay timeSheetFSRecord;
        public TimeSheetFSWorkingDay TimeSheetFSRecord
        {
            get
            {
                return timeSheetFSRecord;
            }
            set
            {
                timeSheetFSRecord = value;
            }
        }

        public string Department
        {
            get
            {
                if (factStaff!= null)
                    if (factStaff.Department != null)
                        return factStaff.Department.DepartmentSmallName;
                return "";
            }
            
        }
        private TimeSheet timeSheet;

        private decimal staffCount;

        private int workingDaysCount;

        private FactStaff factStaff;
        public FactStaff FactStaff
        {
            get
            {
                return factStaff;
            }
            set
            {
                factStaff = value;
            }
        }

        public bool IsClosed
        {
            get
            {
                if (IsCreated)
                    return timeSheetFSRecord.IsClosed;
                return false;
            }
         }


        public bool IsCreated
        {
            get
            {
                return (!(timeSheetFSRecord as INull).IsNull());
                    
            }
            
        }

        public decimal StaffCount
        {
            get
            {
                if (IsCreated)
                    return timeSheetFSRecord.StaffCount;
                else
                    return staffCount;
            }
        }

        public int WorkingDaysCount
        {
            get
            {
                if (IsCreated)
                    return timeSheetFSRecord.WorkingDaysCount;
                else
                    return workingDaysCount;
            }
         }
    }

}
