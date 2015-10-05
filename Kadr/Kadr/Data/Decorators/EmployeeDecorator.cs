using System.ComponentModel;
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
            if (_employee.id == 0)
                return "Ввод личных данных сотрудника";
            return "Редактирование личных данных сотрудника";
        }

        #region MainData
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

        
        [System.ComponentModel.DisplayName("Электронный адрес")]
        [System.ComponentModel.Category("\t\t\t\t\t\tЛичные данные")]
        [System.ComponentModel.Description("Адрес электронной почты")]
        [System.ComponentModel.ReadOnly(false)]
        public string Email
        {
            get
            {
                return _employee.email;
            }
            set
            {
                _employee.email = value;
            }
        }

        [System.ComponentModel.DisplayName("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tТабельный номер")]
        [System.ComponentModel.Category("\t\t\t\t\t\tЛичные данные")]
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
        [System.ComponentModel.Category("\t\t\t\t\t\tЛичные данные")]
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

        [System.ComponentModel.DisplayName("\t\t\t\t\t\tПол")]
        [System.ComponentModel.Category("\t\t\t\t\t\tЛичные данные")]
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
        [System.ComponentModel.Category("\t\t\t\t\t\tЛичные данные")]
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

        [System.ComponentModel.DisplayName("\t\t\t\t\t\t\tОтчество")]
        [System.ComponentModel.Category("\t\t\t\t\t\tЛичные данные")]
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

        [System.ComponentModel.DisplayName("\t\t\t\t\tГражданство")]
        [System.ComponentModel.Category("\t\t\t\t\t\tЛичные данные")]
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

        [System.ComponentModel.DisplayName("\t\t\t\t\tСемейное положение")]
        [System.ComponentModel.Category("\t\t\t\t\t\tЛичные данные")]
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
        #endregion

        #region BirthData
        [System.ComponentModel.DisplayName("\t\t\t\tДата рождения")]
        [System.ComponentModel.Category("\t\t\t\t\t\tЛичные данные")]
        [System.ComponentModel.Description("Дата рождения сотрудника")]
        [System.ComponentModel.RefreshProperties(RefreshProperties.Repaint)]
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

        [System.ComponentModel.DisplayName("\t\tМесто рождения")]
        [System.ComponentModel.Category("\t\t\t\t\t\tЛичные данные")]
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

        [System.ComponentModel.DisplayName("\t\t\tВыводить дату рождения")]
        [System.ComponentModel.Category("\t\t\t\t\t\tЛичные данные")]
        [System.ComponentModel.Description("Выводить дату рождения на сайте ugtu")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.TypeConverter(typeof(Kadr.UI.Common.CustomBooleanConverter))]//Kadr.UI.Common.CustomBooleanConverter
        public bool AllowBirthdate
        {
            get
            {
                return _employee.AllowBirthdate;
            }
            set
            {
                _employee.AllowBirthdate = value;
            }
        }

        [System.ComponentModel.DisplayName("\tВозраст")]
        [System.ComponentModel.Category("\t\t\t\t\t\tЛичные данные")]
        [System.ComponentModel.Description("Возраст полных лет сотрудника")]
        [System.ComponentModel.ReadOnly(false)]
        public string Age
        {
            get
            {
                var age = _employee.GetAge();
                if (age == null) return "Не указана дата рождения";
                //return string.Format("{0} {1}", age.Value, age.Value.GetYearStr());
                return age.ToString();
            }

        }

        #endregion

        #region Koeffs
        [System.ComponentModel.DisplayName("Районный коэффициент")]
        [System.ComponentModel.Category("\t\t\t\tКоэффициенты")]
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
        [System.ComponentModel.Category("\t\t\t\tКоэффициенты")]
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
        #endregion

        #region PaspData
        [System.ComponentModel.DisplayName("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tСерия")]
        [System.ComponentModel.Category("\t\t\tПаспорт")]
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

        [System.ComponentModel.DisplayName("\t\t\t\t\t\t\t\t\t\t\t\tНомер")]
        [System.ComponentModel.Category("\t\t\tПаспорт")]
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

        [System.ComponentModel.DisplayName("\t\t\t\t\t\tКем выдан")]
        [System.ComponentModel.Category("\t\t\tПаспорт")]
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

        [System.ComponentModel.DisplayName("\t\t\t\t\t\t\t\t\tДата выдачи")]
        [System.ComponentModel.Category("\t\t\tПаспорт")]
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

        [System.ComponentModel.DisplayName("\t\t\tКод подразделения")]
        [System.ComponentModel.Category("\t\t\tПаспорт")]
        [System.ComponentModel.Description("Код подразделения, выдавшего паспорт")]
        [System.ComponentModel.ReadOnly(false)]
        public string paspCodeKem
        {
            get
            {
                return _employee.paspCodeKem;
            }
            set
            {
                _employee.paspCodeKem = value;
            }
        }

        #endregion

        #region EmplHist
        [System.ComponentModel.DisplayName("Серия ТК")]
        [System.ComponentModel.Category("\t\tТрудовая книжка")]
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
        [System.ComponentModel.Category("\t\tТрудовая книжка")]
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
        [System.ComponentModel.Category("\t\tТрудовая книжка")]
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
        #endregion

        #region OtherDocsData
        [System.ComponentModel.DisplayName("ИНН")]
        [System.ComponentModel.Category("\t\t\t\t\tДокументы")]
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
        [System.ComponentModel.Category("\t\t\t\t\tДокументы")]
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
        [System.ComponentModel.Category("\t\t\t\t\tДокументы")]
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
        #endregion

        #region ExperienceData
        [System.ComponentModel.DisplayName("Общий трудовой стаж")]
        [System.ComponentModel.Category("Трудовой стаж")]
        [System.ComponentModel.Description("Число лет, месяцев и дней стажа сотрудника")]
        [System.ComponentModel.ReadOnly(true)]
        public string TotalExperience
        {
            get
            {
                return _employee.EmployeeExperiences
                    .SequenceInterval()
                    .GetExperience().FormatAsExperience();
            }
        }

        [System.ComponentModel.DisplayName("Научно-педагогический трудовой стаж")]
        [System.ComponentModel.Category("Трудовой стаж")]
        [System.ComponentModel.Description("Число лет, месяцев и дней стажа сотрудника на научно-педагогических должностях")]
        [System.ComponentModel.ReadOnly(true)]
        public string TotalPedagogicalExperience
        {
            get
            {
                return _employee.EmployeeExperiences
                  .Where(x => x.Experience == KindOfExperience.Pedagogical)
                  .SequenceInterval()
                  .GetExperience().FormatAsExperience();
            }
        }

        [System.ComponentModel.DisplayName("Северный трудовой стаж")]
        [System.ComponentModel.Category("Трудовой стаж")]
        [System.ComponentModel.Description("Число лет, месяцев и дней стажа сотрудника в районах МКС или РКС")]
        [System.ComponentModel.ReadOnly(true)]
        public string TotalNorthExperience
        {
            get
            {
                return GetSpecificNorthExperienceStr();
            }
        }

        [System.ComponentModel.DisplayName("Трудовой стаж МКС")]
        [System.ComponentModel.Category("Трудовой стаж")]
        [System.ComponentModel.Description("Число лет, месяцев и дней стажа сотрудника в районах МКС")]
        [System.ComponentModel.ReadOnly(true)]
        public string NorthExperience
        {
            get
            {
                return GetSpecificNorthExperienceStr(TerritoryConditions.North);
            }
        }
        [System.ComponentModel.DisplayName("Трудовой стаж РКС")]
        [System.ComponentModel.Category("Трудовой стаж")]
        [System.ComponentModel.Description("Число лет, месяцев и дней стажа сотрудника в районах РКС")]
        [System.ComponentModel.ReadOnly(true)]
        public string StrictNorthExperience
        {
            get
            {
                return GetSpecificNorthExperienceStr(TerritoryConditions.StrictNorth);
            }
        }

        private string GetSpecificNorthExperienceStr()
        {
            return _employee.EmployeeExperiences.FilterNorthExperience().
                SequenceInterval()
                .GetExperience().FormatAsExperience();
        }
        private string GetSpecificNorthExperienceStr(TerritoryConditions conditions)
        {
            return _employee.EmployeeExperiences
                .FilterNorthExperience()
                .Where(x=>x.Territory == conditions)
                .SequenceInterval()
                .GetExperience().FormatAsExperience();
        }

        [System.ComponentModel.DisplayName("Трудовой стаж в организации")]
        [System.ComponentModel.Category("Трудовой стаж")]
        [System.ComponentModel.Description("Число лет, месяцев и дней стажа сотрудника в этой организации")]
        [System.ComponentModel.ReadOnly(true)]
        public string TotalOrganizationExperience
        {
            get
            {
                return _employee.EmployeeExperiences
                    .Where(x => x.Affilation == Affilations.Organization)
                    .SequenceInterval()
                    .GetExperience()
                    .FormatAsExperience();
            }
        }

        [System.ComponentModel.DisplayName("Непрерывный трудовой стаж в организации")]
        [System.ComponentModel.Category("Трудовой стаж")]
        [System.ComponentModel.Description("Число лет, месяцев и дней непрерывного стажа сотрудника в этой организации")]
        [System.ComponentModel.ReadOnly(true)]
        public string TotalOrganizationContiniousExperience
        {
            get
            {
                return _employee.EmployeeExperiences
                  .Where(x => x.Affilation == Affilations.Organization)
                  .SequenceInterval()
                  .Continious()
                  .GetExperience()
                  .FormatAsExperience();
            }
        }
        #endregion

        #region MilitaryData
        //Воинский учет
        [System.ComponentModel.DisplayName("\t\t\t\t\t\t\t\tКатегория запаса")]
        [System.ComponentModel.Category("\tВоинский учет")]
        [System.ComponentModel.Description("Категория запаса")]
        [TypeConverter(typeof(SimpleToStringConvertor<MilitaryCategory>))]
        [System.ComponentModel.ReadOnly(false)]
        public MilitaryCategory MilitaryCategory
        {
            get
            {
                return _employee.MilitaryCategory;
            }
            set
            {
                _employee.MilitaryCategory = value;
            }
        }

        [System.ComponentModel.DisplayName("\t\t\t\t\t\t\tВоинское звание")]
        [System.ComponentModel.Category("\tВоинский учет")]
        [System.ComponentModel.Description("Воинское звание")]
        [TypeConverter(typeof(SimpleToStringConvertor<MilitaryRank>))]
        [System.ComponentModel.ReadOnly(false)]
        public MilitaryRank MilitaryRank
        {
            get
            {
                return _employee.MilitaryRank;
            }
            set
            {
                _employee.MilitaryRank = value;
            }
        }

        [System.ComponentModel.DisplayName("\t\t\t\t\t\tСостав (профиль)")]
        [System.ComponentModel.Category("\tВоинский учет")]
        [System.ComponentModel.Description("Состав (профиль)")]
        [TypeConverter(typeof(SimpleToStringConvertor<MilitaryStructure>))]
        [System.ComponentModel.ReadOnly(false)]
        public MilitaryStructure MilitaryStructure
        {
            get
            {
                return _employee.MilitaryStructure;
            }
            set
            {
                _employee.MilitaryStructure = value;
            }
        }

        [System.ComponentModel.DisplayName("\t\t\t\t\tПолное кодовое обозначение ВУС ")]
        [System.ComponentModel.Category("\tВоинский учет")]
        [System.ComponentModel.Description("Полное кодовое обозначение ВУС ")]
        [System.ComponentModel.ReadOnly(false)]
        public string VUSCode
        {
            get
            {
                return _employee.VUSCode;
            }
            set
            {
                _employee.VUSCode = value;
            }
        }

        [System.ComponentModel.DisplayName("\t\t\t\tКатегория годности к военной службе ")]
        [System.ComponentModel.Category("\tВоинский учет")]
        [System.ComponentModel.Description("Категория годности к военной службе ")]
        [TypeConverter(typeof(SimpleToStringConvertor<MilitaryFitness>))]
        [System.ComponentModel.ReadOnly(false)]
        public MilitaryFitness MilitaryFitness
        {
            get
            {
                return _employee.MilitaryFitness;
            }
            set
            {
                _employee.MilitaryFitness = value;
            }
        }

        [System.ComponentModel.DisplayName("\t\t\tВоенный комиссариат")]
        [System.ComponentModel.Category("\tВоинский учет")]
        [System.ComponentModel.Description("Наименование военного комиссариата по месту жительства")]
        [System.ComponentModel.ReadOnly(false)]
        public string MilitaryCommissariat
        {
            get
            {
                return _employee.MilitaryCommissariat;
            }
            set
            {
                _employee.MilitaryCommissariat = value;
            }
        }

        [System.ComponentModel.DisplayName("\t\tТип воинского учета")]
        [System.ComponentModel.Category("\tВоинский учет")]
        [System.ComponentModel.Description("Тип воинского учета")]
        [TypeConverter(typeof(SimpleToStringConvertor<MilitaryType>))]
        [System.ComponentModel.ReadOnly(false)]
        public MilitaryType MilitaryType
        {
            get
            {
                return _employee.MilitaryType;
            }
            set
            {
                _employee.MilitaryType = value;
            }
        }

        [System.ComponentModel.DisplayName("Отметка о снятии с воинского учета")]
        [System.ComponentModel.Category("\tВоинский учет")]
        [System.ComponentModel.Description("Отметка о снятии с воинского учета")]
        [System.ComponentModel.ReadOnly(false)]
        public string RemovalMilitaryMark
        {
            get
            {
                return _employee.RemovalMilitaryMark;
            }
            set
            {
                _employee.RemovalMilitaryMark = value;
            }
        }

        [System.ComponentModel.DisplayName("\tНомер команды, партии / Номер спец. учета")]
        [System.ComponentModel.Category("\tВоинский учет")]
        [System.ComponentModel.Description("Номер команды, партии / Номер спец. учета")]
        [System.ComponentModel.ReadOnly(false)]
        public string NumberMilitaryType
        {
            get
            {
                return _employee.NumberMilitaryType;
            }
            set
            {
                _employee.NumberMilitaryType = value;
            }
        }

        #endregion

    }
}
