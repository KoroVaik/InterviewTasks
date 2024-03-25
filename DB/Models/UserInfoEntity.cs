namespace DB.Models
{
    public class UserInfoEntity
    {
        public string UserName { get; set; }

        public int FailedLogins { get; set; }
    }
}
