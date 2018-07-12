using FacebookWrapper.ObjectModel;

namespace FacebookBasicApplication
{
    public sealed class FriendsHometownStrategy : IFriendsFilterStrategy
    {
        private static FriendsHometownStrategy s_FriendsHometownStrategy = null;

        private FriendsHometownStrategy()
        {
        }

        public bool FilterBy(User i_FbFriend1, User i_FbFriend2)
        {
            bool answer = false;

            if (i_FbFriend1.Hometown != null && i_FbFriend2.Hometown != null)
            {
                if (string.IsNullOrEmpty(i_FbFriend1.Hometown.Name) && string.IsNullOrEmpty(i_FbFriend1.Hometown.Name))
                {
                    if (string.Compare(i_FbFriend1.Hometown.Name, i_FbFriend2.Hometown.Name) == 1)
                    {
                        answer = true;
                    }
                }
            }

            return answer;
        }

        public static FriendsHometownStrategy GetInstance
        {
            get
            {
                if (s_FriendsHometownStrategy == null)
                {
                    s_FriendsHometownStrategy = new FriendsHometownStrategy();
                }

                return s_FriendsHometownStrategy;
            }
        }
    }
}
