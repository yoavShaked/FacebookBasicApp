using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace FacebookBasicApplication
{
    public class DataGridViewInitializerFriend : DataGridViewInitializer
    {
        public DataGridViewInitializerFriend(DataGridView i_DataGridView) : base(i_DataGridView)
        {
        }

        public override void InitInfoToDataGrid(User i_LoginUser)
        {
            foreach(User friend in i_LoginUser.Friends)
            {
                FbDataGridView.Invoke(new Action(() => UserInfoAdapters.Add(new FriendAdapter(friend))));
            }
        }
    }
}
