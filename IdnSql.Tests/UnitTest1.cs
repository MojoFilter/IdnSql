using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdnSql.Tests
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        ///   <see cref="https://sqlkata.com/docs#compile-only-example" />
        /// </summary>
        [TestMethod]
        public void CompileOnlyExample()
        {
            var expectedQuery = @"SELECT * FROM [Users] WHERE [Id] = @p0 AND [Status] = @p1";
            
            var query = new Query();
            var compiledQuery = query
                .From("Users")
                .Where("Id", 1)
                .Where("Status", "Active")
                .Compile();

            Assert.AreEqual(expectedQuery, compiledQuery);
        }
    }
}
