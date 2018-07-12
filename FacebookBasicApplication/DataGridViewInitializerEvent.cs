using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace FacebookBasicApplication
{
    public class DataGridViewInitializerEvent : DataGridViewInitializer
    {
        public DataGridViewInitializerEvent(DataGridView i_DataGridView) : base(i_DataGridView)
        {
		}

        public override void InitInfoToDataGrid(User i_LoginUser)
        {
            foreach (Event fbEvent in i_LoginUser.Events)
            {
                FbDataGridView.Invoke(new Action(() => UserInfoAdapters.Add(new EventAdapter(fbEvent))));
            }
        }
    }
}