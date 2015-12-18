using System;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Runtime.Serialization;
using Kadr.Helpers;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kadr.Tests
{
    [TestClass]
    public class SqlExceptionHelperFixture
    {
        [TestMethod]
        public void DuplicateKeySimple()
        {
            using (ShimsContext.Create())
            {
                var sqlException = new ShimSqlException()
                {
                    NumberGet = () => SqlExceptionHelper.DuplicateKeyNumber                    
                };                

                Assert.IsTrue(((SqlException)sqlException).IsDuplicateKey());

            }
        }
    }
}