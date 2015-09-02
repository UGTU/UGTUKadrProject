using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    class BusinessTripRegionTypeDecorator
    {
        private BusinessTripRegionType Type;

        public BusinessTripRegionTypeDecorator(BusinessTripRegionType Type)
        {
            this.Type = Type;
        }

        public override string ToString()
        {
            return Type.ToString();
        }

        [System.ComponentModel.Category("Регион")]
        [System.ComponentModel.DisplayName("Территориальные условия")]
        [System.ComponentModel.Description("В какой регион командируется сотрудник")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.TypeConverter(typeof(Kadr.Data.Converters.RegionConverter))]

        public RegionType TripMainRegion
        {
            get
            {
                return Type.RegionType;
            }

            set
            {
                Type.RegionType = value;
            }

        }


        [System.ComponentModel.DisplayName("Дата начала")]
        [System.ComponentModel.Category("Сроки")]
        [System.ComponentModel.Description("Дата начала пребывания в регионе")]
        [System.ComponentModel.ReadOnly(false)]
        public DateTime DateBegin
        {
            get
            {
                return Type.DateBegin;
            }
            set
            {
                if (value != null)
                {
                    Type.DateBegin = value;
                }

            }
        }

        [System.ComponentModel.DisplayName("Дата окончания")]
        [System.ComponentModel.Category("Сроки")]
        [System.ComponentModel.Description("Дата окончания пребывания в регионе")]
        [System.ComponentModel.ReadOnly(false)]
        public DateTime DateEnd
        {
            get
            {
                return Type.DateEnd;
            }
            set
            {

                if (value != null)
                {
                    Type.DateEnd = value;
                }

            }
        }


    }
}
