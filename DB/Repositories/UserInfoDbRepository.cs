using DB.Models;

namespace DB.Repositories
{
    public class UserInfoDbRepository : DbRepository<UserInfoEntity>
    {
        public UserInfoDbRepository(DbContext context) : base(context)
        {
        }

        public UserInfoEntity GetUserInfo(string userName) 
        {
            return SearchByExpression(x => x.UserName == userName).Single();
        }

        public List<UserInfoEntity> GetAllUserInfos()
        {
            return GetAllEntites().ToList();
        }
    }
}
