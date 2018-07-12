using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace FacebookBasicApplication
{
    internal class LikedPageAdapter : IImageAndTextAdapter
    {
        private Page m_LikedPage;

        public LikedPageAdapter()
        {       
        }

        public LikedPageAdapter(Page i_Page)
        {
            m_LikedPage = i_Page;
        }

        public string GetName
				{
					get
					{ 
						return m_LikedPage.Name; 
					}
				}

        public Image GetImage
        {
            get
            {
                try
                {
                    return m_LikedPage.ImageSmall;
                }
                catch
                {
                    return Properties.Resources.Not_available;
                }
            }
        }

        public Page GetLikePage
        {
            get { return m_LikedPage; }
        }
    }
}
