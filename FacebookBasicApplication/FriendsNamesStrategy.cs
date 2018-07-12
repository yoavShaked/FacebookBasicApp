using FacebookWrapper.ObjectModel;

namespace FacebookBasicApplication
{
    public class FriendsNamesStrategy : IFriendsFilterStrategy
    {
        private static FriendsNamesStrategy s_FriendsNamesStrategy = null;

        public bool FilterBy(User i_FbFriend1, User i_FbFriend2)
        {
            return string.Compare(i_FbFriend1.Name, i_FbFriend2.Name) == 1 ? true : false;
        }

        public static FriendsNamesStrategy GetInstance
        {
            get
            {
                if (s_FriendsNamesStrategy == null)
                {
                    s_FriendsNamesStrategy = new FriendsNamesStrategy();
                }

                return s_FriendsNamesStrategy;
            }
        }
    }
}
