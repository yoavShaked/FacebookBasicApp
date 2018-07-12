using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace FacebookBasicApplication
{
    public class PhotoAdapter : IImageAndTextAdapter
    {
        private Photo m_Photo;

        public PhotoAdapter(Photo i_Photo)
        {
            m_Photo = i_Photo;
        }

        public Image GetImage 
				{
					get
					{ 
						return ServicePosts.PhotoHendler(m_Photo.ImageNormal); 
					} 
				}

        public string GetName
				{
					get
					{ 
						return m_Photo.Name; 
					}
				}
    }
}
