using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;
using Kadr.Controllers;
using System.Data.Linq;

namespace Kadr.Data
{
    public partial class Department 
    {
        private Dep dep;
        public Dep Dep
        {
            get
            {
                if (dep == null)
                    dep = Kadr.Controllers.KadrController.Instance.Model.Deps.Where(dp => dp.id == id).FirstOrDefault();

                return dep;
            }
        }


        public override string ToString()
        {

            
            if (Dep != null)
            {
                return Dep.ToString();
             
            }
            else return null;
        }

    }

}

