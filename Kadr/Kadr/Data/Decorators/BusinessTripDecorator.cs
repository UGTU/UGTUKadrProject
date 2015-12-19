using Kadr.Controllers;
using Kadr.Data.Converters;
using Kadr.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    [TypeConverter(typeof(PropertySorter))]
    class BusinessTripDecorator: IPrikazTypeProvider
    {
        private BusinessTrip Trip;

        public BusinessTripDecorator(BusinessTrip Trip)
        {
            this.Trip = Trip;
            /*if (Trip.Event.Prikaz != null)
                if (Trip.Event.Prikaz.DatePrikaz != null)
                    PDate = (DateTime)Trip.Event.Prikaz.DatePrikaz;*/
        }

        public override string ToString()
        {
            return Trip.ToString();
        }

        [DisplayName("ID")]
        [Category("Атрибуты")]
        [Description("Уникальный код командировки")]
        [ReadOnly(true)]
        [Browsable(false)]
        public int ID
        {
            get
            {
                return Trip.id;
            }
            /*set
            {
                Trip.id = value;
            }*/
        }

        /*
        [DisplayName("Дата приказа")]
        [Category("Основные")]
        [Description("Дата, по которой будет отфильтровано поле 'Приказ'")]
        public DateTime PrikazDate
        {
            get
            {
                return PDate;
            }
            set
            {
                if (value != null) PDate = value;
            }
        }*/

        [DisplayName("Приказ")]
        [Category("1. Основные")]
        [Description("Приказ, назначающий командировку")]
        [ReadOnly(false)]
        [PropertyOrder(1)]
        [Editor(typeof(Kadr.UI.Editors.PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Prikaz Prikaz
        {
            get
            {
                return Trip.Event.Prikaz;
            }
            set
            {
                Trip.Event.Prikaz = value;
                if (value != null)
                {
                    if (value.DateBegin != null) DateBegin = (DateTime)value.DateBegin;
                    if (value.DateEnd != null) DateEnd = (DateTime)value.DateBegin;
                }
                
                // спросить про это:
                // factStaff.MainFactStaff = KadrController.Instance.Model.FactStaffs.Where(fcSt => fcSt.id == value.id).SingleOrDefault();
            }
        }

        [DisplayName("Дата начала")]
        [PropertyOrder(10)]
        [Category("2. Сроки командировки")]
        [Description("Дата начала командировки, значащаяся в приказе")]
        [ReadOnly(false)]
        public DateTime DateBegin
        {
            get
            {
                return (DateTime)Trip.Event.DateBegin;
            }
            set
            {
                if (value != null)
                {
                    if ((Trip.BusinessTripRegionTypes.First().DateBegin == DateBegin)|| (Trip.BusinessTripRegionTypes.First().DateBegin < value)) Trip.BusinessTripRegionTypes.First().DateBegin = value;
                    Trip.Event.DateBegin = value;
                }
            }
        }

        [DisplayName("Дата окончания")]
        [PropertyOrder(20)]
        [Category("2. Сроки командировки")]
        [Description("Дата окончания командировки, значащаяся в приказе")]
        [ReadOnly(false)]
        public DateTime DateEnd
        {
            get
            {

                return (DateTime)Trip.Event.DateEnd;
            }
            set
            {

                if (value != null)
                {
                    if ((Trip.BusinessTripRegionTypes.First().DateEnd == DateEnd)||(Trip.BusinessTripRegionTypes.First().DateEnd > value)) Trip.BusinessTripRegionTypes.First().DateEnd = value;
                    Trip.Event.DateEnd = value;
                }

            }
        }

        [DisplayName("Дней в дороге")]
        [Category("4. Дополнительно")]
        [Description("Сколько дней сотрудник проводит в дороге до места пребывания и обратно")]
        [ReadOnly(false)]
        public int? DaysInRoad
        {
            get
            {

                return Trip.DaysInRoad;
            }
            set
            {

                if ((value<=(DateEnd-DateBegin).Days)&&(value>=0))
                Trip.DaysInRoad = value;
                                    
            }

        }


        [DisplayName("Основное место назначения")]
        [Category("3. Места пребывания")]
        [Description("Основное место назначения командировки")]
        [ReadOnly(false)]
        public string TargetPlace
        {
            get
            {
                return Trip.TripTargetPlace;
            }
            set
            {
                 Trip.TripTargetPlace = value;
            }
        }



        [DisplayName("Финансирование")]
        [Category("4. Дополнительно")]
        [Description("За счет каких средств осуществляется командировка")]
        [ReadOnly(false)]
        [TypeConverter(typeof(SimpleToStringConvertor<FinancingSource>))]
        //[Editor(typeof(Kadr.UI.Editors.FinancingSourceEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public FinancingSource FinSource
        {
            get
            {
                return Trip.FinancingSource;
            }
            set
            {
                 Trip.FinancingSource = value;
            }
        }

        [DisplayName("Территориальные условия")]
        [Category("3. Места пребывания")]
        [Description("В какой регион командируется сотрудник")]
        [ReadOnly(false)]
        [TypeConverter(typeof(SimpleToStringConvertor<RegionType>))]
        //В случае, если регион не требует дополнительного указания сроков пребывания, для создания записи BusinessTripRegionType будут использованы Сроки командировки командировки из приказа
        //В ином случае предполагается, что пользователь отредактирует запись места пребывания при помощи пункта меню "Изменить Сроки командировки пребывания в регионе"
        public RegionType TripMainRegion
        {
            get
            {
                return Trip.BusinessTripRegionTypes.First().RegionType;
            }

            set
            {
                Trip.BusinessTripRegionTypes.First().RegionType = value;
            }

        }

        [DisplayName("Сроки командировки пребывания в регионах уточнены")]
        [Category("3. Места пребывания")]
        [Description("Изменены даты пребывания в регионах командировки")]
        [ReadOnly(true)]
        [Browsable(false)]
        //[TypeConverter(typeof(SimpleToStringConvertor<RegionType>))]

        public bool IsRegionDatesChanged
        {
            get
            {
                var list = Trip.BusinessTripRegionTypes;
                return ((list.Count > 1) || (list[0].DateBegin != DateBegin) || (list[0].DateEnd != DateEnd));
            }
        }

        [Browsable(false)]
        [ReadOnly(true)]
        public PrikazType PrikazType
        {
            get
            {
                return MagicNumberController.BusinessTripPrikazType;
            }
        }

        internal BusinessTrip GetTrip()
        {
            return Trip;
        }

        internal BusinessTripRegionType GetRegionType()
        {
            return Trip.BusinessTripRegionTypes.FirstOrDefault();
        }

        internal void CancelTrip(Prikaz p)
        {
            Trip.Event.PrikazEnd = p;
        }

        internal void ChangeDates(DateTime beg, DateTime end)
        {
            DateBegin = beg;
            DateEnd = end;
        }
    }

}
