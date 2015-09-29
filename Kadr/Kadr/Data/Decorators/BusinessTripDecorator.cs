using Kadr.Controllers;
using Kadr.Data.Converters;
using Kadr.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
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

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код командировки")]
        [System.ComponentModel.ReadOnly(true)]
        [System.ComponentModel.Browsable(false)]
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
        [System.ComponentModel.DisplayName("Дата приказа")]
        [System.ComponentModel.Category("Основные")]
        [System.ComponentModel.Description("Дата, по которой будет отфильтровано поле 'Приказ'")]
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

        [System.ComponentModel.DisplayName("Приказ")]

        [System.ComponentModel.Category("\t\tОсновные")]
        [System.ComponentModel.Description("Приказ, назначающий командировку")]
        [System.ComponentModel.ReadOnly(false)]
        //[System.ComponentModel.TypeConverter())]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Prikaz Prikaz
        {
            get
            {
                return Trip.Event.Prikaz;
            }
            set
            {
                if (value != null) Trip.Event.Prikaz = value;
                // спросить про это:
                // factStaff.MainFactStaff = KadrController.Instance.Model.FactStaffs.Where(fcSt => fcSt.id == value.id).SingleOrDefault();
            }
        }

        [System.ComponentModel.DisplayName("Дата начала")]

        [System.ComponentModel.Category("\t\tСроки")]
        [System.ComponentModel.Description("Дата начала командировки, значащаяся в приказе")]
        [System.ComponentModel.ReadOnly(false)]
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
                    if (Trip.BusinessTripRegionTypes.First().DateBegin == DateBegin) Trip.BusinessTripRegionTypes.First().DateBegin = value;
                    Trip.Event.DateBegin = value;
                }

            }
        }

        [System.ComponentModel.DisplayName("Дата окончания")]
        [System.ComponentModel.Category("\t\tСроки")]
        [System.ComponentModel.Description("Дата окончания командировки, значащаяся в приказе")]
        [System.ComponentModel.ReadOnly(false)]
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
                    if (Trip.BusinessTripRegionTypes.First().DateEnd == DateEnd) Trip.BusinessTripRegionTypes.First().DateEnd = value;
                    Trip.Event.DateEnd = value;
                }

            }
        }

        [System.ComponentModel.DisplayName("Дней в дороге")]
        [System.ComponentModel.Category("Дополнительно")]
        [System.ComponentModel.Description("Сколько дней сотрудник проводит в дороге до места пребывания и обратно")]
        [System.ComponentModel.ReadOnly(false)]
        public int? DaysInRoad
        {
            get
            {

                return Trip.DaysInRoad;
            }
            set
            {
                Trip.DaysInRoad = value;
            }

        }


        [System.ComponentModel.DisplayName("Основное место назначения")]
        [System.ComponentModel.Category("\tМеста пребывания")]
        [System.ComponentModel.Description("Основное место назначения командировки")]
        [System.ComponentModel.ReadOnly(false)]
        public string TargetPlace
        {
            get
            {
                return Trip.TripTargetPlace;
            }
            set
            {
                if (value != null) Trip.TripTargetPlace = value;
            }
        }


        [System.ComponentModel.DisplayName("Финансирование")]
        [System.ComponentModel.Category("Дополнительно")]
        [System.ComponentModel.Description("За счет каких средств осуществляется командировка")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.TypeConverter(typeof(SimpleToStringConvertor<FinancingSource>))]
        //[System.ComponentModel.Editor(typeof(Kadr.UI.Editors.FinancingSourceEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public FinancingSource FinSource
        {
            get
            {
                return Trip.FinancingSource;
            }
            set
            {
                if (value != null) Trip.FinancingSource = value;
            }
        }

        [System.ComponentModel.DisplayName("Территориальные условия")]
        [System.ComponentModel.Category("\tМеста пребывания")]
        [System.ComponentModel.Description("В какой регион командируется сотрудник")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.TypeConverter(typeof(SimpleToStringConvertor<RegionType>))]
        //В случае, если регион не требует дополнительного указания сроков пребывания, для создания записи BusinessTripRegionType будут использованы сроки командировки из приказа
        //В ином случае предполагается, что пользователь отредактирует запись места пребывания при помощи пункта меню "Изменить сроки пребывания в регионе"
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

        [System.ComponentModel.DisplayName("Сроки пребывания в регионах уточнены")]
        [System.ComponentModel.Category("\tМеста пребывания")]
        [System.ComponentModel.Description("Изменены даты пребывания в регионах командировки")]
        [System.ComponentModel.ReadOnly(true)]
        [System.ComponentModel.Browsable(false)]
        //[System.ComponentModel.TypeConverter(typeof(SimpleToStringConvertor<RegionType>))]

        public bool IsRegionDatesChanged
        {
            get
            {
                var list = Trip.BusinessTripRegionTypes;
                return ((list.Count > 1) || (list[0].DateBegin != DateBegin) || (list[0].DateEnd != DateEnd));
            }
        }

        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.ReadOnly(true)]
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
    }

}
