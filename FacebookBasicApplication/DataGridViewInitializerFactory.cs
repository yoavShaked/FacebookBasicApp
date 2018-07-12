using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace FacebookBasicApplication
{
    public static class DataGridViewInitializerFactory
    {
        public static DataGridViewInitializer CreateDataGridViewInitializer(DataGridView i_DataGridView, eTabPageType i_TabPageType)
        {
            DataGridViewInitializer dataGridViewInitializer = null;

            switch (i_TabPageType)
            {
                case eTabPageType.Checkins:
                    {
                        dataGridViewInitializer = new DataGridViewInitializerCheckin(i_DataGridView);
                        break;
                    }

                case eTabPageType.Events:
                    {
                        dataGridViewInitializer = new DataGridViewInitializerEvent(i_DataGridView);
                        break;
                    }

                case eTabPageType.Friends:
                    {
                        dataGridViewInitializer = new DataGridViewInitializerFriend(i_DataGridView);
                        break;
                    }

                case eTabPageType.LikesPages:
                    {
                        dataGridViewInitializer = new DataGridViewInitializerLikedPage(i_DataGridView);
                        break;
                    }
            }

            return dataGridViewInitializer;
        }
    }
}
