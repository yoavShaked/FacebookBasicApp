using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace FacebookBasicApplication
{
    public class DataGridViewInitializerLikedPage : DataGridViewInitializer
    {
        public DataGridViewInitializerLikedPage(DataGridView i_DataGridView) : base(i_DataGridView)
        {
        }

        public override void InitInfoToDataGrid(User i_LoginUser)
        {
            foreach(Page page in i_LoginUser.LikedPages)
            {
                FbDataGridView.Invoke(new Action(() => UserInfoAdapters.Add(new LikedPageAdapter(page))));
            }
        }
    }
}
