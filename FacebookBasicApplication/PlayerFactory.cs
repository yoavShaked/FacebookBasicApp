using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace FacebookBasicApplication
{
    public static class PlayerFactory
    {
        public static Player CreatePlayer(Link i_Link)
        {
            Player player = null;

            if (i_Link != null && !string.IsNullOrEmpty(i_Link.URL))
            {
                if (i_Link.URL.Contains("youtube"))
                {
                    player = new YoutubePlayer(i_Link);
                }
                else if (i_Link.URL.Contains("vimeo"))
                {
                    player = new VimeoPlayer(i_Link);
                }
            }

            return player;
        }
    }
}
