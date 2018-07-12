using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace FacebookBasicApplication
{
    internal class EventAdapter : IImageAndTextAdapter
    {
        private Event m_UserEvent;

        public EventAdapter()
        {
        }

        public EventAdapter(Event i_UserEvent)
        {
            m_UserEvent = i_UserEvent;
        }

        public Event GetUserEvent
        {
           get { return m_UserEvent; }
        }

        public string GetName
				{
					get 
					{
						return m_UserEvent.Name; 
					} 
				}

        public Image GetImage
        {
            get
            {
                return ServicePosts.PhotoHendlerByPlace(m_UserEvent.Place);
            }
        }
    }
}
