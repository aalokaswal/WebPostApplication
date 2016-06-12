using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WebPosts.Base;
using WebPosts.BusinnesLogic;
using WebPosts.Model;

namespace WebPosts.ViewModel
{
    public class DisplayWebpostsVM : ViewModelBase
    {
        WebPostBL webPostBlObj;
        public DisplayWebpostsVM()
        {
            webPostBlObj = new WebPostBL();
            LoadWebPosts();
            SelectedPostCommand = new RelayCommand<object>(DisPlayWebPostContent);
            SaveContent = new RelayCommand<Object>(SaveWebPostContent);
        }

        public ICommand SaveContent { get; private set; }
        public ICommand SelectedPostCommand { get; private set; }

        private List<WebPost> webPostList;
        public List<WebPost> WebPostList 
        {
            get { return webPostList; }
            set { webPostList = value; }
        }

        private WebPost selectedWebPost;
        public WebPost SelectedWebPost
        {
            get {
                return selectedWebPost;
            }
            set 
            {
                selectedWebPost = value;
                OnPropertyChanged("SelectedWebPost");
            }
        }

        private string webPostTitle;
        public string WebPostTitle
        {
            get 
            { 
                return webPostTitle;
            }
            set
            {
                webPostTitle = value;
            }
        }

        private string webPostContent;
        public string WebPostContent
        {
            get
            {
                return webPostContent;
            }
            set
            {
                webPostContent = value;
            }
        }

        private string userId;
        public string UserId
        {
            get
            {
                return userId;
            }
            set
            {
                userId = value;
            }
        }

        private string webUser;
        public string WebUser
        {
            get
            {
                return webUser;
            }
            set
            {
                webUser = value;
            }
        }


        private string userName;
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }

        private string userEmail;
        public string UserEmail
        {
            get
            {
                return userEmail;
            }
            set
            {
                userEmail = value;
            }
        }

        private async void  LoadWebPosts()
        {
            webPostList = await webPostBlObj.GetAllWebPost();
        }

        public async void DisPlayWebPostContent(object value)
        {
            try 
            {
                var webPost = (WebPost)value;
                if (webPost != null)
                {
                    webPostTitle = webPost.title;
                    OnPropertyChanged("WebPostTitle");
                    var content = await webPostBlObj.GetWebPostContent(webPost.id.ToString());
                    webPostContent = content;
                    OnPropertyChanged("WebPostContent");

                    SetUserInfo(webPost.userId.ToString());
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }

        private async void SetUserInfo(string userID) 
        {
            var user = await webPostBlObj.GetUserById(userID); 

            if(user != null)
            {
                userId = userID; 
                OnPropertyChanged("UserId");
                webUser = user.username;
                OnPropertyChanged("WebUser");
                userName = user.name;
                OnPropertyChanged("UserName");
                userEmail = user.email;
                OnPropertyChanged("UserEmail");
            }

        }

        private void SaveWebPostContent(object value)
        {
            if (WebPostContent == null || WebPostContent == string.Empty)
                return;
            var selectedItem = (ComboBoxItem)value;
            string fileExtension= "txt";
            if(selectedItem!= null )
            {
                fileExtension = (string)selectedItem.Content;
            }

            UnicodeEncoding uniEncoding = new UnicodeEncoding();
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "(." +fileExtension  + ")|*." + fileExtension  + '"';
            saveFileDialog1.FileName  = "*";
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.DefaultExt = fileExtension;
            
            if (saveFileDialog1.ShowDialog() == true)
            {  
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    var sw = new StreamWriter(myStream, uniEncoding);
                    sw.Write(WebPostContent);
                    sw.Flush();
                    myStream.Seek(0, SeekOrigin.Begin);
                    myStream.Close();
                }
            }
        }
    }
}
