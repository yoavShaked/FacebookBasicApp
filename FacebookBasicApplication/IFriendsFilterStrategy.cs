using FacebookWrapper.ObjectModel;

namespace FacebookBasicApplication
{
    public interface IFriendsFilterStrategy
    {
        bool FilterBy(User i_FbFriend1, User i_FbFriend2);
    }
}
