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
    [TypeConverter(typeof(PropertySorter))]
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
        [DisplayName("ID")]
        [Category("Атрибуты")]
        [Description("Уникальный код сотрудника")]
        [ReadOnly(true)]
        [Browsable(false)]
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

        
        [DisplayName("Электронный адрес")]
        [Category("1. Личные данные")]
        [PropertyOrder(13)]
        [Description("Адрес электронной почты")]
        [ReadOnly(false)]
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

        [DisplayName("Табельный номер")]
        [PropertyOrder(1)]
        [Category("1. Личные данные")]
        [Description("Табельный номер сотрудника в системе отдела кадров")]
        [ReadOnly(false)]
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

        [DisplayName("Фамилия")]
        [Category("1. Личные данные")]
        [PropertyOrder(2)]
        [Description("Фамилия сотрудника")]
        [ReadOnly(false)]
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

        [DisplayName("Пол")]
        [Category("1. Личные данные")]
        [Description("Пол сотрудника")]
        [PropertyOrder(5)]
        [ReadOnly(false)]
        [TypeConverter(typeof(Kadr.UI.Common.GenderBooleanConverter))]//Kadr.UI.Common.CustomBooleanConverter
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

        
        [DisplayName("Имя")]
        [Category("1. Личные данные")]
        [Description("Имя сотрудника")]
        [PropertyOrder(3)]
        [ReadOnly(false)]
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

        [DisplayName("Отчество")]
        [Category("1. Личные данные")]
        [Description("Отчество сотрудника")]
        [PropertyOrder(4)]
        [ReadOnly(false)]
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

        /*[DisplayName("ИНН")]
        [Category("Документы")]
        [Description("ИНН сотрудника")]
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

        [DisplayName("Гражданство")]
        [Category("1. Личные данные")]
        [PropertyOrder(6)]
        [Description("Гражданство сотрудника")]
        [ReadOnly(false)]
        [TypeConverter(typeof(SimpleToStringConvertor<Grazd>))]
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

        [DisplayName("Семейное положение")]
        [Category("1. Личные данные")]
        [PropertyOrder(7)]
        [Description("Семейное положение сотрудника")]
        [ReadOnly(false)]
        [TypeConverter(typeof(SimpleToStringConvertor<SemPol>))]
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
        [DisplayName("Дата рождения")]
        [Category("1. Личные данные")]
        [PropertyOrder(8)]
        [Description("Дата рождения сотрудника")]
        [RefreshProperties(RefreshProperties.Repaint)]
        [ReadOnly(false)]
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

        [DisplayName("Место рождения")]
        [Category("1. Личные данные")]
        [PropertyOrder(10)]
        [Description("Место рождения сотрудника")]
        [ReadOnly(false)]
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

        [DisplayName("Выводить дату рождения")]
        [Category("1. Личные данные")]
        [PropertyOrder(9)]
        [Description("Выводить дату рождения на сайте ugtu")]
        [ReadOnly(false)]
        [TypeConverter(typeof(Kadr.UI.Common.CustomBooleanConverter))]//Kadr.UI.Common.CustomBooleanConverter
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

        [DisplayName("Возраст")]
        [Category("1. Личные данные")]
        [PropertyOrder(12)]
        [Description("Возраст полных лет сотрудника")]
        [ReadOnly(false)]
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
        [DisplayName("Районный коэффициент")]
        [Category("3. Коэффициенты")]
        [PropertyOrder(1)]
        [Description("Районный коэффициент сотрудника")]
        [ReadOnly(false)]
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

        [DisplayName("Северный коэффициент")]
        [Category("3. Коэффициенты")]
        [PropertyOrder(2)]
        [Description("Северный коэффициент сотрудника")]
        [ReadOnly(false)]
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
        [DisplayName("Серия")]
        [Category("4. Паспорт")]
        [PropertyOrder(1)]
        [Description("Серия паспорта сотрудника")]
        [ReadOnly(false)]
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

        [DisplayName("Номер")]
        [Category("4. Паспорт")]
        [PropertyOrder(2)]
        [Description("Номер паспорта сотрудника")]
        [ReadOnly(false)]
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

        [DisplayName("Кем выдан")]
        [Category("4. Паспорт")]
        [PropertyOrder(4)]
        [Description("Кем выдан паспорт сотрудника")]
        [ReadOnly(false)]
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

        [DisplayName(" Дата выдачи")]
        [Category("4. Паспорт")]
        [PropertyOrder(3)]
        [Description("Дата выдачи паспорта сотрудника")]
        [ReadOnly(false)]
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

        [DisplayName("Код подразделения")]
        [Category("4. Паспорт")]
        [PropertyOrder(5)]
        [Description("Код подразделения, выдавшего паспорт")]
        [ReadOnly(false)]
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
        [DisplayName("Серия ТК")]
        [Category("5. Трудовая книжка")]
        [PropertyOrder(3)]
        [Description("Серия трудовой книжки сотрудника")]
        [ReadOnly(false)]
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

        [DisplayName("Номер ТК")]
        [Category("5. Трудовая книжка")]
        [PropertyOrder(2)]
        [Description("Номер трудовой книжки сотрудника")]
        [ReadOnly(false)]
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

        [DisplayName("Дата выдачи ТК")]
        [Category("5. Трудовая книжка")]
        [PropertyOrder(1)]
        [Description("Дата выдачи трудовой книжки сотрудника")]
        [ReadOnly(false)]
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
        [DisplayName("ИНН")]
        [Category("2. Документы")]
        [PropertyOrder(1)]
        [Description("ИНН сотрудника")]
        [ReadOnly(false)]
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

        [DisplayName("Номер мед полиса")]
        [Category("2. Документы")]
        [PropertyOrder(2)]
        [Description("Номер медицинского полиса сотрудника")]
        [ReadOnly(false)]
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

        [DisplayName("СНИЛС")]
        [Category("2. Документы")]
        [PropertyOrder(3)]
        [Description("СНИЛС сотрудника")]
        [ReadOnly(false)]
        public string Ssgps
        {
            get
            {
                return _employee.ssgps;
            }
            set
            {
                if ((value.Substring(3, 1) != "-") && (value.Length == 11))
                    _employee.ssgps = value.Substring(0, 3) + "-" + value.Substring(3, 3) + "-" + value.Substring(6, 3) + "-" + value.Substring(9, 2); 
                else
                    _employee.ssgps = value;
            }
        }
        #endregion

        #region ExperienceData
        [DisplayName("Общий трудовой стаж")]
        [Category("7. Трудовой стаж")]
        [PropertyOrder(3)]
        [Description("Число лет, месяцев и дней стажа сотрудника")]
        [ReadOnly(true)]
        public string TotalExperience
        {
            get
            {
                return "";/* _employee.EmployeeExperiences
                    .SequenceInterval()
                    .GetExperience().FormatAsExperience();*/
            }
        }

        [DisplayName("Научно-педагогический трудовой стаж")]
        [Category("7. Трудовой стаж")]
        [PropertyOrder(1)]
        [Description("Число лет, месяцев и дней стажа сотрудника на научно-педагогических должностях")]
        [ReadOnly(true)]
        public string TotalPedagogicalExperience
        {
            get
            {
                return "";/* _employee.EmployeeExperiences
                  .Where(x => x.Experience == KindOfExperience.Pedagogical)
                  .SequenceInterval()
                  .GetExperience().FormatAsExperience();*/
            }
        }

        [DisplayName("Северный трудовой стаж")]
        [Category("7. Трудовой стаж")]
        [PropertyOrder(4)]
        [Description("Число лет, месяцев и дней стажа сотрудника в районах МКС или РКС")]
        [ReadOnly(true)]
        public string TotalNorthExperience
        {
            get
            {
                return "";// GetSpecificNorthExperienceStr();
            }
        }

        [DisplayName("Трудовой стаж МКС")]
        [Category("7. Трудовой стаж")]
        [PropertyOrder(6)]
        [Description("Число лет, месяцев и дней стажа сотрудника в районах МКС")]
        [ReadOnly(true)]
        public string NorthExperience
        {
            get
            {
                return "";// GetSpecificNorthExperienceStr(TerritoryConditions.North);
            }
        }
        [DisplayName("Трудовой стаж РКС")]
        [Category("7. Трудовой стаж")]
        [PropertyOrder(7)]
        [Description("Число лет, месяцев и дней стажа сотрудника в районах РКС")]
        [ReadOnly(true)]
        public string StrictNorthExperience
        {
            get
            {
                return "";// GetSpecificNorthExperienceStr(TerritoryConditions.StrictNorth);
            }
        }

        private string GetSpecificNorthExperienceStr()
        {
            return "";/* _employee.EmployeeExperiences.FilterNorthExperience().
                SequenceInterval()
                .GetExperience().FormatAsExperience();*/
        }
        private string GetSpecificNorthExperienceStr(TerritoryConditions conditions)
        {
            return "";/* _employee.EmployeeExperiences
                .FilterNorthExperience()
                .Where(x=>x.Territory == conditions)
                .SequenceInterval()
                .GetExperience().FormatAsExperience();*/
        }

        [DisplayName("Трудовой стаж в организации")]
        [Category("7. Трудовой стаж")]
        [PropertyOrder(5)]
        [Description("Число лет, месяцев и дней стажа сотрудника в этой организации")]
        [ReadOnly(true)]
        public string TotalOrganizationExperience
        {
            get
            {
                return "";/* _employee.EmployeeExperiences
                    .Where(x => x.Affilation == Affilations.Organization)
                    .SequenceInterval()
                    .GetExperience()
                    .FormatAsExperience();*/
            }
        }

        [DisplayName("Непрерывный трудовой стаж в организации")]
        [Category("7. Трудовой стаж")]
        [PropertyOrder(2)]
        [Description("Число лет, месяцев и дней непрерывного стажа сотрудника в этой организации")]
        [ReadOnly(true)]
        public string TotalOrganizationContiniousExperience
        {
            get
            {
                return "";/* _employee.EmployeeExperiences
                  .Where(x => x.Affilation == Affilations.Organization)
                  .SequenceInterval()
                  .Continious()
                  .GetExperience()
                  .FormatAsExperience();*/
            }
        }
        #endregion

        #region MilitaryData
        //Воинский учет
        [DisplayName("Категория запаса")]
        [Category("6. Воинский учет")]
        [PropertyOrder(1)]
        [Description("Категория запаса")]
        [TypeConverter(typeof(SimpleToStringConvertor<MilitaryCategory>))]
        [ReadOnly(false)]
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

        [DisplayName("Воинское звание")]
        [Category("6. Воинский учет")]
        [PropertyOrder(2)]
        [Description("Воинское звание")]
        [TypeConverter(typeof(SimpleToStringConvertor<MilitaryRank>))]
        [ReadOnly(false)]
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

        [DisplayName("Состав (профиль)")]
        [Category("6. Воинский учет")]
        [PropertyOrder(3)]
        [Description("Состав (профиль)")]
        [TypeConverter(typeof(SimpleToStringConvertor<MilitaryStructure>))]
        [ReadOnly(false)]
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

        [DisplayName("Полное кодовое обозначение ВУС ")]
        [Category("6. Воинский учет")]
        [PropertyOrder(4)]
        [Description("Полное кодовое обозначение ВУС ")]
        [ReadOnly(false)]
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

        [DisplayName("Категория годности к военной службе ")]
        [Category("6. Воинский учет")]
        [PropertyOrder(5)]
        [Description("Категория годности к военной службе ")]
        [TypeConverter(typeof(SimpleToStringConvertor<MilitaryFitness>))]
        [ReadOnly(false)]
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

        [DisplayName("Военный комиссариат")]
        [Category("6. Воинский учет")]
        [PropertyOrder(6)]
        [Description("Наименование военного комиссариата по месту жительства")]
        [ReadOnly(false)]
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

        [DisplayName("Тип воинского учета")]
        [Category("6. Воинский учет")]
        [PropertyOrder(7)]
        [Description("Тип воинского учета")]
        [TypeConverter(typeof(SimpleToStringConvertor<MilitaryType>))]
        [ReadOnly(false)]
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

        [DisplayName("Отметка о снятии с воинского учета")]
        [Category("6. Воинский учет")]
        [PropertyOrder(9)]
        [Description("Отметка о снятии с воинского учета")]
        [ReadOnly(false)]
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

        [DisplayName("Номер команды, партии / Номер спец. учета")]
        [Category("6. Воинский учет")]
        [PropertyOrder(8)]
        [Description("Номер команды, партии / Номер спец. учета")]
        [ReadOnly(false)]
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
