using Core;
using DB;
using NUnit.Framework;

namespace APITests.Tests
{
    [TestFixture]
    public class BaseApiTests
    {
        protected APIConfigurations _configurations { get => GetAPIConfigurations(); }

        protected DbContext _dbContext { get; private set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _dbContext = ConfigureDbContext();
        }

        private APIConfigurations GetAPIConfigurations()
        {
            return ConfigurationManager.Get<APIConfigurations>();
        }

        private DbContext ConfigureDbContext()
        {
            return new();
        }
    }
}
