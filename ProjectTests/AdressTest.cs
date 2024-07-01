using Esports_Org_Manager.Entities;

namespace ProjectTests
{
    public class AdressTest
    {
        [Fact]
        public void TestAdressCreation()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new Adress(null,"wadaw",2);
                new Adress("awdaw", null, 2);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                new Adress("", "wadaw", 2);
                new Adress("awdaw", "", 2);
            });

        }
    }
}