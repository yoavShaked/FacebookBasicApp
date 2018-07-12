using System;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace FacebookBasicApplication
{
    internal class FriendAdapter : IImageAndTextAdapter
    {
        private User m_Friend;

        public FriendAdapter()
        {
        }

        public FriendAdapter(User i_Friend)
        {
            m_Friend = i_Friend;
        }

        public User GetFriend
        {
            get 
						{ 
							return m_Friend;
						}
        }

        public string GetName 
				{
					get
					{
						return m_Friend.FirstName + " " + m_Friend.LastName; 
					} 
				}

        public Image GetImage
        {
            get
            {
                return ServicePosts.PhotoHendler(m_Friend.ImageSmall);
            }
        }
    }
}
