using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text.Json;


namespace _26_5
{

    public class DevNews
    {
        Tools tools = new Tools();

        static HttpClient client = new HttpClient();
    
        static string baseAddress = "https://jsonplaceholder.typicode.com/posts";

        static int newIdNum = 100;


        public static async Task<List<Post>> GetPosts()
        {
            var respons = await client.GetAsync(baseAddress);
            respons.EnsureSuccessStatusCode();
            string text = await respons.Content.ReadAsStringAsync();
            List<Post> posts = JsonConvert.DeserializeObject<List<Post>>(text);
            return posts;
        }

        public static void GetFirstPost(List<Post> posts) 
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(posts[i].Title);
            }
        }

        

        public static void GetPostByID(List<Post> posts)
        {
            int id = Tools.GetIdNum();
            string result = "";
            foreach(var post in posts)
            {
                if (post.ID == id)
                {
                    result = $"post id: {post.ID}\n" +
                        $"post tilte: {post.Title}\n" +
                        $"post body: {post.Body}";
                    break;
                }
            }
            Console.WriteLine((result != "" ? result : "this post not exists, try agin later: "));
        }

        

        public static Post BuildNewPost()
        {
            Post newPost = new Post();

            Console.WriteLine("Enter the post title:");
            string title = Tools.GetString();
            Console.WriteLine("Enter the post body:");
            string body = Tools.GetString();
            
            newPost.Title = title;
            newPost.Body = body;
            newPost.userID = Tools.GetUserId();

            return newPost;
        }

        public static async Task AddNewPost(Post newPost)
        {
            var obj = new
            {
                userId = newPost.userID,
                id = ++newIdNum,
                title = newPost.Title,
                body = newPost.Body
            };
            var json = JsonConvert.SerializeObject(obj);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var postResponse = await client.PostAsync(baseAddress + "/echo" , data);
            Console.WriteLine(newIdNum);
        }

        public static async Task Main()
        {
            var posts = await GetPosts();
            GetPostByID(posts);

        }
    }
}
