using Common.Models;

namespace Common
{
    public class UserDataProvider
    {
        //Users data could be taken from a Vault or an other secure location
        public UserCredentials GetUserCredentials(string userAlias) => new UserCredentials();
    }
}
