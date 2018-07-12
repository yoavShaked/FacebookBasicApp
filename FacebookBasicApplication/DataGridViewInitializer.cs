using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace FacebookBasicApplication
{
    public abstract class DataGridViewInitializer
    {
        private readonly DataGridView r_DataGridView;
        private readonly BindingList<IImageAndTextAdapter> r_UserInfoAdapters = new BindingList<IImageAndTextAdapter>();

        public DataGridViewInitializer(DataGridView i_DataGridView)
        {
            r_DataGridView = i_DataGridView;
            r_DataGridView.DataSource = r_UserInfoAdapters;
        }

        public DataGridViewInitializer()
        {
        }

        public DataGridView FbDataGridView
        {
            get
            {
                return r_DataGridView;
            }
        }

        public BindingList<IImageAndTextAdapter> UserInfoAdapters
        {
            get
            {
                return r_UserInfoAdapters;
            }
        }

        public abstract void InitInfoToDataGrid(User i_LoginUser);
    }
}
