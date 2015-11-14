using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kadr.Data;
using System.Linq;
using Kadr.Controllers;
using UIX.Views;

namespace Kadr.Tests
{
    [TestClass]
    public class AwardTest
    {
        [TestMethod]
        public void MakeAwardWithNullType()
        {
            Award a = new Award();
            a.Employee = KadrController.Instance.Model.Employees.FirstOrDefault();
            a.EducDocument = new EducDocument();
            a.AwardLevel = NullAwardLevel.Instance;
            a.AwardType = NullAwardType.Instance;
            
            KadrController.Instance.Model.Awards.InsertOnSubmit(a);
            (a as IValidatable).Validate();
            KadrController.Instance.Model.SubmitChanges();

        }
    }
}
