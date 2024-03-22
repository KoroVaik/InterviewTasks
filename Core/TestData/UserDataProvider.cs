using UITests.TestData.Models;

namespace UITests.TestData
{
    public class UserDataProvider
    {
        //Users data could be taken from a Vault or an other secure location
        public UserData GetUserData(string userAlias) => new UserData();
    }
}
