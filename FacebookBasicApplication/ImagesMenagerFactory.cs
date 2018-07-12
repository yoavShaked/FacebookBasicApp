using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace FacebookBasicApplication
{
    public static class ImagesMenagerFactory
    {
        public static ImagesMenager CreateImagesManager(eTabPageType i_TabPageType, User i_LoginUser)
        {
            ImagesMenager imagesMenager = null;

            switch (i_TabPageType)
            {
                case eTabPageType.Albums:
                    {
                        imagesMenager = new ImagesMenagerAlbums(i_LoginUser);
                        break;
                    }

                case eTabPageType.TVShows:
                    {
                        imagesMenager = new ImagesMenagerTVShow(i_LoginUser);
                        break;
                    }
            }

            return imagesMenager;
        }
    }
}
