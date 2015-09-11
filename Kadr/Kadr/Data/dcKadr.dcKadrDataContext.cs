using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.ComponentModel;
using System.Web.UI.WebControls;

namespace Kadr.Data
{    

    public partial class dckadrDataContext  
    {

        /// <summary>
        /// Добавление нового отдела
        /// </summary>
        /// <param name="managerDepartment">Руководящий отдел</param>
        /// <param name="departmentType">Тип отдела</param>
        /// <returns></returns>
        public Dep CreateNewDepartment(Dep managerDepartment, DepartmentType departmentType)
        {
            Dep result = new Dep();
            result.ManagerDepartment = managerDepartment;
            result.DepartmentType = departmentType;
            result.DepartmentName = "Не указано";
            result.DepartmentSmallName = "Не указано";
            Deps.InsertOnSubmit(result);
            return result;
        }

        public dckadrDataContext() :
        base(global::Kadr.Properties.Settings.Default.KadrConnectionString1, mappingSource)
        {
            OnCreated();
        }

        /*public PlanStaff CreateNewPlanStaff(Department department)
        {
            PlanStaff result = new PlanStaff();
            result.Department = department;
            result.Category = NullCategory.Instance;
            result.Post = NullPost.Instance;
            result.Prikaz = NullPrikaz.Instance;
            PlanStaff.InsertOnSubmit(result);
            return result;
        }*/


    }
}

