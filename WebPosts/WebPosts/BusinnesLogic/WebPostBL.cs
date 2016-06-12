using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebPosts.Model;

namespace WebPosts.BusinnesLogic
{
    public class WebPostBL
    {
        string webUrl = string.Empty; 

        public WebPostBL()
        {
            webUrl= "http://jsonplaceholder.typicode.com/";
        }

        public async Task<List<WebPost>> GetAllWebPost()
        {
            var url = webUrl + "posts";
            List<WebPost> webPostList = null;
            var client = new HttpClient();
            var task = client.GetAsync(url)
              .ContinueWith((taskwithresponse) =>
              {
                  var response = taskwithresponse.Result;
                  var jsonString = response.Content.ReadAsStringAsync();
                  jsonString.Wait();
                  webPostList = JsonConvert.DeserializeObject<List<WebPost>>(jsonString.Result);

              });
            task.Wait();

            return webPostList;
        }

        public WebPost GetWebPostById(string id)
        {
            var url = webUrl + "posts/" + id;
            WebPost webPost = null;
            var client = new HttpClient();
            var task = client.GetAsync(url)
              .ContinueWith((taskwithresponse) =>
              {
                  var response = taskwithresponse.Result;
                  var jsonString = response.Content.ReadAsStringAsync();
                  jsonString.Wait();
                  webPost = JsonConvert.DeserializeObject<WebPost>(jsonString.Result);

              });
            task.Wait();

            return webPost;
        }

        public async Task<String> GetWebPostContent(string id)
        {
            var webPostContent = string.Empty;
            var postUrl = webUrl + "posts/" + id ;
            var client1 = new HttpClient();
            webPostContent = await client1.GetStringAsync(postUrl);

            var postCommentUrl = webUrl + "posts/" + id + "/comments";
            var client = new HttpClient();
            webPostContent += await client.GetStringAsync(postCommentUrl);
           
            return webPostContent;
        }

        public async Task<User> GetUserById(string userId)
        {
            var url = webUrl + "users/" + userId;
            User webPost = null;
            var client = new HttpClient();
            var task = client.GetAsync(url)
              .ContinueWith((taskwithresponse) =>
              {
                  var response = taskwithresponse.Result;
                  var jsonString = response.Content.ReadAsStringAsync();
                  jsonString.Wait();
                  webPost = JsonConvert.DeserializeObject<User>(jsonString.Result);

              });
            task.Wait();

            return webPost;
        }

    }
}
