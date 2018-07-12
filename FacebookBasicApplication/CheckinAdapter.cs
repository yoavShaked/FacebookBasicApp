using System.Drawing;
using FacebookWrapper.ObjectModel;

namespace FacebookBasicApplication
{
    internal class CheckinAdapter : IImageAndTextAdapter
    {
        private Checkin m_UserCheckin;

        public CheckinAdapter()
        {
        }

        public CheckinAdapter(Checkin i_UserCheckin)
        {
            m_UserCheckin = i_UserCheckin;
        }

        public string GetName 
				{ 
					get
					{ 
						return m_UserCheckin.Place.Name;
					}
				}

        public Image GetImage
        {
            get
            {
                return ServicePosts.PhotoHendlerByPlace(m_UserCheckin.Place);
            }
        }
    }
}
