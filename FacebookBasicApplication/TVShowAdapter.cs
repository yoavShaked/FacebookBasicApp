using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace FacebookBasicApplication
{
    public class TVShowAdapter : IImageAndTextAdapter
    {
        private Page m_TVShowPage;

        public TVShowAdapter()
        {
        }

        public TVShowAdapter(Page i_TVShow)
        {
            m_TVShowPage = i_TVShow;
        }

        public Page TVShowPage
        {
            get { return m_TVShowPage; }
        }

        public string GetName
				{
					get
					{ 
						return m_TVShowPage.Name; 
					}
				}

        public Image GetImage
        {
            get
            {
                return ServicePosts.PhotoHendler(m_TVShowPage.ImageSmall);
            }
        }
    }
}
