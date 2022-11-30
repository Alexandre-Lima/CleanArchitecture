using Bogus;

namespace CleanArchitecture.UnitTests.Utils
{
    internal class FakerPtBr
    {
        public static Faker CreateFaker()
        {
            return new Faker("pt_BR");
        }
    }
}
