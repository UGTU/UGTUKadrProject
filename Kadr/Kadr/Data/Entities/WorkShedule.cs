using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;
using Kadr.Controllers;

namespace Kadr.Data
{
    public partial class WorkShedule: INull
    {
        public override string ToString()
        {
            return NameShedule;
        }

        public int? ToIntSign
        {
            get
            {
                if (id == 1)
                    return 5;
                if (id == 2)
                    return 6;
                return null;
            }
        }

        public static WorkShedule IntSignToShedule(int? intSing)
        {
            if (intSing == 5)
                return KadrController.Instance.Model.WorkShedules.Where(wSh => wSh.id == 1).SingleOrDefault();
            if (intSing == 6)
                return KadrController.Instance.Model.WorkShedules.Where(wSh => wSh.id == 2).SingleOrDefault();
            throw new ArgumentOutOfRangeException("Название должности");
        }

        #region INull Members

        bool INull.IsNull()
        {
            return false;
        }

        #endregion
    }

    public class NullWorkShedule : WorkShedule, INull
    {

        private NullWorkShedule()
        {
            this.id = 0;
        }

        public static readonly NullWorkShedule Instance = new NullWorkShedule();

        #region INull Members

        bool INull.IsNull()
        {
            return true;
        }
        public override string ToString()
        {
            return "(Не задан)";
        }

        #endregion
    }

}
