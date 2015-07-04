using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.UI.Editors;
using Kadr.Controllers;
using Kadr.Data;

namespace Kadr.Data
{
    #region Department Decorator
    class DepartmentDecorator
    {
        private Department department;
        public DepartmentDecorator(Department department)
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

        [System.ComponentModel.DisplayName("Руководящий отдел")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Руководящий отдел")]
        [System.ComponentModel.Editor(typeof(DepartmentEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Department ManagerDepartment
        {
            get
            {
                return department.Department1;
            }
            set
            {
                department.Department1 = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата создания")]
        [System.ComponentModel.Category("Параметры создания/расформирования")]
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
        [System.ComponentModel.Category("Параметры создания/расформирования")]
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

    }
    #endregion

    #region PlanStaff Decorator
    class PlanStaffDecorator
    {
        private PlanStaff planStaff;

        override public string ToString()
        {
            return "Штатное расписание отдела "+planStaff.Department.ToString().ToLower();
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
        public Kadr.Data.Department Department
        {
            get
            {
                //return model.Departments.First(dep => dep.id == planStaff.idDepartment);
                return planStaff.Department;
            }
            set
            {
                planStaff.Department = value;
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

        [System.ComponentModel.DisplayName("Название категории")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Название категории персонала")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.CategryEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Category Category
        {
            get
            {
                return planStaff.Category;
            }
            set
            {
                planStaff.Category = value;
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
                return planStaff.Prikaz;
            }
            set
            {
                planStaff.Prikaz = value;
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
                return planStaff.Prikaz1;
            }
            set
            {
                planStaff.Prikaz1 = value;
            }
        }

        [System.ComponentModel.DisplayName("Источник финансирования")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Источник финансирования записи в штатном расписании")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.FinancingSourceEditor), typeof(System.Drawing.Design.UITypeEditor))]
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
            return "Распределение штатов отдела "+factStaff.Department.ToString().ToLower()+", "+
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

        [System.ComponentModel.DisplayName("Отдел")]
        [System.ComponentModel.Category("Общие")]
        [System.ComponentModel.Description("Название отдела")]
        // [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PostEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Department Department
        {
            get
            {
                return factStaff.PlanStaff.Department;
            }
            set
            {
                factStaff.PlanStaff.Department = value;
            }
        }

        [System.ComponentModel.DisplayName("Должность")]
        [System.ComponentModel.Category("Общие")]
        [System.ComponentModel.Description("Название должности в штатном расписании")]
        // [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PostEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Post Post
        {
            get
            {
                return factStaff.PlanStaff.Post;
            }
            set
            {
                factStaff.PlanStaff.Post = value;
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

        [System.ComponentModel.DisplayName("Приказ утверждения")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Приказ назначения сотрудника")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Prikaz PrikazBegin
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

        [System.ComponentModel.DisplayName("Приказ увольнения")]
        [System.ComponentModel.Category("Параметры увольнения")]
        [System.ComponentModel.Description("Приказ увольнения сотрудника")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Prikaz PrikazEnd
        {
            get
            {
                return factStaff.Prikaz1;
            }
            set
            {
                factStaff.Prikaz1 = value;
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
            return "Надбавка сотрудника "+bonus.FactStaff.Employee.EmployeeSmallName;
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
        [System.ComponentModel.Description("Размер назначенной сотруднику надбавки")]
        public decimal BonusCount
        {
            get
            {
                return bonus.BonusCount;
            }
            set
            {
                bonus.BonusCount = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата начала начисления")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Дата начала начисления надбавки")]
        public DateTime DateBegin
        {
            get
            {
                return Convert.ToDateTime( bonus.DateBegin );
            }
            set
            {
                bonus.DateBegin = value;
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
            }
        }

        [System.ComponentModel.DisplayName("Приказ назначения")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Приказ назначения надбавки")]
        [System.ComponentModel.Editor(typeof(PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Prikaz Prikaz
        {
            get
            {
                return bonus.Prikaz;
            }
            set
            {
                bonus.Prikaz = value;
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
        public DateTime DateBegin
        {
            get
            {
                return  Convert.ToDateTime(prikaz.DateBegin);
            }
            set
            {
                prikaz.DateBegin = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата создания")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Дата создания приказа")]
        public DateTime DatePrikaz
        {
            get
            {
                return Convert.ToDateTime(prikaz.DatePrikaz);
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
        [System.ComponentModel.ReadOnly(true)]
        public int itab_n
        {
            get
            {
                return Convert.ToInt16(employee.itab_n);
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
            return "Категория " + Convert.ToString(this.PKCategoryNumber);
        }

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код профессионально-квалификационной категории")]
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

        [System.ComponentModel.DisplayName("Номер категории")]
        [System.ComponentModel.Category("Основые параметры")]
        [System.ComponentModel.Description("Номер профессионально-квалификационной категории")]
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

        [System.ComponentModel.DisplayName("Профессиональная группа")]
        [System.ComponentModel.Category("Основые параметры")]
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
            return Convert.ToString(this.PostName);
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
        [System.ComponentModel.Category("Основые параметры")]
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

        [System.ComponentModel.DisplayName("Руководитель")]
        [System.ComponentModel.Category("Основые параметры")]
        [System.ComponentModel.Description("Руководящая должность")]
        [System.ComponentModel.TypeConverter(typeof(Kadr.UI.Common.CustomBooleanConverter))]//Kadr.UI.Common.CustomBooleanConverter
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

        [System.ComponentModel.DisplayName("Профессиональная категория")]
        [System.ComponentModel.Category("Основые параметры")]
        [System.ComponentModel.Description("Профессиональная категория должности")]
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
        [System.ComponentModel.Category("Основые параметры")]
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

        [System.ComponentModel.DisplayName("Профессиональная категория")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Профессионально-квалификационная категория")]
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


    }


    #endregion

    #region PlanStaffSalary Decorator
    class PlanStaffSalaryDecorator
    {
        private PlanStaffSalary planStaffSalary;
        public PlanStaffSalaryDecorator(PlanStaffSalary planStaffSalary)
        {
            this.planStaffSalary = planStaffSalary;
        }

        override public string ToString()
        {
            return "Оклад " + planStaffSalary.ToString();
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
                return planStaffSalary.id;
            }
            set
            {
                planStaffSalary.id = value;
            }
        }

        [System.ComponentModel.DisplayName("Запись штатного расписания")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Запись штатного расписания")]
        public PlanStaff PlanStaff
        {
            get
            {
                return planStaffSalary.PlanStaff;
            }
            set
            {
                planStaffSalary.PlanStaff = value;
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
                return planStaffSalary.SalarySize;
            }
            set
            {
                planStaffSalary.SalarySize = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата назначения оклада")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Дата назначения индивидуального оклада")]
        public DateTime DateBegin
        {
            get
            {
                return Convert.ToDateTime(planStaffSalary.DateBegin);
            }
            set
            {
                planStaffSalary.DateBegin = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата отмены оклада")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Дата отмены индивидуального оклада")]
        public DateTime DateEnd
        {
            get
            {
                return Convert.ToDateTime(planStaffSalary.DateEnd);
            }
            set
            {
                planStaffSalary.DateEnd = value;
            }
        }


    }


    #endregion

}
