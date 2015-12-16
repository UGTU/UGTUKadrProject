using System;
using System.Linq;
using Kadr.Data;
using Kadr.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kadr.Tests
{
    [TestClass]
    public class KadrExperienceDbTestFixture
    {
        [TestMethod]
        public void DbEmployeeExperienceTest()
        {
            using (var ctx = new Kadr.Data.dckadrDataContext())
            {
                var fs = ctx.FactStaffs.Where(x => x.idEmployee == 1);
            }
        }
    }
}
