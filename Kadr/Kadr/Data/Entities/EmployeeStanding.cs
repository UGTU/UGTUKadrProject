

namespace Kadr.Data
{
    public partial class EmployeeStanding : UIX.Views.IDecorable
    {
        public override string ToString()
        {
            return "Запись трудовой книжки сотрудника " +Employee.EmployeeSmallName;
        }

        #region IDecorable Members

        public object GetDecorator()
        {
            return new EmployeeStandingDecorator(this);
        }


        #endregion
    }
}
