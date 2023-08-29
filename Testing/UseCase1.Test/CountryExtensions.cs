using UseCase1.Extensions;
using UseCase1.Models;

namespace UseCase1.Test
{
    [TestClass]
    public class CountryExtensions
    {
        private static readonly List<Country> Countries = new()
        {
            new Country {
                Name = new Name { Common = "A Country" },
                Population = 1000000
            },
            new Country {
                Name = new Name { Common = "B Country" },
                Population = 1000001
            },
            new Country {
                Name = new Name { Common = "C" },
                Population = 999999
            },
            new Country {
                Name = new Name { Common = "D" },
                Population = 1000000000
            },
            new Country {
                Name = new Name { Common = "Z Country" },
                Population = 10
            },
            new Country {
                Name = new Name { Common = "AB Country" },
                Population = 10
            },
        };

        [DataTestMethod]
        [DataRow(1, 3)]
        [DataRow(10, 5)]
        [DataRow(9999, 6)]
        public void PopulationFilter(int maxPopulationInMilions, int correctCount)
        {
            var result = Countries.FilterByPopulation(maxPopulationInMilions);

            Assert.AreEqual(correctCount, result.Count);
        }

        [DataTestMethod]
        [DataRow("country", 4)]
        [DataRow("A", 2)]
        [DataRow("a", 2)]
        public void NameFilter(string name, int correctCount)
        {
            var result = Countries.FilterByCommonName(name);

            Assert.AreEqual(correctCount, result.Count);
        }

        [TestMethod]
        public void SortAscend()
        {
            var result = Countries.SortByCommonName("ascend");

            Assert.AreEqual(result[0]?.Name?.Common, Countries[0]?.Name?.Common);
            Assert.AreEqual(result[1]?.Name?.Common, Countries[5]?.Name?.Common);
            Assert.AreEqual(result[2]?.Name?.Common, Countries[1]?.Name?.Common);
        }

        [TestMethod]
        public void SortDescend()
        {
            var result = Countries.SortByCommonName("descend");

            Assert.AreEqual(result[5]?.Name?.Common, Countries[0]?.Name?.Common);
            Assert.AreEqual(result[4]?.Name?.Common, Countries[5]?.Name?.Common);
            Assert.AreEqual(result[3]?.Name?.Common, Countries[1]?.Name?.Common);
        }

        [TestMethod]
        public void Sort_UnknowndOrder()
        {
            try
            {
                var result = Countries.SortByCommonName("");
                Assert.Fail();
            }
            catch (InvalidOperationException e)
            {
                Assert.AreEqual(e.Message, "Invalid order");
            }
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(3, 3)]
        [DataRow(9999, 6)]
        public void Pagination(int number, int correctCount)
        {
            var result = Countries.Paginate(number);

            Assert.AreEqual(correctCount, result.Count);
        }
    }
}