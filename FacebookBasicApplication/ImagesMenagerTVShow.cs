using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace FacebookBasicApplication
{
    public class ImagesMenagerTVShow : ImagesMenager
    {
        public ImagesMenagerTVShow(Control i_DispalyPanel, User i_LoginUser, Control i_Projector) : base(i_DispalyPanel, i_LoginUser, i_Projector)
        {
        }

        public ImagesMenagerTVShow()
        {
        }

        public ImagesMenagerTVShow(User i_LoginUser) : base(i_LoginUser)
        {
        }

        protected override void pictureBoxIcon_Click(object sender, EventArgs e)
        {
            PictureBox icon = sender as PictureBox;

            Projector.Invoke(new Action(() => Projector.Visible = true));
            Projector.Invoke(new Action(() => (Projector as WebBrowser).Navigate("https://www.google.com/search?q=" + icon.Name + " watch online")));
        }

        protected override bool TryLoadingPagesToPanel()
        {
            bool userGotPages = false;
            SetCoordinatesForPanel();

            foreach (Page page in MyUser.LikedPages)
            {
                if (page.Category == "TV Show")
                {
                    userGotPages = true;
                    LoadPanel(new TVShowAdapter(page));
                }
            }

            return userGotPages;
        }

        protected override string InfoName 
				{
					get
					{ 
						return "tv show"; 
					} 
				}
    }
}
