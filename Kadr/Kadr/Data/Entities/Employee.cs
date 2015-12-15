using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;
using Kadr.Controllers;
using System.Data.Linq;


namespace Kadr.Data
{
    public partial class Employee : UIX.Views.IDecorable, UIX.Views.IValidatable, INullable, IComparable, IExperienceProvider
    {
         public string currentEmployeeName
         {
             get
             {
                 return LastName + " " + FirstName + " " + Otch;
             }
         }

         public string currentEmployeeSmallName
        {
             get
             {
                 if ((FirstName != null) && (Otch != null))
                     return LastName + " " + FirstName[0] + "." + Otch[0] + ".";
                 else
                     return LastName;
             }
         }

        /// <summary>
        /// возвращает все договоры сотрудника (без доп соглашений)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Contract> GetAllMainContracts()
        {
            return FactStaffs.SelectMany(x => x.FactStaffHistories).SelectMany(y => y.Events).Where(x => x.EventKind != null).Where(x
                        => x.EventKind.ForFactStaff).Where(x => x.Contract != null).Select(z => z.Contract).Where(m => m.idMainContract == null).Where(x => x.id > 0).Concat(
                            FactStaffs.SelectMany(x => x.FactStaffHistories).SelectMany(y => y.Events).Where(x => x.EventKind != null).Where(x
                              => x.EventKind.ForFactStaff).Where(x => x.Contract != null).Select(z => z.Contract).Where(m => m.idMainContract != null).Select(x => x.MainContract).Where(x => x.id > 0)).Distinct();
        }


        public EmployeeRank Rank
        {
            get
            {
                return EmployeeRanks.OrderBy(empR => empR.Rank.RankOrder).LastOrDefault();
            }
        }

        public EmployeeDegree Degree
        {
            get
            {
                return EmployeeDegrees.OrderBy(empD => empD.Degree.DegreeOrder).LastOrDefault();
            }
        }

        public string EmployeeGender
        {
            get
            {
                if (this.SexBit)
                    return "Мужской";
                else
                    return "Женский";
            }
        }


        public override string ToString()
        {
            if (BirthDate != null)
                return currentEmployeeName + " ("+BirthDate.Value.ToShortDateString()+")";
            return this.currentEmployeeName;
        }


        #region partial Methods
        partial void OnCreated()
        {
            RayonKoeff = 30;
            SeverKoeff = 50;

        }


        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            if ((action == ChangeAction.Insert) || (action == ChangeAction.Update))
            {
                if (Grazd.IsNull()) throw new ArgumentNullException("Гражданство сотрудника.");
                if (SemPol.IsNull()) throw new ArgumentNullException("Семейное положение сотрудника.");
                if ((LastName == null) || (LastName == "")) throw new ArgumentNullException("Фамилия сотрудника.");
                if ((FirstName == null) || (FirstName == "")) throw new ArgumentNullException("Имя сотрудника.");
            }
        }

        partial void OnLoaded()
        {
        }

        #endregion

        #region IDecorable Members

        public object GetDecorator()
        {
            return new EmployeeDecorator(this);
        }

        #endregion

        #region IValidatable Members

        void UIX.Views.IValidatable.Validate()
        {
            OnValidate(ChangeAction.Insert);
        }

        #endregion


        #region Члены IComparable

        public int CompareTo(object obj)
        {
            return EmployeeName.CompareTo(obj.ToString());
        }

        #endregion

        #region Члены IEmployeeExperienceRecord

        public IEnumerable<IEmployeeExperienceRecord> EmployeeExperiences
        {
            get
            {
                // Записи из трудовой книжки, другие организации
                var standingSet = EmployeeStandings.Cast<IEmployeeExperienceRecord>();
                // Записи из штатного расписания, эта организация
                // ===Записи замещения временно исключены, поскольку вызывают зацикливание программы====
                // var stuffSet = FactStaffs.Cast<IEmployeeExperienceRecord>();
                var stuffSet = FactStaffs.Where(x => x.DateBegin < DateTime.Today).Where(x=>!x.isReplacement).Cast<IEmployeeExperienceRecord>();
                // Записи о пребываниях в различных регионах во время командировок
                var tripsSet = GetAllRegionTypes().Cast<IEmployeeExperienceRecord>();

                return tripsSet.Concat(standingSet).Concat(stuffSet);
            }
        }

        #endregion

        public IEnumerable<BusinessTrip> GetAllTrips()
        {
            return  FactStaffs.SelectMany(x => x.FactStaffHistories).SelectMany(x => x.Events).Select(p => p.Event_BusinessTrip).Where(p=>p!=null).Select(x=>x.BusinessTrip).Distinct();
        }

        public IEnumerable<BusinessTripRegionType> GetAllRegionTypes()
        {
            return GetAllTrips().SelectMany(x => x.BusinessTripRegionTypes);
        }

    }

    public class NullEmployee : Employee, INull
    {

        private NullEmployee()
        {
            this.id = 0;
        }

        public static readonly NullEmployee Instance = new NullEmployee();


        public override string ToString()
        {
            return "(Не задан)";
        }

    }

}
