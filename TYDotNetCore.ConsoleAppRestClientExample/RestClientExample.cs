using Newtonsoft.Json;
using RestSharp;

namespace TYDotNetCore.ConsoleAppRestClientExample
{
    internal class RestClientExample
    {
        private readonly RestClient _client = new RestClient(new Uri("https://localhost:7261"));
        private readonly string _blogEndpoint = "api/blog";

        public async Task AsyncRun()
        {
            //await AsyncRead();
            //await AsyncEdit(3012);
            //await AsyncCreate("test 2", "test 2", "test 2");
            //await AsyncUpdate(4011, "Crazy Rich Asian", "Kevin Kwan", "Rich Asians");
            await AsyncDelete(4011);
        }

        private async Task AsyncRead()
        {
            //RestRequest request = new RestRequest(_blogEndpoint);
            //var response = await _client.GetAsync(request);

            RestRequest request = new RestRequest(_blogEndpoint, Method.Get);
            var response = await _client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;
                List<BlogDto> lst = JsonConvert.DeserializeObject<List<BlogDto>>(jsonStr)!;
                foreach (var blog in lst)
                {
                    Console.WriteLine(blog.BlogTitle);
                    Console.WriteLine(blog.BlogAuthor);
                    Console.WriteLine(blog.BlogContent);
                }
            }
        }

        private async Task AsyncEdit(int id)
        {
            RestRequest request = new RestRequest($"{_blogEndpoint}/{id}", Method.Get);
            var response = await _client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;
                var item = JsonConvert.DeserializeObject<BlogDto>(jsonStr)!;

                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
            else
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }
        }

        private async Task AsyncCreate(string title, string author, string content)
        {
            BlogDto blog = new BlogDto()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            var restRequest = new RestRequest(_blogEndpoint, Method.Post);
            restRequest.AddJsonBody(blog);
            var response = await _client.ExecuteAsync(restRequest);
            if (response.IsSuccessStatusCode)
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }
        }

        private async Task AsyncUpdate(int id, string title, string author, string content)
        {
            BlogDto blog = new BlogDto()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            var restRequest = new RestRequest($"{_blogEndpoint}/{id}", Method.Put);
            restRequest.AddJsonBody(blog);
            var response = await _client.ExecuteAsync(restRequest)!;
            if (response.IsSuccessStatusCode)
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }
        }

        private async Task AsyncDelete(int id)
        {
            RestRequest request = new RestRequest($"{_blogEndpoint}/{id}", Method.Delete);
            var response = await _client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string message =  response.Content!;
                Console.WriteLine(message);
            }
            else
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }
        }
    }
}
