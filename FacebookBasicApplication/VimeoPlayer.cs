using FacebookWrapper.ObjectModel;

namespace FacebookBasicApplication
{
    public class VimeoPlayer : Player
    {
        public VimeoPlayer(Link i_Link) : base(i_Link)
        {
        }

        protected override string ConvertToEmbedURL(string i_URL)
        {
            string videoID = i_URL.Substring(i_URL.IndexOf(".com/") + ".com/".Length, i_URL.Length - (i_URL.IndexOf(".com/") + ".com/".Length));

            return @"https://player.vimeo.com/video/" + videoID + @"?autoplay=1&title=0&byline=0";
        }
    }
}
