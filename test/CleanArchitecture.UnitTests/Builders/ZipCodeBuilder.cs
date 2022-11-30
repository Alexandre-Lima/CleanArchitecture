using CleanArchitecture.UnitTests.Utils;

namespace CleanArchitecture.UnitTests.Builders
{
    public class ZipCodeBuilder
    {
        private readonly string _instance;

        public ZipCodeBuilder()
        {
            var faker = FakerPtBr.CreateFaker();

            _instance = faker.Address.ZipCode("########");
        }

        public string Build()
        {
            return _instance;
        }
    }
}
