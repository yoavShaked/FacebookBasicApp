using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace FacebookBasicApplication
{
    public class ImagesMenagerAlbums : ImagesMenager
    {
        public Button ButtonNextPhoto { get; set; }

        public Button ButtonPrevPhoto { get; set; }

        private List<Photo> PhotosCollection { get; set; }

        private static int m_PhotoIndex = 0;

        public ImagesMenagerAlbums(Control i_DispalyPanel, User i_LoginUser, Control i_Projector) : base(i_DispalyPanel, i_LoginUser, i_Projector)
        {
        }

        public ImagesMenagerAlbums()
        {
        }

        public ImagesMenagerAlbums(User i_LoginUser) : base(i_LoginUser)
        {
        }

        protected override void pictureBoxIcon_Click(object sender, EventArgs e)
        {
            PictureBox albumIcon = sender as PictureBox;
            m_PhotoIndex = 0;
            Projector.Invoke(new Action(() => Projector.Visible = true));
            
            foreach (Album fbAlbum in MyUser.Albums)
            {
                if(albumIcon.Name == fbAlbum.Name)
                {
                    PhotosCollection = fbAlbum.Photos.ToList();
                    putPictureInProjector();
                    ButtonNextPhoto.Click += ButtonNextPhoto_Click;
                    ButtonPrevPhoto.Click += ButtonPrevPhoto_Click;
                }
            }
        }

        private void putPictureInProjector()
        {
            PictureBox picture = SetPictureBox(new PhotoAdapter(PhotosCollection[m_PhotoIndex]));
            Projector.Invoke(new Action(() => Projector.Controls.Clear()));
            Projector.Invoke(new Action(() => Projector.Controls.Add(picture)));
        }

        private void ButtonPrevPhoto_Click(object sender, EventArgs e)
        {
            if(m_PhotoIndex - 1 >= 0)
            {
                m_PhotoIndex--;
                putPictureInProjector();
            }
        }

        private void ButtonNextPhoto_Click(object sender, EventArgs e)
        {
            if(m_PhotoIndex + 1 < PhotosCollection.Count)
            {
                m_PhotoIndex++;
                putPictureInProjector();
            }
        }

        protected override string InfoName 
				{
					get
					{ 
						return "album";
					}
				}

        protected override bool TryLoadingPagesToPanel()
        {
            bool userGotPages = false;
            SetCoordinatesForPanel();

            foreach (Album album in MyUser.Albums)
            {
                userGotPages = true;
                LoadPanel(new AlbumAdapter(album));
            }

            return userGotPages;
        }
    }
}
