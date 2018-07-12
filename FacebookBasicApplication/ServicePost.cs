using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace FacebookBasicApplication
{
    public static class ServicePosts
    {
        public static Image PhotoHendler(Image i_Photo)
        {
            try
            {
                return i_Photo;
            }
            catch
            {
                return Properties.Resources.Not_available;
            }
        }

        public static Image PhotoHendlerByPlace(Page i_Place)
        {
            try
            {
                return i_Place.ImageSmall;
            }
            catch
            {
                return Properties.Resources.Not_available;
            }
        }
    }
}
