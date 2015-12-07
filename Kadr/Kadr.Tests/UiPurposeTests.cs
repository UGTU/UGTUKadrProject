using System.Linq.Expressions;
using Kadr.UI.Common;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kadr.Tests
{
    [TestClass]
    public class UiPurposeTests
    {
        static void CheckPurposeTest(string connString, DbConnectionPurpose expected)
        {
            var conn = new System.Data.Fakes.StubIDbConnection()
            {
                ConnectionStringGet = () =>connString
            };
            var actual = conn.GetDbPurpose();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetDbPurposeTest()
        {

            CheckPurposeTest("Data Source=ugtudb.ugtu.net;Initial Catalog=KadrRealTest;Integrated Security=True", DbConnectionPurpose.PublicTest);
            CheckPurposeTest("Data Source=ugtudb.ugtu.net;Initial Catalog=KadrDebug;Integrated Security=True", DbConnectionPurpose.LocalDebug);
            CheckPurposeTest("Data Source=ugtudb.ugtu.net;Integrated Security=True", DbConnectionPurpose.Unknown);
            CheckPurposeTest("Data Source=ugtudb.ugtu.net;Initial Catalog=Kadr;Integrated Security=True", DbConnectionPurpose.Release);


        }
    }
}
