using Kadr.UI.Editors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APG.Base;
using Kadr.Data.Common;
using Kadr.Data.Converters;

namespace Kadr.Data
{
    public class EmployeeDecorator
    {
        private readonly Employee _employee;
        public EmployeeDecorator(Employee employee)
        {
            this._employee = employee;
        }

        override public string ToString()
        {

            return "Сотрудник " + _employee.EmployeeSmallName;
        }

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код сотрудника")]
        [System.ComponentModel.ReadOnly(true)]
        [System.ComponentModel.Browsable(false)]
        public int ID
        {
            get
            {
                return _employee.id;
            }
            set
            {
                _employee.id = value;
            }
        }
        [System.ComponentModel.DisplayName("Возраст")]
        [System.ComponentModel.Category("\t\t\t\tЛичные данные")]
        [System.ComponentModel.Description("Возраст полных лет сотрудника")]
        [System.ComponentModel.ReadOnly(false)]
        public string Age
        {
            get
            {
                var age = _employee.GetAge();
                if (!age.HasValue) return "Не указана дата рождения";
                return string.Format("{0} {1}", age.Value, age.Value.GetYearStr());
            }
            
        }
        [System.ComponentModel.DisplayName("Табельный номер")]
        [System.ComponentModel.Category("\t\t\t\tЛичные данные")]
        [System.ComponentModel.Description("Табельный номер сотрудника в системе отдела кадров")]
        [System.ComponentModel.ReadOnly(false)]
        public string itab_n
        {
            get
            {

                return (_employee.itab_n);
            }
            set
            {
                _employee.itab_n = value;
            }
        }

        [System.ComponentModel.DisplayName("\t\t\t\t\t\t\t\t\t\tФамилия")]
        [System.ComponentModel.Category("\t\t\t\tЛичные данные")]
        [System.ComponentModel.Description("Фамилия сотрудника")]
        [System.ComponentModel.ReadOnly(false)]
        public string LastName
        {
            get
            {
                return _employee.LastName;
            }
            set
            {
                _employee.LastName = value;
            }
        }

        [System.ComponentModel.DisplayName("\t\t\t\t\tПол")]
        [System.ComponentModel.Category("\t\t\t\tЛичные данные")]
        [System.ComponentModel.Description("Пол сотрудника")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.TypeConverter(typeof(Kadr.UI.Common.GenderBooleanConverter))]//Kadr.UI.Common.CustomBooleanConverter
        public bool SexBit
        {
            get
            {
                return _employee.SexBit;
            }
            set
            {
                _employee.SexBit = value;
            }
        }

        [System.ComponentModel.DisplayName("\t\t\t\t\t\t\t\tИмя")]
        [System.ComponentModel.Category("\t\t\t\tЛичные данные")]
        [System.ComponentModel.Description("Имя сотрудника")]
        [System.ComponentModel.ReadOnly(false)]
        public string FirstName
        {
            get
            {
                return _employee.FirstName;
            }
            set
            {
                _employee.FirstName = value;
            }
        }

        [System.ComponentModel.DisplayName("\t\t\t\t\t\tОтчество")]
        [System.ComponentModel.Category("\t\t\t\tЛичные данные")]
        [System.ComponentModel.Description("Отчество сотрудника")]
        [System.ComponentModel.ReadOnly(false)]
        public string Otch
        {
            get
            {
                return _employee.Otch;
            }
            set
            {
                _employee.Otch = value;
            }
        }

        /*[System.ComponentModel.DisplayName("ИНН")]
        [System.ComponentModel.Category("Документы")]
        [System.ComponentModel.Description("ИНН сотрудника")]
        public string
        {
            get
            {
                return employee;
            }
            set
            {
                employee = value;
            }
        }*/
        [System.ComponentModel.DisplayName("\t\t\t\tДата рождения")]
        [System.ComponentModel.Category("\t\t\t\tЛичные данные")]
        [System.ComponentModel.Description("Дата рождения сотрудника")]
        [System.ComponentModel.ReadOnly(false)]
        public DateTime BirthDate
        {
            get
            {
                return Convert.ToDateTime(_employee.BirthDate);
            }
            set
            {
                _employee.BirthDate = value;
            }
        }

        [System.ComponentModel.DisplayName("\t\t\tМесто рождения")]
        [System.ComponentModel.Category("\t\t\t\tЛичные данные")]
        [System.ComponentModel.Description("Место рождения сотрудника")]
        [System.ComponentModel.ReadOnly(false)]
        public string BirthPlace
        {
            get
            {
                return _employee.BirthPlace;
            }
            set
            {
                _employee.BirthPlace = value;
            }
        }

        [System.ComponentModel.DisplayName("\t\tГражданство")]
        [System.ComponentModel.Category("\t\t\t\tЛичные данные")]
        [System.ComponentModel.Description("Гражданство сотрудника")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.TypeConverter(typeof(SimpleToStringConvertor<Grazd>))]
        public Grazd Grazd
        {
            get
            {
                return _employee.Grazd;
            }
            set
            {
                _employee.Grazd = value;
            }
        }

        [System.ComponentModel.DisplayName("\tСемейное положение")]
        [System.ComponentModel.Category("\t\t\t\tЛичные данные")]
        [System.ComponentModel.Description("Семейное положение сотрудника")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.TypeConverter(typeof(SimpleToStringConvertor<SemPol>))]
        public SemPol SemPol
        {
            get
            {
                return _employee.SemPol;
            }
            set
            {
                _employee.SemPol = value;
            }
        }

        [System.ComponentModel.DisplayName("Районный коэффициент")]
        [System.ComponentModel.Category("Коэффициенты")]
        [System.ComponentModel.Description("Районный коэффициент сотрудника")]
        [System.ComponentModel.ReadOnly(false)]
        public int RayonKoeff
        {
            get
            {
                return _employee.RayonKoeff;
            }
            set
            {
                _employee.RayonKoeff = value;
            }
        }

        [System.ComponentModel.DisplayName("Северный коэффициент")]
        [System.ComponentModel.Category("Коэффициенты")]
        [System.ComponentModel.Description("Северный коэффициент сотрудника")]
        [System.ComponentModel.ReadOnly(false)]
        public int SeverKoeff
        {
            get
            {
                return _employee.SeverKoeff;
            }
            set
            {
                _employee.SeverKoeff = value;
            }
        }


        [System.ComponentModel.DisplayName("Серия")]
        [System.ComponentModel.Category("Паспорт")]
        [System.ComponentModel.Description("Серия паспорта сотрудника")]
        [System.ComponentModel.ReadOnly(false)]
        public string Paspser
        {
            get
            {
                return _employee.paspser;
            }
            set
            {
                _employee.paspser = value;
            }
        }

        [System.ComponentModel.DisplayName("Номер")]
        [System.ComponentModel.Category("Паспорт")]
        [System.ComponentModel.Description("Номер паспорта сотрудника")]
        [System.ComponentModel.ReadOnly(false)]
        public string Paspnomer
        {
            get
            {
                return _employee.paspnomer;
            }
            set
            {
                _employee.paspnomer = value;
            }
        }

        [System.ComponentModel.DisplayName("Кем выдан")]
        [System.ComponentModel.Category("Паспорт")]
        [System.ComponentModel.Description("Кем выдан паспорт сотрудника")]
        [System.ComponentModel.ReadOnly(false)]
        public string Paspkem
        {
            get
            {
                return _employee.paspkem;
            }
            set
            {
                _employee.paspkem = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата выдачи")]
        [System.ComponentModel.Category("Паспорт")]
        [System.ComponentModel.Description("Дата выдачи паспорта сотрудника")]
        [System.ComponentModel.ReadOnly(false)]
        public DateTime Paspdate
        {
            get
            {
                return Convert.ToDateTime(_employee.paspdate);
            }
            set
            {
                _employee.paspdate = value;
            }
        }

        [System.ComponentModel.DisplayName("Серия ТК")]
        [System.ComponentModel.Category("Трудовая книжка")]
        [System.ComponentModel.Description("Серия трудовой книжки сотрудника")]
        [System.ComponentModel.ReadOnly(false)]
        public string EmplHistSer
        {
            get
            {
                return _employee.EmplHistSer;
            }
            set
            {
                _employee.EmplHistSer = value;
            }
        }

        [System.ComponentModel.DisplayName("Номер ТК")]
        [System.ComponentModel.Category("Трудовая книжка")]
        [System.ComponentModel.Description("Номер трудовой книжки сотрудника")]
        [System.ComponentModel.ReadOnly(false)]
        public string EmplHistNumber
        {
            get
            {
                return _employee.EmplHistNumber;
            }
            set
            {
                _employee.EmplHistNumber = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата выдачи ТК")]
        [System.ComponentModel.Category("Трудовая книжка")]
        [System.ComponentModel.Description("Дата выдачи трудовой книжки сотрудника")]
        [System.ComponentModel.ReadOnly(false)]
        public DateTime EmplHistDate
        {
            get
            {
                return Convert.ToDateTime(_employee.EmplHistDate);
            }
            set
            {
                _employee.EmplHistDate = value;
            }
        }
        [System.ComponentModel.DisplayName("ИНН")]
        [System.ComponentModel.Category("Документы")]
        [System.ComponentModel.Description("ИНН сотрудника")]
        [System.ComponentModel.ReadOnly(false)]
        public string INN
        {
            get
            {
                return _employee.inn;
            }
            set
            {
                _employee.inn = value;
            }
        }

        [System.ComponentModel.DisplayName("Номер мед полиса")]
        [System.ComponentModel.Category("Документы")]
        [System.ComponentModel.Description("Номер медицинского полиса сотрудника")]
        [System.ComponentModel.ReadOnly(false)]
        public string Medpolis
        {
            get
            {
                return _employee.medpolis;
            }
            set
            {
                _employee.medpolis = value;
            }
        }

        [System.ComponentModel.DisplayName("СНИЛС")]
        [System.ComponentModel.Category("Документы")]
        [System.ComponentModel.Description("СНИЛС сотрудника")]
        [System.ComponentModel.ReadOnly(false)]
        public string Ssgps
        {
            get
            {
                return _employee.ssgps;
            }
            set
            {
                _employee.ssgps = value;
            }
        }
        [System.ComponentModel.DisplayName("Общий трудовой стаж")]
        [System.ComponentModel.Category("Трудовой стаж")]
        [System.ComponentModel.Description("Число лет, месяцев и дней стажа сотрудника")]
        [System.ComponentModel.ReadOnly(true)]
        public string TotalExperience
        {
            get { return _employee.EmployeeExperiences
                    .GetExperience().FormatAsExperience(); }            
        }

        [System.ComponentModel.DisplayName("Научно-педагогический трудовой стаж")]
        [System.ComponentModel.Category("Трудовой стаж")]
        [System.ComponentModel.Description("Число лет, месяцев и дней стажа сотрудника на научно-педагогических должностях")]
        [System.ComponentModel.ReadOnly(true)]
        public string TotalPedagogicalExperience
        {
            get { return _employee.EmployeeExperiences
                    .Where(x=>x.Experience == KindOfExperience.Pedagogical)
                    .GetExperience().FormatAsExperience(); }
        }

        [System.ComponentModel.DisplayName("Трудовой стаж МКС")]
        [System.ComponentModel.Category("Трудовой стаж")]
        [System.ComponentModel.Description("Число лет, месяцев и дней стажа сотрудника в МКС")]
        [System.ComponentModel.ReadOnly(true)]
        public string TotalNorthExperience
        {
            get
            {
                return _employee.EmployeeExperiences.
                    FilterNorthExperience().Where(x => x.Territory == TerritoryConditions.North)
                    .GetExperience().FormatAsExperience();
            }
        }

        [System.ComponentModel.DisplayName("Трудовой стаж РКС")]
        [System.ComponentModel.Category("Трудовой стаж")]
        [System.ComponentModel.Description("Число лет, месяцев и дней стажа сотрудника в РКС")]
        [System.ComponentModel.ReadOnly(true)]
        public string TotalStrictNorthExperience
        {
            get
            {
                return _employee.EmployeeExperiences.
                        FilterNorthExperience().Where(x => x.Territory == TerritoryConditions.StrictNorth)
                        .GetExperience().FormatAsExperience();
            }
        }


        [System.ComponentModel.DisplayName("Трудовой стаж в организации")]
        [System.ComponentModel.Category("Трудовой стаж")]
        [System.ComponentModel.Description("Число лет, месяцев и дней стажа сотрудника в этой организации")]
        [System.ComponentModel.ReadOnly(true)]
        public string TotalOrganizationExperience
        {
            get { return _employee.EmployeeExperiences
                    .Where(x => x.Affilation == Affilations.Organization)
                    .GetExperience()
                    .FormatAsExperience(); }
        }

        [System.ComponentModel.DisplayName("Непрерывный трудовой стаж в организации")]
        [System.ComponentModel.Category("Трудовой стаж")]
        [System.ComponentModel.Description("Число лет, месяцев и дней непрерывного стажа сотрудника в этой организации")]
        [System.ComponentModel.ReadOnly(true)]
        public string TotalOrganizationContiniousExperience
        {
            get { return _employee.EmployeeExperiences
                    .Where(x => x.Affilation == Affilations.Organization)
                    .Continious()
                    .GetExperience()
                    .FormatAsExperience(); }
        }
    }
}
