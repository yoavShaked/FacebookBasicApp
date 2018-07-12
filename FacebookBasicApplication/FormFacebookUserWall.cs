using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using System.Windows.Forms;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace FacebookBasicApplication
{
    internal partial class FormWall : Form
    {
        private static bool s_IsUserLogin;
        private readonly List<Player> r_ShardeVideos = new List<Player>();
        private readonly List<DataGridViewInitializer> r_DGVInitializers = new List<DataGridViewInitializer>();
        private readonly List<ImagesMenager> r_ImagesMenagers = new List<ImagesMenager>();
        private User m_LoginUser = new User();
        private LoginResult m_LoginResult;
        private AppSettings m_AppSettings;
        private string m_AppId = "1690592877650606";
        private static readonly string[] sr_Permissions =
            {
    "public_profile",
    "user_actions.music",
    "user_friends",
    "user_events",
    "user_likes",
    "user_location",
    "user_photos",
    "user_posts",
    "user_videos",
    "read_custom_friendlists",
    "manage_pages",
    "publish_pages",
    "publish_actions"
        };

        public FormWall()
        {
            InitializeComponent();

            m_AppSettings = AppSettings.LoadFromFile();
            checkBoxRememberLastUser.Checked = m_AppSettings.RemamberUser;
            listBoxSongPlayer.DisplayMember = "Name";

            if (m_AppSettings.RemamberUser && !string.IsNullOrEmpty(m_AppSettings.LastAccessToken))
            {
                m_LoginResult = FacebookService.Connect(m_AppSettings.LastAccessToken);
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (m_AppSettings.RemamberUser)
            {
                uploadDataToUIFromFacebook();
            }
            else
            {
                hideComponentsBeforeUserLogin();
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            m_AppSettings.RemamberUser = checkBoxRememberLastUser.Checked;

            if (!checkBoxRememberLastUser.Checked)
            {
                m_AppSettings.LastAccessToken = null;
                FacebookService.Logout(doLogOut);
            }
            else
            {
                m_AppSettings.LastAccessToken = m_LoginResult.AccessToken;
            }

            m_AppSettings.SaveToFile();
        }

        private void loginOrLogout()
        {
            if (!s_IsUserLogin)
            {
                doLogIn();
            }
            else
            {
                FacebookService.Logout(doLogOut);
            }
        }

        private void doLogIn()
        {
            if (checkBoxGuyAppID.Checked)
            {
                m_AppId = "1450160541956417";
            }

            m_LoginResult = FacebookService.Login(m_AppId, sr_Permissions);

            uploadDataToUIFromFacebook();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            loginOrLogout();
        }

        private void uploadDataToUIFromFacebook()
        {
            m_LoginUser = m_LoginResult.LoggedInUser;
            pictureBoxUserProfilePicture.Image = m_LoginUser.ImageNormal;
            labelUserLoggedIn.Invoke(new Action(() => labelUserLoggedIn.Text = "Hello, " + m_LoginUser.FirstName));
            initilaizeImagesManagers();
            new Thread(showComponentsAfterUserLogin).Start();
            fillImagesPanels();
            feelDataGrids();
            new Thread(uplaodLinksToSongPlayer).Start();
            buttonLogin.Invoke(new Action(() => buttonLogin.Text = "Logout"));
            s_IsUserLogin = true;
        }

        private void doLogOut()
        {
            buttonLogin.Invoke(new Action(() => buttonLogin.Text = "Login"));
            new Thread(hideComponentsBeforeUserLogin).Start();
            s_IsUserLogin = false;
        }

        private void showComponentsAfterUserLogin()
        {
            string checkBoxName = string.Empty;
            checkBoxGuyAppID.Invoke(new Action(() => checkBoxName = checkBoxGuyAppID.Name));

            foreach (Control formControl in this.Controls)
            {
                string formControlName = string.Empty;
                formControl.Invoke(new Action(() => formControlName = formControl.Name));
                if (formControlName != checkBoxName)
                {
                    formControl.Invoke(new Action(() => formControl.Show()));
                }
            }

            checkBoxGuyAppID.Invoke(new Action(() => checkBoxGuyAppID.Visible = false));
            checkBoxGuyAppID.Invoke(new Action(() => checkBoxGuyAppID.Enabled = false));
        }

        private void hideComponentsBeforeUserLogin()
        {
            string buttonLoginName = string.Empty;
            string checkBoxName = string.Empty;
            buttonLogin.Invoke(new Action(() => buttonLoginName = buttonLogin.Name));
            checkBoxGuyAppID.Invoke(new Action(() => checkBoxName = checkBoxGuyAppID.Name));

            foreach (Control formControl in this.Controls)
            {
                string formControlName = string.Empty;
                formControl.Invoke(new Action(() => formControlName = formControl.Name));

                if (formControlName != buttonLoginName && formControlName != checkBoxName)
                {
                    formControl.Invoke(new Action(() => formControl.Hide()));
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            initilaizeDataGridsDataSurce();
        }

        private eTabPageType wichTabPage(string i_TabPageName)
        {
            eTabPageType tabPageType = eTabPageType.None;

            if (i_TabPageName.Contains("Albums"))
            {
                tabPageType = eTabPageType.Albums;
            }
            else if (i_TabPageName.Contains("TVShows"))
            {
                tabPageType = eTabPageType.TVShows;
            }
            else if (i_TabPageName.Contains("SongPlayer"))
            {
                tabPageType = eTabPageType.SongPlayer;
            }
            else if (i_TabPageName.Contains("Friends"))
            {
                tabPageType = eTabPageType.Friends;
            }
            else if (i_TabPageName.Contains("LikesPages"))
            {
                tabPageType = eTabPageType.LikesPages;
            }
            else if (i_TabPageName.Contains("Events"))
            {
                tabPageType = eTabPageType.Events;
            }
            else if (i_TabPageName.Contains("Checkins"))
            {
                tabPageType = eTabPageType.Checkins;
            }
            else if (i_TabPageName.Contains("Checkins"))
            {
                tabPageType = eTabPageType.Checkins;
            }

            return tabPageType;
        }

        private void initilaizeImagesManagers()
        {
            foreach (TabPage tabPage in FeaturesTabs.Controls)
            {
                eTabPageType tabPageType = wichTabPage(tabPage.Name);
                ImagesMenager imagesMenager = ImagesMenagerFactory.CreateImagesManager(tabPageType, m_LoginUser);

                if (imagesMenager != null)
                {
                    r_ImagesMenagers.Add(imagesMenager);
                }
            }

            initilaizeImagesManager();
        }

        private void initilaizeImagesManager()
        {
            foreach (ImagesMenager imagesMenager in r_ImagesMenagers)
            {
                if (imagesMenager is ImagesMenagerTVShow)
                {
                    imagesMenager.DispalyImagesPanel = panelTVShowsPages;
                    imagesMenager.Projector = webBrowserGoogleSearch;
                    imagesMenager.TitleLabel = labelSubtitleTVShow;
                }
                else if (imagesMenager is ImagesMenagerAlbums)
                {
                    imagesMenager.DispalyImagesPanel = panelAlbums;
                    imagesMenager.Projector = panelAlbumPhotos;
                    imagesMenager.TitleLabel = labelTitleAlbums;
                    (imagesMenager as ImagesMenagerAlbums).ButtonNextPhoto = buttonNextPhoto;
                    (imagesMenager as ImagesMenagerAlbums).ButtonPrevPhoto = buttonPrevPhoto;
                }
            }
        }

        private void fillImagesPanels()
        {
            foreach (ImagesMenager imagesMenager in r_ImagesMenagers)
            {
                new Thread(imagesMenager.DisplayPanel).Start();
            }
        }

        private void initilaizeDataGridsDataSurce()
        {
            foreach (TabPage tabPage in FeaturesTabs.Controls)
            {
                foreach (Control dg in tabPage.Controls)
                {
                    if (dg is DataGridView)
                    {
                        eTabPageType tabPageType = wichTabPage(tabPage.Name);
                        DataGridViewInitializer dataGridViewInitializer = DataGridViewInitializerFactory.CreateDataGridViewInitializer(dg as DataGridView, tabPageType);

                        if (dataGridViewInitializer != null)
                        {
                            r_DGVInitializers.Add(dataGridViewInitializer);
                        }
                    }
                }
            }
        }

        private void feelDataGrids()
        {
            foreach (DataGridViewInitializer dgvi in r_DGVInitializers)
            {
                new Thread(() => dgvi.InitInfoToDataGrid(m_LoginUser)).Start();
            }
        }

        private void buttonPost_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxPost.Text))
            {
                MessageBox.Show("There is nothing to post");
            }
            else
            {
                m_LoginUser.PostStatus(textBoxPost.Text);
                textBoxPost.Invoke(new Action(() => textBoxPost.Text = string.Empty));
            }
        }

        private void uplaodLinksToSongPlayer()
        {
            foreach (Link link in m_LoginUser.PostedLinks)
            {
                Player linkItem = PlayerFactory.CreatePlayer(link);

                if (linkItem != null)
                {
                    listBoxSongPlayer.Invoke(new Action(() => listBoxSongPlayer.Items.Add(link)));
                    r_ShardeVideos.Add(linkItem);
                }
            }
        }

        private void listBoxSongPlayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Player shardeVideo in r_ShardeVideos)
            {
                if (shardeVideo.Name == (sender as ListBox).Text)
                {
                    webBrowserSongsPlayer.Invoke(new Action(() => webBrowserSongsPlayer.Visible = true));
                    webBrowserSongsPlayer.Invoke(new Action(() => webBrowserSongsPlayer.Navigate(shardeVideo.URL)));
                    break;
                }
            }
        }

        private void checkBoxRememberLastUser_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRememberLastUser.Checked)
            {
                buttonLogin.Invoke(new Action(() => buttonLogin.Enabled = false));
            }
            else
            {
                buttonLogin.Invoke(new Action(() => buttonLogin.Enabled = true));
            }
        }

        private void dataGridViewEvents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string eventName = dataGridViewEvents.CurrentRow.Cells[1].Value as string;

            foreach (DataGridViewInitializer dgvi in r_DGVInitializers)
            {
                if (dgvi is DataGridViewInitializerEvent)
                {
                    foreach (EventAdapter eventAdapter in dgvi.UserInfoAdapters)
                    {
                        if (eventAdapter.GetName == eventName)
                        {
                            textBoxDescription.Text = eventAdapter.GetUserEvent.Description;
                            pictureBoxEvent.Load(eventAdapter.GetUserEvent.PictureNormalURL);
                            break;
                        }
                    }
                }
            }
        }

        private void dataGridViewFriends_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string friendName = dataGridViewFriends.CurrentRow.Cells[1].Value as string;

            foreach (DataGridViewInitializer dgvi in r_DGVInitializers)
            {
                if (dgvi is DataGridViewInitializerFriend)
                {
                    foreach (FriendAdapter friendAdapter in dgvi.UserInfoAdapters)
                    {
                        if (friendAdapter.GetName == friendName)
                        {
                            textBoxFriendName.Invoke(new Action(() => textBoxFriendName.Text = friendAdapter.GetFriend.Name));
                            textBoxFriendGender.Invoke(new Action(() => textBoxFriendGender.Text = friendAdapter.GetFriend.Gender.Value.ToString()));
                            textBoxFriendBio.Invoke(new Action(() => textBoxFriendBio.Text = friendAdapter.GetFriend.Bio));
                            break;
                        }
                    }
                }
            }
        }

        private void dataGridViewCheckins_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string checkinName = dataGridViewCheckins.CurrentRow.Cells[1].Value as string;

            foreach (DataGridViewInitializer dgvi in r_DGVInitializers)
            {
                if (dgvi is DataGridViewInitializerCheckin)
                {
                    foreach (CheckinAdapter checkinAdapter in dgvi.UserInfoAdapters)
                    {
                        if (checkinAdapter.GetName == checkinName)
                        {
                            textBoxDescription.Invoke(new Action(() => textBoxDescription.Text = checkinAdapter.ToString()));
                            break;
                        }
                    }
                }
            }
        }

        private void dataGridViewLikedPages_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string likePageName = dataGridViewLikedPages.CurrentRow.Cells[1].Value as string;

            foreach (DataGridViewInitializer dgvi in r_DGVInitializers)
            {
                if (dgvi is DataGridViewInitializerLikedPage)
                {
                    foreach (LikedPageAdapter likePageAdapter in dgvi.UserInfoAdapters)
                    {
                        if (likePageAdapter.GetName == likePageName)
                        {
                            textBoxLikePageDescription.Invoke(new Action(() => textBoxLikePageDescription.Text = likePageAdapter.GetLikePage.Description));
                            pictureBoxLikePage.Load(likePageAdapter.GetLikePage.PictureNormalURL);
                            break;
                        }
                    }
                }
            }
        }
    }
}
