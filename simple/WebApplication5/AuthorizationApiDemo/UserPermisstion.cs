namespace AuthorizationApiDemo
{
    public static class UserPermisstion
    {
        public static Dictionary<string, List<string>> Users = new Dictionary<string, List<string>>();
        static UserPermisstion()
        {
            Users.Add("456@qq.com", new List<string>() {
            "Get1","Get2","Get6","Set7"});
        }

    }
}
