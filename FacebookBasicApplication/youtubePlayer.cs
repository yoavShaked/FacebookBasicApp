using FacebookWrapper.ObjectModel;

namespace FacebookBasicApplication
{
    public class YoutubePlayer : Player
    {
        public YoutubePlayer(Link i_Link) : base(i_Link)
        {
        }

        protected override string ConvertToEmbedURL(string i_URL)
        {
            return @"https://www.youtube.com/embed/" + i_URL.Substring(i_URL.IndexOf("v=") + "v=".Length, 11) + "?version=2&autohide=2";
        }
    }
}
