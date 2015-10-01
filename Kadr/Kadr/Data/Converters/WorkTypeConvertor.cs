using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Kadr.Data.Converters
{
    class WorkTypeConvertor : SimpleToStringConvertor<WorkType>
    {
        private ICollection GetCollection(System.ComponentModel.ITypeDescriptorContext context)
        {
            /*Employee currentEmployee = null;
            if (context.Instance is FactStaffMainBaseDecorator)
            {
                currentEmployee = (context.Instance as FactStaffMainBaseDecorator).Employee;
            }

            if (context.Instance is FactStaffHistoryMainBaseDecorator)
            {
                currentEmployee = (context.Instance as FactStaffHistoryMainBaseDecorator).FactStaff.Employee;
            }

            if (currentEmployee != null)
            {
                //выбираем только договоры (без доп соглашений)
                var res = currentEmployee.FactStaffs.SelectMany(x => x.FactStaffHistories).SelectMany(y => y.Events).Where(x
                        => x.EventKind.ForFactStaff).Where(x => x.Contract != null).Select(z => z.Contract).Where(m => m.idMainContract == null).Where(x => x != currentContract);

                if (res == null)
                    return null;
                List<Contract> resList = res.ToList();
                return resList;
            }
            else*/
            {
                return Kadr.Controllers.KadrController.Instance.Model.WorkTypes.ToArray();
            }
        }

        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(GetCollection(context));
        }

        public override object ConvertFrom(ITypeDescriptorContext context,
        System.Globalization.CultureInfo culture, object value)
        {
            /*if (value == null)
                return NullSocialFareTransit.Instance;*/
            if (value.GetType() == typeof(string))
            {

                Contract itemSelected = null;
                var c = GetCollection(context);
                foreach (Contract Item in c)
                {
                    string ItemName = Item.ToString();

                    if (ItemName.Equals((string)value))
                    {
                        itemSelected = Item;
                    }
                }
                return itemSelected;
            }
            else
                return base.ConvertFrom(context, culture, value);
        }

 
    }
}



