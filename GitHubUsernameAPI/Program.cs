using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestEase;

namespace GitHubAPI
{
    public class User
    {
        public string Name { get; set; }
        public string Blog { get; set; }
        [JsonProperty("created_at")] public DateTime CreatedAt { get; set; }
    }

    [Header("User-Agent", "RestEase")]
    public interface IGitHubApi
    {
        [Get("users/{userId}")]
        Task<User> GetUserAsync([Path] string userId);
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            IGitHubApi api = RestClient.For<IGitHubApi>("https://api.github.com");

            Console.WriteLine("Type your GitHub username: ");
            string userName = Console.ReadLine();

            User user = api.GetUserAsync(userName).Result;
            Console.WriteLine($"Name: {user.Name}. Blog: {user.Blog}. CreatedAt: {user.CreatedAt}");
            Console.ReadLine();
        }
    }
}