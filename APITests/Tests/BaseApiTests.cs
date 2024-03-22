using Core;
using NUnit.Framework;

namespace APITests.Tests
{
    [TestFixture]
    public class BaseApiTests
    {
        protected APIConfigurations _configurations { get => GetAPIConfigurations(); }

        private APIConfigurations GetAPIConfigurations()
        {
            return ConfigurationManager.Get<APIConfigurations>();
        }
    }
}
