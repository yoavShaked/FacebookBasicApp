using FacebookWrapper.ObjectModel;

namespace FacebookBasicApplication
{
    public abstract class Player
    {
        private string m_URL;

        private string m_Name;

        public Player(Link i_PostedLink)
        {
            m_URL = ConvertToEmbedURL(i_PostedLink.URL);
            m_Name = i_PostedLink.Name;
        }

        protected abstract string ConvertToEmbedURL(string i_URL);

        public string URL
        {
            get { return m_URL; }
        }

        public string Name
        {
            get { return m_Name; }
        }
    }
}
