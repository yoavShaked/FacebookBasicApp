using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace FacebookBasicApplication
{
    public class DataGridViewInitializerCheckin : DataGridViewInitializer
    {
        public DataGridViewInitializerCheckin(DataGridView i_DataGridView) : base(i_DataGridView)
        {
				}

        public override void InitInfoToDataGrid(User i_LoginUser)
        {
            foreach(Checkin checkin in i_LoginUser.Checkins)
            {
                FbDataGridView.Invoke(new Action(() => UserInfoAdapters.Add(new CheckinAdapter(checkin))));
            }
        }
    }
}
