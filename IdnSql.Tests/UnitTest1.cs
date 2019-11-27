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

        /// <summary>
        ///   <see cref="https://sqlkata.com/docs#introduction"/>
        /// </summary>
        [TestMethod]
        public void IntroductionExample()
        {
            var expectedQuery = @"SELECT [Id], [Title] FROM [Posts] WHERE [Likes] > @p0 AND [Lang] IN (@p1, @p2) AND [AuthorId] IS NOT NULL ORDER BY [Date] DESC";
            var query = new Query();
            var sql = query
                .From("Posts")
                .Where("Likes", ">", 10)
                .WhereIn("Lang", "en", "fr")
                .WhereNotNull("AuthorId")
                .OrderByDesc("Date")
                .Select("Id", "Title")
                .Compile();
            Assert.AreEqual(expectedQuery, sql);
        }
    }
}
