using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;
using System.ComponentModel;

namespace FacebookBasicApplication
{
    public class FriendsSorter
    {
        private BindingList<IImageAndTextAdapter> m_FacebookCollection = null;
        private IFriendsFilterStrategy m_FriendsFilterStrategy;

        public FriendsSorter()
        {
        }

        public BindingList<IImageAndTextAdapter> FacebookCollection
        {
            get
            {
                return m_FacebookCollection;
            }
            set
            {
                if(m_FacebookCollection == null)
                {
                    m_FacebookCollection = value;
                }
            }
        }

        public IFriendsFilterStrategy FriendsFilterStrategy
        {
            get
            {
                return m_FriendsFilterStrategy;
            }
            set
            {
                m_FriendsFilterStrategy = value;
            }
        }

        public void SortFacebookCollectionByFilter()
        {
            bubbleSort();
        }

        private void bubbleSort()
        {
            for(int i = 0; i < m_FacebookCollection.Count - 1; i++)
            {
                for(int j = 0; j < m_FacebookCollection.Count - i - 1; j++)
                {
                    FriendAdapter fa1 = m_FacebookCollection[j] as FriendAdapter;
                    FriendAdapter fa2 = m_FacebookCollection[j+1] as FriendAdapter;

                    if (m_FriendsFilterStrategy.FilterBy(fa1.GetFriend, fa2.GetFriend))
                    {
                        IImageAndTextAdapter temp =  m_FacebookCollection[j];
                        m_FacebookCollection[j] = m_FacebookCollection[j+1];
                        m_FacebookCollection[j + 1] = temp;
                    }
                }
            }
        }
    }
}
