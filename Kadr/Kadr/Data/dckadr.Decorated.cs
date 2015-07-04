using System;
//using System.
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.UI.Editors;
using Kadr.Controllers;
using Kadr.Data;
using Kadr.Data.Common;

namespace Kadr.Data
{
    #region Department Decorator
    class DepartmentDecorator
    {
        private Dep department;
        public DepartmentDecorator(Dep department)
        {
            this.department = department;
        }

        override public string ToString()
        {
            return "Отдел "+department.ToString();
        }

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код отдела")]
        [System.ComponentModel.ReadOnly(true)]
        public int ID
        {
            get
            {
                return department.id;
            }
            set
            {
                department.id = value;
            }
        }

        [System.ComponentModel.DisplayName("KadrID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Код отдела в системе отдела кадров")]
        [System.ComponentModel.ReadOnly(true)]
        public int KadrID
        {
            get
            {
                //if (department.KadrID!=null)
                return Convert.ToInt16(department.KadrID);
                //else return 0;
            }
            set
            {
                department.KadrID = value;
            }
        }

        [System.ComponentModel.DisplayName("LastChangeID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("LastChangeID")]
        [System.ComponentModel.ReadOnly(true)]
        public int LastChangeID
        {
            get
            {
                //if (department.KadrID!=null)
                return Convert.ToInt16(department.LastChange.id);
                //else return 0;
            }
            
        }

        [System.ComponentModel.DisplayName("Название отдела")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Уникальное название отдела в организации")]
        public string DepartmentName
        {
            get
            {
                return department.DepartmentName;
            }
            set
            {
                department.DepartmentName = value;
            }
        }

        [System.ComponentModel.DisplayName("Краткое название отдела")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Краткое название отдела в организации")]
        public string DepartmentSmallName
        {
            get
            {
                return department.DepartmentSmallName;
            }
            set
            {
                department.DepartmentSmallName = value;
            }
        }

        [System.ComponentModel.DisplayName("Руководитель отдела")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Руководитель отдела")]
        [System.ComponentModel.Editor(typeof(PlanStaffEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public PlanStaff ManagmentPlanStaff
        {
            get
            {
                return department.PlanStaff;
            }
            set
            {
                department.PlanStaff = value;
            }
        }

        [System.ComponentModel.DisplayName("ОКВЭД")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Код экономической деятельности")]
        [System.ComponentModel.Editor(typeof(OKVEDEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public OKVED OKVED
        {
            get
            {
                return department.OKVED;
            }
            set
            {
                department.OKVED = value;
            }
        }

        [System.ComponentModel.DisplayName("Руководящий отдел")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Руководящий отдел")]
        [System.ComponentModel.Editor(typeof(DepartmentEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Department ManagerDepartment
        {
            get
            {
                if (department.ManagerDepartment != null)
                    return department.ManagerDepartment.Department;
                else
                    return null;
            }
            set
            {
                if (value != null)
                    department.ManagerDepartment = value.Dep;
                else
                    department.ManagerDepartment = null;
            }
        }

        [System.ComponentModel.DisplayName("Дата создания")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Дата создания отдела")]
        public DateTime dateCreate
        {
            get
            {
                return Convert.ToDateTime(department.dateCreate);
            }
            set
            {
                department.dateCreate = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата расформирования")]
        [System.ComponentModel.Category("Расформирование отдела")]
        [System.ComponentModel.Description("Дата расформирования отдела")]
        public DateTime dateExit
        {
            get
            {
                return Convert.ToDateTime(department.dateExit);
            }
            set
            {
                department.dateExit = value;
            }
        }

        [System.ComponentModel.DisplayName("Приказ о создании")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Приказ о создании отдела")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Prikaz PrikazBegin
        {
            get
            {
                return department.PrikazBegin;
            }
            set
            {
                department.PrikazBegin = value;
            }
        }

        [System.ComponentModel.DisplayName("Приказ о расформировании")]
        [System.ComponentModel.Category("Расформирование отдела")]
        [System.ComponentModel.Description("Приказ о расформировании отдела")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Prikaz PrikazEnd
        {
            get
            {
                return department.Prikaz;
            }
            set
            { 
                department.Prikaz = value;
            }
        }

        [System.ComponentModel.DisplayName("Центр затрат отдела")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Центр затрат отдела")]
        [System.ComponentModel.Editor(typeof(FundingCenterEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public FundingCenter FundingCenter
        {
            get
            {
                return department.FundingCenter;
            }
            set
            {
                department.FundingCenter = value;
            }
        }

        [System.ComponentModel.DisplayName("Номер телефона отдела")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Основной номер телефона отдела")]
        public string DepPhoneNumber
        {
            get
            {
                return department.DepPhoneNumber;
            }
            set
            {
                department.DepPhoneNumber = value;
            }
        }

        [System.ComponentModel.DisplayName("Код отдела")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Код отдела")]
        public string DepartmentIndex
        {
            get
            {
                return department.DepartmentIndex;
            }
            set
            {
                department.DepartmentIndex = value;
            }
        }

        [System.ComponentModel.DisplayName("Тип отдела")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Код типа отдела")]
        public int? WorkSheduleToIntSing
        {
            get
            {
                if (department.DepartmentType == null)
                    return null;
                return department.DepartmentType.id;
            }
            set
            {
                if (value == null)
                    department.DepartmentType = null;
                else
                    department.DepartmentType = KadrController.Instance.Model.DepartmentTypes.Where(dt => dt.id == value).SingleOrDefault();
            }
        }
    }
    #endregion

    #region DepartmentHistory Decorator
    class DepartmentHistoryDecorator
    {
        private DepartmentHistory departmentHistory;
        public DepartmentHistoryDecorator(DepartmentHistory departmentHistory)
        {
            this.departmentHistory = departmentHistory;
        }

        override public string ToString()
        {
            return departmentHistory.ToString();
        }

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код отдела")]
        [System.ComponentModel.ReadOnly(true)]
        public int ID
        {
            get
            {
                return departmentHistory.id;
            }
            set
            {
                departmentHistory.id = value;
            }
        }
 
        [System.ComponentModel.DisplayName("Название отдела")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Уникальное название отдела в организации")]
        public string DepartmentName
        {
            get
            {
                return departmentHistory.DepartmentName;
            }
            set
            {
                departmentHistory.DepartmentName = value;
            }
        }

        [System.ComponentModel.DisplayName("Краткое название отдела")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Краткое название отдела в организации")]
        public string DepartmentSmallName
        {
            get
            {
                return departmentHistory.DepartmentSmallName;
            }
            set
            {
                departmentHistory.DepartmentSmallName = value;
            }
        }

        
        [System.ComponentModel.DisplayName("Руководящий отдел")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Руководящий отдел")]
        [System.ComponentModel.Editor(typeof(DepartmentEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Department ManagerDepartment
        {
            get
            {
                if (departmentHistory.Dep1 != null)
                    return departmentHistory.Dep1.Department;
                else
                    return null;
            }
            set
            {
                if (value != null)
                    departmentHistory.Dep1 = value.Dep;
            }
        }

        [System.ComponentModel.DisplayName("Дата изменения")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Дата изменения отдела")]
        public DateTime dateCreate
        {
            get
            {
                return Convert.ToDateTime(departmentHistory.DateBegin);
            }
            set
            {
                departmentHistory.DateBegin = value;
            }
        }

        
        [System.ComponentModel.DisplayName("Приказ о создании")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Приказ о создании отдела")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Prikaz PrikazBegin
        {
            get
            {
                return departmentHistory.Prikaz;
            }
            set
            {
                departmentHistory.Prikaz = value;
            }
        }

        

    }
    #endregion

    #region PlanStaff Decorator
    class PlanStaffDecorator
    {
        private PlanStaff planStaff;

        override public string ToString()
        {
            return "Штатное расписание отдела "+planStaff.Dep.ToString().ToLower();
        }

        public PlanStaffDecorator(PlanStaff planStaff)
        {
            this.planStaff = planStaff;
        }

        private dckadrDataContext model
        {
            get
            {
                return KadrController.Instance.Model;
            }
        }

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код записи в штатном расписании")]
        [System.ComponentModel.ReadOnly(true)]
        public int ID
        {
            get
            {
                return planStaff.id;
            }
            set
            {
                planStaff.id = value;
            }
        }

        [System.ComponentModel.DisplayName("Отдел")]
        [System.ComponentModel.Category("Общие")]
        [System.ComponentModel.Description("Название отдела, к которому относится запись в штатном расписании")]
        //[System.ComponentModel.Editor(typeof(Kadr.UI.Editors.DepartmentEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [System.ComponentModel.ReadOnly(true)]
        public Kadr.Data.Dep Department
        {
            get
            {
                //return model.Departments.First(dep => dep.id == planStaff.idDepartment);
                return planStaff.Dep;
            }
            set
            {
                planStaff.Dep = value;
            }
        }

        [System.ComponentModel.DisplayName("Должность")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Название должности в штатном расписании")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PostEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Post Post
        {
            get
            {
                return planStaff.Post;
            }
            set
            {
                planStaff.Post = value;
            }
        }

        [System.ComponentModel.DisplayName("Количество ставок")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Запланированное количество ставок в штатном расписании")]
        public decimal StaffCount
        {
            get
            {
                return planStaff.StaffCount;
            }
            set
            {
                if (value >= 0.1M)
                    planStaff.StaffCount = value;
                else
                    throw new ApplicationException("Количество ставок не может быть меньше 0,1.");
            }
        }

        [System.ComponentModel.DisplayName("Приказ утверждения")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Приказ утверждения записи в штатном расписании")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Prikaz PrikazBegin
        {
            get
            {
                return planStaff.PrikazBegin;
            }
            set
            {
                planStaff.PrikazBegin = value;
            }
        }

        [System.ComponentModel.DisplayName("Приказ отмены")]
        [System.ComponentModel.Category("Отмена штатного расписания")]
        [System.ComponentModel.Description("Приказ отмены записи в штатном расписании")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Prikaz PrikazEnd
        {
            get
            {
                return planStaff.Prikaz;
            }
            set
            {
                planStaff.Prikaz = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата назначения")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Дата назначения")]
        // [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PostEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public DateTime DataBegin
        {
            get
            {
                return Convert.ToDateTime(planStaff.DateBegin);
            }
            set
            {
                planStaff.DateBegin = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата отмены")]
        [System.ComponentModel.Category("Отмена штатного расписания")]
        [System.ComponentModel.Description("Дата отмены")]
        // [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PostEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public DateTime DataEnd
        {
            get
            {
                return Convert.ToDateTime(planStaff.DateEnd);
            }
            set
            {
                planStaff.DateEnd = value;
            }
        }
        [System.ComponentModel.DisplayName("Источник финансирования")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Источник финансирования записи в штатном расписании")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.AllFinancingSourceEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.FinancingSource FinancingSource
        {
            get
            {
                return planStaff.FinancingSource;
            }
            set
            {
                planStaff.FinancingSource = value;
            }
        }

        [System.ComponentModel.DisplayName("График работы")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("График работы сотрудников на данной должности")]
        public int? WorkSheduleToIntSing
        {
            get
            {
                if (planStaff.WorkShedule == null)
                    return null;
                return planStaff.WorkShedule.ToIntSign;
            }
            set
            {
                planStaff.WorkShedule = WorkShedule.IntSignToShedule(value);
            }
        }

    }
    #endregion

    #region FactStaff Decorator
    class FactStaffDecorator
    {
        private FactStaff factStaff;
        public FactStaffDecorator(FactStaff factStaff)
        {
            this.factStaff = factStaff;
        }

        public override string ToString()
        {
             return "Распределение штатов отдела " + factStaff.Department.ToString().ToLower() + ", " +
                factStaff.Post.ToString().ToLower();
        }

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код сотрудника в штатном расписании")]
        [System.ComponentModel.ReadOnly(true)]
        public int ID
        {
            get
            {
                return factStaff.id;
            }
            set
            {
                factStaff.id = value;
            }
        }

        [System.ComponentModel.DisplayName("ФИО сотрудника")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("ФИО сотрудника, назначенного на должность")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.EmployeeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Employee Employee
        {
            get
            {
                return factStaff.Employee;
            }
            set
            {
                factStaff.Employee = value;
            }
        }

        [System.ComponentModel.DisplayName("Количество ставок")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Занимаемое сотрудником по факту количество ставок")]
        public decimal StaffCount
        {
            get
            {
                return factStaff.StaffCount;
            }
            set
            {
                factStaff.StaffCount = value;
            }
        }

        
        [System.ComponentModel.DisplayName("Подподкатегория")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Подподкатегория (определяет коэффициент к окладу сотрудника)")]
        public int? SalaryKoeff
        {
            get
            {
                if (factStaff.SalaryKoeff != null)
                    return factStaff.SalaryKoeff.PKSubSubCategoryNumber;
                return null;
            }
            set
            {
                factStaff.SalaryKoeff = KadrController.Instance.Model.SalaryKoeffs.Where(koef => koef.PKSubSubCategoryNumber == value).FirstOrDefault();
            }
        }

        
        [System.ComponentModel.DisplayName("Должность в штатном расписании")]
        [System.ComponentModel.Category("Общие")]
        [System.ComponentModel.Description("Должность в штатном расписании")]
        public Kadr.Data.PlanStaff PlanStaff
        {
            get
            {
                return factStaff.PlanStaff;
            }
        }

        [System.ComponentModel.DisplayName("Название вида работы")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Название вида работы")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.WorkTypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.WorkType WorkType
        {
            get
            {
                return factStaff.WorkType;
            }
            set
            {
                factStaff.WorkType = value;
            }
        }

        /*[System.ComponentModel.DisplayName("Источник финансирования")]
        [System.ComponentModel.Category("Почасовики")]
        [System.ComponentModel.Description("Источник финансирования (редактировать для почасовиков)")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.FinancingSourceEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.FinancingSource FinancingSource
        {
            get
            {
                return factStaff.FinancingSource;
            }
            set
            {
                factStaff.FinancingSource = value;
            }
        }*/

        [System.ComponentModel.DisplayName("ОКВЭД")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Код экономической деятельности")]
        [System.ComponentModel.Editor(typeof(OKVEDEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public OKVED OKVED
        {
            get
            {
                return factStaff.OKVED;
            }
            set
            {
                factStaff.OKVED = value;
            }
        }

        [System.ComponentModel.DisplayName("Приказ утверждения")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Приказ назначения сотрудника")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Prikaz PrikazBegin
        {
            get
            {
                return factStaff.PrikazBegin;
            }
            set
            {
                factStaff.PrikazBegin = value;
            }
        }

        [System.ComponentModel.DisplayName("Приказ увольнения")]
        [System.ComponentModel.Category("Параметры увольнения")]
        [System.ComponentModel.Description("Приказ увольнения сотрудника")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Prikaz PrikazEnd
        {
            get
            {
                return factStaff.Prikaz;
            }
            set
            {
                factStaff.Prikaz = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата назначения")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Дата назначения на должность")]
        // [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PostEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public DateTime DataBegin
        {
            get
            {
                return Convert.ToDateTime(factStaff.DateBegin);
            }
            set
            {
                factStaff.DateBegin = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата увольнения")]
        [System.ComponentModel.Category("Параметры увольнения")]
        [System.ComponentModel.Description("Дата снятия с должности")]
        // [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PostEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public DateTime DataEnd
        {
            get
            {
                return Convert.ToDateTime(factStaff.DateEnd);
            }
            set
            {
                factStaff.DateEnd = value;
                //если есть замещения данного сотрудника, то их надо отменить (указать дату окончания)
                /*if ((value != null) )
                {
                    foreach (FactStaffReplacement replacement in FactStaff.FactStaffReplacements)
                    {
                        replacement.DateEnd = value;
                        replacement.FactStaff1.IsReplacement = false;
                    }
                }*/
            }



        }

        [System.ComponentModel.DisplayName("Центр затрат")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Центр затрат")]
        [System.ComponentModel.Editor(typeof(FundingCenterEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public FundingCenter FundingCenter
        {
            get
            {
                return factStaff.FundingCenter;
            }
            set
            {
                factStaff.FundingCenter = value;
            }
        }

        
    }


    #endregion

    #region FactStaffReplacement Decorator
    class FactStaffReplacementDecorator
    {
        private FactStaffReplacement factStaffReplacement;
        public FactStaffReplacementDecorator(FactStaffReplacement factStaffReplacement)
        {
            this.factStaffReplacement = factStaffReplacement;
        }


        public override string ToString()
        {
            string res = "Cовмещение сотрудника ";

            if (!factStaffReplacement.ReplacedFactStaff.IsNull())
                res = res + factStaffReplacement.ReplacedFactStaff.ToString();
            return res;
        }

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код сотрудника (совмещающего) в штатном расписании")]
        [System.ComponentModel.ReadOnly(true)]
        public int ID
        {
            get
            {
                return factStaffReplacement.MainFactStaff.id;
            }
        }

        [System.ComponentModel.DisplayName("ФИО совмещающего сотрудника")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("ФИО совмещающего сотрудника")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.EmployeeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Employee Employee
        {
            get
            {
                return factStaffReplacement.MainFactStaff.Employee;
            }
            set
            {
                factStaffReplacement.MainFactStaff.Employee = value;
            }
        }


        [System.ComponentModel.DisplayName("Отдел")]
        [System.ComponentModel.Category("Общие")]
        [System.ComponentModel.Description("Название отдела")]
        [System.ComponentModel.ReadOnly(true)]
        // [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PostEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Dep Department
        {
            get
            {
                return factStaffReplacement.ReplacedFactStaff.PlanStaff.Dep;
            }
            set
            {
                factStaffReplacement.ReplacedFactStaff.PlanStaff.Dep = value;
            }
        }

        [System.ComponentModel.DisplayName("Должность")]
        [System.ComponentModel.Category("Общие")]
        [System.ComponentModel.Description("Название должности в штатном расписании")]
        [System.ComponentModel.ReadOnly(true)]
        // [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PostEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Post Post
        {
            get
            {
                return factStaffReplacement.ReplacedFactStaff.PlanStaff.Post;
            }
            set
            {
                factStaffReplacement.ReplacedFactStaff.PlanStaff.Post = value;
            }
        }


        [System.ComponentModel.DisplayName("Название вида работы")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Название вида работы")]
        //[System.ComponentModel.ReadOnly(true)]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.WorkTypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.WorkType WorkType
        {
            get
            {
                return factStaffReplacement.MainFactStaff.WorkType;
            }
            set
            {
                factStaffReplacement.MainFactStaff.WorkType = value;
            }
        }

        [System.ComponentModel.DisplayName("ФИО совмещаемого сотрудника")]
        [System.ComponentModel.Category("Общие")]
        [System.ComponentModel.Description("ФИО совмещаемого сотрудника")]
        [System.ComponentModel.ReadOnly(true)]
        public Kadr.Data.Employee ReplacedEmployee
        {
            get
            {
                return factStaffReplacement.ReplacedFactStaff.Employee;
            }
            set
            {
                factStaffReplacement.ReplacedFactStaff.Employee = value;
            }
        }

        [System.ComponentModel.DisplayName("% совмещения")]
        [System.ComponentModel.Category("Параметры совмещения")]
        [System.ComponentModel.Description("% совмещения сотрудника")]
        public decimal StaffCount
        {
            get
            {
                return factStaffReplacement.ReplacedPercent;
            }
            set
            {
                factStaffReplacement.ReplacedPercent = value;
            }
        }

        [System.ComponentModel.DisplayName("Причина совмещения")]
        [System.ComponentModel.Category("Параметры совмещения")]
        [System.ComponentModel.Description("Причина замещения сотрудника")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.FactStaffReplacementReasonEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.FactStaffReplacementReason FactStaffReplacementReason
        {
            get
            {
                return factStaffReplacement.FactStaffReplacementReason;
            }
            set
            {
                factStaffReplacement.FactStaffReplacementReason = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата окончания совмещения")]
        [System.ComponentModel.Category("Параметры совмещения")]
        [System.ComponentModel.Description("Дата окончания совмещения")]
        // [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PostEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public DateTime ReplacementDataEnd
        {
            get
            {
                return Convert.ToDateTime(factStaffReplacement.DateEnd);
            }
            set
            {
                factStaffReplacement.DateEnd = value;
                if (value == DateTime.MinValue)
                    factStaffReplacement.DateEnd = null;
                if (factStaffReplacement.DateEnd == null)
                    factStaffReplacement.FactStaff1.IsReplacement = true;
                else
                    factStaffReplacement.FactStaff1.IsReplacement = false;
           }
        }

        [System.ComponentModel.DisplayName("Приказ утверждения")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Приказ назначения сотрудника")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Prikaz PrikazBegin
        {
            get
            {
                return factStaffReplacement.MainFactStaff.PrikazBegin;
            }
            set
            {
                factStaffReplacement.MainFactStaff.PrikazBegin = value;
            }
        }

        [System.ComponentModel.DisplayName("Приказ увольнения")]
        [System.ComponentModel.Category("Параметры увольнения")]
        [System.ComponentModel.Description("Приказ увольнения сотрудника")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Prikaz PrikazEnd
        {
            get
            {
                return factStaffReplacement.MainFactStaff.Prikaz;
            }
            set
            {
                factStaffReplacement.MainFactStaff.Prikaz = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата назначения")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Дата назначения на должность")]
        // [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PostEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public DateTime DataBegin
        {
            get
            {
                return Convert.ToDateTime(factStaffReplacement.MainFactStaff.DateBegin);
            }
            set
            {
                factStaffReplacement.MainFactStaff.DateBegin = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата увольнения")]
        [System.ComponentModel.Category("Параметры увольнения")]
        [System.ComponentModel.Description("Дата снятия с должности")]
        // [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PostEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public DateTime DataEnd
        {
            get
            {
                return Convert.ToDateTime(factStaffReplacement.MainFactStaff.DateEnd);
            }
            set
            {
                if ((value != null) && ((factStaffReplacement.DateEnd == null)
                        || (factStaffReplacement.DateEnd == factStaffReplacement.MainFactStaff.DateEnd)))
                    factStaffReplacement.DateEnd = value;
                factStaffReplacement.MainFactStaff.DateEnd = value;
            }
        }

        [System.ComponentModel.DisplayName("Подподкатегория")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Подподкатегория (определяет коэффициент к окладу сотрудника)")]
        public int? SalaryKoeff
        {
            get
            {
                if (factStaffReplacement.MainFactStaff.SalaryKoeff != null)
                    return factStaffReplacement.MainFactStaff.SalaryKoeff.PKSubSubCategoryNumber;
                return null;
            }
            set
            {
                factStaffReplacement.MainFactStaff.SalaryKoeff = KadrController.Instance.Model.SalaryKoeffs.Where(koef => koef.PKSubSubCategoryNumber == value).FirstOrDefault();
            }
        }

        [System.ComponentModel.DisplayName("Количество часов")]
        [System.ComponentModel.Category("Почасовики")]
        [System.ComponentModel.Description("Количество часов для почасовиков")]
        public decimal? HourCount
        {
            get
            {
                return factStaffReplacement.MainFactStaff.HourCount;
            }
            set
            {
                factStaffReplacement.MainFactStaff.HourCount = value;
            }
        }

        [System.ComponentModel.DisplayName("Оплата за час (без 1,8)")]
        [System.ComponentModel.Category("Почасовики")]
        [System.ComponentModel.Description("Оплата за час (без 1,8) для почасовиков")]
        public decimal? HourSalary
        {
            get
            {
                return factStaffReplacement.MainFactStaff.HourSalary;
            }
            set
            {
                factStaffReplacement.MainFactStaff.HourSalary = value;
            }
        }
    }


    #endregion

    #region BonusType Decorator
    class BonusTypeDecorator
    {
        private BonusType bonusType;
        public BonusTypeDecorator(BonusType bonusType)
        {
            this.bonusType = bonusType;
        }

        override public string ToString()
        {
            //return pkCategory.ToString();
            return "Bид надбавки " + BonusTypeName;
        }

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код вида надбавки")]
        [System.ComponentModel.ReadOnly(true)]
        public int ID
        {
            get
            {
                return bonusType.id;
            }
            set
            {
                bonusType.id = value;
            }
        }

        [System.ComponentModel.DisplayName("Единица измерения")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Единица измерения надбавки")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.BonusMeasureEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public BonusMeasure BonusMeasure
        {
            get
            {
                return bonusType.BonusMeasure;
            }
            set
            {
                bonusType.BonusMeasure = value;
            }
        }

        [System.ComponentModel.DisplayName("Тип надбавки")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Тип надбавки")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.BonusSuperTypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public BonusSuperType BonusSuperType
        {
            get
            {
                return bonusType.BonusSuperType;
            }
            set
            {
                bonusType.BonusSuperType = value;
            }
        }

        [System.ComponentModel.DisplayName("Название вида надбавки")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Полное название вида надбавки")]
        public string BonusTypeName
        {
            get
            {
                return bonusType.BonusTypeName;
            }
            set
            {
                bonusType.BonusTypeName = value;
            }
        }

        [System.ComponentModel.DisplayName("Источник финансирования")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Источник финансирования, используемый по умолчанию для данного вида надбавки")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.AllFinancingSourceEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public FinancingSource FinancingSource
        {
            get
            {
                return bonusType.FinancingSource;
            }
            set
            {
                bonusType.FinancingSource = value;
            }
        }

        [System.ComponentModel.DisplayName("Краткое название")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Краткое название вида надбавки")]
        public string BonusTypeShortName
        {
            get
            {
                return bonusType.BonusTypeShortName;
            }
            set
            {
                bonusType.BonusTypeShortName = value;
            }
        }

        [System.ComponentModel.DisplayName("Начисляются северные")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Признак, указывающий начисляются ли северный и районный коэффициент для надбавки")]
        [System.ComponentModel.TypeConverter(typeof(Kadr.UI.Common.CustomBooleanConverter))]
        public bool HasEnvironmentBonus
        {
            get
            {
                return bonusType.HasEnvironmentBonus;
            }
            set
            {
                bonusType.HasEnvironmentBonus = value;
            }
        }

        [System.ComponentModel.DisplayName("Зависит от размера ставки")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Признак, указывающий зависит ли размер надбавки от размера ставки")]
        [System.ComponentModel.TypeConverter(typeof(Kadr.UI.Common.CustomBooleanConverter))]
        public bool IsStaffRateable
        {
            get
            {
                return bonusType.IsStaffRateable;
            }
            set
            {
                bonusType.IsStaffRateable = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата отмены")]
        [System.ComponentModel.Category("Параметры отмены")]
        [System.ComponentModel.Description("Дата отмены вида надбавки")]
        public DateTime DateBegin
        {
            get
            {
                return Convert.ToDateTime(bonusType.DateEnd);
            }
            set
            {
                bonusType.DateEnd = value;
            }
        }
    }


    #endregion

    #region Bonus Decorator
    class BonusDecorator
    {
        private Bonus bonus;
        public BonusDecorator(Bonus bonus)
        {
            this.bonus = bonus;
        }

        override public string ToString()
        {
            return "Надбавка";
        }

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код надбавки в системе")]
        [System.ComponentModel.ReadOnly(true)]
        public int ID
        {
            get
            {
                return bonus.id;
            }
            set
            {
                bonus.id = value;
            }
        }


        [System.ComponentModel.DisplayName("Размер надбавки")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Последний размер, назначенной сотруднику надбавки")]
        public decimal BonusCount
        {
            get
            {
                return bonus.LastBonusCount;
            }
            set
            {
                bonus.LastBonusCount = value;
            }
        }

        [System.ComponentModel.DisplayName("Источник финансирования")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Последний назначенный источник финансирования надбавки")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.AllFinancingSourceEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public FinancingSource FinancingSource
        {
            get
            {
                return bonus.LastFinancingSource;
            }
            set
            {
                bonus.LastFinancingSource = value;
            }
        }

        [System.ComponentModel.DisplayName("Примечание")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Примечание к надбавке")]
        public string Comment
        {
            get
            {
                return bonus.Comment;
            }
            set
            {
                bonus.Comment = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата начала начисления")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Дата начала начисления (последнего изменения) надбавки")]
        public DateTime DateBegin
        {
            get
            {
                return Convert.ToDateTime( bonus.LastDateBegin );
            }
            set
            {
                bonus.LastDateBegin = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата прекращения начисления")]
        [System.ComponentModel.Category("Прекращение начисления")]
        [System.ComponentModel.Description("Дата прекращения начисления надбавки")]
        public DateTime DateEnd
        {
            get
            {
                return Convert.ToDateTime( bonus.DateEnd );
            }
            set
            {
                bonus.DateEnd = value;
            }
        }

        [System.ComponentModel.DisplayName("Вид надбавки")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Вид назначаемой надбавки")]
        [System.ComponentModel.Editor(typeof(BonusTypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public BonusType BonusType
        {
            get
            {
                return bonus.BonusType;
            }
            set
            {
                bonus.BonusType = value;
                if (value != null)
                    bonus.LastFinancingSource = value.FinancingSource;
            }
        }

        [System.ComponentModel.DisplayName("Приказ назначения")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Приказ назначения (последнего изменения) надбавки")]
        [System.ComponentModel.Editor(typeof(PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Prikaz Prikaz
        {
            get
            {
                return bonus.LastPrikazBegin;
            }
            set
            {
                bonus.LastPrikazBegin = value;
            }
        }


        [System.ComponentModel.DisplayName("Промежуточный приказ отмены")]
        [System.ComponentModel.Category("Прекращение начисления")]
        [System.ComponentModel.Description("Промежуточный приказ отмены надбавки")]
        [System.ComponentModel.Editor(typeof(PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Prikaz IntermediateEndPrikaz
        {
            get
            {
                return bonus.IntermediateEndPrikaz;
            }
            set
            {
                bonus.IntermediateEndPrikaz = value;
            }
        }
        
        [System.ComponentModel.DisplayName("Приказ отмены")]
        [System.ComponentModel.Category("Прекращение начисления")]
        [System.ComponentModel.Description("Приказ отмены надбавки")]
        [System.ComponentModel.Editor(typeof(PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Prikaz EndPrikaz
        {
            get
            {
                return bonus.EndPrikaz;
            }
            set
            {
                bonus.EndPrikaz = value;
            }
        }


        [System.ComponentModel.DisplayName("Надбавка только для вакансий")]
        [System.ComponentModel.Category("Атрибуты надбавки штатной должности")]
        [System.ComponentModel.Description("Показатель того, что надбавка только для вакансий")]
        [System.ComponentModel.TypeConverter(typeof(Kadr.UI.Common.CustomBooleanConverter))]
        public bool ForVacancy
        {
            get
            {
                if (bonus.BonusPlanStaff != null)
                    return bonus.BonusPlanStaff.ForVacancy;
                else
                    return true;
            }
            set
            {
                if (bonus.BonusPlanStaff != null)
                    bonus.BonusPlanStaff.ForVacancy = value;
            }
        }

        [System.ComponentModel.DisplayName("Надбавка только для сотрудников")]
        [System.ComponentModel.Category("Атрибуты надбавки штатной должности")]
        [System.ComponentModel.Description("Показатель того, что надбавка только для сотрудников")]
        [System.ComponentModel.TypeConverter(typeof(Kadr.UI.Common.CustomBooleanConverter))]
        public bool ForEmployee
        {
            get
            {
                if (bonus.BonusPlanStaff != null)
                    return bonus.BonusPlanStaff.ForEmployee;
                else
                    return false;
            }
            set
            {
                if (bonus.BonusPlanStaff != null)
                    bonus.BonusPlanStaff.ForEmployee = value;
            }
        }
    }
    #endregion

    #region Prikaz Decorator
    class PrikazDecorator
    {

        private Prikaz prikaz;
        public PrikazDecorator(Prikaz prikaz)
        {
            this.prikaz = prikaz;
        }

        override public string ToString()
        {
            return "Приказ "+prikaz.ToString();
        }

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код приказа в системе")]
        [System.ComponentModel.ReadOnly(true)]
        public int ID
        {
            get
            {
                return prikaz.id;
            }
            set
            {
                prikaz.id = value;
            }
        }


        [System.ComponentModel.DisplayName("Название приказа")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Название приказа")]
        public string PrikazName
        {
            get
            {
                return prikaz.PrikazName;
            }
            set
            {
                prikaz.PrikazName = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата вступления в силу")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Дата вступления приказа в силу")]
        public DateTime DatePrikaz
        {
            get
            {
                return  Convert.ToDateTime(prikaz.DatePrikaz);
            }
            set
            {
                prikaz.DatePrikaz = value;
            }
        }

        [System.ComponentModel.DisplayName("Вид приказа")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Вид приказа")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PrikazTypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.PrikazType PrikazType
        {
            get
            {
                return prikaz.PrikazType;
            }
            set
            {
                prikaz.PrikazType = value;
            }
        }


    }
    #endregion

    #region Employee Decorator
    class EmployeeDecorator
    {
        private Employee employee;
        public EmployeeDecorator(Employee employee)
        {
            this.employee = employee;
        }

        override public string ToString()
        {
            
            return "Сотрудник " + employee.EmployeeSmallName;
        }

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код сотрудника")]
        [System.ComponentModel.ReadOnly(true)]
        public int ID
        {
            get
            {
                return employee.id;
            }
            set
            {
                employee.id = value;
            }
        }

        [System.ComponentModel.DisplayName("Табельный номер")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Табельный номер сотрудника в системе отдела кадров")]
        public string itab_n
        {
            get
            {
                
                return (employee.itab_n);
            }
            set
            {
                employee.itab_n = value;
            }
        }

        [System.ComponentModel.DisplayName("Фамилия")]
        [System.ComponentModel.Category("Фамилия, имя, отчество")]
        [System.ComponentModel.Description("Фамилия сотрудника")]
        public string LastName
        {
            get
            {
                return employee.LastName;
            }
            set
            {
                employee.LastName = value;
            }
        }

        [System.ComponentModel.DisplayName("Пол")]
        [System.ComponentModel.Category("Личные данные")]
        [System.ComponentModel.Description("Пол сотрудника")]
        [System.ComponentModel.TypeConverter(typeof(Kadr.UI.Common.GenderBooleanConverter))]//Kadr.UI.Common.CustomBooleanConverter
        public bool SexBit
        {
            get
            {
                return employee.SexBit;
            }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
            set
            {
                employee.SexBit = value;
            }
        }

        [System.ComponentModel.DisplayName("Имя")]
        [System.ComponentModel.Category("Фамилия, имя, отчество")]
        [System.ComponentModel.Description("Имя сотрудника")]
        public string FirstName
        {
            get
            {
                return employee.FirstName;
            }
            set
            {
                employee.FirstName = value;
            }
        }

        [System.ComponentModel.DisplayName("Отчество")]
        [System.ComponentModel.Category("Фамилия, имя, отчество")]
        [System.ComponentModel.Description("Отчество сотрудника")]
        public string Otch
        {
            get
            {
                return employee.Otch;
            }
            set
            {
                employee.Otch = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата рождения")]
        [System.ComponentModel.Category("Личные данные")]
        [System.ComponentModel.Description("Дата рождения сотрудника")]
        public DateTime BirthDate
        {
            get
            {
                return Convert.ToDateTime(employee.BirthDate);
            }
            set
            {
                employee.BirthDate = value;
            }
        }

        [System.ComponentModel.DisplayName("Место рождения")]
        [System.ComponentModel.Category("Личные данные")]
        [System.ComponentModel.Description("Место рождения сотрудника")]
        public string BirthPlace
        {
            get
            {
                return employee.BirthPlace;
            }
            set
            {
                employee.BirthPlace = value;
            }
        }

        [System.ComponentModel.DisplayName("Районный коэффициент")]
        [System.ComponentModel.Category("Коэффициенты")]
        [System.ComponentModel.Description("Районный коэффициент сотрудника")]
        public int RayonKoeff
        {
            get
            {
                return employee.RayonKoeff;
            }
            set
            {
                employee.RayonKoeff = value;
            }
        }

        [System.ComponentModel.DisplayName("Северный коэффициент")]
        [System.ComponentModel.Category("Коэффициенты")]
        [System.ComponentModel.Description("Северный коэффициент сотрудника")]
        public int SeverKoeff
        {
            get
            {
                return employee.SeverKoeff;
            }
            set
            {
                employee.SeverKoeff = value;
            }
        }

        [System.ComponentModel.DisplayName("Гражданство")]
        [System.ComponentModel.Category("Личные данные")]
        [System.ComponentModel.Description("Гражданство сотрудника")]
        [System.ComponentModel.Editor(typeof(GrazdEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Grazd Grazd
        {
            get
            {
                return employee.Grazd;
            }
            set
            {
                employee.Grazd = value;
            }
        }

        [System.ComponentModel.DisplayName("Семейное положение")]
        [System.ComponentModel.Category("Личные данные")]
        [System.ComponentModel.Description("Семейное положение сотрудника")]
        [System.ComponentModel.Editor(typeof(SemPolEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public SemPol SemPol
        {
            get
            {
                return employee.SemPol;
            }
            set
            {
                employee.SemPol = value;
            }
        }

    }
    #endregion

    #region PKGroup Decorator
    class PKGroupDecorator
    {
        private PKGroup pkGroup;
        public PKGroupDecorator(PKGroup pkGroup)
        {
            this.pkGroup = pkGroup;
        }

        override public string ToString()
        {
            return pkGroup.ToString();
        }

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код профессионально-квалификационной группы")]
        [System.ComponentModel.ReadOnly(true)]
        public int ID
        {
            get
            {
                return pkGroup.id;
            }
            set
            {
                pkGroup.id = value;
            }
        }

        [System.ComponentModel.DisplayName("Полное имя профессионально-квалификационной группы")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Полное имя профессионально-квалификационной группы")]
        [System.ComponentModel.ReadOnly(true)]
        public string GroupFullName
        {
            get
            {
                return pkGroup.GroupNumber + " (" + pkGroup.GroupName + ")";
            }
        }
    }


    #endregion

    #region PKCategory Decorator
    class PKCategoryDecorator
    {
        private PKCategory pkCategory;
        public PKCategoryDecorator(PKCategory pkCategory)
        {
            this.pkCategory = pkCategory;
        }

        override public string ToString()
        {
            //return pkCategory.ToString();
            return "Профессионально-квалификационный подуровень " + CategoryFullName;
        }

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код профессионально-квалификационного подуровня")]
        [System.ComponentModel.ReadOnly(true)]
        public int ID
        {
            get
            {
                return pkCategory.id;
            }
            set
            {
                pkCategory.id = value;
            }
        }

        [System.ComponentModel.DisplayName("Номер уровня")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Номер профессионально-квалификационного уровня")]
        public int PKCategoryNumber
        {
            get
            {
                return pkCategory.PKCategoryNumber;
            }
            set
            {
                pkCategory.PKCategoryNumber = value;
            }
        }

        [System.ComponentModel.DisplayName("Номер подуровня 1")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Номер профессионально-квалификационного подуровня 1")]
        public int PKSubCategoryNumber
        {
            get
            {
                return pkCategory.PKSubCategoryNumber;
            }
            set
            {
                pkCategory.PKSubCategoryNumber = value;
            }
        }

        [System.ComponentModel.DisplayName("Номер подуровня 2")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Номер профессионально-квалификационного подуровня 2")]
        public int? PKSubSubCategoryNumber
        {
            get
            {
                return pkCategory.PKSubSubCategoryNumber;
            }
            set
            {
                pkCategory.PKSubSubCategoryNumber = value;
            }
        }

        [System.ComponentModel.DisplayName("Подподкатегория")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Подподкатегория (определяет коэффициент к окладу сотрудника)")]
        public int? SalaryKoeff
        {
            get
            {
                if (pkCategory.SalaryKoeff != null)
                    return pkCategory.SalaryKoeff.PKSubSubCategoryNumber;
                return null;
            }
            set
            {
                pkCategory.SalaryKoeff = KadrController.Instance.Model.SalaryKoeffs.Where(koef => koef.PKSubSubCategoryNumber == value).FirstOrDefault();
            }
        }

        [System.ComponentModel.DisplayName("Профессиональная группа")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Профессионально-квалификационная группа")]
        [System.ComponentModel.Editor(typeof(PKGroupEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public PKGroup PKGroup
        {
            get
            {
                return pkCategory.PKGroup;
            }
            set
            {
                pkCategory.PKGroup = value;
            }
        }

        [System.ComponentModel.DisplayName("Полное имя профессионально-квалификационного подуровня")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Полное имя профессионально-квалификационного подуровня")]
        [System.ComponentModel.ReadOnly(true)]
        public string CategoryFullName
        {
            get
            {
                return pkCategory.CategoryFullName;
            }
        }

        [System.ComponentModel.DisplayName("Комментарий")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Комментарий к профессионально-квалификационному подуровню")]
        public string PKComment
        {
            get
            {
                return pkCategory.PKComment;
            }
            set
            {
                pkCategory.PKComment = value;
            }
        }

        //[System.ComponentModel.DisplayName("PKCategorySalary")]
        //[System.ComponentModel.Category("Атрибуты")]
        //[System.ComponentModel.Description("Оклад профессионально-квалификационной категории")]
        //[System.ComponentModel.ReadOnly(true)]
        //public PKCategorySalary PKCategorySalary
        //{
        //    get
        //    {
        //        return pkCategory.PKCategorySalaries.Where(pkCatSal => pkCatSal.DateEnd == null).First() as PKCategorySalary;
        //    }
        //}

    }


    #endregion

    #region Post Decorator
    class PostDecorator
    {
        private Post post;
        public PostDecorator(Post post)
        {
            this.post = post;
        }

        override public string ToString()
        {
            return post.ToString();
        }

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код должности")]
        [System.ComponentModel.ReadOnly(true)]
        public int ID
        {
            get
            {
                return post.id;
            }
            set
            {
                post.id = value;
            }
        }

        [System.ComponentModel.DisplayName("Название должности")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Название должности")]
        public string PostName
        {
            get
            {
                return post.PostName;
            }
            set
            {
                post.PostName = value;
            }
        }


        [System.ComponentModel.DisplayName("Название категории персонала")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Название категории персонала, к которой относится должность")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.CategryEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Category Category
        {
            get
            {
                return post.Category;
            }
            set
            {
                post.Category = value;
            }
        }


        [System.ComponentModel.DisplayName("Новая категория персонала")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Название новой категории персонала, к которой относится должность")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.CategryEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Category NewCategory
        {
            get
            {
                return post.NewCategory;
            }
            set
            {
                post.NewCategory = value;
            }
        }


        [System.ComponentModel.DisplayName("Название группы должностей")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Название группы должностей, к которой относится должность")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PostGroupEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.PostGroup PostGroup
        {
            get
            {
                return post.PostGroup;
            }
            set
            {
                post.PostGroup = value;
            }
        }

        [System.ComponentModel.DisplayName("Название категории для ВПО-2")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Название категории для ВПО-2, к которой относится должность")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.CategoryVPOEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.CategoryVPO CategoryVPO
        {
            get
            {
                return post.CategoryVPO;
            }
            set
            {
                post.CategoryVPO = value;
            }
        }

        [System.ComponentModel.DisplayName("Название категории для ЗП-образования")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Название категории для ЗП-образования, к которой относится должность")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.CategoryZPEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.CategoryZP CategoryZP
        {
            get
            {
                return post.CategoryZP;
            }
            set
            {
                post.CategoryZP = value;
            }
        }
        
        [System.ComponentModel.DisplayName("Руководитель")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Руководящая должность")]
        [System.ComponentModel.TypeConverter(typeof(Kadr.UI.Common.CustomBooleanConverter))]
        //[System.ComponentModel.TypeConverter
        public bool ManagerBit
        {
            get
            {
                return post.ManagerBit;
            }
            set
            {
                post.ManagerBit = value;
            }
        }

        [System.ComponentModel.DisplayName("Профессиональный уровень")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Профессиональный уровень должности")]
        [System.ComponentModel.Editor(typeof(PKCategoryEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public PKCategory PKCategory
        {
            get
            {
                return post.PKCategory;
                
            }
            set
            {
                post.PKCategory = value;
            }
        }

        [System.ComponentModel.DisplayName("Приказ министерства")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Приказ министерства")]
        [System.ComponentModel.Editor(typeof(GlobalPrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public GlobalPrikaz GlobalPrikaz
        {
            get
            {
                return post.GlobalPrikaz;
            }
            set
            {
                post.GlobalPrikaz = value;
            }
        }

        [System.ComponentModel.DisplayName("Вид должности")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Вид должности")]
        [System.ComponentModel.Editor(typeof(PostTypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public PostType PostType
        {
            get
            {
                return post.PostType;

            }
            set
            {
                post.PostType = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата отмены должности")]
        [System.ComponentModel.Category("Параметры отмены")]
        [System.ComponentModel.Description("Дата отмены должности")]
        public DateTime DateBegin
        {
            get
            {
                return Convert.ToDateTime(post.DateEnd);
            }
            set
            {
                post.DateEnd = value;
            }
        }

        [System.ComponentModel.DisplayName("Примечание")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Комментарий к должности")]
        public string Comment
        {
            get
            {
                return post.Comment;
            }
            set
            {
                post.Comment = value;
            }
        }

        [System.ComponentModel.DisplayName("Код должности")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Код должности")]
        public string PostCode
        {
            get
            {
                return post.PostCode;
            }
            set
            {
                post.PostCode = value;
            }
        }

    }


    #endregion

    #region PKCategorySalary Decorator
    class PKCategorySalaryDecorator
    {
        private PKCategorySalary pkCategorySalary;
        public PKCategorySalaryDecorator(PKCategorySalary pkCategorySalary)
        {
            this.pkCategorySalary = pkCategorySalary;
        }

        override public string ToString()
        {
            return "Оклад " + pkCategorySalary.PKCategory.ToString();
        }

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код оклада")]
        [System.ComponentModel.ReadOnly(true)]
        public int ID
        {
            get
            {
                return pkCategorySalary.id;
            }
            set
            {
                pkCategorySalary.id = value;
            }
        }

        [System.ComponentModel.DisplayName("Профессиональный уровень")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Профессионально-квалификационный уровень")]
        public PKCategory PKCategory
        {
            get
            {
                return pkCategorySalary.PKCategory;
            }
            set
            {
                pkCategorySalary.PKCategory = value;
            }
        }

        [System.ComponentModel.DisplayName("Размер оклада")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Размер оклада профессионально-квалификационной категории")]
        //[System.ComponentModel.]
        public decimal SalarySize
        {
            get
            {
                return pkCategorySalary.SalarySize;
            }
            set
            {
                pkCategorySalary.SalarySize = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата назначения оклада")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Дата назначения оклада категории")]
        public DateTime DateBegin
        {
            get
            {
                return Convert.ToDateTime(pkCategorySalary.DateBegin);
            }
            set
            {
                pkCategorySalary.DateBegin = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата отмены оклада")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Дата отмены оклада категории")]
        public DateTime DateEnd
        {
            get
            {
                return Convert.ToDateTime(pkCategorySalary.DateEnd);
            }
            set
            {
                pkCategorySalary.DateEnd = value;
            }
        }

        [System.ComponentModel.DisplayName("Приказ назначения")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Приказ назначения оклада")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Prikaz Prikaz
        {
            get
            {
                return pkCategorySalary.Prikaz;
            }
            set
            {
                pkCategorySalary.Prikaz = value;
            }
        }
    }


    #endregion

    #region PlanStaffSalary Decorator
    class PlanStaffSalaryDecorator
    {
        private PlanStaffSalary PlanStaffSalary;
        public PlanStaffSalaryDecorator(PlanStaffSalary PlanStaffSalary)
        {
            this.PlanStaffSalary = PlanStaffSalary;
        }

        override public string ToString()
        {
            return "Оклад " + PlanStaffSalary.ToString();
        }

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код оклада")]
        [System.ComponentModel.ReadOnly(true)]
        //[System.ComponentModel.(true)]
        public int ID
        {
            get
            {
                return PlanStaffSalary.id;
            }
            set
            {
                PlanStaffSalary.id = value;
            }
        }

        [System.ComponentModel.DisplayName("Запись штатного расписания")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Запись штатного расписания")]
        public PlanStaff PlanStaff
        {
            get
            {
                return PlanStaffSalary.PlanStaff;
            }
            set
            {
                PlanStaffSalary.PlanStaff = value;
            }
        }

        [System.ComponentModel.DisplayName("Размер оклада")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Размер индивидуального оклада")]
        //[System.ComponentModel.]
        public decimal SalarySize
        {
            get
            {
                return PlanStaffSalary.SalarySize;
            }
            set
            {
                PlanStaffSalary.SalarySize = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата назначения оклада")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Дата назначения индивидуального оклада")]
        public DateTime DateBegin
        {
            get
            {
                return Convert.ToDateTime(PlanStaffSalary.DateBegin);
            }
            set
            {
                PlanStaffSalary.DateBegin = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата отмены оклада")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Дата отмены индивидуального оклада")]
        public DateTime DateEnd
        {
            get
            {
                return Convert.ToDateTime(PlanStaffSalary.DateEnd);
            }
            set
            {
                PlanStaffSalary.DateEnd = value;
            }
        }

        [System.ComponentModel.DisplayName("Приказ назначения")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Приказ назначения оклада")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Prikaz Prikaz
        {
            get
            {
                return PlanStaffSalary.Prikaz;
            }
            set
            {
                PlanStaffSalary.Prikaz = value;
            }
        }
    }


    #endregion

    #region EmployeeDegree Decorator
    class EmployeeDegreeDecorator
    {
        private EmployeeDegree employeeDegree;
        public EmployeeDegreeDecorator(EmployeeDegree employeeDegree)
        {
            this.employeeDegree = employeeDegree;
        }


        public override string ToString()
        {
            if (employeeDegree.Employee == null)
                return "Научная степень ";
            else
                return "Научная степень "+employeeDegree.Employee.ToString();
        }

        

        [System.ComponentModel.DisplayName("Диссертационный совет")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Диссертационный совет, в котором была защищена степень")]
        public string DissertCouncil
        {
            get
            {
                return employeeDegree.DissertCouncil;
            }
            set
            {
                employeeDegree.DissertCouncil = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата присвоения степени")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Дата присвоения научной степени")]
        public DateTime degreeDate
        {
            get
            {
                return Convert.ToDateTime(employeeDegree.degreeDate);
            }
            set
            {
                employeeDegree.degreeDate = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата выдачи диплома")]
        [System.ComponentModel.Category("Данные диплома")]
        [System.ComponentModel.Description("Дата выдачи диплома")]
        public DateTime DocDate
        {
            get
            {
                return Convert.ToDateTime(employeeDegree.EducDocument.DocDate);
            }
            set
            {
                employeeDegree.EducDocument.DocDate = value;
            }
        }

        [System.ComponentModel.DisplayName("Серия диплома")]
        [System.ComponentModel.Category("Данные диплома")]
        [System.ComponentModel.Description("Серия диплома")]
        public string DocSeries
        {
            get
            {
                return employeeDegree.EducDocument.DocSeries;
            }
            set
            {
                employeeDegree.EducDocument.DocSeries = value;
            }
        }

        [System.ComponentModel.DisplayName("Номер диплома")]
        [System.ComponentModel.Category("Данные диплома")]
        [System.ComponentModel.Description("Номер диплома")]
        public string DocNumber
        {
            get
            {
                return employeeDegree.EducDocument.DocNumber;
            }
            set
            {
                employeeDegree.EducDocument.DocNumber = value;
            }
        }

        [System.ComponentModel.DisplayName("Кем выдан диплом")]
        [System.ComponentModel.Category("Данные диплома")]
        [System.ComponentModel.Description("Кем выдан диплом")]
        public string diplWhere
        {
            get
            {
                return employeeDegree.diplWhere;
            }
            set
            {
                employeeDegree.diplWhere = value;
            }
        }

        [System.ComponentModel.DisplayName("Научная степень сотрудника")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Название научной степени сотрудника")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.DegreeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Degree Degree
        {
            get
            {
                return employeeDegree.Degree;
            }
            set
            {
                employeeDegree.Degree = value;
            }
        }

        [System.ComponentModel.DisplayName("Научное направление")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Научное направление, в котором присвоена степень")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.ScienceTypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.ScienceType ScienceType
        {
            get
            {
                return employeeDegree.ScienceType;
            }
            set
            {
                employeeDegree.ScienceType = value;
            }
        }
    }


    #endregion

    #region EmployeeRank Decorator
    class EmployeeRankDecorator
    {
        private EmployeeRank employeeRank;
        public EmployeeRankDecorator(EmployeeRank employeeRank)
        {
            this.employeeRank = employeeRank;
        }


        public override string ToString()
        {
            return "Ученое звание " + employeeRank.Employee.ToString();
        }


        [System.ComponentModel.DisplayName("Дата выдачи диплома")]
        [System.ComponentModel.Category("Данные диплома")]
        [System.ComponentModel.Description("Дата выдачи диплома")]
        public DateTime DocDate
        {
            get
            {
                return Convert.ToDateTime(employeeRank.EducDocument.DocDate);
            }
            set
            {
                employeeRank.EducDocument.DocDate = value;
            }
        }

        [System.ComponentModel.DisplayName("Серия диплома")]
        [System.ComponentModel.Category("Данные диплома")]
        [System.ComponentModel.Description("Серия диплома")]
        public string DocSeries
        {
            get
            {
                return employeeRank.EducDocument.DocSeries;
            }
            set
            {
                employeeRank.EducDocument.DocSeries = value;
            }
        }

        [System.ComponentModel.DisplayName("Номер диплома")]
        [System.ComponentModel.Category("Данные диплома")]
        [System.ComponentModel.Description("Номер диплома")]
        public string DocNumber
        {
            get
            {
                return employeeRank.EducDocument.DocNumber;
            }
            set
            {
                employeeRank.EducDocument.DocNumber = value;
            }
        }

        [System.ComponentModel.DisplayName("Кем выдан диплом")]
        [System.ComponentModel.Category("Данные диплома")]
        [System.ComponentModel.Description("Кем выдан диплом")]
        public string diplWhere
        {
            get
            {
                return employeeRank.rankWhere;
            }
            set
            {
                employeeRank.rankWhere = value;
            }
        }

        [System.ComponentModel.DisplayName("Ученое звание сотрудника")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Название ученого звания сотрудника")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.RankEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Rank Rank
        {
            get
            {
                return employeeRank.Rank;
            }
            set
            {
                employeeRank.Rank = value;
            }
        }

    }


    #endregion

    #region TimeSheet Decorator
    class TimeSheetDecorator
    {

        private TimeSheet timeSheet;
        public TimeSheetDecorator(TimeSheet timeSheet)
        {
            this.timeSheet = timeSheet;
        }

        override public string ToString()
        {
            return "Табель " + timeSheet.ToString();
        }

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код табеля в системе")]
        [System.ComponentModel.ReadOnly(true)]
        public int ID
        {
            get
            {
                return timeSheet.id;
            }
            set
            {
                timeSheet.id = value;
            }
        }


        [System.ComponentModel.DisplayName("Год табеля")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Год табеля")]
        public int TimeSheetYear
        {
            get
            {
                return timeSheet.TimeSheetYear;
            }
            set
            {
                timeSheet.TimeSheetYear = value;
            }
        }

        [System.ComponentModel.DisplayName("Среднемесячное количество часов")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Среднемесячное количество часов")]
        public double TimeSheetHourCount
        {
            get
            {
                return Convert.ToDouble(timeSheet.TimeSheetWorkingHourCount);
            }
            set
            {
                timeSheet.TimeSheetWorkingHourCount = value;
            }
        }

        [System.ComponentModel.DisplayName("Заполнен")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Признак заполненного табеля")]
        [System.ComponentModel.TypeConverter(typeof(Kadr.UI.Common.CustomBooleanConverter))]
        public bool IsFilled
        {
            get
            {
                return Convert.ToBoolean(timeSheet.IsFilled);
            }
            set
            {
                timeSheet.IsFilled = value;
            }
        }

        [System.ComponentModel.DisplayName("Закрыт")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Признак закрытого табеля")]
        [System.ComponentModel.TypeConverter(typeof(Kadr.UI.Common.CustomBooleanConverter))]
        public bool IsClosed
        {
            get
            {
                return Convert.ToBoolean(timeSheet.IsClosed);
            }
            set
            {
                timeSheet.IsClosed = value;
            }
        }

        /*[System.ComponentModel.DisplayName("Общее количество дней")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Общее количество дней в месяце")]
        public int TimeSheetAllDayCount
        {
            get
            {
                return timeSheet.TimeSheetAllDayCount;
            }
            set
            {
                timeSheet.TimeSheetAllDayCount = value;
            }
        }*/

        [System.ComponentModel.DisplayName("Количество рабочих дней")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Количество дней в месяце")]
        public int TimeSheetWorkingDayCount
        {
            get
            {
                return timeSheet.TimeSheetWorkingDayCount;
            }
            set
            {
                timeSheet.TimeSheetWorkingDayCount = value;
            }
        }
       
        [System.ComponentModel.DisplayName("Месяц")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Месяц табеля")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.MonthEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string MonthName
        {
            get
            {
                return timeSheet.MonthName;
            }
            set
            {
                timeSheet.MonthName = value;
            }
        }


    }
    #endregion

    #region TimeSheetFSWorkingDays Decorator
    class TimeSheetFSWorkingDaysDecorator
    {

        private TimeSheetFSWorkingDay timeSheetFSWorkingDays;
        public TimeSheetFSWorkingDaysDecorator(TimeSheetFSWorkingDay timeSheetFSWorkingDays)
        {
            this.timeSheetFSWorkingDays = timeSheetFSWorkingDays;
        }

        override public string ToString()
        {
            return timeSheetFSWorkingDays.ToString();
        }

        [System.ComponentModel.DisplayName("Сотрудник отдела")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Сотрудник отдела")]
        [System.ComponentModel.ReadOnly(true)]
        public FactStaff FactStaff
        {
            get
            {
                return timeSheetFSWorkingDays.FactStaff;
            }
            set
            {
                timeSheetFSWorkingDays.FactStaff = value;
            }
        }

        [System.ComponentModel.DisplayName("Количество ставок")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Занимаемое сотрудником на период табеля количество ставок")]
        [System.ComponentModel.ReadOnly(true)]
        public decimal StaffCount
        {
            get
            {
                return timeSheetFSWorkingDays.StaffCount;
            }
            set
            {
                timeSheetFSWorkingDays.StaffCount = value;
            }
        }

        [System.ComponentModel.DisplayName("Табель")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Табель")]
        [System.ComponentModel.ReadOnly(true)]
        public TimeSheet TimeSheet
        {
            get
            {
                return timeSheetFSWorkingDays.TimeSheet;
            }
            set
            {
                timeSheetFSWorkingDays.TimeSheet = value;
            }
        }

        [System.ComponentModel.DisplayName("Количество рабочих дней")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Общее количество рабочих дней сотрудника за месяц")]
        public int WorkingDaysCount
        {
            get
            {
                return timeSheetFSWorkingDays.WorkingDaysCount;
            }
            set
            {
                timeSheetFSWorkingDays.WorkingDaysCount = value;
            }
        }

        [System.ComponentModel.DisplayName("Заполнена")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Признак закрытой записи табеля")]
        [System.ComponentModel.TypeConverter(typeof(Kadr.UI.Common.CustomBooleanConverter))]
        public bool IsClosed
        {
            get
            {
                return timeSheetFSWorkingDays.IsClosed;
            }
            set
            {
                timeSheetFSWorkingDays.IsClosed = value;
            }
        }

    }
    #endregion

    #region PlanStaffHistory Decorator
    class PlanStaffHistoryDecorator
    {

        private PlanStaffHistory planStaffHistory;
        public PlanStaffHistoryDecorator(PlanStaffHistory planStaffHistory)
        {
            this.planStaffHistory = planStaffHistory;
        }

        override public string ToString()
        {
            return planStaffHistory.ToString();
        }

        
        [System.ComponentModel.DisplayName("Дата изменения")]
        [System.ComponentModel.Category("Основные атрибуты изменения")]
        [System.ComponentModel.Description("Дата изменения записи в штатном расписании")]
        public DateTime DateBegin
        {
            get
            {
                return planStaffHistory.DateBegin;
            }
            set
            {
                planStaffHistory.DateBegin = value;

            }
        }

        [System.ComponentModel.DisplayName("Приказ изменения")]
        [System.ComponentModel.Category("Основные атрибуты изменения")]
        [System.ComponentModel.Description("Приказ изменения записи в штатном расписании")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Prikaz Prikaz
        {
            get
            {
                return planStaffHistory.Prikaz;               
            }
            set
            {
                planStaffHistory.Prikaz = value;
            }
        }

        [System.ComponentModel.DisplayName("Новый источник финансирования")]
        [System.ComponentModel.Category("Новые значения атрибутов")]
        [System.ComponentModel.Description("Новый источник финансирования записи в штатном расписании")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.AllFinancingSourceEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public FinancingSource FinancingSource
        {
            get
            {
                return planStaffHistory.FinancingSource;
            }
            set
            {
                planStaffHistory.FinancingSource = value;
            }
        }


        [System.ComponentModel.DisplayName("Количество ставок")]
        [System.ComponentModel.Category("Новые значения атрибутов")]
        [System.ComponentModel.Description("Запланированное количество ставок в штатном расписании")]
        public decimal StaffCount
        {
            get
            {
                return planStaffHistory.StaffCount;
            }
            set
            {
                if (value >= 0.1M)
                {
                    planStaffHistory.StaffCount = value;
                }
                else
                    throw new ApplicationException("Количество ставок не может быть меньше 0,1.");
            }
        }

    }
    #endregion

    #region FactStaffHistory Decorator
    class FactStaffHistoryDecorator
    {

        private FactStaffHistory factStaffHistory;
        public FactStaffHistoryDecorator(FactStaffHistory factStaffHistory)
        {
            this.factStaffHistory = factStaffHistory;
        }

        override public string ToString()
        {
            return factStaffHistory.ToString();
        }


        [System.ComponentModel.DisplayName("Дата изменения")]
        [System.ComponentModel.Category("Основные атрибуты изменения")]
        [System.ComponentModel.Description("Дата изменения")]
        public DateTime DateBegin
        {
            get
            {
                return factStaffHistory.DateBegin;
            }
            set
            {
                factStaffHistory.DateBegin = value;

            }
        }

        [System.ComponentModel.DisplayName("Приказ изменения")]
        [System.ComponentModel.Category("Основные атрибуты изменения")]
        [System.ComponentModel.Description("Приказ изменения записи в штатном расписании")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Prikaz PrikazBegin
        {
            get
            {
                return factStaffHistory.Prikaz;
            }
            set
            {
                factStaffHistory.Prikaz = value;
            }
        }


        [System.ComponentModel.DisplayName("Новый вид работы")]
        [System.ComponentModel.Category("Новые значения атрибутов")]
        [System.ComponentModel.Description("Новый вид работы сотрудника")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.WorkTypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public WorkType WorkType
        {
            get
            {
                return factStaffHistory.WorkType;
            }
            set
            {
                factStaffHistory.WorkType = value;
            }
        }


        [System.ComponentModel.DisplayName("Количество ставок")]
        [System.ComponentModel.Category("Новые значения атрибутов")]
        [System.ComponentModel.Description("Новое количество ставок сотрудника")]
        public decimal StaffCount
        {
            get
            {
                return factStaffHistory.StaffCount;
            }
            set
            {
                if (value >= 0.1M)
                {
                    factStaffHistory.StaffCount = value;
                }
                else
                    throw new ApplicationException("Количество ставок не может быть меньше 0,1.");
            }
        }

        [System.ComponentModel.DisplayName("Количество ставок по нагрузке")]
        [System.ComponentModel.Category("Новые значения атрибутов")]
        [System.ComponentModel.Description("Занимаемое сотрудником по факту количество ставок по нагрузке")]
        [System.ComponentModel.ReadOnly(true)]
        public decimal? HourStaffCount
        {
            get
            {
                return factStaffHistory.HourStaffCount;
            }
            set
            {
                factStaffHistory.HourStaffCount = value;
            }
        }

        [System.ComponentModel.DisplayName("Количество часов")]
        [System.ComponentModel.Category("Почасовики")]
        [System.ComponentModel.Description("Количество часов для почасовиков")]
        public decimal? HourCount
        {
            get
            {
                return factStaffHistory.HourCount;
            }
            set
            {
                factStaffHistory.HourCount = value;
            }
        }

        [System.ComponentModel.DisplayName("Подподкатегория")]
        [System.ComponentModel.Category("Новые значения атрибутов")]
        [System.ComponentModel.Description("Подподкатегория (определяет коэффициент к окладу сотрудника)")]
        public int? SalaryKoeff
        {
            get
            {
                if (factStaffHistory.SalaryKoeff != null)
                    return factStaffHistory.SalaryKoeff.PKSubSubCategoryNumber;
                return null;
            }
            set
            {
                factStaffHistory.SalaryKoeff = KadrController.Instance.Model.SalaryKoeffs.Where(koef => koef.PKSubSubCategoryNumber == value).FirstOrDefault();
            }
        }

        [System.ComponentModel.DisplayName("Оплата за час")]
        [System.ComponentModel.Category("Почасовики")]
        [System.ComponentModel.Description("Оплата за час для почасовиков")]
        public decimal? HourSalary
        {
            get
            {
                return factStaffHistory.HourSalary;
            }
            set
            {
                factStaffHistory.HourSalary = value;
            }
        }

        
        [System.ComponentModel.DisplayName("Отдел")]
        [System.ComponentModel.Category("Общие")]
        [System.ComponentModel.Description("Название отдела")]
        [System.ComponentModel.ReadOnly(true)]
        public Kadr.Data.Dep Department
        {
            get
            {
                return factStaffHistory.FactStaff.Department;
            }
        }

    }
    #endregion

    #region FactStaffHistoryReplacement Decorator
    class FactStaffHistoryReplacementDecorator
    {

        private FactStaffHistory factStaffHistory;
        public FactStaffHistoryReplacementDecorator(FactStaffHistory factStaffHistory)
        {
            this.factStaffHistory = factStaffHistory;
        }

        override public string ToString()
        {
            return factStaffHistory.ToString();
        }


        [System.ComponentModel.DisplayName("Дата изменения")]
        [System.ComponentModel.Category("Основные атрибуты изменения")]
        [System.ComponentModel.Description("Дата изменения")]
        public DateTime DateBegin
        {
            get
            {
                return factStaffHistory.DateBegin;
            }
            set
            {
                factStaffHistory.DateBegin = value;

            }
        }

        [System.ComponentModel.DisplayName("Приказ изменения")]
        [System.ComponentModel.Category("Основные атрибуты изменения")]
        [System.ComponentModel.Description("Приказ изменения записи в штатном расписании")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Prikaz PrikazBegin
        {
            get
            {
                return factStaffHistory.Prikaz;
            }
            set
            {
                factStaffHistory.Prikaz = value;
            }
        }


        [System.ComponentModel.DisplayName("Новый вид работы")]
        [System.ComponentModel.Category("Новые значения атрибутов")]
        [System.ComponentModel.Description("Новый вид работы сотрудника")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.WorkTypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public WorkType WorkType
        {
            get
            {
                return factStaffHistory.WorkType;
            }
            set
            {
                factStaffHistory.WorkType = value;
            }
        }

        [System.ComponentModel.DisplayName("Количество часов")]
        [System.ComponentModel.Category("Почасовики")]
        [System.ComponentModel.Description("Количество часов для почасовиков")]
        public decimal? HourCount
        {
            get
            {
                return factStaffHistory.HourCount;
            }
            set
            {
                factStaffHistory.HourCount = value;
            }
        }

        [System.ComponentModel.DisplayName("Подподкатегория")]
        [System.ComponentModel.Category("Новые значения атрибутов")]
        [System.ComponentModel.Description("Подподкатегория (определяет коэффициент к окладу сотрудника)")]
        public int? SalaryKoeff
        {
            get
            {
                if (factStaffHistory.SalaryKoeff != null)
                    return factStaffHistory.SalaryKoeff.PKSubSubCategoryNumber;
                return null;
            }
            set
            {
                factStaffHistory.SalaryKoeff = KadrController.Instance.Model.SalaryKoeffs.Where(koef => koef.PKSubSubCategoryNumber == value).FirstOrDefault();
            }
        }

        [System.ComponentModel.DisplayName("Оплата за час")]
        [System.ComponentModel.Category("Почасовики")]
        [System.ComponentModel.Description("Оплата за час для почасовиков")]
        public decimal? HourSalary
        {
            get
            {
                return factStaffHistory.HourSalary;
            }
            set
            {
                factStaffHistory.HourSalary = value;
            }
        }

        [System.ComponentModel.DisplayName("ФИО совмещаемого сотрудника")]
        [System.ComponentModel.Category("Параметры совмещения")]
        [System.ComponentModel.Description("ФИО совмещаемого сотрудника")]
        [System.ComponentModel.ReadOnly(true)]
        public Kadr.Data.Employee ReplacedEmployee
        {
            get
            {
                return factStaffHistory.FactStaff.FactStaffReplacement.ReplacedFactStaff.Employee;
            }
            set
            {
                factStaffHistory.FactStaff.FactStaffReplacement.ReplacedFactStaff.Employee = value;
            }
        }

        [System.ComponentModel.DisplayName("% совмещения")]
        [System.ComponentModel.Category("Параметры совмещения")]
        [System.ComponentModel.Description("% совмещения сотрудника")]
        public decimal StaffCount
        {
            get
            {
                return factStaffHistory.FactStaff.FactStaffReplacement.ReplacedPercent;
            }
            set
            {
                factStaffHistory.FactStaff.FactStaffReplacement.ReplacedPercent = value;
            }
        }

        [System.ComponentModel.DisplayName("Причина совмещения")]
        [System.ComponentModel.Category("Параметры совмещения")]
        [System.ComponentModel.Description("Причина замещения сотрудника")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.FactStaffReplacementReasonEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.FactStaffReplacementReason FactStaffReplacementReason
        {
            get
            {
                return factStaffHistory.FactStaff.FactStaffReplacement.FactStaffReplacementReason;
            }
            set
            {
                factStaffHistory.FactStaff.FactStaffReplacement.FactStaffReplacementReason = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата окончания совмещения")]
        [System.ComponentModel.Category("Параметры совмещения")]
        [System.ComponentModel.Description("Дата окончания совмещения")]
        // [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PostEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public DateTime ReplacementDataEnd
        {
            get
            {
                return Convert.ToDateTime(factStaffHistory.FactStaff.FactStaffReplacement.DateEnd);
            }
            set
            {
                factStaffHistory.FactStaff.FactStaffReplacement.DateEnd = value;
                if (value == DateTime.MinValue)
                    factStaffHistory.FactStaff.FactStaffReplacement.DateEnd = null;
                if (factStaffHistory.FactStaff.FactStaffReplacement.DateEnd == null)
                    factStaffHistory.FactStaff.FactStaffReplacement.FactStaff1.IsReplacement = true;
                else
                    factStaffHistory.FactStaff.FactStaffReplacement.FactStaff1.IsReplacement = false;
            }
        }

    }
    #endregion

    #region BonusHistory Decorator
    class BonusHistoryDecorator
    {

        private BonusHistory bonusHistory;
        public BonusHistoryDecorator(BonusHistory bonusHistory)
        {
            this.bonusHistory = bonusHistory;
        }

        override public string ToString()
        {
            return bonusHistory.ToString();
        }

        
        [System.ComponentModel.DisplayName("Дата назначения")]
        [System.ComponentModel.Category("Основные атрибуты изменения")]
        [System.ComponentModel.Description("Дата назначения/изменения надбавки")]
        public DateTime DateBegin
        {
            get
            {
                return bonusHistory.DateBegin;
            }
            set
            {
                bonusHistory.DateBegin = value;

            }
        }

        [System.ComponentModel.DisplayName("Приказ назначения")]
        [System.ComponentModel.Category("Основные атрибуты изменения")]
        [System.ComponentModel.Description("Приказ назначения/изменения надбавки")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Prikaz Prikaz
        {
            get
            {
                return bonusHistory.Prikaz;
            }
            set
            {
                //bonusHistory.Prikaz = value;
                bonusHistory.Prikaz = value;
            }
        }

        [System.ComponentModel.DisplayName("Источник финансирования")]
        [System.ComponentModel.Category("Основные атрибуты изменения")]
        [System.ComponentModel.Description("Источник финансирования надбавки")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.AllFinancingSourceEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public FinancingSource FinancingSource
        {
            get
            {
                return bonusHistory.FinancingSource;
            }
            set
            {
                bonusHistory.FinancingSource = value;
            }
        }

        [System.ComponentModel.DisplayName("Размер надбавки")]
        [System.ComponentModel.Category("Основные атрибуты изменения")]
        [System.ComponentModel.Description("Новый размер надбавки")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public decimal BonusCount
        {
            get
            {
                return bonusHistory.BonusCount;
            }
            set
            {
                bonusHistory.BonusCount = value;
            }
        }

        [System.ComponentModel.DisplayName("Вид изменяемой надбавки")]
        [System.ComponentModel.Category("Основные атрибуты надбавки")]
        [System.ComponentModel.Description("Вид изменяемой надбавки")]
        [System.ComponentModel.ReadOnly(true)]
        public BonusType BonusType
        {
            get
            {
                return bonusHistory.Bonus.BonusType;
            }
        }

       /* [System.ComponentModel.DisplayName("Дата назначения надбавки")]
        [System.ComponentModel.Category("Основные атрибуты надбавки")]
        [System.ComponentModel.Description("Первоначальная дата назначения надбавки")]
        [System.ComponentModel.ReadOnly(true)]
        public DateTime da
        {
            get
            {
                return Convert.ToDateTime(bonusHistory.Bonus.DateBegin);
            }
        }*/
    }
    #endregion

    #region DepartmentTimeNorm Decorator
    class DepartmentTimeNormDecorator
    {
        private DepartmentTimeNorm departmentTimeNorm;

        override public string ToString()
        {
            return "Норма времени отдела " + departmentTimeNorm.Dep.ToString().ToLower();
        }

        public DepartmentTimeNormDecorator(DepartmentTimeNorm departmentTimeNorm)
        {
            this.departmentTimeNorm = departmentTimeNorm;
        }

 
        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код нормы времени")]
        [System.ComponentModel.ReadOnly(true)]
        public int ID
        {
            get
            {
                return departmentTimeNorm.id;
            }
            set
            {
                departmentTimeNorm.id = value;
            }
        }

        [System.ComponentModel.DisplayName("Отдел")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Название отдела, к которому относится норма времени")]
        [System.ComponentModel.ReadOnly(true)]
        public Kadr.Data.Dep Department
        {
            get
            {
                return departmentTimeNorm.Dep;
            }
            set
            {
                departmentTimeNorm.Dep = value;
            }
        }

        [System.ComponentModel.DisplayName("Источник финансирования")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Источник финансирования, для которой задана норма времени")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.FinancingSourceEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.FinancingSource FinancingSource
        {
            get
            {
                return departmentTimeNorm.FinancingSource;
            }
            set
            {
                departmentTimeNorm.FinancingSource = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата назначения")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Дата назначения")]
        public DateTime DataBegin
        {
            get
            {
                return Convert.ToDateTime(departmentTimeNorm.DateBegin);
            }
            set
            {
                departmentTimeNorm.DateBegin = value;
            }
        }

        [System.ComponentModel.DisplayName("Количество часов по норме")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Количество часов по норме времени на ставку")]
        public decimal NormHoursCount
        {
            get
            {
                return departmentTimeNorm.NormHoursCount;
            }
            set
            {
                departmentTimeNorm.NormHoursCount = value;
            }
        }
    }
    #endregion

    #region DepartmentFund Decorator
    class DepartmentFundDecorator
    {
        private DepartmentFund departmentFund;

        override public string ToString()
        {
            return "Бюджетный фонд отдела " + departmentFund.Dep.ToString().ToLower();
        }

        public DepartmentFundDecorator(DepartmentFund departmentFund)
        {
            this.departmentFund = departmentFund;
        }


       
        [System.ComponentModel.DisplayName("Отдел")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Название отдела, к которому относится норма времени")]
        [System.ComponentModel.ReadOnly(true)]
        public Kadr.Data.Dep Department
        {
            get
            {
                return departmentFund.Dep;
            }
            set
            {
                departmentFund.Dep = value;
            }
        }

        
        [System.ComponentModel.DisplayName("Дата назначения")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Дата назначения")]
        public DateTime DataBegin
        {
            get
            {
                return departmentFund.DateBegin;
            }
            set
            {
                departmentFund.DateBegin = value;
            }
        }

        [System.ComponentModel.DisplayName("Плановый размер фонда")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Плановый размер фонда отдела")]
        public decimal PlanFundSum
        {
            get
            {
                return departmentFund.PlanFundSum;
            }
            set
            {
                departmentFund.PlanFundSum = value;
            }
        }

        [System.ComponentModel.DisplayName("Фактический размер фонда")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Фактический размер фонда отдела")]
        public decimal FactFundSum
        {
            get
            {
                return departmentFund.FactFundSum;
            }
            set
            {
                departmentFund.FactFundSum = value;
            }
        }

        [System.ComponentModel.DisplayName("Размер внеплановых выплат")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Размер внеплановых выплат, установленный для отдела")]
        public decimal ExtraordSum
        {
            get
            {
                return departmentFund.ExtraordSum;
            }
            set
            {
                departmentFund.ExtraordSum = value;
            }
        }
    }
    #endregion

    #region FactStaffMonthHour Decorator
    class FactStaffMonthHourDecorator
    {

        private FactStaffMonthHour factStaffMonthHour;
        public FactStaffMonthHourDecorator(FactStaffMonthHour factStaffMonthHour)
        {
            this.factStaffMonthHour = factStaffMonthHour;
        }

        override public string ToString()
        {
            return factStaffMonthHour.ToString();
        }

        [System.ComponentModel.DisplayName("Сотрудник")]
        [System.ComponentModel.Category("Общие")]
        [System.ComponentModel.Description("Сотрудник, для которого указываются часы")]
        [System.ComponentModel.ReadOnly(true)]
        public FactStaff FactStaff
        {
            get
            {
                return factStaffMonthHour.FactStaff;
            }
            set
            {
                factStaffMonthHour.FactStaff = value;
            }
        }

        [System.ComponentModel.DisplayName("Количество часов")]
        [System.ComponentModel.Category("Основные атрибуты")]
        [System.ComponentModel.Description("Проведенное количество часов за месяц")]
        public decimal HourCount
        {
            get
            {
                return factStaffMonthHour.HourCount;
            }
            set
            {
                factStaffMonthHour.HourCount = value;
            }
        }

        [System.ComponentModel.DisplayName("Месяц")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Месяц")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.MonthEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string MonthName
        {
            get
            {
                return factStaffMonthHour.MonthName;
            }
            set
            {
                factStaffMonthHour.MonthName = value;
            }
        }

        [System.ComponentModel.DisplayName("Год")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Год, для которого указываются часы")]
        public int YearNumber
        {
            get
            {
                return factStaffMonthHour.YearNumber;
            }
            set
            {
                factStaffMonthHour.YearNumber = value;
            }
        }
    }
    #endregion

    #region FactStaffHour Decorator
    class FactStaffHourDecorator
    {
        private FactStaff factStaff;
        public FactStaffHourDecorator(FactStaff factStaff)
        {
            this.factStaff = factStaff;
        }


        public override string ToString()
        {
            return "Почасовики (бюджет) отдела " + factStaff.Department.ToString().ToLower() ;
        }

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код сотрудника в штатном расписании")]
        [System.ComponentModel.ReadOnly(true)]
        public int ID
        {
            get
            {
                return factStaff.id;
            }
            set
            {
                factStaff.id = value;
            }
        }

        [System.ComponentModel.DisplayName("ФИО сотрудника")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("ФИО сотрудника, назначенного на должность")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.EmployeeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Employee Employee
        {
            get
            {
                return factStaff.Employee;
            }
            set
            {
                factStaff.Employee = value;
            }
        }

        [System.ComponentModel.DisplayName("Количество ставок")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Занимаемое сотрудником по факту количество ставок")]
        public decimal StaffCount
        {
            get
            {
                return factStaff.StaffCount;
            }
            set
            {
                factStaff.StaffCount = value;
            }
        }

        [System.ComponentModel.DisplayName("Количество ставок по нагрузке")]
        [System.ComponentModel.Category("Почасовики")]
        [System.ComponentModel.Description("Занимаемое сотрудником количество ставок по нагрузке")]
        [System.ComponentModel.ReadOnly(true)]
        public decimal? HourStaffCount
        {
            get
            {
                return factStaff.HourStaffCount;
            }
        }

        [System.ComponentModel.DisplayName("Количество часов")]
        [System.ComponentModel.Category("Почасовики")]
        [System.ComponentModel.Description("Количество часов для почасовиков")]
        public decimal? HourCount
        {
            get
            {
                return factStaff.HourCount;
            }
            set
            {
                factStaff.HourCount = value;
            }
        }

        [System.ComponentModel.DisplayName("Оплата за час")]
        [System.ComponentModel.Category("Почасовики")]
        [System.ComponentModel.Description("Оплата за час для почасовиков")]
        public decimal? HourSalary
        {
            get
            {
                return factStaff.HourSalary;
            }
            set
            {
                factStaff.HourSalary = value;
            }
        }

        [System.ComponentModel.DisplayName("Отдел")]
        [System.ComponentModel.Category("Общие")]
        [System.ComponentModel.Description("Название отдела")]
        [System.ComponentModel.ReadOnly(true)]
        // [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PostEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Dep Department
        {
            get
            {
                return factStaff.Department;
            }
        }

        [System.ComponentModel.DisplayName("Название вида работы")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Название вида работы")]
        //[System.ComponentModel.Editor(typeof(Kadr.UI.Editors.WorkTypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.WorkType WorkType
        {
            get
            {
                return factStaff.WorkType;
            }
            set
            {
                factStaff.WorkType = value;
            }
        }

        [System.ComponentModel.DisplayName("Источник финансирования")]
        [System.ComponentModel.Category("Почасовики")]
        [System.ComponentModel.Description("Источник финансирования (редактировать для почасовиков)")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.FinancingSourceEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.FinancingSource FinancingSource
        {
            get
            {
                return factStaff.FinancingSource;
            }
            set
            {
                factStaff.FinancingSource = value;
            }
        }

        [System.ComponentModel.DisplayName("Приказ утверждения")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Приказ назначения сотрудника")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Prikaz PrikazBegin
        {
            get
            {
                return factStaff.PrikazBegin;
            }
            set
            {
                factStaff.PrikazBegin = value;
            }
        }

        [System.ComponentModel.DisplayName("Приказ увольнения")]
        [System.ComponentModel.Category("Параметры увольнения")]
        [System.ComponentModel.Description("Приказ увольнения сотрудника")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Prikaz PrikazEnd
        {
            get
            {
                return factStaff.Prikaz;
            }
            set
            {
                factStaff.Prikaz = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата назначения")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Дата назначения на должность")]
        // [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PostEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public DateTime DataBegin
        {
            get
            {
                return Convert.ToDateTime(factStaff.DateBegin);
            }
            set
            {
                factStaff.DateBegin = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата увольнения")]
        [System.ComponentModel.Category("Параметры увольнения")]
        [System.ComponentModel.Description("Дата снятия с должности")]
        // [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PostEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public DateTime DataEnd
        {
            get
            {
                return Convert.ToDateTime(factStaff.DateEnd);
            }
            set
            {
                factStaff.DateEnd = value;
             }
        }

        [System.ComponentModel.DisplayName("Комментарий")]
        [System.ComponentModel.Category("Почасовики")]
        [System.ComponentModel.Description("Комментарий")]
        // [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PostEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string Comment
        {
            get
            {
                return factStaff.Comment;
            }
            set
            {
                factStaff.Comment = value;
            }
        }

        [System.ComponentModel.DisplayName("Центр затрат")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Центр затрат")]
        [System.ComponentModel.Editor(typeof(FundingCenterEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public FundingCenter FundingCenter
        {
            get
            {
                return factStaff.FundingCenter;
            }
            set
            {
                factStaff.FundingCenter = value;
            }
        }

    }


    #endregion

    #region FactStaffHourContract Decorator
    class FactStaffHourContractDecorator
    {
        private FactStaff factStaff;
        public FactStaffHourContractDecorator(FactStaff factStaff)
        {
            this.factStaff = factStaff;
        }


        public override string ToString()
        {
             return "Распределение штатов отдела " + factStaff.Department.ToString().ToLower() + ", " +
                factStaff.Post.ToString().ToLower();
        }

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код сотрудника в штатном расписании")]
        [System.ComponentModel.ReadOnly(true)]
        public int ID
        {
            get
            {
                return factStaff.id;
            }
            set
            {
                factStaff.id = value;
            }
        }

        [System.ComponentModel.DisplayName("Cотрудник договора")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Сотрудник, для которого указывается договор")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.FactStaffEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.FactStaffCurrentMainData MainFactStaff
        {
            get
            {
                return factStaff.MainFactStaffData;
            }
            set
            {
                if (value != null)
                    factStaff.MainFactStaff = KadrController.Instance.Model.FactStaffs.Where(fcSt => fcSt.id == value.id).SingleOrDefault();
            }
        }

        [System.ComponentModel.DisplayName("Количество ставок")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Занимаемое сотрудником по факту количество ставок")]
        public decimal StaffCount
        {
            get
            {
                return factStaff.StaffCount;
            }
            set
            {
                factStaff.StaffCount = value;
            }
        }

        [System.ComponentModel.DisplayName("Количество ставок по нагрузке")]
        [System.ComponentModel.Category("Почасовики")]
        [System.ComponentModel.Description("Занимаемое сотрудником количество ставок по нагрузке")]
        [System.ComponentModel.ReadOnly(true)]
        public decimal? HourStaffCount
        {
            get
            {
                return factStaff.HourStaffCount;
            }
        }
        
        [System.ComponentModel.DisplayName("Количество часов")]
        [System.ComponentModel.Category("Почасовики")]
        [System.ComponentModel.Description("Количество часов для почасовиков")]
        public decimal? HourCount
        {
            get
            {
                return factStaff.HourCount;
            }
            set
            {
                factStaff.HourCount = value;
            }
        }

        [System.ComponentModel.DisplayName("Оплата за час")]
        [System.ComponentModel.Category("Почасовики")]
        [System.ComponentModel.Description("Оплата за час для почасовиков")]
        public decimal? HourSalary
        {
            get
            {
                return factStaff.HourSalary;
            }
            set
            {
                factStaff.HourSalary = value;
            }
        }

        [System.ComponentModel.DisplayName("Отдел")]
        [System.ComponentModel.Category("Общие")]
        [System.ComponentModel.Description("Название отдела")]
        [System.ComponentModel.ReadOnly(true)]
        // [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PostEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Dep Department
        {
            get
            {
                return factStaff.Department;
            }
        }
        
        [System.ComponentModel.DisplayName("Название вида работы")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Название вида работы")]
        //[System.ComponentModel.Editor(typeof(Kadr.UI.Editors.WorkTypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.WorkType WorkType
        {
            get
            {
                return factStaff.WorkType;
            }
            set
            {
                factStaff.WorkType = value;
            }
        }

        [System.ComponentModel.DisplayName("Источник финансирования")]
        [System.ComponentModel.Category("Почасовики")]
        [System.ComponentModel.Description("Источник финансирования (редактировать для почасовиков)")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.FinancingSourceEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.FinancingSource FinancingSource
        {
            get
            {
                return factStaff.FinancingSource;
            }
            set
            {
                factStaff.FinancingSource = value;
            }
        }

        [System.ComponentModel.DisplayName("Приказ увольнения")]
        [System.ComponentModel.Category("Параметры увольнения")]
        [System.ComponentModel.Description("Приказ увольнения сотрудника")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Prikaz PrikazEnd
        {
            get
            {
                return factStaff.Prikaz;
            }
            set
            {
                factStaff.Prikaz = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата назначения")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Дата назначения на должность")]
        // [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PostEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public DateTime DataBegin
        {
            get
            {
                return Convert.ToDateTime(factStaff.DateBegin);
            }
            set
            {
                factStaff.DateBegin = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата увольнения")]
        [System.ComponentModel.Category("Параметры увольнения")]
        [System.ComponentModel.Description("Дата снятия с должности")]
        // [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PostEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public DateTime DataEnd
        {
            get
            {
                return Convert.ToDateTime(factStaff.DateEnd);
            }
            set
            {
                factStaff.DateEnd = value;
                //если есть замещения данного сотрудника, то их надо отменить (указать дату окончания)
                /*if ((value != null) )
                {
                    foreach (FactStaffReplacement replacement in FactStaff.FactStaffReplacements)
                    {
                        replacement.DateEnd = value;
                        replacement.FactStaff1.IsReplacement = false;
                    }
                }*/
            }



        }

        [System.ComponentModel.DisplayName("Центр затрат")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Центр затрат")]
        [System.ComponentModel.Editor(typeof(FundingCenterEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public FundingCenter FundingCenter
        {
            get
            {
                return factStaff.FundingCenter;
            }
            set
            {
                factStaff.FundingCenter = value;
            }
        }

        [System.ComponentModel.DisplayName("Комментарий")]
        [System.ComponentModel.Category("Почасовики")]
        [System.ComponentModel.Description("Комментарий")]
        // [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PostEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string Comment
        {
            get
            {
                return factStaff.Comment;
            }
            set
            {
                factStaff.Comment = value;
            }
        }

    }


    #endregion
}
