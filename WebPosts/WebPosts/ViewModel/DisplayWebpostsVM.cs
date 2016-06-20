using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WebPosts.WebAccess;
using WebPosts.BusinnesLogic;
using WebPosts.Helper;
using WebPosts.Model;

namespace WebPosts.ViewModel
{
    public class WebpostsViewModel : ViewModelBase
    {
        IWebPostBL objWebPostBl;
        public WebpostsViewModel()
        {
            objWebPostBl =  new WebPostBL();
            IntializeVariables();
        }

        public WebpostsViewModel(IWebPostBL objectWebPstBl)
        {
            objWebPostBl = objectWebPstBl;
            IntializeVariables();
        }

        private void IntializeVariables()
        {
            LoadWebPosts();
            SelectedPostCommand = new RelayCommand<object>(DisPlayWebPostContent);
            SaveContent = new RelayCommand<Object>(SaveWebPostContent);
            CopyContent = new RelayCommand<object>(CopyWebPostContent);
        }

        public ICommand SaveContent { get; private set; }
        public ICommand SelectedPostCommand { get; private set; }
        public ICommand CopyContent { get; private set; }

        private List<WebPost> webPostList;
        public List<WebPost> WebPostList 
        {
            get { return webPostList; }
            set { webPostList = value; }
        }

        private WebPost selectedWebPost;
        public WebPost SelectedWebPost
        {
            get {return selectedWebPost;}
            set 
            {
                selectedWebPost = value;
                OnPropertyChanged("SelectedWebPost");
            }
        }

        private string webPostTitle;
        public string WebPostTitle
        {
            get { return webPostTitle;}
            set { webPostTitle = value;}
        }

        private string webContent;
        public string WebContent
        {
            get { return webContent;}
            set {webContent = value;}
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

        private string webPostComment;
        public string WebPostComment
        {
            get
            {
                return webPostComment;
            }
            set
            {
                webPostComment = value;
            }
        }

        public async void  LoadWebPosts()
        {
            webPostList = await objWebPostBl.GetAllWebPost();
        }

        public async void DisPlayWebPostContent(object value)
        {
            try 
            {
                var webPost = (WebPost)value;
                if (webPost != null)
                {
                    selectedWebPost = webPost;
                    OnPropertyChanged("SelectedWebPost");
                    webPostTitle = webPost.title;
                    OnPropertyChanged("WebPostTitle");

                    webPostContent = await objWebPostBl.GetWebPostContentById(webPost.id.ToString());
                    webPostComment = await objWebPostBl.GetWebPostCommentContent(webPost.id.ToString());

                    WebContent = WebPostContent + webPostComment;
                    OnPropertyChanged("WebContent");
                }

                var user = await objWebPostBl.GetUserById(webPost.userId.ToString());
                if (user != null)
                {
                    userId = user.id.ToString();
                    OnPropertyChanged("UserId");
                    webUser = user.username;
                    OnPropertyChanged("WebUser");
                    userName = user.name;
                    OnPropertyChanged("UserName");
                    userEmail = user.email;
                    OnPropertyChanged("UserEmail");
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }

        private void CopyWebPostContent(object value)
        {
            Clipboard.SetText((string)value); 
        }

        private async void SaveWebPostContent(object value)
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
                    if(fileExtension == "html")
                    {
                        var webPost = await objWebPostBl.GetWebPost(SelectedWebPost.id.ToString());
                        var webPostComments = await objWebPostBl.GetWebPostComments(SelectedWebPost.id.ToString());
                        var webPostList = new List<WebPost>();
                        webPostList.Add(webPost);
                        var webPostHtml = Conversion.GetHtml((IEnumerable<WebPost>)webPostList,"WebPost", x => x.id, x => x.title, x => x.body);
                        var webPostCommentsHtml = Conversion.GetHtml((IEnumerable<WebPostComment>)webPostComments,"WebPostContent", x => x.postId, x => x.id, x => x.name, x => x.email, x => x.body);

                        var htmlStrbuilder = new StringBuilder();
                        htmlStrbuilder.Append(webPostHtml);
                        htmlStrbuilder.Append("  ").Append(webPostCommentsHtml);

                        sw.Write(htmlStrbuilder.ToString());
                    }
                    else
                    {
                        sw.Write(WebContent);
                    }
                    sw.Flush();
                    myStream.Seek(0, SeekOrigin.Begin);
                    myStream.Close();
                }
            }
        }
    }
}
