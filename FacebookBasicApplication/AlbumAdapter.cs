using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace FacebookBasicApplication
{
    public class AlbumAdapter : IImageAndTextAdapter
    {
        private Album m_UserAlbum;

        public AlbumAdapter(Album i_UserAlbum)
        {
            m_UserAlbum = i_UserAlbum;
        }

        public AlbumAdapter()
        {
        }

        public string GetName	
				{ 
					get 
					{ 
						return m_UserAlbum.Name; 
					} 
				}

        public Image GetImage
        {
            get
            {
                return ServicePosts.PhotoHendler(m_UserAlbum.ImageSmall);
            }
        }

        public IEnumerable<Photo> Photos
        {
            get
            {
                return m_UserAlbum.Photos;
            }
        }
    }
}
