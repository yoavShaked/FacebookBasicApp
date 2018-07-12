using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace FacebookBasicApplication
{
    public abstract class ImagesMenager
    {
        public Panel DispalyImagesPanel { get; set; }

        public Label TitleLabel { get; set; }

        public User MyUser { get; set; }

        public Control Projector { get; set; }

        private int X { get; set; }

        private int Y { get; set; }

        public ImagesMenager(Control i_DispalyPanel, User i_LoginUser, Control i_Projector)
        {
            DispalyImagesPanel.Invoke(new Action(() => DispalyImagesPanel = i_DispalyPanel as Panel));
            Projector.Invoke(new Action(() => Projector = i_Projector));
            MyUser = i_LoginUser;
        }

        public ImagesMenager(User i_LoginUser)
        {
            MyUser = i_LoginUser;
        }

        public ImagesMenager()
        {
        }

        protected PictureBox SetPictureBox(IImageAndTextAdapter i_wrapper)
        {
            PictureBox iconPage = new PictureBox();
            iconPage.Size = new Size(100, 100);
            iconPage.Image = i_wrapper.GetImage;
            iconPage.Name = i_wrapper.GetName;
            iconPage.SizeMode = PictureBoxSizeMode.StretchImage;

            return iconPage;
        }

        protected PictureBox InitIcon(IImageAndTextAdapter i_wrapper)
        {
            PictureBox iconPage = SetPictureBox(i_wrapper);
            iconPage.Location = new Point(X, Y);

            return iconPage;
        }

        private void loadLabelPanel()
        {
            foreach (PictureBox mypicture in DispalyImagesPanel.Controls)
            {
                Label name = new Label();
                settingForPictureBox(mypicture, name);
                DispalyImagesPanel.Invoke(new Action(() => DispalyImagesPanel.Controls.Add(name)));
            }
        }

        private void settingForPictureBox(PictureBox i_MyPictureBox, Label i_MyLabel)
        {
            i_MyLabel.Invoke(new Action(() => i_MyLabel.TextAlign = ContentAlignment.BottomCenter));
            i_MyLabel.Invoke(new Action(() => i_MyLabel.Size = new Size(86, 13)));
            int x = i_MyPictureBox.Location.X;
            int y = i_MyPictureBox.Location.Y + i_MyPictureBox.Height;
            i_MyLabel.Invoke(new Action(() => i_MyLabel.Text = i_MyPictureBox.Name));
            i_MyLabel.Invoke(new Action(() => i_MyLabel.Location = new Point(x, y)));
        }

        protected void SetCoordinatesForPanel()
        {
            DispalyImagesPanel.Invoke(new Action(() => X = DispalyImagesPanel.Location.X - 10));
            DispalyImagesPanel.Invoke(new Action(() => Y = DispalyImagesPanel.Location.Y + 5));
        }

        protected void LoadPanel(IImageAndTextAdapter i_Page)
        {
            PictureBox iconPage = InitIcon(i_Page);

            iconPage.Click += new EventHandler(pictureBoxIcon_Click);

            int amountOfControls = 0;

            DispalyImagesPanel.Invoke(new Action(() => amountOfControls = DispalyImagesPanel.Controls.Count));

            if (amountOfControls % 2 == 0)
            {
                DispalyImagesPanel.Invoke(new Action(() => DispalyImagesPanel.Controls.Add(iconPage)));
                X += iconPage.Width + 10;
            }
            else
            {
                DispalyImagesPanel.Invoke(new Action(() => DispalyImagesPanel.Controls.Add(iconPage)));
                Y += iconPage.Height + 20;
                DispalyImagesPanel.Invoke(new Action(() => X = DispalyImagesPanel.Location.X - 10));
            }
        }

        public void DisplayPanel()
        {
            if (TryLoadingPagesToPanel())
            {
                TitleLabel.Invoke(new Action(() => TitleLabel.Text = "choose the " + InfoName + " you want to watch"));
            }
            else
            {
                TitleLabel.Invoke(new Action(() => TitleLabel.Text = "looks like you didn't like any" + InfoName));
            }
        }

        protected abstract void pictureBoxIcon_Click(object sender, EventArgs e);

        protected abstract bool TryLoadingPagesToPanel();

        protected abstract string InfoName { get; }
    }
}
